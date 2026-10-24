using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Security;

namespace InventoryManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private readonly ProductRepository _products = new ProductRepository();
        private readonly CategoryRepository _categories = new CategoryRepository();

        /// <summary>
        /// Program.cs بيقراها عشان يعرف: هل المستخدم عمل Logout ولا قفل البرنامج؟
        /// </summary>
        public bool LoggedOut { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            Load += MainForm_Load;
            btnSearch.Click += delegate { LoadProducts(); };
            btnClear.Click += btnClear_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += delegate { EditSelected(); };
            btnDelete.Click += btnDelete_Click;
            btnReport.Click += btnReport_Click;
            btnAudit.Click += btnAudit_Click;
            btnLogout.Click += btnLogout_Click;

            cboCategory.SelectionChangeCommitted += delegate { LoadProducts(); };
            cboStatus.SelectionChangeCommitted += delegate { LoadProducts(); };

            dgvProducts.DataBindingComplete += dgvProducts_DataBindingComplete;
            dgvProducts.CellDoubleClick += (s, e) =>
            {
                if (Session.IsAdmin && e.RowIndex >= 0) EditSelected();
            };

            AcceptButton = btnSearch; // Enter في خانة البحث = بحث
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = "User: " + Session.CurrentUser.Username +
                               "  |  Role: " + Session.CurrentUser.Role;
            ApplyPermissions();
            LoadFilters();
            LoadProducts();
        }

        // ---------- الصلاحيات ----------
        private void ApplyPermissions()
        {
            bool isAdmin = Session.IsAdmin;
            btnAdd.Visible = isAdmin;
            btnEdit.Visible = isAdmin;
            btnDelete.Visible = isAdmin;
            btnAudit.Visible = isAdmin;
        }

        // ---------- تجهيز الفلاتر ----------
        private void LoadFilters()
        {
            var cats = _categories.GetAll();
            cats.Insert(0, new Category { CategoryId = 0, Name = "All Categories" });
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "CategoryId";
            cboCategory.DataSource = cats;

            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new object[] { "All Statuses", "In Stock", "Low Stock", "Out of Stock" });
            cboStatus.SelectedIndex = 0;
        }

        // ---------- تحميل المنتجات ----------
        private void LoadProducts()
        {
            try
            {
                string text = txtSearch.Text.Trim();

                int? categoryId = null;
                int catValue = Convert.ToInt32(cboCategory.SelectedValue ?? 0);
                if (catValue > 0) categoryId = catValue;

                string status = cboStatus.SelectedIndex > 0 ? cboStatus.Text : null;

                dgvProducts.DataSource = _products.Search(text, categoryId, status, AppSettings.LowStockThreshold);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load products:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // بعد تملية الجدول: تعديل العناوين + تلوين الصفوف
        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvProducts.Columns.Count == 0) return;

            SetHeader("ProductId",    "ID");
            SetHeader("Name",         "Product Name");
            SetHeader("Description",  "Description");
            SetHeader("Quantity",     "Qty in Stock");
            SetHeader("Price",        "Price");
            SetHeader("SupplierName", "Supplier");
            SetHeader("CategoryName", "Category");
            SetHeader("TotalValue",   "Total Value");
            SetHeader("StockStatus",  "Stock Status");

            HideColumn("CategoryId");
            HideColumn("IsLowStock");

            if (dgvProducts.Columns["Price"] != null)
                dgvProducts.Columns["Price"].DefaultCellStyle.Format = "N2";
            if (dgvProducts.Columns["TotalValue"] != null)
                dgvProducts.Columns["TotalValue"].DefaultCellStyle.Format = "N2";

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                string st = Convert.ToString(row.Cells["StockStatus"].Value);
                if (st == "Out of Stock")
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                else if (st == "Low Stock")
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
        }

        private void SetHeader(string column, string header)
        {
            if (dgvProducts.Columns[column] != null)
                dgvProducts.Columns[column].HeaderText = header;
        }

        private void HideColumn(string column)
        {
            if (dgvProducts.Columns[column] != null)
                dgvProducts.Columns[column].Visible = false;
        }

        private int? GetSelectedProductId()
        {
            if (dgvProducts.CurrentRow == null) return null;
            return Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductId"].Value);
        }

        // ---------- الأزرار ----------
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboCategory.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new ProductForm())
            {
                if (f.ShowDialog(this) == DialogResult.OK) LoadProducts();
            }
        }

        private void EditSelected()
        {
            int? id = GetSelectedProductId();
            if (id == null)
            {
                MessageBox.Show("Select a product first.");
                return;
            }
            using (var f = new ProductForm(id.Value))
            {
                if (f.ShowDialog(this) == DialogResult.OK) LoadProducts();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedProductId();
            if (id == null) { MessageBox.Show("Select a product first."); return; }

            string name = Convert.ToString(dgvProducts.CurrentRow.Cells["Name"].Value);
            var answer = MessageBox.Show("Delete product \"" + name + "\"?\nThis cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes) return;

            try
            {
                _products.Delete(id.Value);
                LoadProducts();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            using (var f = new ReportForm())
                f.ShowDialog(this);
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            using (var f = new AuditLogForm())
                f.ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoggedOut = true;
            Close();
        }
    }
}
