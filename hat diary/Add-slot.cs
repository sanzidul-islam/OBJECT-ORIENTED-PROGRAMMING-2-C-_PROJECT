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
    public partial class Add_slot : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cdbcs"].ConnectionString;
        public Add_slot()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into add_slot values (@s_number,@s_size,@cow_capacity,@slot_price,@slot_location,@picture)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@s_number", textBox1.Text);
            cmd.Parameters.AddWithValue("@s_size", textBox2.Text);
            cmd.Parameters.AddWithValue("@cow_capacity", textBox3.Text);
            cmd.Parameters.AddWithValue("@slot_price", textBox4.Text);
            cmd.Parameters.AddWithValue("@slot_location", textBox5.Text);
            cmd.Parameters.AddWithValue("@picture", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Data inserted successfully!");
                BindGridGrive();
                Reset();


            }
            else
            {
                MessageBox.Show("data not insert");
            }
            con.Close();

        }
        private byte[] SavePhoto()
        {
            //  throw new NotImplementedException();
            MemoryStream ms = new MemoryStream();
            pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
            // pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
            return ms.GetBuffer();
        }
        void Reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            pictureBox3.Image = Properties.Resources.avatar;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        void BindGridGrive(string query = "select * from add_slot")
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from add_slot where s_number like '" + this.textBox6
                .Text + "%' ";
            this.BindGridGrive(query);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select image";
            ofd.Filter = "All image file *.*) | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(ofd.FileName);

            }

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox3.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "update add_slot set s_number=@s_number,s_size=@s_size,cow_capacity=@cow_capacity,slot_price=@slot_price,slot_location=@slot_location,picture=@picture where  s_number=@s_number";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@s_number", textBox1.Text);
            cmd.Parameters.AddWithValue("@s_size", textBox2.Text);
            cmd.Parameters.AddWithValue("@cow_capacity", textBox3.Text);
            cmd.Parameters.AddWithValue("@slot_price", textBox4.Text);
            cmd.Parameters.AddWithValue("@slot_location", textBox5.Text);
            cmd.Parameters.AddWithValue("@picture", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Data updateed successfully!");
                BindGridGrive();
                Reset();


            }
            else
            {
                MessageBox.Show("data not update");
            }
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from add_slot  where s_number=@s_number";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@s_number", textBox1.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Data delete successfully!");
                BindGridGrive();
                Reset();


            }
            else
            {
                MessageBox.Show("data not delete");
            }
            con.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Admin_dashboard ad = new Admin_dashboard();
            ad.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
