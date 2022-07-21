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
    public partial class Alm_o : Form
    {
        public Alm_o()
        {
            InitializeComponent();
        }
        int hak = 3;
        int puan = 0;

        MySqlConnection sqlconnect = new MySqlConnection(veriyolu.sqlconnection);
        public void Listele()
        {
            try
            {
                if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                {
                    sqlconnect.Open();
                    string Select = "Select * From alm_orta Order by skor desc";
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
        public void tablararasi_gecis()
        {
            int i = tabControl1.SelectedIndex + 1;
            tabControl1.SelectedIndex = i % tabControl1.TabCount;
        }
        private void button32_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox16.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("insert into alm_orta (isim,skor) values (@i,@s)", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@i", textBox16.Text);
                        sqlcommad.Parameters.AddWithValue("@s", textBox17.Text);
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

        private void button33_Click(object sender, EventArgs e)
        {
            tablararasi_gecis();
        }

        private void Alm_o_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;

            textBox1.Text = "ansonsten";
            textBox2.Text = "beabsichtigen";
            textBox3.Text = "bestechen";
            textBox4.Text = "der Feiertag";
            textBox5.Text = "der Führerschein";
            textBox6.Text = "die Heimatstadt";
            textBox7.Text = "erfüllen";
            textBox8.Text = "historisch";
            textBox9.Text = "kauen";
            textBox10.Text = "Passen";
            textBox11.Text = "sich beeilen";
            textBox12.Text = "unterhaltsam";
            textBox13.Text = "wirksam";
            textBox14.Text = "wirtschaftlich";
            textBox15.Text = "zum Schluss";

            button3.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            button12.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button20.Enabled = false;
            button22.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button28.Enabled = false;
            button30.Enabled = false;
            button32.Enabled = false;

            textBox17.Enabled = false;

            tabPage1.Text = "1.Aşama";
            tabPage2.Text = "2.Aşama";
            tabPage3.Text = "3.Aşama";
            tabPage4.Text = "Skorlar";

            Listele();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(puan.ToString());
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox1.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox1.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button1.Enabled = false;
                            button3.Enabled = true;
                            richTextBox1.BackColor = Color.Green;
                            richTextBox1.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("1. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox1.BackColor = Color.Red;
                            richTextBox1.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox2.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox2.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox2.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button3.Enabled = false;
                            button5.Enabled = true;
                            richTextBox2.BackColor = Color.Green;
                            richTextBox2.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("2. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox2.BackColor = Color.Red;
                            richTextBox2.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox3.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox3.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox3.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button5.Enabled = false;
                            button7.Enabled = true;
                            richTextBox3.BackColor = Color.Green;
                            richTextBox3.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("3. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox3.BackColor = Color.Red;
                            richTextBox3.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox4.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox4.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox4.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button7.Enabled = false;
                            button9.Enabled = true;
                            richTextBox4.BackColor = Color.Green;
                            richTextBox4.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("4. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox4.BackColor = Color.Red;
                            richTextBox4.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox5.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox5.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox5.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button9.Enabled = false;
                            button12.Enabled = true;
                            richTextBox5.BackColor = Color.Green;
                            richTextBox5.ForeColor = Color.White;
                            tablararasi_gecis();
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("5. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox5.BackColor = Color.Red;
                            richTextBox5.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button12_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox6.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox6.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox6.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button12.Enabled = false;
                            button14.Enabled = true;
                            richTextBox6.BackColor = Color.Green;
                            richTextBox6.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("6. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox6.BackColor = Color.Red;
                            richTextBox6.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button14_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox7.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox7.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox7.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button14.Enabled = false;
                            button16.Enabled = true;
                            richTextBox7.BackColor = Color.Green;
                            richTextBox7.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("7. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox7.BackColor = Color.Red;
                            richTextBox7.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button16_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox8.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox8.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox8.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button16.Enabled = false;
                            button18.Enabled = true;
                            richTextBox8.BackColor = Color.Green;
                            richTextBox8.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("8. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox8.BackColor = Color.Red;
                            richTextBox8.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button18_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox9.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox9.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox9.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button18.Enabled = false;
                            button20.Enabled = true;
                            richTextBox9.BackColor = Color.Green;
                            richTextBox9.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("9. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox9.BackColor = Color.Red;
                            richTextBox9.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button20_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox10.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox10.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox10.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button20.Enabled = false;
                            button22.Enabled = true;
                            richTextBox10.BackColor = Color.Green;
                            richTextBox10.ForeColor = Color.White;
                            tablararasi_gecis();
                           
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("10. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox10.BackColor = Color.Red;
                            richTextBox10.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button22_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox11.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox11.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox11.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button22.Enabled = false;
                            button24.Enabled = true;
                            richTextBox11.BackColor = Color.Green;
                            richTextBox11.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("11. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox11.BackColor = Color.Red;
                            richTextBox11.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button24_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox12.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox12.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox12.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button24.Enabled = false;
                            button26.Enabled = true;
                            richTextBox12.BackColor = Color.Green;
                            richTextBox12.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("12. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox12.BackColor = Color.Red;
                            richTextBox12.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button26_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox13.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox13.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox13.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button26.Enabled = false;
                            button28.Enabled = true;
                            richTextBox13.BackColor = Color.Green;
                            richTextBox13.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("13. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox13.BackColor = Color.Red;
                            richTextBox13.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button28_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox14.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox14.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox14.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button28.Enabled = false;
                            button30.Enabled = true;
                            richTextBox14.BackColor = Color.Green;
                            richTextBox14.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("14. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox14.BackColor = Color.Red;
                            richTextBox14.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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

        private void button30_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox15.Text))
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ao where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox15.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox15.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 10;
                            button30.Enabled = false;
                            button32.Enabled = true;
                            textBox17.Text = puan.ToString();
                            richTextBox15.BackColor = Color.Green;
                            richTextBox15.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("15. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox15.BackColor = Color.Red;
                            richTextBox15.ForeColor = Color.White;
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
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
            axWindowsMediaPlayer1.URL = "Almanca\\Orta\\ansonsten.mp3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.URL = "Almanca\\Orta\\beabsichtigen.mp3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.URL = "Almanca\\Orta\\bestechen.mp3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer4.URL = "Almanca\\Orta\\der Feiertag.mp3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer5.URL = "Almanca\\Orta\\der Führerschein.mp3";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer6.URL = "Almanca\\Orta\\die Heimatstadt.mp3";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer7.URL = "Almanca\\Orta\\erfüllen.mp3";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer8.URL = "Almanca\\Orta\\historisch.mp3";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer9.URL = "Almanca\\Orta\\kauen.mp3";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer10.URL = "Almanca\\Orta\\Passen.mp3";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer11.URL = "Almanca\\Orta\\sich beeilen.mp3";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer12.URL = "Almanca\\Orta\\unterhaltsam.mp3";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer13.URL = "Almanca\\Orta\\wirksam.mp3";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer14.URL = "Almanca\\Orta\\wirtschaftlich.mp3";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer15.URL = "Almanca\\Orta\\zum Schluss.mp3";
        }

        private void button33_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(puan.ToString());
        }

        private void Alm_o_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
