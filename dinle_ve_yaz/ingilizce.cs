using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dinle_ve_yaz
{
    public partial class ingilizce : Form
    {
        public ingilizce()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i_k ing_kolay = new i_k();
            ing_kolay.Show();
            this.Hide();
        }

        private void ingilizce_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i_o ing_orta = new i_o();
            ing_orta.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i_z ing_zor = new i_z();
            ing_zor.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
