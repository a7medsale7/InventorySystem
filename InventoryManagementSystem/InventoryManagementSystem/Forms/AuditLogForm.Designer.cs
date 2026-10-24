namespace InventoryManagementSystem.Forms
{
    partial class AuditLogForm
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
            this.dgvAudit = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAudit
            // 
            this.dgvAudit.AllowUserToAddRows = false;
            this.dgvAudit.AllowUserToDeleteRows = false;
            this.dgvAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAudit.BackgroundColor = System.Drawing.Color.White;
            this.dgvAudit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAudit.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.dgvAudit.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvAudit.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAudit.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAudit.EnableHeadersVisualStyles = false;
            this.dgvAudit.GridColor = System.Drawing.Color.LightGray;
            this.dgvAudit.Name = "dgvAudit";
            this.dgvAudit.ReadOnly = true;
            this.dgvAudit.RowHeadersVisible = false;
            this.dgvAudit.RowTemplate.Height = 26;
            this.dgvAudit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAudit.TabIndex = 0;
            // 
            // AuditLogForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.dgvAudit);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AuditLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audit Log";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudit)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAudit;
    }
}
