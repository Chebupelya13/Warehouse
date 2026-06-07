using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class ProductEditForm : Form
    {
        private int? _productId = null;

        public ProductEditForm(int? productId = null)
        {
            InitializeComponent();
            _productId = productId;

            LoadCategories();

            if (_productId.HasValue)
            {
                this.Text = "Редактирование товара";
                LoadProductData();
            }
            else
            {
                this.Text = "Добавление товара";
            }
        }

        private void LoadCategories()
        {
            string query = "SELECT DISTINCT Category FROM Products";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                cmbCategory.Items.Add(row["Category"].ToString());
            }
        }

        private void LoadProductData()
        {
            string query = "SELECT Name, Category, BasePrice FROM Products WHERE Id = @Id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@Id", _productId.Value));

            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                cmbCategory.Text = dt.Rows[0]["Category"].ToString();
                numBasePrice.Value = Convert.ToDecimal(dt.Rows[0]["BasePrice"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Заполните наименование и категорию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_productId.HasValue)
            {
                string query = "UPDATE Products SET Name = @Name, Category = @Category, BasePrice = @Price WHERE Id = @Id";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@Name", txtName.Text.Trim()),
                    new SqlParameter("@Category", cmbCategory.Text.Trim()),
                    new SqlParameter("@Price", numBasePrice.Value),
                    new SqlParameter("@Id", _productId.Value));
            }
            else
            {
                string query = "INSERT INTO Products (Name, Category, BasePrice) VALUES (@Name, @Category, @BasePrice)";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@Name", txtName.Text.Trim()),
                    new SqlParameter("@Category", cmbCategory.Text.Trim()),
                    new SqlParameter("@BasePrice", numBasePrice.Value));
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
