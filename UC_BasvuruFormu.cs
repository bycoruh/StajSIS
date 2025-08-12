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
    public partial class UC_BasvuruFormu : UserControl
    {
        private Anaform anaform;
        public UC_BasvuruFormu(Anaform anaform)
        {
            InitializeComponent();
            this.anaform = anaform;
        }

        private void cmbStajTuru_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UC_BasvuruFormu_Load(object sender, EventArgs e)
        {
            cmbStajTuru.Items.Clear();
            cmbStajTuru.Items.Add("15 Gün");
            cmbStajTuru.Items.Add("30 Gün");
            cmbStajTuru.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = anaform.GirisYapanEmail;
            string stajTuru = cmbStajTuru.SelectedItem.ToString();
            string kurumAdi = txtKurumAdi.Text.Trim();
            string kurumAdresi = txtKurumAdresi.Text.Trim();
            string baslangic = dtBaslangic.Value.ToString("yyyy-MM-dd");
            string bitis = dtBitis.Value.ToString("yyyy-MM-dd");


            if (string.IsNullOrWhiteSpace(kurumAdi) || string.IsNullOrWhiteSpace(kurumAdresi))
            {
                MessageBox.Show("Kurum adı ve adresi boş bırakılamaz.");
                return;
            }

            using SQLiteConnection conn = VeritabaniYardimcisi.BaglantiOlustur();
            {
                conn.Open();

                string sql = "INSERT INTO Basvurular (OgrenciEmail, StajTuru, KurumAdi, KurumAdresi, BaslangicTarih, BitisTarih, Durum) " +
             "VALUES (@Email, @StajTuru, @KurumAdi, @KurumAdresi, @BaslangicTarih, @BitisTarih, 'Beklemede')";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@StajTuru", stajTuru);
                    cmd.Parameters.AddWithValue("@KurumAdi", kurumAdi);
                    cmd.Parameters.AddWithValue("@KurumAdresi", kurumAdresi);
                    cmd.Parameters.AddWithValue("@BaslangicTarih", baslangic);
                    cmd.Parameters.AddWithValue("@BitisTarih", bitis);

                    try
                    {
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                        MessageBox.Show("Başvurunuz başarıyla gönderildi.");
                        TemizleForm();
                        conn.Close(); 
                    }
                }
            }
        }

        private void TemizleForm()
        {
            txtKurumAdi.Clear();
            txtKurumAdresi.Clear();
            cmbStajTuru.SelectedIndex = 0;
            dtBaslangic.Value = DateTime.Today;
            dtBitis.Value = DateTime.Today;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
