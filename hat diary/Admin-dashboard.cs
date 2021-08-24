using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hat_diary
{
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin_show_buyee_details abd = new Admin_show_buyee_details();
            abd.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Stuff_details sd = new Stuff_details();
            sd.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Transection t1 = new Transection();
            t1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Add_slot add = new Add_slot();
            add.Show();
            this.Hide();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Lock_slot ac = new Lock_slot();
            ac.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Admin_show_seller_details ad = new Admin_show_seller_details();
            ad.Show();
            this.Hide();
        }
    }
}
