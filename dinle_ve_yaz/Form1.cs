using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dinle_ve_yaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ingilizce ing = new ingilizce();
            ing.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Almanca alm = new Almanca();
            alm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ekstra eks = new Ekstra();
            eks.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Girisi a_giris = new Admin_Girisi();
            a_giris.Show();
            this.Hide();
        }
    }
}
