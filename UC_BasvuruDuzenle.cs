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
    public partial class UC_BasvuruDuzenle : UserControl
    {
        private Anaform anaform;
        private int ID;
        public UC_BasvuruDuzenle(Anaform anaform, int id, string stajTuru, string kurumAdi, string kurumAdresi, string baslangic, string bitis)
        {
            InitializeComponent();
            this.anaform = anaform;
            this.ID = id;

            cmbStajTuru.SelectedItem = stajTuru;
            txtKurumAdi.Text = kurumAdi;
            txtKurumAdresi.Text = kurumAdresi;
            dtBaslangic.Value = DateTime.Parse(baslangic);
            dtBitis.Value = DateTime.Parse(bitis);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = VeritabaniYardimcisi.BaglantiOlustur())
            {
                conn.Open();
                string sql = "UPDATE Basvurular SET StajTuru=@StajTuru, KurumAdi=@KurumAdi, KurumAdresi=@KurumAdresi, BaslangicTarih=@Baslangic, BitisTarih=@Bitis WHERE ID=@ID";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StajTuru", cmbStajTuru.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@KurumAdi", txtKurumAdi.Text.Trim());
                    cmd.Parameters.AddWithValue("@KurumAdresi", txtKurumAdresi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Baslangic", dtBaslangic.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Bitis", dtBitis.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Durum", "Beklemede");
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Başvuru başarıyla güncellendi.");
            anaform.GosterKontrol(new UC_Ogrenci(anaform));
        }


        private void UC_BasvuruDuzenle_Load(object sender, EventArgs e)
        {
            cmbStajTuru.Items.Clear();
            cmbStajTuru.Items.Add("15 Gün");
            cmbStajTuru.Items.Add("30 Gün");
            cmbStajTuru.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           anaform.GosterKontrol(new UC_Ogrenci(anaform));
        }
    }
}
