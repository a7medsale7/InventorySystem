using InventoryManagementSystem.Models;
using InventoryManagementSystem.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class ProductRepository
    {
        // Query أساسي مشترك بين البحث والتقرير. الأعمدة هنا لازم تتطابق مع الـ XSD في الوحدة 12.
        private const string BaseSelect = @"
SELECT * FROM (
    SELECT  p.ProductId,
            p.Name,
            p.Description,
            p.Quantity,
            p.Price,
            p.SupplierName,
            p.CategoryId,
            ISNULL(c.Name, 'Uncategorized') AS CategoryName,
            CAST(p.Quantity * p.Price AS DECIMAL(18,2)) AS TotalValue,
            CASE WHEN p.Quantity = 0           THEN 'Out of Stock'
                 WHEN p.Quantity < @Threshold  THEN 'Low Stock'
                 ELSE 'In Stock' END AS StockStatus,
            CAST(CASE WHEN p.Quantity < @Threshold THEN 1 ELSE 0 END AS BIT) AS IsLowStock
    FROM Products p
    LEFT JOIN Categories c ON c.CategoryId = p.CategoryId
) AS X";

        // ---------- البحث والفلترة ----------
        public DataTable Search(string text, int? categoryId, string stockStatus, int threshold)
        {
            var sql = new StringBuilder(BaseSelect);
            sql.Append(" WHERE 1 = 1");

            bool hasText = !string.IsNullOrWhiteSpace(text);
            if (hasText)
                sql.Append(" AND (Name LIKE @text OR SupplierName LIKE @text OR Description LIKE @text)");
            if (categoryId.HasValue)
                sql.Append(" AND CategoryId = @cat");
            if (!string.IsNullOrEmpty(stockStatus))
                sql.Append(" AND StockStatus = @status");

            sql.Append(" ORDER BY Name");

            var dt = new DataTable("Products");
            using (var con = Db.GetConnection())
            using (var cmd = new SqlCommand(sql.ToString(), con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@Threshold", SqlDbType.Int).Value = threshold;
                if (hasText)
                    cmd.Parameters.Add("@text", SqlDbType.NVarChar, 200).Value = "%" + text.Trim() + "%";
                if (categoryId.HasValue)
                    cmd.Parameters.Add("@cat", SqlDbType.Int).Value = categoryId.Value;
                if (!string.IsNullOrEmpty(stockStatus))
                    cmd.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value = stockStatus;

                da.Fill(dt);   // Fill بيفتح ويقفل الـ Connection لوحده
            }
            return dt;
        }

        // ---------- داتا التقرير ----------
        public DataTable GetReportTable(int threshold, bool lowStockOnly)
        {
            string sql = BaseSelect
                + (lowStockOnly ? " WHERE IsLowStock = 1" : "")
                + " ORDER BY IsLowStock DESC, Name";

            var dt = new DataTable("Products");
            using (var con = Db.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@Threshold", SqlDbType.Int).Value = threshold;
                da.Fill(dt);
            }
            return dt;
        }

        // ---------- جلب منتج واحد ----------
        public Product GetById(int id)
        {
            using (var con = Db.GetConnection())
            {
                con.Open();
                return GetById(con, null, id);
            }
        }

        private static Product GetById(SqlConnection con, SqlTransaction tx, int id)
        {
            const string sql = @"SELECT ProductId, Name, Description, Quantity, Price, SupplierName, CategoryId
                                 FROM Products WHERE ProductId = @id";
            using (var cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    return new Product
                    {
                        ProductId = r.GetInt32(0),
                        Name = r.GetString(1),
                        Description = r.IsDBNull(2) ? null : r.GetString(2),
                        Quantity = r.GetInt32(3),
                        Price = r.GetDecimal(4),
                        SupplierName = r.GetString(5),
                        CategoryId = r.IsDBNull(6) ? (int?)null : r.GetInt32(6)
                    };
                }
            }
        }

        // ---------- إضافة ----------
        public int Add(Product p)
        {
            Session.RequireAdmin();

            using (var con = Db.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        const string sql = @"
INSERT INTO Products (Name, Description, Quantity, Price, SupplierName, CategoryId)
OUTPUT INSERTED.ProductId
VALUES (@name, @desc, @qty, @price, @supplier, @cat)";

                        int newId;
                        using (var cmd = new SqlCommand(sql, con, tx))
                        {
                            AddParams(cmd, p);
                            newId = (int)cmd.ExecuteScalar();
                        }

                        p.ProductId = newId;
                        AuditRepository.Write(con, tx, "INSERT", newId, p.Name, null, p.ToAuditString());

                        tx.Commit();
                        return newId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ---------- تعديل ----------
        public void Update(Product p)
        {
            Session.RequireAdmin();

            using (var con = Db.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        Product old = GetById(con, tx, p.ProductId);
                        if (old == null) throw new InvalidOperationException("Product no longer exists.");

                        const string sql = @"
UPDATE Products
SET Name = @name, Description = @desc, Quantity = @qty, Price = @price,
    SupplierName = @supplier, CategoryId = @cat
WHERE ProductId = @id";

                        using (var cmd = new SqlCommand(sql, con, tx))
                        {
                            AddParams(cmd, p);
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = p.ProductId;
                            cmd.ExecuteNonQuery();
                        }

                        AuditRepository.Write(con, tx, "UPDATE", p.ProductId, p.Name,
                                              old.ToAuditString(), p.ToAuditString());
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ---------- حذف ----------
        public void Delete(int id)
        {
            Session.RequireAdmin();

            using (var con = Db.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        Product old = GetById(con, tx, id);
                        if (old == null) throw new InvalidOperationException("Product no longer exists.");

                        using (var cmd = new SqlCommand("DELETE FROM Products WHERE ProductId = @id", con, tx))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            cmd.ExecuteNonQuery();
                        }

                        AuditRepository.Write(con, tx, "DELETE", id, old.Name, old.ToAuditString(), null);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        private static void AddParams(SqlCommand cmd, Product p)
        {
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = p.Name;
            cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 500).Value = Db.ToDb(p.Description);
            cmd.Parameters.Add("@qty", SqlDbType.Int).Value = p.Quantity;
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = p.Price;
            cmd.Parameters["@price"].Precision = 18;
            cmd.Parameters["@price"].Scale = 2;
            cmd.Parameters.Add("@supplier", SqlDbType.NVarChar, 100).Value = p.SupplierName;
            cmd.Parameters.Add("@cat", SqlDbType.Int).Value = Db.ToDb(p.CategoryId);
        }
    }
}
