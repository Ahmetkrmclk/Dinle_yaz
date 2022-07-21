using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace dinle_ve_yaz
{
    public partial class i_k : Form
    {
        public i_k()
        {
            InitializeComponent();
        }
        int hak = 3;
        int puan = 0;

        MySqlConnection sqlconnect = new MySqlConnection(veriyolu.sqlconnection);

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void Listele()
        {
            try
            {
                if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                {
                    sqlconnect.Open();
                    string Select = "Select * From ing_kolay Order by skor desc";
                    MySqlDataAdapter da = new MySqlDataAdapter(Select, sqlconnect);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    sqlconnect.Close();
                }
            }
            catch (Exception a )
            {
                MessageBox.Show(a.Message);
            }
            
        }
        private void i_k_Load(object sender, EventArgs e)
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

            textBox1.Text = "After";
            textBox2.Text = "Again";
            textBox3.Text = "All";
            textBox4.Text = "Always";
            textBox5.Text = "Another";
            textBox6.Text = "Ask";
            textBox7.Text = "Be";
            textBox8.Text = "Before";
            textBox9.Text = "Begin";
            textBox10.Text = "Buy";
            textBox11.Text = "Change";
            textBox12.Text = "Cheap";
            textBox13.Text = "Contiune";
            textBox14.Text = "Different";
            textBox15.Text = "Drive";

            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button13.Enabled = false;
            button15.Enabled = false;
            button17.Enabled = false;
            button19.Enabled = false;
            button21.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button29.Enabled = false;
            button31.Enabled = false;
            button33.Enabled = false;
            button35.Enabled = false;
           


            textBox17.Enabled = false;

            tabPage1.Text = "1.Aşama";
            tabPage2.Text = "2.Aşama";
            tabPage3.Text = "3.Aşama";
            tabPage4.Text = "Skorlar";
            //tabControl1.Enabled = false;

            Listele();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "İngilizce\\Kolay\\After.mp3";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.URL = "İngilizce\\Kolay\\Again.mp3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.URL = "İngilizce\\Kolay\\All.mp3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer4.URL = "İngilizce\\Kolay\\Always.mp3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer5.URL = "İngilizce\\Kolay\\Another.mp3";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show(puan.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox1.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox1.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button8.Enabled = true;
                            button7.Enabled = false;
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

        private void button8_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox2.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox2.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button9.Enabled = true;
                            button8.Enabled = false;
                            richTextBox2.BackColor = Color.Green;
                            richTextBox2.ForeColor = Color.White;

                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("2. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            richTextBox2.BackColor = Color.Red;
                            richTextBox2.ForeColor = Color.White;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            if (hak == 0)
                            {
                                MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                                Application.Exit();
                                puan = 0;
                            }

                        }
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }
            
            }
        }

        private void button9_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox3.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox3.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button10.Enabled = true;
                            button9.Enabled = false;
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
                catch (Exception s)
                {
                    MessageBox.Show(s.Message);
                }
            
            }
        }

        private void button10_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox4.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox4.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button11.Enabled = true;
                            button10.Enabled = false;
                            richTextBox4.BackColor = Color.Green;
                            richTextBox4.ForeColor = Color.White;
                        }
                        else
                        {
                            sqlconnect.Close();
                            MessageBox.Show("4. Sorunun Yazılışını Kontrol Ediniz ");
                            hak--;
                            MessageBox.Show("Kalan Hakkınız:" + hak);
                            richTextBox4.BackColor = Color.Green;
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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
            
            }
        }

        private void button11_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox5.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox5.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button13.Enabled = true;
                            button11.Enabled = false;
                            richTextBox5.BackColor = Color.Green;
                            richTextBox5.ForeColor = Color.White;
                            int i = tabControl1.SelectedIndex + 1;
                            tabControl1.SelectedIndex = i % tabControl1.TabCount;
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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }
            
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MessageBox.Show(puan.ToString());
        }

        private void button13_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox6.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox6.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button13.Enabled = false;
                            button15.Enabled = true;
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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
            
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer6.URL = "İngilizce\\Kolay\\Ask.mp3";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer7.URL = "İngilizce\\Kolay\\Be.mp3";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer8.URL = "İngilizce\\Kolay\\Before.mp3";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer9.URL = "İngilizce\\Kolay\\Begin.mp3";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer10.URL = "İngilizce\\Kolay\\Buy.mp3";
        }

        private void button15_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox7.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox7.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button17.Enabled = true;
                            button15.Enabled = false;

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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
            
            }
        }

        private void button17_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox8.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox8.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button19.Enabled = true;
                            button17.Enabled = false;

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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
            
            }
        }

        private void button19_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox9.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox9.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button21.Enabled = true;
                            button19.Enabled = false;

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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
             
            }
        }

        private void button21_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox10.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox10.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button26.Enabled = true;
                            button21.Enabled = false;

                            richTextBox10.BackColor = Color.Green;
                            richTextBox10.ForeColor = Color.White;
                            int i = tabControl1.SelectedIndex + 1;
                            tabControl1.SelectedIndex = i % tabControl1.TabCount;
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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
                
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer11.URL = "İngilizce\\Kolay\\Change.mp3";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer12.URL = "İngilizce\\Kolay\\Cheap.mp3";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer13.URL = "İngilizce\\Kolay\\Contiune.mp3";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer14.URL = "İngilizce\\Kolay\\Different.mp3";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer15.URL = "İngilizce\\Kolay\\Drive.mp3";
        }

        private void button26_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox11.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox11.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button27.Enabled = true;
                            button26.Enabled = false;
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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }

            
            }
        }

        private void button27_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox12.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox12.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button29.Enabled = true;
                            button27.Enabled = false;

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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
                
            }
        }


        private void button29_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox13.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox13.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button31.Enabled = true;
                            button29.Enabled = false;

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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
                
            }
        }

        private void button31_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox14.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox14.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            button33.Enabled = true;
                            button31.Enabled = false;
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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
                
            }
        }

        private void button33_Click(object sender, EventArgs e)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_ik where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox15.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox15.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 5;
                            //button33.Enabled = true;
                            button33.Enabled = false;
                            textBox17.Text = puan.ToString();
                            richTextBox15.BackColor = Color.Green;
                            richTextBox15.ForeColor = Color.White;
                            button35.Enabled = true;
                            //button36.Enabled = true;
                            Listele();

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
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    throw;
                }
                
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        public void tablararasi_gecis()
        {
            int i = tabControl1.SelectedIndex + 1;
            tabControl1.SelectedIndex = i % tabControl1.TabCount;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox16.Text))
            {
                MessageBox.Show("İsminizi yazmadan devam edemezsiniz");
            }
            else
            {
                try
                {
                    if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                    {
                        sqlconnect.Open();//Bağlantıyı açtık
                        MySqlCommand sqlcommad = new MySqlCommand("insert into ing_kolay (isim,skor) values (@i,@s)", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@i", textBox16.Text);
                        sqlcommad.Parameters.AddWithValue("@s", textBox17.Text);
                        sqlcommad.ExecuteNonQuery();//Göndermiş oldugumuz parametreleri çalıştırır.
                        sqlconnect.Close();//Bağlantıyı kapattık.
                        MessageBox.Show("İsminiz ve Puanınız Basarıyla Sistemimize Kaydedilmiştir...");
                        // button36.Enabled = true; 
                        tablararasi_gecis();
                        Listele();

                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }
            }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex + 1;
            tabControl1.SelectedIndex = i % tabControl1.TabCount;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex + 1;
            tabControl1.SelectedIndex = i % tabControl1.TabCount;
            Listele();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void i_k_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
