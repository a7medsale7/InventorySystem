namespace InventoryManagementSystem.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.topPanel       = new System.Windows.Forms.Panel();
            this.lblSearch      = new System.Windows.Forms.Label();
            this.txtSearch      = new System.Windows.Forms.TextBox();
            this.lblCategory    = new System.Windows.Forms.Label();
            this.cboCategory    = new System.Windows.Forms.ComboBox();
            this.lblStatus      = new System.Windows.Forms.Label();
            this.cboStatus      = new System.Windows.Forms.ComboBox();
            this.btnSearch      = new System.Windows.Forms.Button();
            this.btnClear       = new System.Windows.Forms.Button();

            this.bottomPanel    = new System.Windows.Forms.Panel();
            this.btnAdd         = new System.Windows.Forms.Button();
            this.btnEdit        = new System.Windows.Forms.Button();
            this.btnDelete      = new System.Windows.Forms.Button();
            this.btnReport      = new System.Windows.Forms.Button();
            this.btnAudit       = new System.Windows.Forms.Button();
            this.btnLogout      = new System.Windows.Forms.Button();
            this.lblUserInfo    = new System.Windows.Forms.Label();

            this.dgvProducts    = new System.Windows.Forms.DataGridView();

            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // ─── topPanel ────────────────────────────────────────────
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 70;
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSearch, this.txtSearch,
                this.lblCategory, this.cboCategory,
                this.lblStatus, this.cboStatus,
                this.btnSearch, this.btnClear
            });

            int top = 22;

            this.lblSearch.Text     = "Search (name / supplier)";
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, top + 3);

            this.txtSearch.Width    = 220;
            this.txtSearch.Location = new System.Drawing.Point(175, top);

            this.lblCategory.Text     = "Category";
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(410, top + 3);

            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Width  = 160;
            this.cboCategory.Location = new System.Drawing.Point(468, top);

            this.lblStatus.Text     = "Stock status";
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(640, top + 3);

            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Width    = 140;
            this.cboStatus.Location = new System.Drawing.Point(715, top);

            this.btnSearch.Text     = "Search";
            this.btnSearch.Size     = new System.Drawing.Size(75, 26);
            this.btnSearch.Location = new System.Drawing.Point(870, top - 1);

            this.btnClear.Text      = "Clear";
            this.btnClear.Size      = new System.Drawing.Size(65, 26);
            this.btnClear.Location  = new System.Drawing.Point(955, top - 1);

            // ─── bottomPanel ─────────────────────────────────────────
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Height = 55;
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.bottomPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnEdit, this.btnDelete,
                this.btnReport, this.btnAudit, this.btnLogout,
                this.lblUserInfo
            });

            int bTop = 13;
            int bx   = 10;

            this.btnAdd.Text     = "Add Product";
            this.btnAdd.Size     = new System.Drawing.Size(100, 30);
            this.btnAdd.Location = new System.Drawing.Point(bx, bTop); bx += 110;

            this.btnEdit.Text    = "Edit";
            this.btnEdit.Size    = new System.Drawing.Size(80, 30);
            this.btnEdit.Location = new System.Drawing.Point(bx, bTop); bx += 90;

            this.btnDelete.Text  = "Delete";
            this.btnDelete.Size  = new System.Drawing.Size(80, 30);
            this.btnDelete.Location = new System.Drawing.Point(bx, bTop); bx += 100;

            this.btnReport.Text  = "Reports";
            this.btnReport.Size  = new System.Drawing.Size(80, 30);
            this.btnReport.Location = new System.Drawing.Point(bx, bTop); bx += 90;

            this.btnAudit.Text   = "Audit Log";
            this.btnAudit.Size   = new System.Drawing.Size(90, 30);
            this.btnAudit.Location = new System.Drawing.Point(bx, bTop);

            this.btnLogout.Text  = "Logout";
            this.btnLogout.Size  = new System.Drawing.Size(80, 30);
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogout.Location = new System.Drawing.Point(900, bTop);

            this.lblUserInfo.Text     = "";
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Anchor   = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.lblUserInfo.Location = new System.Drawing.Point(650, bTop + 6);

            // ─── dgvProducts ─────────────────────────────────────────
            this.dgvProducts.Dock                   = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.ReadOnly               = true;
            this.dgvProducts.AllowUserToAddRows     = false;
            this.dgvProducts.AllowUserToDeleteRows  = false;
            this.dgvProducts.SelectionMode          = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect            = false;
            this.dgvProducts.AutoSizeColumnsMode    = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.RowHeadersVisible      = false;
            this.dgvProducts.BackgroundColor        = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle            = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.DefaultCellStyle.Font  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProducts.RowTemplate.Height     = 26;
            this.dgvProducts.GridColor              = System.Drawing.Color.LightGray;

            // ─── MainForm ─────────────────────────────────────────────
            this.Text          = "Inventory Management System";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState   = System.Windows.Forms.FormWindowState.Maximized;
            this.Size          = new System.Drawing.Size(1000, 600);
            this.Font          = new System.Drawing.Font("Segoe UI", 9F);

            this.Controls.Add(this.dgvProducts);   // Fill بيتأثر بالترتيب - dgv أول
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel       topPanel;
        private System.Windows.Forms.Label       lblSearch;
        private System.Windows.Forms.TextBox     txtSearch;
        private System.Windows.Forms.Label       lblCategory;
        private System.Windows.Forms.ComboBox    cboCategory;
        private System.Windows.Forms.Label       lblStatus;
        private System.Windows.Forms.ComboBox    cboStatus;
        private System.Windows.Forms.Button      btnSearch;
        private System.Windows.Forms.Button      btnClear;

        private System.Windows.Forms.Panel       bottomPanel;
        private System.Windows.Forms.Button      btnAdd;
        private System.Windows.Forms.Button      btnEdit;
        private System.Windows.Forms.Button      btnDelete;
        private System.Windows.Forms.Button      btnReport;
        private System.Windows.Forms.Button      btnAudit;
        private System.Windows.Forms.Button      btnLogout;
        private System.Windows.Forms.Label       lblUserInfo;

        private System.Windows.Forms.DataGridView dgvProducts;
    }
}
