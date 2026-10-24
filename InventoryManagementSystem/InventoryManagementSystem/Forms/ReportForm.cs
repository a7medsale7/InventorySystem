using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Reports;

namespace InventoryManagementSystem.Forms
{
    public partial class ReportForm : Form
    {
        private readonly ProductRepository _products = new ProductRepository();
        private ReportDocument _report;

        public ReportForm()
        {
            InitializeComponent();
            Load += ReportForm_Load;
            btnRefresh.Click += delegate { ShowReport(); };
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            nudThreshold.Value = AppSettings.LowStockThreshold;
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            ShowReport();
        }

        private void ShowReport()
        {
            try
            {
                int threshold = (int)nudThreshold.Value;
                bool lowOnly = chkLowOnly.Checked;
                DataTable data = _products.GetReportTable(threshold, lowOnly);

                var report = new InventoryReport();
                report.Bind(data, threshold);

                crystalReportViewer1.ReportSource = report;

                if (_report != null) _report.Dispose();
                _report = report;
            }
            catch (Exception ex)
            {
                string hint = "";
                if (ex.Message.IndexOf("Crystal", StringComparison.OrdinalIgnoreCase) >= 0
                    || ex.GetType().FullName.IndexOf("Crystal", StringComparison.OrdinalIgnoreCase) >= 0
                    || ex.Message.IndexOf("load report", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    hint = "\n\nCrystal Reports Runtime may not be installed.\n"
                         + "Run tools\\Install-CrystalRuntime.bat as Administrator, then reopen this form.";
                }

                MessageBox.Show("Could not show the report:\n" + ex.Message + hint, "Report error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_report != null) _report.Dispose();
            base.OnFormClosed(e);
        }
    }
}
