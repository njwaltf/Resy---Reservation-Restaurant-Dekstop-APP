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
    public partial class CreateReservation : Form
    {
        int tblNum;
        SqlConnection conn = new SqlConnection("Data Source=AWA-PC\\SQLEXPRESS;Initial Catalog=db_resy;Integrated Security=True");
        public CreateReservation()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void mj1_CheckedChanged(object sender, EventArgs e)
        {
            tblNum = 1;
        }

        private void mj2_CheckedChanged(object sender, EventArgs e)
        {
            tblNum = 2;
        }

        private void mj3_CheckedChanged(object sender, EventArgs e)
        {
            tblNum = 3;
        }

        private void mj4_CheckedChanged(object sender, EventArgs e)
        {
            tblNum = 4;
        }

        private void mj5_CheckedChanged(object sender, EventArgs e)
        {
            tblNum = 5;
        }

        private void mj6_CheckedChanged(object sender, EventArgs e)
        {
            tblNum = 6;
        }

        private void btnReserv_Click(object sender, EventArgs e)
        {
            conn.Open();
            DateTime date = DateTime.Now;
            string formatDate = date.ToString("yyyy-MM-dd");
            string status = "Belum Checkin";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO reservations (user_id,name,table_num,people,date,status) VALUES (@user_id,@name,@table_num,@people,@date,@status)";
            cmd.Parameters.Add("@user_id",SqlDbType.Int).Value = User.id;
            cmd.Parameters.Add("@name",SqlDbType.NVarChar).Value = txtNameRes.Text;
            cmd.Parameters.Add("@table_num",SqlDbType.Int).Value = tblNum;
            cmd.Parameters.Add("@people",SqlDbType.Decimal).Value = txtPeople.Value;
            cmd.Parameters.Add("@date",SqlDbType.NVarChar).Value = formatDate;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Reservasi berhasil dibuat!");
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
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
