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

namespace hat_diary
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "enter your name");

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "select * from login_tbl where username=@user and pass =@pass and category=@category";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                cmd.Parameters.AddWithValue("@category", comboBox1.SelectedItem.ToString());

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (comboBox1.SelectedItem.ToString() == "Admin")
                    {
                        MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        Admin_dashboard ad = new Admin_dashboard();
                        ad.Show();
                        this.Hide();
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Seller")
                    {
                        MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        Seller_dashboard mn = new Seller_dashboard();
                         mn.Show();
                        this.Hide();
                    }
                     //con.Close();



                }
                else
                {
                    MessageBox.Show("Login field", "failed", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
               
            }
            
        }
    

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "enter your Passward");

            }
            else
            {
                errorProvider2.Clear();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           bool status = checkBox1.Checked;
            switch(status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Buyer_dashboard b1 = new Buyer_dashboard();
            b1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            About_us a1 = new About_us();
            a1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
