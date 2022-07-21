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
    public partial class Admin_Girisi : Form
    {
        public Admin_Girisi()
        {
            InitializeComponent();
        }
        MySqlConnection sqlconnect = new MySqlConnection(veriyolu.sqlconnection);
        int hak = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Boş Alanları Doldurunuz");
            }
            else
            {
                try
                {
                    if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                    {
                        MySqlDataReader dr;
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From admin where ad=@ad AND sifre=@sifre", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@ad", textBox1.Text);
                        sqlcommad.Parameters.AddWithValue("@sifre", textBox2.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            textBox1.BackColor = Color.Green;
                            textBox2.BackColor = Color.Green;
                            textBox1.ForeColor = Color.White;
                            textBox2.ForeColor = Color.White;
                            /* MessageBox.Show("Bilet Sayfasına Şuan Gittin, Bilet Sayfasını Daha olusturmadım, Giriş Basarılı");*/
                            Admin_alman_ekstra tek = new Admin_alman_ekstra();
                            tek.Show();
                            sqlconnect.Close();
                            this.Hide();
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("Adınızı veya Şifrenizi Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            textBox1.BackColor = Color.Red;
                            textBox2.BackColor = Color.Red;
                            textBox1.ForeColor = Color.White;
                            textBox2.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                            }

                        }
                    }
                }

                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void Admin_Girisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
