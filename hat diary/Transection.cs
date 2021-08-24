using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace hat_diary
{
    public partial class Transection : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cdbcs"].ConnectionString;
        public Transection()
        {
            InitializeComponent();
            BindGridGrive();
            BindGridGrived();
        }

        void BindGridGrive()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select name, mobile, amount from customer_details";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView1.RowTemplate.Height = 50;

        }
        void BindGridGrived()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select sum(amount) as total_amount from customer_details";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView2.DataSource = data;
            //Autosize column
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView2.RowTemplate.Height = 30;

        }

        private void Transection_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Admin_dashboard ad = new Admin_dashboard();
            ad.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
