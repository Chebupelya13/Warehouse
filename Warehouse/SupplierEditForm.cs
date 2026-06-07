using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class SupplierEditForm : Form
    {
        private int? _supplierId = null;

        public SupplierEditForm(int? supplierId = null)
        {
            InitializeComponent();
            _supplierId = supplierId;

            if (_supplierId.HasValue)
            {
                this.Text = "Редактирование контрагента";
                LoadSupplierData();
            }
            else
            {
                this.Text = "Добавление контрагента";
            }
        }

        private void LoadSupplierData()
        {
            string query = "SELECT Name, ContactInfo, Address FROM Suppliers WHERE Id = @Id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@Id", _supplierId.Value));

            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtContactInfo.Text = dt.Rows[0]["ContactInfo"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Заполните наименование.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_supplierId.HasValue)
            {
                string query = "UPDATE Suppliers SET Name = @Name, ContactInfo = @ContactInfo, Address = @Address WHERE Id = @Id";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@Name", txtName.Text.Trim()),
                    new SqlParameter("@ContactInfo", txtContactInfo.Text.Trim()),
                    new SqlParameter("@Address", txtAddress.Text.Trim()),
                    new SqlParameter("@Id", _supplierId.Value));
            }
            else
            {
                string query = "INSERT INTO Suppliers (Name, ContactInfo, Address) VALUES (@Name, @ContactInfo, @Address)";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@Name", txtName.Text.Trim()),
                    new SqlParameter("@ContactInfo", txtContactInfo.Text.Trim()),
                    new SqlParameter("@Address", txtAddress.Text.Trim()));
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
