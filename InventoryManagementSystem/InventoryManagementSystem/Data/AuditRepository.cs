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
    public class AuditRepository
    {
        // بتتنادى من جوه ProductRepository بنفس الـ Connection والـ Transaction
        public static void Write(SqlConnection con, SqlTransaction tx, string actionType,
                                 int? productId, string productName, string oldValues, string newValues)
        {
            const string sql = @"
INSERT INTO AuditLogs (ActionType, ProductId, ProductName, UserId, Username, OldValues, NewValues)
VALUES (@a, @pid, @pn, @uid, @un, @old, @new)";

            using (var cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.Add("@a", SqlDbType.NVarChar, 10).Value = actionType;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = Db.ToDb(productId);
                cmd.Parameters.Add("@pn", SqlDbType.NVarChar, 100).Value = Db.ToDb(productName);
                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Session.CurrentUser.UserId;
                cmd.Parameters.Add("@un", SqlDbType.NVarChar, 50).Value = Session.CurrentUser.Username;
                cmd.Parameters.Add("@old", SqlDbType.NVarChar, -1).Value = Db.ToDb(oldValues);
                cmd.Parameters.Add("@new", SqlDbType.NVarChar, -1).Value = Db.ToDb(newValues);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            var dt = new DataTable("AuditLogs");
            const string sql = @"
SELECT TOP 500 AuditId, ChangedAt, ActionType, ProductId, ProductName, Username, OldValues, NewValues
FROM AuditLogs
ORDER BY ChangedAt DESC, AuditId DESC";

            using (var con = Db.GetConnection())
            using (var da = new SqlDataAdapter(sql, con))
            {
                da.Fill(dt);
            }
            return dt;
        }
    }
}
