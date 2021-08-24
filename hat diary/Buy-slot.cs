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
    public partial class Buy_slot : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cdbcs"].ConnectionString;
        public Buy_slot()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void Buy_slot_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into card_slot values (@s_number,@s_size,@cow_capacity,@slot_price,@slot_location,@picture,@sell_name)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@s_number", textBox1.Text);
            cmd.Parameters.AddWithValue("@s_size", textBox2.Text);
            cmd.Parameters.AddWithValue("@cow_capacity", textBox3.Text);
            cmd.Parameters.AddWithValue("@slot_price", textBox4.Text);
            cmd.Parameters.AddWithValue("@slot_location", textBox5.Text);
            cmd.Parameters.AddWithValue("@picture", SavePhoto());
            cmd.Parameters.AddWithValue("@sell_name", textBox6.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Please confirm!");
                BindGridGrive();
               // Reset();


            }
            else
            {
                MessageBox.Show("cart not insert");
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

        private void button2_Click(object sender, EventArgs e)
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
                MessageBox.Show("successfully added");
                BindGridGrive();
               // Reset();


            }
            else
            {
                MessageBox.Show(" not ");
            }
            con.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Seller_dashboard s2 = new Seller_dashboard();
            s2.Show();
            this.Hide();

        }
        
    }
}
