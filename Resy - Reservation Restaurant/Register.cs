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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Resy___Reservation_Restaurant
{
    public partial class frmRegister : Form
    {
        public string conn = "Data Source=AWA-PC\\SQLEXPRESS;Initial Catalog=db_resy;Integrated Security=True";
        public bool emailExist,usernameExist;
        public frmRegister()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void masukLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        //show password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (chkShowPW.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                
            }
        }

        static bool CheckIfEmailExists(string connectionString, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE email = @email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        static bool CheckIfUsernameExists(string connectionString, string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        //Regis
        private void btnRegis_Click(object sender, EventArgs e)
        {
            CreateAcc();   
        }

        public void CreateAcc()
        {
            if (txtUsername.Text == "" && txtEmail.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data anda!", "Daftar Gagal");
            }
            else if (usernameExist = CheckIfUsernameExists(this.conn, txtUsername.Text))
            {
                MessageBox.Show("Username telah digunakan!");
            }
            else if (emailExist = CheckIfEmailExists(this.conn, txtEmail.Text))
            {
                MessageBox.Show("Email telah digunakan!");
            }
            else
            {
                using (var connection = new SqlConnection(this.conn))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO users (username,email,password) VALUES(@username,@email,@password)";
                        command.Parameters.Add("@username", SqlDbType.NVarChar).Value = txtUsername.Text;
                        command.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword.Text;
                        command.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Akun berhasil dibuat!, Silahkan masuk terlebih dahulu");
                        this.Hide();
                        Login login = new Login();
                        login.Show();
                    }
            }
        }
    }
}
