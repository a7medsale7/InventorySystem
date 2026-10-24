namespace InventoryManagementSystem.Forms
{
    partial class ReportForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.nudThreshold = new System.Windows.Forms.NumericUpDown();
            this.chkLowOnly = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.topPanel.Controls.Add(this.lblThreshold);
            this.topPanel.Controls.Add(this.nudThreshold);
            this.topPanel.Controls.Add(this.chkLowOnly);
            this.topPanel.Controls.Add(this.btnRefresh);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(282, 45);
            this.topPanel.TabIndex = 0;
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(10, 13);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(122, 20);
            this.lblThreshold.TabIndex = 0;
            this.lblThreshold.Text = "Low stock below:";
            // 
            // nudThreshold
            // 
            this.nudThreshold.Location = new System.Drawing.Point(120, 10);
            this.nudThreshold.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(70, 27);
            this.nudThreshold.TabIndex = 1;
            this.nudThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chkLowOnly
            // 
            this.chkLowOnly.AutoSize = true;
            this.chkLowOnly.Location = new System.Drawing.Point(205, 13);
            this.chkLowOnly.Name = "chkLowOnly";
            this.chkLowOnly.Size = new System.Drawing.Size(168, 24);
            this.chkLowOnly.TabIndex = 2;
            this.chkLowOnly.Text = "Low stock items only";
            this.chkLowOnly.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(380, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 26);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 45);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(282, 208);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // ReportForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.NumericUpDown nudThreshold;
        private System.Windows.Forms.CheckBox chkLowOnly;
        private System.Windows.Forms.Button btnRefresh;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}
