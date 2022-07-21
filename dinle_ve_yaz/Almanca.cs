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
    public partial class Almanca : Form
    {
        public Almanca()
        {
            InitializeComponent();
        }

        private void Almanca_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alm_k almancaKolay = new alm_k();
            almancaKolay.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Alm_o almanca_orta = new Alm_o();
            almanca_orta.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alm_z almanca_zor = new Alm_z();
            almanca_zor.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
