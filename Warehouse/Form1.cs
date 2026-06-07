using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class Form1 : Form
    {
        private DataTable dtProducts;
        private DataView dvProducts;

        private DataTable dtSuppliers;
        private DataView dvSuppliers;

        public Form1()
        {
            InitializeComponent();
            ApplyRoleBasedAccessControl();
            LoadData();

            // Setup Events
            txtSearchProduct.TextChanged += TxtSearchProduct_TextChanged;
            cmbFilterCategory.SelectedIndexChanged += CmbFilterCategory_SelectedIndexChanged;
            tsbAddProduct.Click += TsbAddProduct_Click;
            tsbEditProduct.Click += TsbEditProduct_Click;
            tsbDeleteProduct.Click += TsbDeleteProduct_Click;

            txtSearchSupplier.TextChanged += TxtSearchSupplier_TextChanged;
            tsbAddSupplier.Click += TsbAddSupplier_Click;
            tsbEditSupplier.Click += TsbEditSupplier_Click;
            tsbDeleteSupplier.Click += TsbDeleteSupplier_Click;
        }

        private void ApplyRoleBasedAccessControl()
        {
            this.Text = $"Система управления складом - {CurrentUser.Login} ({CurrentUser.Role})";

            if (CurrentUser.IsStorekeeper)
            {
                tsbDeleteProduct.Visible = false;
                tsbDeleteSupplier.Visible = false;
                tabControlMain.TabPages.Remove(tabAnalytics);
            }
        }

        private void LoadData()
        {
            LoadProducts();
            LoadSuppliers();
            LoadOrders();

            if (!CurrentUser.IsStorekeeper)
            {
                cmbReportType.SelectedIndexChanged += CmbReportType_SelectedIndexChanged;
                btnGenerateReport.Click += BtnGenerateReport_Click;
                cmbReportType.SelectedIndex = 0; // Trigger default report
            }
        }

        #region Analytics
        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReport = cmbReportType.SelectedItem.ToString();
            bool showDates = (selectedReport == "Аудит транзакций");

            dtpStartDate.Visible = showDates;
            dtpEndDate.Visible = showDates;
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null) return;

            string selectedReport = cmbReportType.SelectedItem.ToString();
            DataTable dtReport = null;

            try
            {
                switch (selectedReport)
                {
                    case "Динамические остатки":
                        dtReport = DatabaseHelper.ExecuteQuery(@"
                            SELECT p.Name AS Товар, p.Category AS Категория,
                                   SUM(CASE WHEN m.MovementType = 'Поступление' THEN m.Quantity ELSE -m.Quantity END) AS Остаток
                            FROM Movements m
                            JOIN Products p ON m.ProductId = p.Id
                            GROUP BY p.Name, p.Category");
                        break;
                    case "Реестр контрагентов":
                        dtReport = DatabaseHelper.ExecuteQuery("SELECT Name AS Наименование, ContactInfo AS Контакты, Address AS Адрес FROM Suppliers");
                        break;
                    case "Аудит транзакций":
                        dtReport = DatabaseHelper.ExecuteQuery(@"
                            SELECT p.Name AS Товар, m.MovementType AS [Тип движения], m.Quantity AS Количество, m.MovementDate AS Дата
                            FROM Movements m
                            JOIN Products p ON m.ProductId = p.Id
                            WHERE m.MovementDate >= @StartDate AND m.MovementDate <= @EndDate
                            ORDER BY m.MovementDate DESC",
                            new SqlParameter("@StartDate", dtpStartDate.Value.Date),
                            new SqlParameter("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1)));
                        break;
                    case "Топология запасов":
                        dtReport = DatabaseHelper.ExecuteQuery(@"
                            SELECT c.Name AS Ячейка, p.Name AS Товар,
                                   SUM(CASE WHEN m.MovementType = 'Поступление' THEN m.Quantity ELSE -m.Quantity END) AS Остаток
                            FROM Movements m
                            JOIN StorageCells c ON m.CellId = c.Id
                            JOIN Products p ON m.ProductId = p.Id
                            GROUP BY c.Name, p.Name
                            HAVING SUM(CASE WHEN m.MovementType = 'Поступление' THEN m.Quantity ELSE -m.Quantity END) > 0");
                        break;
                    case "Финансовая аналитика оборота":
                        dtReport = DatabaseHelper.ExecuteQuery(@"
                            SELECT p.Category AS Категория, SUM(m.TotalCost) AS [Замороженный капитал]
                            FROM Movements m
                            JOIN Products p ON m.ProductId = p.Id
                            WHERE m.MovementType = 'Поступление'
                            GROUP BY p.Category");
                        break;
                }

                dgvAnalytics.DataSource = dtReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при формировании отчета: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Operations (Orders & Movements)
        private void LoadOrders()
        {
            string query = "SELECT o.Id, s.Name AS SupplierName, o.OrderDate, o.Status " +
                           "FROM Orders o LEFT JOIN Suppliers s ON o.SupplierId = s.Id";
            DataTable dtOrders = DatabaseHelper.ExecuteQuery(query);
            dgvOrders.DataSource = dtOrders;

            dgvOrders.Columns["Id"].Visible = false;
            dgvOrders.Columns["SupplierName"].HeaderText = "Контрагент";
            dgvOrders.Columns["OrderDate"].HeaderText = "Дата заказа";
            dgvOrders.Columns["Status"].HeaderText = "Статус";

            dgvOrders.SelectionChanged -= DgvOrders_SelectionChanged;
            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;

            if (dgvOrders.Rows.Count > 0)
            {
                dgvOrders.Rows[0].Selected = true;
                LoadMovements(Convert.ToInt32(dgvOrders.Rows[0].Cells["Id"].Value));
            }
            else
            {
                dgvMovements.DataSource = null;
            }

            tsbAddOrder.Click -= TsbAddOrder_Click;
            tsbAddOrder.Click += TsbAddOrder_Click;
            tsbEditOrder.Click -= TsbEditOrder_Click;
            tsbEditOrder.Click += TsbEditOrder_Click;

            tsbAddMovement.Click -= TsbAddMovement_Click;
            tsbAddMovement.Click += TsbAddMovement_Click;
            tsbEditMovement.Click -= TsbEditMovement_Click;
            tsbEditMovement.Click += TsbEditMovement_Click;
        }

        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
                LoadMovements(orderId);
            }
        }

        private void LoadMovements(int orderId)
        {
            string query = "SELECT m.Id, p.Name AS ProductName, c.Name AS CellName, m.MovementType, m.Quantity, m.TotalCost, m.MovementDate " +
                           "FROM Movements m " +
                           "JOIN Products p ON m.ProductId = p.Id " +
                           "JOIN StorageCells c ON m.CellId = c.Id " +
                           "WHERE m.OrderId = @OrderId";
            DataTable dtMovements = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@OrderId", orderId));
            dgvMovements.DataSource = dtMovements;

            dgvMovements.Columns["Id"].Visible = false;
            dgvMovements.Columns["ProductName"].HeaderText = "Товар";
            dgvMovements.Columns["CellName"].HeaderText = "Ячейка";
            dgvMovements.Columns["MovementType"].HeaderText = "Тип движения";
            dgvMovements.Columns["Quantity"].HeaderText = "Количество";
            dgvMovements.Columns["TotalCost"].HeaderText = "Сумма";
            dgvMovements.Columns["MovementDate"].HeaderText = "Дата";
        }

        private void TsbAddOrder_Click(object sender, EventArgs e)
        {
            using (OrderEditForm form = new OrderEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOrders();
                }
            }
        }

        private void TsbEditOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
                using (OrderEditForm form = new OrderEditForm(id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TsbAddMovement_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
                using (MovementEditForm form = new MovementEditForm(orderId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadMovements(orderId);
                    }
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите или создайте заказ.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TsbEditMovement_Click(object sender, EventArgs e)
        {
            if (dgvMovements.SelectedRows.Count > 0 && dgvOrders.SelectedRows.Count > 0)
            {
                int movementId = Convert.ToInt32(dgvMovements.SelectedRows[0].Cells["Id"].Value);
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
                using (MovementEditForm form = new MovementEditForm(orderId, movementId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadMovements(orderId);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите позицию движения для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Products
        private void LoadProducts()
        {
            string query = "SELECT Id, Name, Category, BasePrice FROM Products";
            dtProducts = DatabaseHelper.ExecuteQuery(query);
            dvProducts = new DataView(dtProducts);
            dgvProducts.DataSource = dvProducts;

            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["Name"].HeaderText = "Наименование";
            dgvProducts.Columns["Category"].HeaderText = "Категория";
            dgvProducts.Columns["BasePrice"].HeaderText = "Базовая цена";

            UpdateCategoryFilter();
        }

        private void UpdateCategoryFilter()
        {
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("Все");

            string query = "SELECT DISTINCT Category FROM Products";
            DataTable dtCategories = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dtCategories.Rows)
            {
                cmbFilterCategory.Items.Add(row["Category"].ToString());
            }
            if (cmbFilterCategory.Items.Count > 0)
                cmbFilterCategory.SelectedIndex = 0;
        }

        private void FilterProducts()
        {
            string search = txtSearchProduct.Text.Trim().Replace("'", "''");
            string category = cmbFilterCategory.SelectedItem?.ToString();

            string filter = "";
            if (!string.IsNullOrEmpty(search))
            {
                filter += $"Name LIKE '%{search}%'";
            }

            if (category != "Все" && !string.IsNullOrEmpty(category))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += $"Category = '{category.Replace("'", "''")}'";
            }

            dvProducts.RowFilter = filter;
        }

        private void TxtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void CmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void TsbAddProduct_Click(object sender, EventArgs e)
        {
            using (ProductEditForm form = new ProductEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void TsbEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                using (ProductEditForm form = new ProductEditForm(id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TsbDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить выбранный товар?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery("DELETE FROM Products WHERE Id = @Id", new SqlParameter("@Id", id));
                        LoadProducts();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Удаление невозможно: объект участвует в складских операциях.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Suppliers
        private void LoadSuppliers()
        {
            string query = "SELECT Id, Name, ContactInfo, Address FROM Suppliers";
            dtSuppliers = DatabaseHelper.ExecuteQuery(query);
            dvSuppliers = new DataView(dtSuppliers);
            dgvSuppliers.DataSource = dvSuppliers;

            dgvSuppliers.Columns["Id"].Visible = false;
            dgvSuppliers.Columns["Name"].HeaderText = "Наименование";
            dgvSuppliers.Columns["ContactInfo"].HeaderText = "Контактная информация";
            dgvSuppliers.Columns["Address"].HeaderText = "Адрес";
        }

        private void TxtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchSupplier.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(search))
            {
                dvSuppliers.RowFilter = $"Name LIKE '%{search}%'";
            }
            else
            {
                dvSuppliers.RowFilter = "";
            }
        }

        private void TsbAddSupplier_Click(object sender, EventArgs e)
        {
            using (SupplierEditForm form = new SupplierEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSuppliers();
                }
            }
        }

        private void TsbEditSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSuppliers.SelectedRows[0].Cells["Id"].Value);
                using (SupplierEditForm form = new SupplierEditForm(id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadSuppliers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите контрагента для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TsbDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить выбранного контрагента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvSuppliers.SelectedRows[0].Cells["Id"].Value);
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery("DELETE FROM Suppliers WHERE Id = @Id", new SqlParameter("@Id", id));
                        LoadSuppliers();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Удаление невозможно: объект участвует в складских операциях.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите контрагента для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
