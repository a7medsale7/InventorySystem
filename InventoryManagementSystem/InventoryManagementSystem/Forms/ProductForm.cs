using System;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Forms
{
    public partial class ProductForm : Form
    {
        private readonly ProductRepository _repo    = new ProductRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();
        private readonly int? _productId; // null = إضافة ، له قيمة = تعديل

        public ProductForm() : this(null) { }

        public ProductForm(int? productId)
        {
            InitializeComponent();
            _productId = productId;
            Load          += ProductForm_Load;
            btnSave.Click += btnSave_Click;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            var cats = _catRepo.GetAll();
            cats.Insert(0, new Category { CategoryId = 0, Name = "(None)" });
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember   = "CategoryId";
            cboCategory.DataSource    = cats;

            if (!_productId.HasValue)
            {
                Text = "Add Product";
                lblIdValue.Text = "(auto)";
                return;
            }

            Text = "Edit Product";
            Product p = _repo.GetById(_productId.Value);
            if (p == null)
            {
                MessageBox.Show("This product no longer exists.");
                DialogResult = DialogResult.Cancel;
                BeginInvoke((Action)Close);
                return;
            }

            lblIdValue.Text   = p.ProductId.ToString();
            txtName.Text      = p.Name;
            txtDescription.Text = p.Description;
            nudQuantity.Value = p.Quantity;
            nudPrice.Value    = p.Price;
            txtSupplier.Text  = p.SupplierName;
            cboCategory.SelectedValue = p.CategoryId ?? 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name     = txtName.Text.Trim();
            string supplier = txtSupplier.Text.Trim();

            if (name.Length == 0)
            {
                MessageBox.Show("Product name is required.", "Validation");
                txtName.Focus();
                return;
            }
            if (supplier.Length == 0)
            {
                MessageBox.Show("Supplier name is required.", "Validation");
                txtSupplier.Focus();
                return;
            }

            int catId = Convert.ToInt32(cboCategory.SelectedValue ?? 0);

            var p = new Product
            {
                ProductId    = _productId ?? 0,
                Name         = name,
                Description  = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                Quantity     = (int)nudQuantity.Value,
                Price        = nudPrice.Value,
                SupplierName = supplier,
                CategoryId   = catId > 0 ? (int?)catId : null
            };

            try
            {
                if (_productId.HasValue) _repo.Update(p);
                else                     _repo.Add(p);
                DialogResult = DialogResult.OK;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
