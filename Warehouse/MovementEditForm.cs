using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class MovementEditForm : Form
    {
        private int _orderId;
        private int? _movementId = null;

        public MovementEditForm(int orderId, int? movementId = null)
        {
            InitializeComponent();
            _orderId = orderId;
            _movementId = movementId;

            LoadProducts();
            LoadStorageCells();

            if (_movementId.HasValue)
            {
                this.Text = "Редактирование движения";
                LoadMovementData();
            }
            else
            {
                this.Text = "Добавление движения";
                dtpMovementDate.Value = DateTime.Now;
                cmbMovementType.SelectedIndex = 0;
            }

            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;
            numQuantity.ValueChanged += UpdateTotalCost;
        }

        private void LoadProducts()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT Id, Name, BasePrice FROM Products");
            cmbProduct.DataSource = dt;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";
        }

        private void LoadStorageCells()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT Id, Name FROM StorageCells");
            cmbCell.DataSource = dt;
            cmbCell.DisplayMember = "Name";
            cmbCell.ValueMember = "Id";
        }

        private void LoadMovementData()
        {
            string query = "SELECT ProductId, CellId, MovementType, Quantity, MovementDate FROM Movements WHERE Id = @Id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@Id", _movementId.Value));

            if (dt.Rows.Count > 0)
            {
                cmbProduct.SelectedValue = dt.Rows[0]["ProductId"];
                cmbCell.SelectedValue = dt.Rows[0]["CellId"];
                cmbMovementType.Text = dt.Rows[0]["MovementType"].ToString();
                numQuantity.Value = Convert.ToInt32(dt.Rows[0]["Quantity"]);
                dtpMovementDate.Value = Convert.ToDateTime(dt.Rows[0]["MovementDate"]);
            }
        }

        private void CmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalCost(null, null);
        }

        private void UpdateTotalCost(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem != null)
            {
                DataRowView row = cmbProduct.SelectedItem as DataRowView;
                if (row != null)
                {
                    decimal price = Convert.ToDecimal(row["BasePrice"]);
                    int quantity = (int)numQuantity.Value;
                    txtTotalCost.Text = (price * quantity).ToString("0.00");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null || cmbCell.SelectedValue == null || string.IsNullOrEmpty(cmbMovementType.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_movementId.HasValue)
            {
                string query = "UPDATE Movements SET ProductId = @ProductId, CellId = @CellId, MovementType = @MovementType, Quantity = @Quantity, TotalCost = @TotalCost, MovementDate = @MovementDate WHERE Id = @Id";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@ProductId", cmbProduct.SelectedValue),
                    new SqlParameter("@CellId", cmbCell.SelectedValue),
                    new SqlParameter("@MovementType", cmbMovementType.Text),
                    new SqlParameter("@Quantity", numQuantity.Value),
                    new SqlParameter("@TotalCost", Convert.ToDecimal(txtTotalCost.Text)),
                    new SqlParameter("@MovementDate", dtpMovementDate.Value),
                    new SqlParameter("@Id", _movementId.Value));
            }
            else
            {
                string query = "INSERT INTO Movements (ProductId, CellId, OrderId, MovementType, Quantity, TotalCost, MovementDate) VALUES (@ProductId, @CellId, @OrderId, @MovementType, @Quantity, @TotalCost, @MovementDate)";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@ProductId", cmbProduct.SelectedValue),
                    new SqlParameter("@CellId", cmbCell.SelectedValue),
                    new SqlParameter("@OrderId", _orderId),
                    new SqlParameter("@MovementType", cmbMovementType.Text),
                    new SqlParameter("@Quantity", numQuantity.Value),
                    new SqlParameter("@TotalCost", Convert.ToDecimal(txtTotalCost.Text)),
                    new SqlParameter("@MovementDate", dtpMovementDate.Value));
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
