using System;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Security;

namespace InventoryManagementSystem.Forms
{
    public partial class AuditLogForm : Form
    {
        public AuditLogForm()
        {
            InitializeComponent();
            Load += AuditLogForm_Load;
        }

        private void AuditLogForm_Load(object sender, EventArgs e)
        {
            if (!Session.IsAdmin)
            {
                MessageBox.Show("Admins only.");
                BeginInvoke((Action)Close);
                return;
            }

            try
            {
                dgvAudit.DataSource = new AuditRepository().GetAll();
                dgvAudit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                if (dgvAudit.Columns["ChangedAt"] != null)
                    dgvAudit.Columns["ChangedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load audit log:\n" + ex.Message);
            }
        }
    }
}
