using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajSIS
{
    public partial class UC_SistemKayitlari : UserControl
    {
        public UC_SistemKayitlari()
        {
            InitializeComponent();
        }
        private static int IntVal(object o) => (o == DBNull.Value || o is null) ? 0 : Convert.ToInt32(o);
        private void YukleIstatistikler()
        {
            using var con = VeritabaniYardimcisi.BaglantiOlustur();
            con.Open();


            string sql = @"
            SELECT
              SUM(CASE WHEN Durum IN ('Beklemede','Rapor Gönderildi') THEN 1 ELSE 0 END) AS OnayBekleyen,
              SUM(CASE WHEN Durum = 'Onaylandı'                     THEN 1 ELSE 0 END) AS Onaylanan,
              SUM(CASE WHEN Durum IN ('Rapor Reddedildi', 'Reddedildi') THEN 1 ELSE 0 END) AS Reddedilen,
              SUM(CASE WHEN Durum IN ('Rapor Revize', 'Revize')       THEN 1 ELSE 0 END) AS Revizyon,
              SUM(CASE WHEN Durum = 'Tamamlandı'                     THEN 1 ELSE 0 END) AS Tamamlanan
            FROM Basvurular;";

            using (var cmd = new SQLiteCommand(sql, con))
            using (var rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblOnayBekleyen.Text = IntVal(rd["OnayBekleyen"]).ToString();
                    lblOnaylanan.Text = IntVal(rd["Onaylanan"]).ToString();
                    lblReddedilen.Text = IntVal(rd["Reddedilen"]).ToString();
                    lblRevizyon.Text = IntVal(rd["Revizyon"]).ToString();
                    lblTamamlanan.Text = IntVal(rd["Tamamlanan"]).ToString();
                }
            }


            using var cmd2 = new SQLiteCommand("SELECT COUNT(*) FROM Kullanicilar;", con);
            lblKullaniciSayisi.Text = Convert.ToInt32(cmd2.ExecuteScalar()).ToString();
        }
        private void UC_SistemKayitlari_Load(object sender, EventArgs e)
        {
            YukleIstatistikler();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblOnayBekleyen_Click(object sender, EventArgs e)
        {

        }
    }
}
