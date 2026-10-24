using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            var list = new List<Category>();
            using (var con = Db.GetConnection())
            using (var cmd = new SqlCommand("SELECT CategoryId, Name FROM Categories ORDER BY Name", con))
            {
                con.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Category
                        {
                            CategoryId = r.GetInt32(0),
                            Name = r.GetString(1)
                        });
                    }
                }
            }
            return list;
        }
    }
}
