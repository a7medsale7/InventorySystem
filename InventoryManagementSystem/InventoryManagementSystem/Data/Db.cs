using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public static class Db
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // يحوّل null لـ DBNull عشان SQL تفهمه
        public static object ToDb(object value)
        {
            return value ?? System.DBNull.Value;
        }
    }
}
