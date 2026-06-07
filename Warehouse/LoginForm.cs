using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string passwordHash = DatabaseHelper.HashPassword(password);
            string query = "SELECT Role, Id FROM Users WHERE Login = @Login AND PasswordHash = @ComputedHash";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Login", login),
                new SqlParameter("@ComputedHash", passwordHash)
            };

            try
            {
                DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    CurrentUser.Id = Convert.ToInt32(result.Rows[0]["Id"]);
                    CurrentUser.Login = login;
                    CurrentUser.Role = result.Rows[0]["Role"].ToString();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
