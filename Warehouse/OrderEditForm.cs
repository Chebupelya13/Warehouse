using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class OrderEditForm : Form
    {
        private int? _orderId = null;

        public OrderEditForm(int? orderId = null)
        {
            InitializeComponent();
            _orderId = orderId;

            LoadSuppliers();

            if (_orderId.HasValue)
            {
                this.Text = "Редактирование заказа";
                LoadOrderData();
            }
            else
            {
                this.Text = "Создание заказа";
                dtpOrderDate.Value = DateTime.Now;
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void LoadSuppliers()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT Id, Name FROM Suppliers");
            cmbSupplier.DataSource = dt;
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Id";
        }

        private void LoadOrderData()
        {
            string query = "SELECT SupplierId, OrderDate, Status FROM Orders WHERE Id = @Id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@Id", _orderId.Value));

            if (dt.Rows.Count > 0)
            {
                cmbSupplier.SelectedValue = dt.Rows[0]["SupplierId"];
                dtpOrderDate.Value = Convert.ToDateTime(dt.Rows[0]["OrderDate"]);
                cmbStatus.Text = dt.Rows[0]["Status"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedValue == null || string.IsNullOrEmpty(cmbStatus.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_orderId.HasValue)
            {
                string query = "UPDATE Orders SET SupplierId = @SupplierId, OrderDate = @OrderDate, Status = @Status WHERE Id = @Id";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@SupplierId", cmbSupplier.SelectedValue),
                    new SqlParameter("@OrderDate", dtpOrderDate.Value),
                    new SqlParameter("@Status", cmbStatus.Text),
                    new SqlParameter("@Id", _orderId.Value));
            }
            else
            {
                string query = "INSERT INTO Orders (SupplierId, OrderDate, Status) VALUES (@SupplierId, @OrderDate, @Status)";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@SupplierId", cmbSupplier.SelectedValue),
                    new SqlParameter("@OrderDate", dtpOrderDate.Value),
                    new SqlParameter("@Status", cmbStatus.Text));
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
