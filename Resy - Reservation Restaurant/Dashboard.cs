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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Resy___Reservation_Restaurant
{
    public partial class Dashboard : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=AWA-PC\\SQLEXPRESS;Initial Catalog=db_resy;Integrated Security=True");
        public Dashboard()
        {
            InitializeComponent();
            label1.Text = User.username;
            DateTime dateTime = DateTime.Now;
            string formatDate = dateTime.ToString("dd MMMM yyyy");
            date.Text = formatDate;
            display_data();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            GetUserID();
            label1.Text = User.username;
            display_data();
            if (dtReser.Rows.Count < 2)
            {
                dtReser.Visible = false;
                emptyImage.Visible = true;
                emptyStatement.Visible = true;
                txtSearch.Visible = false;
                btnSearch.Visible = false;
                label3.Visible = false;
                pictureBox3.Visible = false;
            }


        }

        private void GetUserID() 
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT id FROM [users] WHERE username = '" + User.username + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User.id = (int)reader[0];
            }
            conn.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void display_data()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT table_num,name,people,date,status FROM [reservations] WHERE user_id = @id";
            cmd.Parameters.Add("@id",SqlDbType.Int).Value = User.id;
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            dta.Fill(dt);
            dtReser.DataSource = dt;
            dtReser.Columns[0].HeaderText = "No Meja";
            dtReser.Columns[1].HeaderText = "Atas Nama";
            dtReser.Columns[2].HeaderText = "Jumlah Orang";
            dtReser.Columns[3].HeaderText = "Tanggal Checkin";
            dtReser.Columns[4].HeaderText = "Status Reservasi";
            conn.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            display_data();
            txtSearch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text.Length > 0)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT table_num,name,people,date,status FROM [reservations] WHERE user_id = @id AND table_num = @table_num";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = User.id;
                cmd.Parameters.Add("@table_num", SqlDbType.Int).Value = txtSearch.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(cmd);
                dta.Fill(dt);
                dtReser.DataSource = dt;
                dtReser.Columns[0].HeaderText = "No Meja";
                dtReser.Columns[1].HeaderText = "Atas Nama";
                dtReser.Columns[2].HeaderText = "Jumlah Orang";
                dtReser.Columns[3].HeaderText = "Tanggal Checkin";
                dtReser.Columns[4].HeaderText = "Status Reservasi";
                conn.Close();
            }
            else
            {
                display_data();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateReservation createReservation = new CreateReservation();
            createReservation.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateReservation createReservation = new CreateReservation();
            createReservation.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }
    }
}
