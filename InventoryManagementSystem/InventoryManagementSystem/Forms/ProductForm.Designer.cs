namespace InventoryManagementSystem.Forms
{
    partial class ProductForm
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
            this.lblId          = new System.Windows.Forms.Label();
            this.lblIdValue     = new System.Windows.Forms.Label();
            this.lblName        = new System.Windows.Forms.Label();
            this.txtName        = new System.Windows.Forms.TextBox();
            this.lblDesc        = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblQty         = new System.Windows.Forms.Label();
            this.nudQuantity    = new System.Windows.Forms.NumericUpDown();
            this.lblPrice       = new System.Windows.Forms.Label();
            this.nudPrice       = new System.Windows.Forms.NumericUpDown();
            this.lblSupplier    = new System.Windows.Forms.Label();
            this.txtSupplier    = new System.Windows.Forms.TextBox();
            this.lblCategory    = new System.Windows.Forms.Label();
            this.cboCategory    = new System.Windows.Forms.ComboBox();
            this.btnSave        = new System.Windows.Forms.Button();
            this.btnCancel      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();

            int labelX  = 20;
            int controlX = 170;
            int w        = 230;
            int row      = 18;
            int step     = 36;

            // ─── Product ID ──────────────────────────────────────────
            this.lblId.Text     = "Product ID";
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(labelX, row + 3);

            this.lblIdValue.Text     = "(auto)";
            this.lblIdValue.AutoSize = true;
            this.lblIdValue.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblIdValue.ForeColor = System.Drawing.Color.Gray;
            this.lblIdValue.Location = new System.Drawing.Point(controlX, row + 3);
            row += step;

            // ─── Name ────────────────────────────────────────────────
            this.lblName.Text     = "Name *";
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(labelX, row + 3);

            this.txtName.MaxLength = 100;
            this.txtName.Width     = w;
            this.txtName.Location  = new System.Drawing.Point(controlX, row);
            row += step;

            // ─── Description ─────────────────────────────────────────
            this.lblDesc.Text     = "Description";
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(labelX, row + 3);

            this.txtDescription.Multiline  = true;
            this.txtDescription.Height     = 60;
            this.txtDescription.MaxLength  = 500;
            this.txtDescription.Width      = w;
            this.txtDescription.Location   = new System.Drawing.Point(controlX, row);
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            row += step + 28;

            // ─── Quantity ────────────────────────────────────────────
            this.lblQty.Text     = "Quantity in Stock";
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(labelX, row + 3);

            this.nudQuantity.Minimum  = 0;
            this.nudQuantity.Maximum  = 10000000;
            this.nudQuantity.Width    = 120;
            this.nudQuantity.Location = new System.Drawing.Point(controlX, row);
            row += step;

            // ─── Price ───────────────────────────────────────────────
            this.lblPrice.Text     = "Price";
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(labelX, row + 3);

            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Minimum       = 0;
            this.nudPrice.Maximum       = 100000000;
            this.nudPrice.Width         = 120;
            this.nudPrice.Location      = new System.Drawing.Point(controlX, row);
            row += step;

            // ─── Supplier ────────────────────────────────────────────
            this.lblSupplier.Text     = "Supplier Name *";
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(labelX, row + 3);

            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Width     = w;
            this.txtSupplier.Location  = new System.Drawing.Point(controlX, row);
            row += step;

            // ─── Category ────────────────────────────────────────────
            this.lblCategory.Text     = "Category";
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(labelX, row + 3);

            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Width    = w;
            this.cboCategory.Location = new System.Drawing.Point(controlX, row);
            row += step + 10;

            // ─── Buttons ─────────────────────────────────────────────
            this.btnSave.Text     = "Save";
            this.btnSave.Size     = new System.Drawing.Size(90, 32);
            this.btnSave.Location = new System.Drawing.Point(controlX, row);

            this.btnCancel.Text         = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Size         = new System.Drawing.Size(90, 32);
            this.btnCancel.Location     = new System.Drawing.Point(controlX + 100, row);

            // ─── Form ────────────────────────────────────────────────
            this.AcceptButton    = this.btnSave;
            this.CancelButton    = this.btnCancel;
            this.ClientSize      = new System.Drawing.Size(440, row + 52);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Product";
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblId,          this.lblIdValue,
                this.lblName,        this.txtName,
                this.lblDesc,        this.txtDescription,
                this.lblQty,         this.nudQuantity,
                this.lblPrice,       this.nudPrice,
                this.lblSupplier,    this.txtSupplier,
                this.lblCategory,    this.cboCategory,
                this.btnSave,        this.btnCancel
            });

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label          lblId;
        private System.Windows.Forms.Label          lblIdValue;
        private System.Windows.Forms.Label          lblName;
        private System.Windows.Forms.TextBox        txtName;
        private System.Windows.Forms.Label          lblDesc;
        private System.Windows.Forms.TextBox        txtDescription;
        private System.Windows.Forms.Label          lblQty;
        private System.Windows.Forms.NumericUpDown  nudQuantity;
        private System.Windows.Forms.Label          lblPrice;
        private System.Windows.Forms.NumericUpDown  nudPrice;
        private System.Windows.Forms.Label          lblSupplier;
        private System.Windows.Forms.TextBox        txtSupplier;
        private System.Windows.Forms.Label          lblCategory;
        private System.Windows.Forms.ComboBox       cboCategory;
        private System.Windows.Forms.Button         btnSave;
        private System.Windows.Forms.Button         btnCancel;
    }
}
