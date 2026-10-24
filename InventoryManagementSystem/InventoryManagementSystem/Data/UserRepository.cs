using InventoryManagementSystem.Models;
using InventoryManagementSystem.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class UserRepository
    {
        // Hash وهمي: بنستخدمه لو اسم المستخدم مش موجود،
        // عشان وقت الرد يبقى نفس الوقت (بيصعّب تخمين أسماء المستخدمين)
        private static readonly string DummyHash = PasswordHasher.Hash("dummy-password");

        public User Authenticate(string username, string password)
        {
            User user = null;
            string storedHash = null;

            using (var con = Db.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT UserId, Username, PasswordHash, Role FROM Users WHERE Username = @u AND IsActive = 1", con))
            {
                cmd.Parameters.Add("@u", System.Data.SqlDbType.NVarChar, 50).Value = username;
                con.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        user = new User
                        {
                            UserId = r.GetInt32(0),
                            Username = r.GetString(1),
                            Role = (Role)Enum.Parse(typeof(Role), r.GetString(3))
                        };
                        storedHash = r.GetString(2);
                    }
                }
            }

            if (user == null)
            {
                PasswordHasher.Verify(password, DummyHash);
                return null;
            }

            return PasswordHasher.Verify(password, storedHash) ? user : null;
        }

        public void Create(string username, string password, Role role)
        {
            using (var con = Db.GetConnection())
            using (var cmd = new SqlCommand(
                "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@u, @h, @r)", con))
            {
                cmd.Parameters.Add("@u", System.Data.SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@h", System.Data.SqlDbType.NVarChar, 255).Value = PasswordHasher.Hash(password);
                cmd.Parameters.Add("@r", System.Data.SqlDbType.NVarChar, 20).Value = role.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // لو مفيش ولا مستخدم، بنعمل admin و viewer
        public void SeedDefaultUsers()
        {
            int count;
            using (var con = Db.GetConnection())
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Users", con))
            {
                con.Open();
                count = (int)cmd.ExecuteScalar();
            }

            if (count > 0) return;

            Create("admin", "Admin@123", Role.Admin);
            Create("viewer", "Viewer@123", Role.Viewer);
        }
    }
}
