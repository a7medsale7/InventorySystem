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
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 21);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(62, 15);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Product ID";
            // 
            // lblIdValue
            // 
            this.lblIdValue.AutoSize = true;
            this.lblIdValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblIdValue.ForeColor = System.Drawing.Color.Gray;
            this.lblIdValue.Location = new System.Drawing.Point(170, 21);
            this.lblIdValue.Name = "lblIdValue";
            this.lblIdValue.Size = new System.Drawing.Size(35, 15);
            this.lblIdValue.TabIndex = 1;
            this.lblIdValue.Text = "(auto)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 57);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 15);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name *";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(170, 54);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 23);
            this.txtName.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(20, 93);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(67, 15);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(170, 90);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(230, 60);
            this.txtDescription.TabIndex = 5;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(20, 157);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(102, 15);
            this.lblQty.TabIndex = 6;
            this.lblQty.Text = "Quantity in Stock";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(170, 154);
            this.nudQuantity.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 23);
            this.nudQuantity.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 193);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(33, 15);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(170, 190);
            this.nudPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(120, 23);
            this.nudPrice.TabIndex = 9;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(20, 229);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(97, 15);
            this.lblSupplier.TabIndex = 10;
            this.lblSupplier.Text = "Supplier Name *";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(170, 226);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(230, 23);
            this.txtSupplier.TabIndex = 11;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 265);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 12;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(170, 262);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(230, 23);
            this.cboCategory.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(170, 308);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(440, 360);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product";
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
