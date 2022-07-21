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
    public partial class Admin_alman_ekstra : Form
    {
        public Admin_alman_ekstra()
        {
            InitializeComponent();
        }
        MySqlConnection sqlconnect = new MySqlConnection(veriyolu.sqlconnection);
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Admin_alman_ekstra_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Users\\Casper\\Desktop\\dinle_ve_yaz\\dinle_ve_yaz\\bin\\Debug\\Almanca\\Cümleler";
            openFileDialog2.InitialDirectory = "C:\\Users\\Casper\\Desktop\\dinle_ve_yaz\\dinle_ve_yaz\\bin\\Debug\\İngilizce\\Cümleler";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Boş Alanları Dikkatli Bir Şekilde Doldurunuz");
            }
            else
            {
                try
                {
                    if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                    {
                        MySqlCommand almcumle = new MySqlCommand("insert into ekstra_a (ses_dosyasi , yazilisi) values (@s,@y)", sqlconnect);
                        almcumle.Parameters.AddWithValue("@s", textBox1.Text);
                        almcumle.Parameters.AddWithValue("@y", textBox2.Text);
                        sqlconnect.Open();
                        almcumle.ExecuteNonQuery();
                        sqlconnect.Close();
                        MessageBox.Show("Veri Kaydınız Basarı ile sonuçlanmıştır");
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bağlantınızı Kontrol Ediniz");
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Boş Alanları Dikkatli Bir Şekilde Doldurunuz");
            }
            else
            {
                try
                {
                    if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                    {
                        MySqlCommand ingcumle = new MySqlCommand("insert into ekstra_i (ses_dosyasi , yazilisi) values (@s,@y)", sqlconnect);
                        ingcumle.Parameters.AddWithValue("@s", textBox3.Text);
                        ingcumle.Parameters.AddWithValue("@y", textBox4.Text);
                        sqlconnect.Open();
                        ingcumle.ExecuteNonQuery();
                        sqlconnect.Close();
                        MessageBox.Show("Veri Kaydınız Basarı ile sonuçlanmıştır");
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bağlantınızı Kontrol Ediniz");
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Admin_alman_ekstra_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
