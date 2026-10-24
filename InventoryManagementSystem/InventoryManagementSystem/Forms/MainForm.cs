using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Security;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace InventoryManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private readonly ProductRepository  _products   = new ProductRepository();
        private readonly CategoryRepository _categories = new CategoryRepository();

        /// <summary>
        /// Program.cs بيقراها عشان يعرف: هل المستخدم عمل Logout ولا قفل البرنامج؟
        /// </summary>
        public bool LoggedOut { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            Load            += MainForm_Load;
            btnSearch.Click += delegate { LoadProducts(); };
            btnClear.Click  += btnClear_Click;
            btnAdd.Click    += btnAdd_Click;
            btnEdit.Click   += delegate { EditSelected(); };
            btnDelete.Click += btnDelete_Click;
            btnReport.Click += btnReport_Click;
            btnAudit.Click  += btnAudit_Click;
            btnLogout.Click += btnLogout_Click;

            cboCategory.SelectionChangeCommitted += delegate { LoadProducts(); };
            cboStatus.SelectionChangeCommitted   += delegate { LoadProducts(); };

            // Telerik: double-click لتعديل صف
            radGridView1.CellDoubleClick += (s, e) =>
            {
                if (Session.IsAdmin) EditSelected();
            };

            // Telerik: تلوين الصفوف حسب StockStatus
            radGridView1.RowFormatting += radGridView1_RowFormatting;

            AcceptButton = btnSearch; // Enter = بحث
        }

        // =====================================================
        // Load
        // =====================================================
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = "User: " + Session.CurrentUser.Username +
                               "  |  Role: " + Session.CurrentUser.Role;
            ApplyPermissions();
            ConfigureRadGrid();
            LoadFilters();
            LoadProducts();
        }

        // =====================================================
        // إعداد Telerik RadGridView
        // =====================================================
        private void ConfigureRadGrid()
        {
            // تفعيل الـ built-in filtering row (فيلتر مدمج تحت كل عمود)
            radGridView1.EnableFiltering          = true;
            radGridView1.ShowFilteringRow         = true;
            radGridView1.MasterTemplate.EnableFiltering  = true;
            radGridView1.MasterTemplate.ShowFilteringRow = true;

            // تفعيل الـ grouping (سحب عمود للتجميع)
            radGridView1.MasterTemplate.AllowColumnChooser = true;
            radGridView1.MasterTemplate.EnableGrouping     = true;
            radGridView1.EnableGrouping                    = true;

            // Alternating rows
            radGridView1.EnableAlternatingRowColor         = true;
            radGridView1.TableElement.AlternatingRowColor  = Color.FromArgb(245, 248, 255);

            // لا يسمح بالتعديل من الـ grid مباشرة
            radGridView1.ReadOnly     = true;
            radGridView1.MultiSelect  = false;

            // عرض بصري
            radGridView1.AutoSizeRows = false;
        }

        // =====================================================
        // تلوين صفوف StockStatus (Telerik RowFormatting event)
        // =====================================================
        private void radGridView1_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            // نتجاهل header rows
            if (!(e.RowElement.RowInfo is GridViewDataRowInfo)) return;

            var cell = e.RowElement.RowInfo.Cells["StockStatus"];
            if (cell == null) return;

            string status = Convert.ToString(cell.Value);

            if (status == "Out of Stock")
            {
                e.RowElement.DrawFill    = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor   = Color.FromArgb(255, 205, 210); // أحمر فاتح
            }
            else if (status == "Low Stock")
            {
                e.RowElement.DrawFill    = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor   = Color.FromArgb(255, 249, 196); // أصفر فاتح
            }
            else
            {
                // Reset - مهم جداً عشان الـ UI Virtualization
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty,    ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty,      ValueResetFlags.Local);
            }
        }

        // =====================================================
        // الصلاحيات
        // =====================================================
        private void ApplyPermissions()
        {
            bool isAdmin   = Session.IsAdmin;
            btnAdd.Visible    = isAdmin;
            btnEdit.Visible   = isAdmin;
            btnDelete.Visible = isAdmin;
            btnAudit.Visible  = isAdmin;
        }

        // =====================================================
        // تجهيز الفلاتر الخارجية (Search bar)
        // =====================================================
        private void LoadFilters()
        {
            var cats = _categories.GetAll();
            cats.Insert(0, new Category { CategoryId = 0, Name = "All Categories" });
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember   = "CategoryId";
            cboCategory.DataSource    = cats;

            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new object[] { "All Statuses", "In Stock", "Low Stock", "Out of Stock" });
            cboStatus.SelectedIndex = 0;
        }

        // =====================================================
        // تحميل المنتجات
        // =====================================================
        private void LoadProducts()
        {
            try
            {
                string text     = txtSearch.Text.Trim();
                int?   categoryId = null;
                int    catValue   = Convert.ToInt32(cboCategory.SelectedValue ?? 0);
                if (catValue > 0) categoryId = catValue;

                string status = cboStatus.SelectedIndex > 0 ? cboStatus.Text : null;

                DataTable dt = _products.Search(text, categoryId, status, AppSettings.LowStockThreshold);
                radGridView1.DataSource = dt;

                SetupColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load products:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupColumns()
        {
            var cols = radGridView1.Columns;
            if (cols.Count == 0) return;

            // عناوين
            SetHeader("ProductId",    "ID");
            SetHeader("Name",         "Product Name");
            SetHeader("Description",  "Description");
            SetHeader("Quantity",     "Qty in Stock");
            SetHeader("Price",        "Price");
            SetHeader("SupplierName", "Supplier");
            SetHeader("CategoryName", "Category");
            SetHeader("TotalValue",   "Total Value");
            SetHeader("StockStatus",  "Stock Status");

            // إخفاء الأعمدة التقنية
            HideColumn("CategoryId");
            HideColumn("IsLowStock");

            // تنسيق الأرقام
            if (cols["Price"]      != null) cols["Price"].FormatString      = "{0:N2}";
            if (cols["TotalValue"] != null) cols["TotalValue"].FormatString = "{0:N2}";

            // عرض الأعمدة
            if (cols["ProductId"]    != null) cols["ProductId"].Width    = 50;
            if (cols["Name"]         != null) cols["Name"].Width         = 180;
            if (cols["Description"]  != null) cols["Description"].Width  = 200;
            if (cols["Quantity"]     != null) cols["Quantity"].Width      = 90;
            if (cols["Price"]        != null) cols["Price"].Width         = 90;
            if (cols["SupplierName"] != null) cols["SupplierName"].Width  = 150;
            if (cols["CategoryName"] != null) cols["CategoryName"].Width  = 120;
            if (cols["TotalValue"]   != null) cols["TotalValue"].Width    = 100;
            if (cols["StockStatus"]  != null) cols["StockStatus"].Width   = 110;
        }

        private void SetHeader(string col, string header)
        {
            if (radGridView1.Columns[col] != null)
                radGridView1.Columns[col].HeaderText = header;
        }

        private void HideColumn(string col)
        {
            if (radGridView1.Columns[col] != null)
                radGridView1.Columns[col].IsVisible = false;
        }

        private int? GetSelectedProductId()
        {
            if (radGridView1.CurrentRow == null) return null;
            var cell = radGridView1.CurrentRow.Cells["ProductId"];
            if (cell == null) return null;
            return Convert.ToInt32(cell.Value);
        }

        // =====================================================
        // أزرار
        // =====================================================
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboCategory.SelectedIndex = 0;
            cboStatus.SelectedIndex   = 0;
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
            if (id == null) { MessageBox.Show("Select a product first."); return; }

            using (var f = new ProductForm(id.Value))
            {
                if (f.ShowDialog(this) == DialogResult.OK) LoadProducts();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedProductId();
            if (id == null) { MessageBox.Show("Select a product first."); return; }

            string name = Convert.ToString(radGridView1.CurrentRow.Cells["Name"]?.Value);
            var answer = MessageBox.Show(
                "Delete product \"" + name + "\"?\nThis cannot be undone.",
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
            using (var f = new ReportForm()) f.ShowDialog(this);
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            using (var f = new AuditLogForm()) f.ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoggedOut = true;
            Close();
        }
    }
}
