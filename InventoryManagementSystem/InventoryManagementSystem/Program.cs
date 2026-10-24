using System;
using System.Windows.Forms;
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
