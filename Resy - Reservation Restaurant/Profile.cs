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

namespace Resy___Reservation_Restaurant
{
    public partial class Profile : Form
    {
        string conS = "Data Source=AWA-PC\\SQLEXPRESS;Initial Catalog=db_resy;Integrated Security=True";
        SqlConnection conn = new SqlConnection("Data Source=AWA-PC\\SQLEXPRESS;Initial Catalog=db_resy;Integrated Security=True");
        bool usernameExist, emalExist;
        public Profile()
        {
            InitializeComponent();
            getAllUserData();
            //txtUsername.Text = User.id.ToString();
        }
        private void getAllUserData()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT username,name,email FROM users WHERE id = @id";
            cmd.Parameters.Add("@id",SqlDbType.Int).Value = User.id;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtUsername.Text = dr[0].ToString();
                txtName.Text = dr[1].ToString();
                txtEmail.Text = dr[2].ToString();
            }
            else
            {
                txtUsername.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateReservation createReservation = new CreateReservation();
            createReservation.Show();
            this.Close();
        }

        private void btnEditProf_Click(object sender, EventArgs e)
        {
            updateProfile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void updateProfile()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nama tidak boleh kosong");
            }else if(txtEmail.Text == "")
            {
                MessageBox.Show("Email tidak boleh kosong");
            }else if (txtUsername.Text == "")
            {
                MessageBox.Show("Username tidak boleh kosong");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [users] SET name = @name,username = @username,email = @email WHERE id = @id";
                cmd.Parameters.Add("@username",SqlDbType.NVarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@id",SqlDbType.Int).Value = User.id;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Profil berhasil diupdate!");
                getAllUserData();
            }
        }
    }
}
