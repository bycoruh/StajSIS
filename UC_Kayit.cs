using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajSIS
{
    public partial class UC_Kayit : UserControl
    {
        private Anaform anaform;
        public UC_Kayit(Anaform anaform)
        {
            InitializeComponent();
            this.anaform = anaform;
            this.Load += UC_Kayit_Load;
        }
        bool SifreGecerliUnicode(string sifre)
        {
            
            var rx = new Regex(@"^(?=.*\p{Ll})(?=.*\p{Lu})(?=.*\p{Nd}).{6,}$",
                               RegexOptions.CultureInvariant);
            return rx.IsMatch(sifre);
        }
        string? SifreHataMesaji(string sifre)
        {
            if (sifre is null) return "Şifre boş olamaz.";
            if (sifre.Length < 6) return "Şifre en az 6 karakter olmalı.";
            if (!Regex.IsMatch(sifre, @"\p{Lu}")) return "En az bir BÜYÜK harf içermeli.";
            if (!Regex.IsMatch(sifre, @"\p{Ll}")) return "En az bir küçük harf içermeli.";
            if (!Regex.IsMatch(sifre, @"\p{Nd}")) return "En az bir rakam içermeli.";
            return null; 
        }
        private void UC_Kayit_Load(object sender, EventArgs e)
        {
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbRol.Items.Count == 0)
                cmbRol.Items.AddRange(new[] { "Admin", "Danisman", "Öğrenci" }); 

            
            cmbRol.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sifre = txtSifre.Text;
            string rol = cmbRol.SelectedItem?.ToString() ?? "Öğrenci"; 
            var hata = SifreHataMesaji(sifre);
            if (hata != null)
            {
                MessageBox.Show(hata, "Geçersiz Şifre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun."); return;
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Geçerli bir e-posta girin."); return;
            }

            using (var con = VeritabaniYardimcisi.BaglantiOlustur())
            {
                con.Open();

               
                using (var cmdKontrol = new SQLiteCommand(@"
            SELECT 
              (SELECT COUNT(*) FROM Kullanicilar WHERE LOWER(Email)=LOWER(@e))
            + (SELECT COUNT(*) FROM UyelikKaydi  WHERE LOWER(Email)=LOWER(@e))
            ", con))
                {
                    cmdKontrol.Parameters.AddWithValue("@e", email);
                    int mevcut = Convert.ToInt32(cmdKontrol.ExecuteScalar());
                    if (mevcut > 0)
                    {
                        MessageBox.Show("Bu e-posta ile daha önce kayıt yapılmış.");
                        return;
                    }
                }

                
                using (var cmdIns = new SQLiteCommand(@"
            INSERT INTO UyelikKaydi (Ad, Soyad, Email, Sifre, Rol, Durum)
            VALUES (@ad, @soyad, @mail, @sifre, @rol, 'Beklemede');", con))
                {
                    cmdIns.Parameters.AddWithValue("@ad", ad);
                    cmdIns.Parameters.AddWithValue("@soyad", soyad);
                    cmdIns.Parameters.AddWithValue("@mail", email);
                    cmdIns.Parameters.AddWithValue("@sifre", sifre);
                    cmdIns.Parameters.AddWithValue("@rol", rol); 
                    cmdIns.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Başvurunuz alındı. Admin onayından sonra giriş yapabilirsiniz.");
            txtAd.Clear();
            txtSoyad.Clear();
            txtEmail.Clear();
            txtSifre.Clear();
            cmbRol.SelectedIndex = 2; 
            anaform.GosterKontrol(new UC_Giris(anaform));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            anaform.GosterKontrol(new UC_Giris(anaform));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
