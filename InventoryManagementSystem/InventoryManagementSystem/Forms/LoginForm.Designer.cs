namespace InventoryManagementSystem.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle     = new System.Windows.Forms.Label();
            this.lblUser      = new System.Windows.Forms.Label();
            this.txtUsername  = new System.Windows.Forms.TextBox();
            this.lblPass      = new System.Windows.Forms.Label();
            this.txtPassword  = new System.Windows.Forms.TextBox();
            this.btnLogin     = new System.Windows.Forms.Button();
            this.btnCancel    = new System.Windows.Forms.Button();
            this.lblError     = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ─── lblTitle ───────────────────────────────────────────────────
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location  = new System.Drawing.Point(90, 20);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "Inventory System";

            // ─── lblUser ────────────────────────────────────────────────────
            this.lblUser.AutoSize  = true;
            this.lblUser.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUser.Location  = new System.Drawing.Point(40, 80);
            this.lblUser.Name      = "lblUser";
            this.lblUser.TabIndex  = 1;
            this.lblUser.Text      = "Username";

            // ─── txtUsername ─────────────────────────────────────────────────
            this.txtUsername.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.Location  = new System.Drawing.Point(130, 77);
            this.txtUsername.Name      = "txtUsername";
            this.txtUsername.Size      = new System.Drawing.Size(220, 23);
            this.txtUsername.TabIndex  = 2;

            // ─── lblPass ─────────────────────────────────────────────────────
            this.lblPass.AutoSize  = true;
            this.lblPass.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPass.Location  = new System.Drawing.Point(40, 120);
            this.lblPass.Name      = "lblPass";
            this.lblPass.TabIndex  = 3;
            this.lblPass.Text      = "Password";

            // ─── txtPassword ─────────────────────────────────────────────────
            this.txtPassword.Font                 = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location             = new System.Drawing.Point(130, 117);
            this.txtPassword.Name                 = "txtPassword";
            this.txtPassword.Size                 = new System.Drawing.Size(220, 23);
            this.txtPassword.TabIndex             = 4;
            this.txtPassword.UseSystemPasswordChar = true;

            // ─── btnLogin ─────────────────────────────────────────────────────
            this.btnLogin.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogin.Location  = new System.Drawing.Point(130, 160);
            this.btnLogin.Name      = "btnLogin";
            this.btnLogin.Size      = new System.Drawing.Size(100, 30);
            this.btnLogin.TabIndex  = 5;
            this.btnLogin.Text      = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // ─── btnCancel ────────────────────────────────────────────────────
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font         = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location     = new System.Drawing.Point(250, 160);
            this.btnCancel.Name         = "btnCancel";
            this.btnCancel.Size         = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex     = 6;
            this.btnCancel.Text         = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click       += new System.EventHandler(this.btnCancel_Click);

            // ─── lblError ─────────────────────────────────────────────────────
            this.lblError.AutoSize  = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.Location  = new System.Drawing.Point(130, 200);
            this.lblError.Name      = "lblError";
            this.lblError.TabIndex  = 7;
            this.lblError.Text      = "";

            // ─── LoginForm ────────────────────────────────────────────────────
            this.AcceptButton      = this.btnLogin;
            this.CancelButton      = this.btnCancel;
            this.ClientSize        = new System.Drawing.Size(380, 240);
            this.FormBorderStyle   = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox       = false;
            this.MinimizeBox       = false;
            this.Name              = "LoginForm";
            this.StartPosition     = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text              = "Inventory System - Login";

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.lblUser,
                this.txtUsername,
                this.lblPass,
                this.txtPassword,
                this.btnLogin,
                this.btnCancel,
                this.lblError
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label   lblPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button  btnLogin;
        private System.Windows.Forms.Button  btnCancel;
        private System.Windows.Forms.Label   lblError;
    }
}
