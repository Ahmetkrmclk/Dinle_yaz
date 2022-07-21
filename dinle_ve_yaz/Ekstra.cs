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
    public partial class Ekstra : Form
    {
        public Ekstra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Eksta_i i = new Eksta_i();
            i.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ekstra_a alek = new Ekstra_a();
            alek.Show();
            this.Hide();
        }

        private void Ekstra_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
