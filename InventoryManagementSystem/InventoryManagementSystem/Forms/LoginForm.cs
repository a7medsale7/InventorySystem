using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Security;

namespace InventoryManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository _users = new UserRepository();
        private int _failedAttempts;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                lblError.Text = "Please enter username and password.";
                return;
            }

            try
            {
                var user = _users.Authenticate(username, password);

                if (user == null)
                {
                    _failedAttempts++;
                    lblError.Text = "Invalid username or password.";
                    txtPassword.Clear();
                    txtPassword.Focus();

                    if (_failedAttempts >= 5)
                    {
                        MessageBox.Show("Too many failed attempts. The application will close.",
                            "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.Cancel;
                    }
                    return;
                }

                Session.CurrentUser = user;
                DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
