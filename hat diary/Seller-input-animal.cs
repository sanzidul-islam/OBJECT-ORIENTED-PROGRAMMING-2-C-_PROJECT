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
    public partial class Seller_input_animal : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdbcs"].ConnectionString;
        public Seller_input_animal()
        {
            InitializeComponent();
        }

        private void Seller_input_animal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into seller_details values (@seller_name,@number,@location,@animal_type,@animal_quantity)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@seller_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@number", textBox2.Text);
            cmd.Parameters.AddWithValue("@location", textBox3.Text);
            cmd.Parameters.AddWithValue("@animal_type", textBox4.Text);
            cmd.Parameters.AddWithValue("@animal_quantity", textBox5.Text);
           
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Seller_dashboard se = new Seller_dashboard();
            se.Show();
            this.Hide();
        }
    }
}
