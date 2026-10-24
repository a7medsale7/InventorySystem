using Telerik.WinControls.UI;

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
            this.radGridView1   = new Telerik.WinControls.UI.RadGridView();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSearch, this.txtSearch,
                this.lblCategory, this.cboCategory,
                this.lblStatus, this.cboStatus,
                this.btnSearch, this.btnClear
            });
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 70;
            this.topPanel.Name = "topPanel";
            this.topPanel.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(157, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search (name / supplier)";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(175, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(410, 25);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(468, 22);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(160, 23);
            this.cboCategory.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(640, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Stock status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(715, 22);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(140, 23);
            this.cboStatus.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(870, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(955, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 26);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.bottomPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnEdit, this.btnDelete,
                this.btnReport, this.btnAudit, this.btnLogout,
                this.lblUserInfo
            });
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Height = 55;
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Product";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(120, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(310, 13);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(80, 30);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Reports";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(400, 13);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(90, 30);
            this.btnAudit.TabIndex = 4;
            this.btnAudit.Text = "Audit Log";
            this.btnAudit.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogout.Location = new System.Drawing.Point(900, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(650, 19);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(38, 15);
            this.lblUserInfo.TabIndex = 6;
            this.lblUserInfo.Text = "";
            // 
            // radGridView1  (Telerik RadGridView - replaces DataGridView)
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.TabIndex = 1;
            this.radGridView1.Text = "radGridView1";
            // 
            // MainForm
            // 
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(1000, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
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

        private Telerik.WinControls.UI.RadGridView radGridView1;
    }
}
