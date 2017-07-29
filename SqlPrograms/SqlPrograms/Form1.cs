using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace SqlPrograms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region sql'e baglanti
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP - MSE4Q0T/SQLEXPRESS; Initial Catalog = kisiler; Integrated Security = True"); // Sql connection ile bağlanacağı sql
                                                                                                                                    // server yolunu gösterdik.
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            #region boşluk kontrolü
            if (usernametxtbx.Text == "" && passwordtxtbx.Text == "") // Eger usenametxtbx (kullanıcı adı kutusu) yazısı "" bu ise yani hiçbir karakter yok ise,
                                                                      // Ve passwordtxtbx (şifre kutusu) yazısı "" bu ise yani 
                                                                      // Hiçbir karakter yok ise, 
            {
                MessageBox.Show("Lütfen Kullanıcı Adınızı veya Şifrenizi Boş Bırakmayınız"); // Ekrana "Lütfen Kullanıcı Adınızı veya Şifrenizi Boş Bırakmayınız" mesajını yaz dedik.

            }
            #endregion
            #region sqlsorgu
            else
            {
                baglantı.Open(); // Yukarıda ki yolu bağlatıyı aç diyerek etkinleştirdik.
                SqlCommand komut = new SqlCommand("select * from kisiler where username= '" + usernametxtbx.Text + " ' and password='" + passwordtxtbx.Text + "'", baglantı); // Sql
                // command komutu ile sql sorgu diline geçiş yaptık ve kullanıcı adı kutusunu ve şifre kutusunu ekleyerek verileri karşılaştırdık. En sonunda bağlantıyı aktif ederek
                // bağlandık.
                SqlDataReader dr = komut.ExecuteReader(); // Verilerin hazır olup olmağıgını öğrenmek için dr komutuna yukarıdaki verilerin hazır olup olmadığını gösteren ExecuteReader
                // komutunu ekledik.
                if (dr.Read()) // Burada eger dr hazır ise aşağıdaki komutları yap dedik.
                {

                    MessageBox.Show("Hosgeldiniz");
                }
                       else
                             {
                              MessageBox.Show("Hatalı Giriş"); // Bukarıdaki değil ise ekrana "Hatalı Giriş"yaz dedik.
                            }

                baglantı.Close();
            }
            #endregion
        }
    }
}
