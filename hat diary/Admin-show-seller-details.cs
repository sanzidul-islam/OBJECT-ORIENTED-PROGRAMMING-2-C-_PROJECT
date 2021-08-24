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
    public partial class Admin_show_seller_details : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdbcs"].ConnectionString;
        public Admin_show_seller_details()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void Admin_show_seller_details_Load(object sender, EventArgs e)
        {

        }
        void BindGridGrive()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from seller_details";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image column
            //DataGridViewImageColumn dgv = new DataGridViewImageColumn();
           // dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
           // dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView1.RowTemplate.Height = 50;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Admin_dashboard mw = new Admin_dashboard();
            mw.Show();
            this.Hide();
        }
    }
}
