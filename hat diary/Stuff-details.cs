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
    public partial class Stuff_details : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdbcs"].ConnectionString;
        public Stuff_details()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select image";
            ofd.Filter = "All image file *.*) | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(ofd.FileName);

            }
        }

        void BindGridGrive( string query = "select * from stuff_details")
        {
            SqlConnection con = new SqlConnection(cs);
           
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView1.RowTemplate.Height = 50;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into stuff_details values (@id,@name,@mobile,@salary,@picture)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@mobile", textBox3.Text);
            cmd.Parameters.AddWithValue("@salary", textBox4.Text);
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
            pictureBox3.Image = Properties.Resources.avatar;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            pictureBox3.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[4].Value);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update stuff_details set id=@id,name=@name,mobile=@mobile,salary=@salary,picture=@picture where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@mobile", textBox3.Text);
            cmd.Parameters.AddWithValue("@salary", textBox4.Text);
            cmd.Parameters.AddWithValue("@picture", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Data updated successfully!");
                BindGridGrive();
                Reset();


            }
            else
            {
                MessageBox.Show("data not updated");
            }
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from stuff_details  where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from stuff_details where id like '" + this.textBox5.Text + "%' ";
            this.BindGridGrive(query);
        }

        private void Stuff_details_Load(object sender, EventArgs e)
        {

        }
    }
}
