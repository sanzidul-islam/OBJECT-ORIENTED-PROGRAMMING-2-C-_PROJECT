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
    public partial class Seller_dashboard : Form
    {
        public Seller_dashboard()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cart c1 = new Cart();
            c1.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Buy_slot bs = new Buy_slot();
            bs.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Seller_input_animal sell = new Seller_input_animal();
            sell.Show();
            this.Hide();
        }
    }
}
