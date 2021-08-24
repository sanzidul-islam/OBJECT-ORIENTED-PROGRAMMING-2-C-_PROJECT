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
    public partial class Buyer_dashboard : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cdbcs"].ConnectionString;
        public Buyer_dashboard()
        {
            InitializeComponent();
        }

        private void Buyer_dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_review r1 = new Add_review();
            r1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cusromer_help_center help = new Cusromer_help_center();
            help.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select image";
            ofd.Filter = "All image file *.*) | *.*";  //image select
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into customer_details values (@name,@mobile,@address,@amount,@date,@user,@pass,@picture)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@mobile", textBox2.Text);
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@amount", textBox4.Text);
            cmd.Parameters.AddWithValue("@date", textBox7.Text);
            cmd.Parameters.AddWithValue("@user", textBox5.Text);
            cmd.Parameters.AddWithValue("@pass", textBox6.Text);
            cmd.Parameters.AddWithValue("@picture",SavePhoto());
            con.Open();
            int a = cmd.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if(a>0)
            {
                MessageBox.Show("Data inserted successfully!");

            }
            else
            {
                MessageBox.Show("data not insert");
            }
            con.Close();

        }

        private byte[] SavePhoto() 
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        public object dateTimePiker1 { get; set; }
    }
}
