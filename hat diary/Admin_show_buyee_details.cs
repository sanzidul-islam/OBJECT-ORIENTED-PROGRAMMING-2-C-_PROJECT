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
    public partial class Admin_show_buyee_details : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cdbcs"].ConnectionString;
       
        public Admin_show_buyee_details()
        {
            InitializeComponent();
            BindGridGrive();
            
        }

        private void Admin_show_buyee_details_Load(object sender, EventArgs e)
        {
          

        }
        void BindGridGrive()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from customer_details";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView1.RowTemplate.Height = 50;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Admin_dashboard ad = new Admin_dashboard();
            ad.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_show_review r1 = new Admin_show_review();
            r1.Show();
            this.Hide();
        }

    }
}
