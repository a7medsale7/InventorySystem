using System;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Forms;

namespace InventoryManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // تأكد من وجود مستخدمين في قاعدة البيانات (admin / viewer)
            try
            {
                new UserRepository().SeedDefaultUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not connect to the database.\n\n" + ex.Message +
                    "\n\nPlease check App.config connection string.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // حلقة: بعد Logout تفتح شاشة Login تاني
            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        break; // المستخدم ضغط Cancel أو أغلق الشاشة
                }

                using (var main = new MainForm())
                {
                    Application.Run(main);

                    // لو مش Logout (يعني أغلق البرنامج عادي) اخرج من الحلقة
                    if (!main.LoggedOut)
                        break;
                }
            }
        }
    }
}
