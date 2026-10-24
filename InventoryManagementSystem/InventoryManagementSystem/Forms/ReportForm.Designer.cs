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
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();

            // ─── topPanel ──────────────────────────────────────────
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 45;
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.topPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblThreshold, this.nudThreshold, this.chkLowOnly, this.btnRefresh
            });

            this.lblThreshold.Text = "Low stock below:";
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(10, 13);

            this.nudThreshold.Minimum = 1;
            this.nudThreshold.Maximum = 100000;
            this.nudThreshold.Value = 10;
            this.nudThreshold.Width = 70;
            this.nudThreshold.Location = new System.Drawing.Point(120, 10);

            this.chkLowOnly.Text = "Low stock items only";
            this.chkLowOnly.AutoSize = true;
            this.chkLowOnly.Location = new System.Drawing.Point(205, 13);

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 26);
            this.btnRefresh.Location = new System.Drawing.Point(380, 9);

            // ─── crystalReportViewer1 ──────────────────────────────
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

            // ─── ReportForm ────────────────────────────────────────
            this.Text = "Inventory Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.topPanel);

            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
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
