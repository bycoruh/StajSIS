using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajSIS
{
    public partial class UC_RaporlarDanısman : UserControl
    {
        public UC_RaporlarDanısman()
        {
            InitializeComponent();
        }
        private int? SeciliBasvuruId()
        {
            if (dgvDanismanRaporlar.CurrentRow == null) return null;
            var cell = dgvDanismanRaporlar.CurrentRow.Cells["ID"];
            return cell?.Value != null && int.TryParse(cell.Value.ToString(), out var id) ? id : (int?)null;
        }
        private string? SeciliRaporYolu()
        {
            if (dgvDanismanRaporlar.CurrentRow == null) return null;
            return dgvDanismanRaporlar.CurrentRow.Cells["RaporDosyaYolu"]?.Value?.ToString();
        }
        private string? SeciliOgrenciEmail()
        {
            if (dgvDanismanRaporlar.CurrentRow == null) return null;
            return dgvDanismanRaporlar.CurrentRow.Cells["OgrenciEmail"]?.Value?.ToString();
        }

        private void Listele_Danisman()
        {
            using var con = VeritabaniYardimcisi.BaglantiOlustur();
            con.Open();
            string sql = @"
        SELECT ID, OgrenciEmail, StajTuru, KurumAdi, BaslangicTarih, BitisTarih, Durum, RaporDosyaYolu
        FROM Basvurular
        WHERE RaporDosyaYolu IS NOT NULL AND TRIM(RaporDosyaYolu) <> ''
          AND Durum IN ('Rapor Gönderildi')
        ORDER BY BaslangicTarih DESC;";
            using var da = new SQLiteDataAdapter(sql, con);
            var dt = new DataTable();
            da.Fill(dt);
            dgvDanismanRaporlar.AutoGenerateColumns = true;
            dgvDanismanRaporlar.DataSource = dt;
        }
        private void MesajTablosunuGarantiEt(SQLiteConnection con)
        {
            
            using var chk = new SQLiteCommand(
                "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='Mesajlar';", con);
            var varMi = Convert.ToInt32(chk.ExecuteScalar()) > 0;

            if (!varMi)
            {
                
                using var crt = new SQLiteCommand(@"
            CREATE TABLE Mesajlar(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                GonderenEmail TEXT NOT NULL,
                AliciEmail    TEXT NOT NULL,
                Konu          TEXT NOT NULL,
                Icerik        TEXT NOT NULL,
                GonderimTarihi TEXT NOT NULL
            );", con);
                crt.ExecuteNonQuery();
                return;
            }

            
            string[] kolonlar = { "GonderenEmail", "AliciEmail", "Konu", "Icerik", "GonderimTarihi" };
            foreach (var k in kolonlar)
            {
                using var kchk = new SQLiteCommand(
                    "SELECT COUNT(*) FROM pragma_table_info('Mesajlar') WHERE name=@k;", con);
                kchk.Parameters.AddWithValue("@k", k);
                var kolonVar = Convert.ToInt32(kchk.ExecuteScalar()) > 0;
                if (!kolonVar)
                {
                    using var alter = new SQLiteCommand(
                        $"ALTER TABLE Mesajlar ADD COLUMN {k} TEXT;", con);
                    alter.ExecuteNonQuery();
                }
            }
        }
        private void DurumGuncelle(string yeniDurum)
        {
            var id = SeciliBasvuruId();
            if (id == null) { MessageBox.Show("Lütfen bir kayıt seçin."); return; }

            using var con = VeritabaniYardimcisi.BaglantiOlustur();
            con.Open();
            using var cmd = new SQLiteCommand(
                "UPDATE Basvurular SET Durum=@d WHERE ID=@id;", con);
            cmd.Parameters.AddWithValue("@d", yeniDurum);
            cmd.Parameters.AddWithValue("@id", id.Value);
            var n = cmd.ExecuteNonQuery();
            if (n > 0) { Listele_Danisman(); MessageBox.Show("Durum güncellendi."); }
            else MessageBox.Show("Güncelleme başarısız.");
        }

        private void UC_RaporlarDanısman_Load(object sender, EventArgs e)
        {
            using (var con = VeritabaniYardimcisi.BaglantiOlustur())
            {
                con.Open();
                VeritabaniYardimcisi.KolonYoksaEkle(con, "Basvurular", "RaporDosyaYolu", "TEXT");
            }
            Listele_Danisman();
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            var yol = SeciliRaporYolu();
            if (string.IsNullOrWhiteSpace(yol) || !File.Exists(yol)) { MessageBox.Show("Dosya bulunamadı."); return; }
            Process.Start(new ProcessStartInfo { FileName = yol, UseShellExecute = true });
        }

        private void btnIndir_Click(object sender, EventArgs e)
        {
            var yol = SeciliRaporYolu();
            if (string.IsNullOrWhiteSpace(yol) || !File.Exists(yol)) { MessageBox.Show("Dosya bulunamadı."); return; }
            using var sfd = new SaveFileDialog { FileName = Path.GetFileName(yol), Filter = "PDF|*.pdf|Tüm Dosyalar|*.*" };
            if (sfd.ShowDialog() == DialogResult.OK) { File.Copy(yol, sfd.FileName, true); MessageBox.Show("İndirildi."); }
        }        
        private void btnRevize_Click(object sender, EventArgs e) => DurumGuncelle("Rapor Revize");

        private void btnRevize_Click_1(object sender, EventArgs e)
        {
            var id = SeciliBasvuruId();
            var ogrEmail = SeciliOgrenciEmail();
            var aciklama = rtbRevizyonAciklama.Text?.Trim() ?? "";

            if (id == null) { MessageBox.Show("Lütfen bir kayıt seçin."); return; }
            if (string.IsNullOrWhiteSpace(ogrEmail)) { MessageBox.Show("Öğrenci e-postası bulunamadı."); return; }
            if (string.IsNullOrWhiteSpace(aciklama)) { MessageBox.Show("Revizyon açıklamasını yazın."); return; }

            try
            {
                using var con = VeritabaniYardimcisi.BaglantiOlustur();
                con.Open();

               
                using (var cmd = new SQLiteCommand(
                    "UPDATE Basvurular SET Durum='Rapor Revize' WHERE ID=@id;", con))
                {
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    cmd.ExecuteNonQuery();
                }
                MesajTablosunuGarantiEt(con);
                using (var msg = new SQLiteCommand(@"
    INSERT INTO Mesajlar(GonderenEmail, AliciEmail, Konu, Icerik, Tarih)
    VALUES(@gonderen, @alici, @konu, @icerik, @tarih);", con))
                {
                    msg.Parameters.AddWithValue("@gonderen", AktifKullanici.Email);
                    msg.Parameters.AddWithValue("@alici", ogrEmail);
                    msg.Parameters.AddWithValue("@konu", "Rapor Revizyon Talebi");
                    msg.Parameters.AddWithValue("@icerik", aciklama);
                    msg.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    msg.ExecuteNonQuery();
                }

                MessageBox.Show("Revizyon talebi gönderildi ve durum güncellendi.");
                rtbRevizyonAciklama.Clear();
                Listele_Danisman();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem sırasında hata: " + ex.Message);
            }
        }
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            DurumGuncelle("Tamamlandı");
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            DurumGuncelle("Rapor Reddedildi");
        }
    }
}
