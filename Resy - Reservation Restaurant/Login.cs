using Resy___Reservation_Restaurant.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Resy___Reservation_Restaurant
{
    public partial class Login : Form
    {
        public string conn = "Data Source=AWA-PC\\SQLEXPRESS;Initial Catalog=db_resy;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            this.Hide();
            frmRegister.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;

            }
        }
        private bool SignIn()
        {
            using (SqlConnection connection = new SqlConnection(this.conn))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SignIn();
            if (SignIn() == true)
            {
                MessageBox.Show("Berhasil Masuk!","Login Sukses",MessageBoxButtons.OK,MessageBoxIcon.Information);
                User.username = txtUsername.Text;
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Login Gagal!");
            }
        }
    }
}
