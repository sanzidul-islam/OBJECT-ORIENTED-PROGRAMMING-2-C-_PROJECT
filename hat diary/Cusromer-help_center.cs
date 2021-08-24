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
    public partial class Cusromer_help_center : Form
    {
        public Cusromer_help_center()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Buyer_dashboard b1 = new Buyer_dashboard();
            b1.Show();
            this.Hide();
        }
    }
}
