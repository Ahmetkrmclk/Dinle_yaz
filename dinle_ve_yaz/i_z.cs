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
    public partial class i_z : Form
    {
        public i_z()
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
                    string Select = "Select * From ing_zor Order by skor desc";
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
        private void i_z_Load(object sender, EventArgs e)
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

            textBox1.Text = "Brewery";
            textBox2.Text = "Congratulations";
            textBox3.Text = "Craftsman";
            textBox4.Text = "Deteriorate";
            textBox5.Text = "Entrepreneurial";
            textBox6.Text = "Explicit";
            textBox7.Text = "Extraterrestrial";
            textBox8.Text = "February";
            textBox9.Text = "Handkerchief";
            textBox10.Text = "Irregardless";
            textBox11.Text = "Lieutenant";
            textBox12.Text = "Prejudice";
            textBox13.Text = "Psychiatrist";
            textBox14.Text = "Rhythm";
            textBox15.Text = "Schedule";

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

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "İngilizce\\Zor\\Brewery.mp3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.URL = "İngilizce\\Zor\\Congratulations.mp3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.URL = "İngilizce\\Zor\\Craftsman.mp3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer4.URL = "İngilizce\\Zor\\Deteriorate.mp3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer5.URL = "İngilizce\\Zor\\Entrepreneurial.mp3";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer6.URL = "İngilizce\\Zor\\Explicit.mp3";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer7.URL = "İngilizce\\Zor\\Extraterrestrial.mp3";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer8.URL = "İngilizce\\Zor\\February.mp3";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer9.URL = "İngilizce\\Zor\\Handkerchief.mp3";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer10.URL = "İngilizce\\Zor\\Irregardless.mp3";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer11.URL = "İngilizce\\Zor\\Lieutenant.mp3";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer13.URL = "İngilizce\\Zor\\Psychiatrist.mp3";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer14.URL = "İngilizce\\Zor\\Rhythm.mp3";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Listele();
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox1.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox1.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox2.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox2.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                            if (hak ==0)
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox3.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox3.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox4.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox4.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox5.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox5.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox6.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox6.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox7.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox7.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox8.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox8.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox9.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox9.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox10.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox10.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox11.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox11.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox12.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox12.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox13.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox13.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox14.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox14.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
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
                        MySqlCommand sqlcommad = new MySqlCommand("Select * From kelimeler_iz where kelimeler=@km AND yazilisi=@yzl", sqlconnect);
                        sqlcommad.Parameters.AddWithValue("@km", textBox15.Text);
                        sqlcommad.Parameters.AddWithValue("@yzl", richTextBox15.Text);
                        sqlconnect.Open();//Bağlantıyı açtık
                        dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                        if (dr.Read())
                        {
                            sqlconnect.Close();
                            puan = puan + 15;
                            button30.Enabled = false;
                            button32.Enabled = true;
                           // button33.Enabled = true;
                            textBox17.Text = puan.ToString();
                            richTextBox15.BackColor = Color.Green;
                            richTextBox15.ForeColor = Color.White;
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
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
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
                        MySqlCommand sqlcommad = new MySqlCommand("insert into ing_zor (isim,skor) values (@i,@s)", sqlconnect);
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

        private void button35_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer12.URL = "İngilizce\\Zor\\Prejudice.mp3";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer15.URL = "İngilizce\\Zor\\Schedule.mp3";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(puan.ToString());
        }

        private void button37_Click(object sender, EventArgs e)
        {
            MessageBox.Show(puan.ToString());
        }

        private void i_z_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
