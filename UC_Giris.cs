using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajSIS
{
    public partial class UC_Giris : UserControl
    {
        private Anaform anaform;
        public UC_Giris(Anaform anaform)
        {
            InitializeComponent();
            this.anaform = anaform;
        }

        private void UC_Giris_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaform.GosterKontrol(new UC_Kayit(anaform));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string ad = "", soyad = "", rol = "";

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=veritabani.db;Version=3;"))
            {
                conn.Open();

                string sql = "SELECT Id, Ad, Soyad, Rol FROM Kullanicilar WHERE Email = @Email AND Sifre = @Sifre";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Sifre", sifre);

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        ad = dr["Ad"].ToString();
                        soyad = dr["Soyad"].ToString();
                        rol = dr["Rol"].ToString();
                        
                        AktifKullanici.Email = email;
                        AktifKullanici.Rol = rol;
                        AktifKullanici.Id = Convert.ToInt32(dr["Id"]);

                        anaform.GirisYapanEmail = email;

                        MessageBox.Show($"Giriş Başarılı\nHoş geldiniz: {ad} {soyad}\nRolünüz: {rol}");

                        if (rol == "Admin")
                            anaform.GosterKontrol(new UC_Admin(anaform));
                        else if (rol == "Danisman")
                            anaform.GosterKontrol(new UC_Danisman(anaform));
                        else if (rol == "Öğrenci")
                            anaform.GosterKontrol(new UC_Ogrenci(anaform));
                    }
                    else
                    {
                        MessageBox.Show("Hatalı giriş.");
                    }
                }
            }
        }
    }
}
