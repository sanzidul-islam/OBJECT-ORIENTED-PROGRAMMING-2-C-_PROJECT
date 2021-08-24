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
    public partial class Add_review : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cdbcs"].ConnectionString;
        public Add_review()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Buyer_dashboard b1 = new Buyer_dashboard();
            b1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into customer_comments values (@comment)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@comment", textBox1.Text);
            
            con.Open();
            int a = cmd.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Data inserted successfully!");

            }
            else
            {
                MessageBox.Show("data not insert");
            }
            con.Close();
        }

        private void Add_review_Load(object sender, EventArgs e)
        {

        }
    }
}
