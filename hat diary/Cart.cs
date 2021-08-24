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
    public partial class Cart : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cdbcs"].ConnectionString;
        public Cart()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void Cart_Load(object sender, EventArgs e)
        {

        }
        void BindGridGrive(string query = "select * from card_slot")
        {
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView1.RowTemplate.Height = 50;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Seller_dashboard s1 = new Seller_dashboard();
            s1.Show();
            this.Hide();
        }
    }
}
