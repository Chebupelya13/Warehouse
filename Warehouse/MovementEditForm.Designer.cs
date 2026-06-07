namespace Warehouse
{
    partial class MovementEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblCell = new System.Windows.Forms.Label();
            this.cmbCell = new System.Windows.Forms.ComboBox();
            this.lblMovementType = new System.Windows.Forms.Label();
            this.cmbMovementType = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.lblMovementDate = new System.Windows.Forms.Label();
            this.dtpMovementDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();

            // lblProduct
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(20, 20);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(41, 13);
            this.lblProduct.Text = "Товар:";

            // cmbProduct
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Location = new System.Drawing.Point(120, 17);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(200, 21);

            // lblCell
            this.lblCell.AutoSize = true;
            this.lblCell.Location = new System.Drawing.Point(20, 60);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(47, 13);
            this.lblCell.Text = "Ячейка:";

            // cmbCell
            this.cmbCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCell.Location = new System.Drawing.Point(120, 57);
            this.cmbCell.Name = "cmbCell";
            this.cmbCell.Size = new System.Drawing.Size(200, 21);

            // lblMovementType
            this.lblMovementType.AutoSize = true;
            this.lblMovementType.Location = new System.Drawing.Point(20, 100);
            this.lblMovementType.Name = "lblMovementType";
            this.lblMovementType.Size = new System.Drawing.Size(83, 13);
            this.lblMovementType.Text = "Тип движения:";

            // cmbMovementType
            this.cmbMovementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovementType.FormattingEnabled = true;
            this.cmbMovementType.Items.AddRange(new object[] {
            "Поступление",
            "Отгрузка"});
            this.cmbMovementType.Location = new System.Drawing.Point(120, 97);
            this.cmbMovementType.Name = "cmbMovementType";
            this.cmbMovementType.Size = new System.Drawing.Size(200, 21);

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(20, 140);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(69, 13);
            this.lblQuantity.Text = "Количество:";

            // numQuantity
            this.numQuantity.Location = new System.Drawing.Point(120, 137);
            this.numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(200, 20);
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // lblTotalCost
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(20, 180);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(82, 13);
            this.lblTotalCost.Text = "Сумма (итого):";

            // txtTotalCost
            this.txtTotalCost.Location = new System.Drawing.Point(120, 177);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(200, 20);

            // lblMovementDate
            this.lblMovementDate.AutoSize = true;
            this.lblMovementDate.Location = new System.Drawing.Point(20, 220);
            this.lblMovementDate.Name = "lblMovementDate";
            this.lblMovementDate.Size = new System.Drawing.Size(36, 13);
            this.lblMovementDate.Text = "Дата:";

            // dtpMovementDate
            this.dtpMovementDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMovementDate.Location = new System.Drawing.Point(120, 217);
            this.dtpMovementDate.Name = "dtpMovementDate";
            this.dtpMovementDate.Size = new System.Drawing.Size(200, 20);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(164, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(245, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // MovementEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 310);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpMovementDate);
            this.Controls.Add(this.lblMovementDate);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cmbMovementType);
            this.Controls.Add(this.lblMovementType);
            this.Controls.Add(this.cmbCell);
            this.Controls.Add(this.lblCell);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovementEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblCell;
        private System.Windows.Forms.ComboBox cmbCell;
        private System.Windows.Forms.Label lblMovementType;
        private System.Windows.Forms.ComboBox cmbMovementType;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.Label lblMovementDate;
        private System.Windows.Forms.DateTimePicker dtpMovementDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
