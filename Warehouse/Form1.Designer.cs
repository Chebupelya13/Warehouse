namespace Warehouse
{
    partial class Form1
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
            this.tabControlMain = new System.Windows.Forms.TabControl();

            // Tabs
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.tabSuppliers = new System.Windows.Forms.TabPage();
            this.tabOperations = new System.Windows.Forms.TabPage();
            this.tabAnalytics = new System.Windows.Forms.TabPage();

            // Products Tab Controls
            this.tsProducts = new System.Windows.Forms.ToolStrip();
            this.tsbAddProduct = new System.Windows.Forms.ToolStripButton();
            this.tsbEditProduct = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteProduct = new System.Windows.Forms.ToolStripButton();
            this.lblSearchProduct = new System.Windows.Forms.ToolStripLabel();
            this.txtSearchProduct = new System.Windows.Forms.ToolStripTextBox();
            this.lblFilterCategory = new System.Windows.Forms.ToolStripLabel();
            this.cmbFilterCategory = new System.Windows.Forms.ToolStripComboBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();

            // Suppliers Tab Controls
            this.tsSuppliers = new System.Windows.Forms.ToolStrip();
            this.tsbAddSupplier = new System.Windows.Forms.ToolStripButton();
            this.tsbEditSupplier = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteSupplier = new System.Windows.Forms.ToolStripButton();
            this.lblSearchSupplier = new System.Windows.Forms.ToolStripLabel();
            this.txtSearchSupplier = new System.Windows.Forms.ToolStripTextBox();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();

            // Operations Tab Controls
            this.splitContainerOperations = new System.Windows.Forms.SplitContainer();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.tsOrders = new System.Windows.Forms.ToolStrip();
            this.tsbAddOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbEditOrder = new System.Windows.Forms.ToolStripButton();
            this.dgvMovements = new System.Windows.Forms.DataGridView();
            this.tsMovements = new System.Windows.Forms.ToolStrip();
            this.tsbAddMovement = new System.Windows.Forms.ToolStripButton();
            this.tsbEditMovement = new System.Windows.Forms.ToolStripButton();

            // Analytics Tab Controls
            this.pnlAnalyticsTop = new System.Windows.Forms.Panel();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.dgvAnalytics = new System.Windows.Forms.DataGridView();

            this.tabControlMain.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tsProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tabSuppliers.SuspendLayout();
            this.tsSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.tabOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOperations)).BeginInit();
            this.splitContainerOperations.Panel1.SuspendLayout();
            this.splitContainerOperations.Panel2.SuspendLayout();
            this.splitContainerOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.tsOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).BeginInit();
            this.tsMovements.SuspendLayout();
            this.tabAnalytics.SuspendLayout();
            this.pnlAnalyticsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalytics)).BeginInit();
            this.SuspendLayout();

            //
            // tabControlMain
            //
            this.tabControlMain.Controls.Add(this.tabProducts);
            this.tabControlMain.Controls.Add(this.tabSuppliers);
            this.tabControlMain.Controls.Add(this.tabOperations);
            this.tabControlMain.Controls.Add(this.tabAnalytics);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1024, 768);
            this.tabControlMain.TabIndex = 0;

            //
            // tabProducts
            //
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Controls.Add(this.tsProducts);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(1016, 742);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Справочник номенклатуры";
            this.tabProducts.UseVisualStyleBackColor = true;

            //
            // tsProducts
            //
            this.tsProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddProduct,
            this.tsbEditProduct,
            this.tsbDeleteProduct,
            new System.Windows.Forms.ToolStripSeparator(),
            this.lblSearchProduct,
            this.txtSearchProduct,
            new System.Windows.Forms.ToolStripSeparator(),
            this.lblFilterCategory,
            this.cmbFilterCategory});
            this.tsProducts.Location = new System.Drawing.Point(3, 3);
            this.tsProducts.Name = "tsProducts";
            this.tsProducts.Size = new System.Drawing.Size(1010, 25);
            this.tsProducts.TabIndex = 0;
            this.tsProducts.Text = "toolStrip1";

            // tsbAddProduct
            this.tsbAddProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddProduct.Name = "tsbAddProduct";
            this.tsbAddProduct.Size = new System.Drawing.Size(63, 22);
            this.tsbAddProduct.Text = "Добавить";

            // tsbEditProduct
            this.tsbEditProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEditProduct.Name = "tsbEditProduct";
            this.tsbEditProduct.Size = new System.Drawing.Size(89, 22);
            this.tsbEditProduct.Text = "Редактировать";

            // tsbDeleteProduct
            this.tsbDeleteProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDeleteProduct.Name = "tsbDeleteProduct";
            this.tsbDeleteProduct.Size = new System.Drawing.Size(55, 22);
            this.tsbDeleteProduct.Text = "Удалить";

            // lblSearchProduct
            this.lblSearchProduct.Name = "lblSearchProduct";
            this.lblSearchProduct.Size = new System.Drawing.Size(45, 22);
            this.lblSearchProduct.Text = "Поиск:";

            // txtSearchProduct
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(150, 25);

            // lblFilterCategory
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(66, 22);
            this.lblFilterCategory.Text = "Категория:";

            // cmbFilterCategory
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(150, 25);

            //
            // dgvProducts
            //
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 28);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(1010, 711);
            this.dgvProducts.TabIndex = 1;

            //
            // tabSuppliers
            //
            this.tabSuppliers.Controls.Add(this.dgvSuppliers);
            this.tabSuppliers.Controls.Add(this.tsSuppliers);
            this.tabSuppliers.Location = new System.Drawing.Point(4, 22);
            this.tabSuppliers.Name = "tabSuppliers";
            this.tabSuppliers.Padding = new System.Windows.Forms.Padding(3);
            this.tabSuppliers.Size = new System.Drawing.Size(1016, 742);
            this.tabSuppliers.TabIndex = 1;
            this.tabSuppliers.Text = "Контрагенты";
            this.tabSuppliers.UseVisualStyleBackColor = true;

            //
            // tsSuppliers
            //
            this.tsSuppliers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddSupplier,
            this.tsbEditSupplier,
            this.tsbDeleteSupplier,
            new System.Windows.Forms.ToolStripSeparator(),
            this.lblSearchSupplier,
            this.txtSearchSupplier});
            this.tsSuppliers.Location = new System.Drawing.Point(3, 3);
            this.tsSuppliers.Name = "tsSuppliers";
            this.tsSuppliers.Size = new System.Drawing.Size(1010, 25);
            this.tsSuppliers.TabIndex = 0;
            this.tsSuppliers.Text = "toolStrip2";

            // tsbAddSupplier
            this.tsbAddSupplier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddSupplier.Name = "tsbAddSupplier";
            this.tsbAddSupplier.Size = new System.Drawing.Size(63, 22);
            this.tsbAddSupplier.Text = "Добавить";

            // tsbEditSupplier
            this.tsbEditSupplier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEditSupplier.Name = "tsbEditSupplier";
            this.tsbEditSupplier.Size = new System.Drawing.Size(89, 22);
            this.tsbEditSupplier.Text = "Редактировать";

            // tsbDeleteSupplier
            this.tsbDeleteSupplier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDeleteSupplier.Name = "tsbDeleteSupplier";
            this.tsbDeleteSupplier.Size = new System.Drawing.Size(55, 22);
            this.tsbDeleteSupplier.Text = "Удалить";

            // lblSearchSupplier
            this.lblSearchSupplier.Name = "lblSearchSupplier";
            this.lblSearchSupplier.Size = new System.Drawing.Size(45, 22);
            this.lblSearchSupplier.Text = "Поиск:";

            // txtSearchSupplier
            this.txtSearchSupplier.Name = "txtSearchSupplier";
            this.txtSearchSupplier.Size = new System.Drawing.Size(150, 25);

            //
            // dgvSuppliers
            //
            this.dgvSuppliers.AllowUserToAddRows = false;
            this.dgvSuppliers.AllowUserToDeleteRows = false;
            this.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuppliers.Location = new System.Drawing.Point(3, 28);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.ReadOnly = true;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(1010, 711);
            this.dgvSuppliers.TabIndex = 1;

            //
            // tabOperations
            //
            this.tabOperations.Controls.Add(this.splitContainerOperations);
            this.tabOperations.Location = new System.Drawing.Point(4, 22);
            this.tabOperations.Name = "tabOperations";
            this.tabOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperations.Size = new System.Drawing.Size(1016, 742);
            this.tabOperations.TabIndex = 2;
            this.tabOperations.Text = "Операции на складе";
            this.tabOperations.UseVisualStyleBackColor = true;

            //
            // splitContainerOperations
            //
            this.splitContainerOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOperations.Location = new System.Drawing.Point(3, 3);
            this.splitContainerOperations.Name = "splitContainerOperations";
            this.splitContainerOperations.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContainerOperations.Panel1
            //
            this.splitContainerOperations.Panel1.Controls.Add(this.dgvOrders);
            this.splitContainerOperations.Panel1.Controls.Add(this.tsOrders);
            //
            // splitContainerOperations.Panel2
            //
            this.splitContainerOperations.Panel2.Controls.Add(this.dgvMovements);
            this.splitContainerOperations.Panel2.Controls.Add(this.tsMovements);
            this.splitContainerOperations.Size = new System.Drawing.Size(1010, 736);
            this.splitContainerOperations.SplitterDistance = 300;
            this.splitContainerOperations.TabIndex = 0;

            //
            // tsOrders
            //
            this.tsOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddOrder,
            this.tsbEditOrder});
            this.tsOrders.Location = new System.Drawing.Point(0, 0);
            this.tsOrders.Name = "tsOrders";
            this.tsOrders.Size = new System.Drawing.Size(1010, 25);
            this.tsOrders.TabIndex = 0;
            this.tsOrders.Text = "toolStrip3";

            // tsbAddOrder
            this.tsbAddOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddOrder.Name = "tsbAddOrder";
            this.tsbAddOrder.Size = new System.Drawing.Size(95, 22);
            this.tsbAddOrder.Text = "Создать заказ";

            // tsbEditOrder
            this.tsbEditOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEditOrder.Name = "tsbEditOrder";
            this.tsbEditOrder.Size = new System.Drawing.Size(124, 22);
            this.tsbEditOrder.Text = "Редактировать заказ";

            //
            // dgvOrders
            //
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 25);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1010, 275);
            this.dgvOrders.TabIndex = 1;

            //
            // tsMovements
            //
            this.tsMovements.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddMovement,
            this.tsbEditMovement});
            this.tsMovements.Location = new System.Drawing.Point(0, 0);
            this.tsMovements.Name = "tsMovements";
            this.tsMovements.Size = new System.Drawing.Size(1010, 25);
            this.tsMovements.TabIndex = 0;
            this.tsMovements.Text = "toolStrip4";

            // tsbAddMovement
            this.tsbAddMovement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddMovement.Name = "tsbAddMovement";
            this.tsbAddMovement.Size = new System.Drawing.Size(117, 22);
            this.tsbAddMovement.Text = "Добавить позицию";

            // tsbEditMovement
            this.tsbEditMovement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEditMovement.Name = "tsbEditMovement";
            this.tsbEditMovement.Size = new System.Drawing.Size(146, 22);
            this.tsbEditMovement.Text = "Редактировать позицию";

            //
            // dgvMovements
            //
            this.dgvMovements.AllowUserToAddRows = false;
            this.dgvMovements.AllowUserToDeleteRows = false;
            this.dgvMovements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovements.Location = new System.Drawing.Point(0, 25);
            this.dgvMovements.Name = "dgvMovements";
            this.dgvMovements.ReadOnly = true;
            this.dgvMovements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovements.Size = new System.Drawing.Size(1010, 407);
            this.dgvMovements.TabIndex = 1;

            //
            // tabAnalytics
            //
            this.tabAnalytics.Controls.Add(this.dgvAnalytics);
            this.tabAnalytics.Controls.Add(this.pnlAnalyticsTop);
            this.tabAnalytics.Location = new System.Drawing.Point(4, 22);
            this.tabAnalytics.Name = "tabAnalytics";
            this.tabAnalytics.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalytics.Size = new System.Drawing.Size(1016, 742);
            this.tabAnalytics.TabIndex = 3;
            this.tabAnalytics.Text = "Аналитические отчеты";
            this.tabAnalytics.UseVisualStyleBackColor = true;

            //
            // pnlAnalyticsTop
            //
            this.pnlAnalyticsTop.Controls.Add(this.cmbReportType);
            this.pnlAnalyticsTop.Controls.Add(this.dtpStartDate);
            this.pnlAnalyticsTop.Controls.Add(this.dtpEndDate);
            this.pnlAnalyticsTop.Controls.Add(this.btnGenerateReport);
            this.pnlAnalyticsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAnalyticsTop.Location = new System.Drawing.Point(3, 3);
            this.pnlAnalyticsTop.Name = "pnlAnalyticsTop";
            this.pnlAnalyticsTop.Size = new System.Drawing.Size(1010, 40);
            this.pnlAnalyticsTop.TabIndex = 0;

            //
            // cmbReportType
            //
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Динамические остатки",
            "Реестр контрагентов",
            "Аудит транзакций",
            "Топология запасов",
            "Финансовая аналитика оборота"});
            this.cmbReportType.Location = new System.Drawing.Point(10, 10);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(250, 21);
            this.cmbReportType.TabIndex = 0;

            //
            // dtpStartDate
            //
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(270, 10);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.Visible = false;

            //
            // dtpEndDate
            //
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(380, 10);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtpEndDate.TabIndex = 2;
            this.dtpEndDate.Visible = false;

            //
            // btnGenerateReport
            //
            this.btnGenerateReport.Location = new System.Drawing.Point(490, 8);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(120, 23);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Сформировать";
            this.btnGenerateReport.UseVisualStyleBackColor = true;

            //
            // dgvAnalytics
            //
            this.dgvAnalytics.AllowUserToAddRows = false;
            this.dgvAnalytics.AllowUserToDeleteRows = false;
            this.dgvAnalytics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnalytics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnalytics.Location = new System.Drawing.Point(3, 43);
            this.dgvAnalytics.Name = "dgvAnalytics";
            this.dgvAnalytics.ReadOnly = true;
            this.dgvAnalytics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnalytics.Size = new System.Drawing.Size(1010, 696);
            this.dgvAnalytics.TabIndex = 1;

            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Система управления складом";
            this.tabControlMain.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            this.tsProducts.ResumeLayout(false);
            this.tsProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tabSuppliers.ResumeLayout(false);
            this.tabSuppliers.PerformLayout();
            this.tsSuppliers.ResumeLayout(false);
            this.tsSuppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.tabOperations.ResumeLayout(false);
            this.splitContainerOperations.Panel1.ResumeLayout(false);
            this.splitContainerOperations.Panel1.PerformLayout();
            this.splitContainerOperations.Panel2.ResumeLayout(false);
            this.splitContainerOperations.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOperations)).EndInit();
            this.splitContainerOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.tsOrders.ResumeLayout(false);
            this.tsOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).EndInit();
            this.tsMovements.ResumeLayout(false);
            this.tsMovements.PerformLayout();
            this.tabAnalytics.ResumeLayout(false);
            this.pnlAnalyticsTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalytics)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControlMain;

        // Products Tab
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.ToolStrip tsProducts;
        private System.Windows.Forms.ToolStripButton tsbAddProduct;
        private System.Windows.Forms.ToolStripButton tsbEditProduct;
        private System.Windows.Forms.ToolStripButton tsbDeleteProduct;
        private System.Windows.Forms.ToolStripLabel lblSearchProduct;
        private System.Windows.Forms.ToolStripTextBox txtSearchProduct;
        private System.Windows.Forms.ToolStripLabel lblFilterCategory;
        private System.Windows.Forms.ToolStripComboBox cmbFilterCategory;
        private System.Windows.Forms.DataGridView dgvProducts;

        // Suppliers Tab
        private System.Windows.Forms.TabPage tabSuppliers;
        private System.Windows.Forms.ToolStrip tsSuppliers;
        private System.Windows.Forms.ToolStripButton tsbAddSupplier;
        private System.Windows.Forms.ToolStripButton tsbEditSupplier;
        private System.Windows.Forms.ToolStripButton tsbDeleteSupplier;
        private System.Windows.Forms.ToolStripLabel lblSearchSupplier;
        private System.Windows.Forms.ToolStripTextBox txtSearchSupplier;
        private System.Windows.Forms.DataGridView dgvSuppliers;

        // Operations Tab
        private System.Windows.Forms.TabPage tabOperations;
        private System.Windows.Forms.SplitContainer splitContainerOperations;
        private System.Windows.Forms.ToolStrip tsOrders;
        private System.Windows.Forms.ToolStripButton tsbAddOrder;
        private System.Windows.Forms.ToolStripButton tsbEditOrder;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.ToolStrip tsMovements;
        private System.Windows.Forms.ToolStripButton tsbAddMovement;
        private System.Windows.Forms.ToolStripButton tsbEditMovement;
        private System.Windows.Forms.DataGridView dgvMovements;

        // Analytics Tab
        private System.Windows.Forms.TabPage tabAnalytics;
        private System.Windows.Forms.Panel pnlAnalyticsTop;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DataGridView dgvAnalytics;
    }
}