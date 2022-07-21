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
    public partial class Eksta_i : Form
    {
        public Eksta_i()
        {
            InitializeComponent();
        }
        MySqlConnection sqlconnect = new MySqlConnection(veriyolu.sqlconnection);
        int puan, hak= 3,sayac=0;
        string cumle,yazilisi;

        Random rnd = new Random();
        int random_sayi;
        int[] dizi;

        private void Eksta_i_Load(object sender, EventArgs e)
        {
            //textBox1.Visible = false;
            tabPage1.Text = "1.Aşama";
            tabPage2.Text = "Skorlar";
            textBox3.Enabled = false;
            button3.Enabled = false;

            dizi = new int[id()];

            for (int i = 0; i < id(); i++)
            {
                dizi[i] = 0;
            }
        }

        void main()
        {

        z:
            random_sayi = rnd.Next(1, id());

            if (dizi[random_sayi] == 1)
            {
                goto z;
            }
            else
            {
                //textBox4.Text = textBox4.Text + random_sayi.ToString() + ", ";
                dizi[random_sayi] = 1;
            }

        }

        public int id()
        {
            MySqlCommand ids = new MySqlCommand("SELECT MAX(`id`) FROM `ekstra_i`",sqlconnect);
            sqlconnect.Open();
            int a = Convert.ToInt32(ids.ExecuteScalar());
            int arttir = a + 1;
           // MessageBox.Show(arttir.ToString());
            sqlconnect.Close();
            return arttir;
        }
        public void isim_al()
        {
            main();
            MySqlCommand cumle_cek = new MySqlCommand("select * from ekstra_i where id=@id", sqlconnect);
            cumle_cek.Parameters.AddWithValue("@id", random_sayi);
            sqlconnect.Open();
            MySqlDataReader read = cumle_cek.ExecuteReader();
            if (read.Read())
            {
                /*MessageBox.Show(read["ses_dosyasi"].ToString());*/
                cumle = read["ses_dosyasi"].ToString();
                yazilisi = read["yazilisi"].ToString();
                //MessageBox.Show(cumle);
            }
            read.Close();
            sqlconnect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == id())
            {
                MessageBox.Show("Toplam Cümle Yazımlarını Tamamladınız. Skorunuzu Kaydediniz");
                button2.Enabled = false;
                button3.Enabled = true;
            }
            else
            {
                isim_al();
                axWindowsMediaPlayer1.URL = "İngilizce\\Cümleler\\" + cumle;
                //textBox1.Text = yazilisi;
                button2.Enabled = false;
                button1.Enabled = true;
            }
        }
        public void Listele()
        {
            try
            {
                if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                {
                    sqlconnect.Open();
                    string Select = "Select * From eksta_ik Order by skor desc";
                    MySqlDataAdapter da = new MySqlDataAdapter(Select, sqlconnect);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    sqlconnect.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("İsim değerini boş gecemezsin");
            }
            else
            {
                try
                {
                    if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                    {
                        sqlconnect.Open();//Bağlantıyı açtık
                        MySqlCommand sqlcommad = new MySqlCommand("insert into eksta_ik (isim,skor) values (@i,@s)", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@i", textBox2.Text);
                        sqlcommad.Parameters.AddWithValue("@s", textBox3.Text);
                        sqlcommad.ExecuteNonQuery();//Göndermiş oldugumuz parametreleri çalıştırır.
                        sqlconnect.Close();//Bağlantıyı kapattık.
                        MessageBox.Show("İsminiz ve Puanınız Basarıyla Sistemimize Kaydedilmiştir...");
                        Listele();
                        tablararasi_gecis();
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }
            }
        }

        private void Eksta_i_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(id().ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        public void tablararasi_gecis()
        {
            int i = tabControl1.SelectedIndex + 1;
            tabControl1.SelectedIndex = i % tabControl1.TabCount;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Boş Geçemezsiniz");
            }
            else
            {
                try
                {
                    if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                    {
                        MySqlDataReader dr;
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From ekstra_i where ses_dosyasi=@sd AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@sd", cumle);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox1.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button2.Enabled = true;
                            textBox3.Text = puan.ToString();
                            button1.Enabled = false;
                            richTextBox1.BackColor = Color.Green;
                            richTextBox1.ForeColor = Color.White;

                        }
                        else
                        {
                            button2.Enabled = false;
                            sqlconnect.Close();
                            MessageBox.Show("Ekstra İngilizce Cümlesinin Yazılışını Kontrol Ediniz ");
                            hak--;
                            puan= puan- 5;
                            textBox3.Text = puan.ToString();
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox1.BackColor = Color.Red;
                            richTextBox1.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                button1.Enabled = false;
                                button2.Enabled = false;
                                button3.Enabled = true;
                                MessageBox.Show("Başka hakkınız kalmamıştır. Lütfen skorunuzu kayıt ediniz");
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
    }
}
