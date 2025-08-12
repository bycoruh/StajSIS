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
    public partial class UC_Raporlar : UserControl
    {
        private string? _secilenDosyaYolu;
        private readonly string _connStr =
    $"Data Source={Application.StartupPath}\\StajSIS.db;Version=3;";
        public UC_Raporlar()
        {
            InitializeComponent();
            this.Load += UC_Raporlar_Load;
        }
        private void RaporKolonuYoksaEkle()
        {
            using var con = VeritabaniYardimcisi.BaglantiOlustur();
            con.Open();

            
            using (var check = new SQLiteCommand(
                "SELECT COUNT(*) FROM pragma_table_info('Basvurular') WHERE name='RaporDosyaYolu';", con))
            {
                var exists = Convert.ToInt32(check.ExecuteScalar()) > 0;
                if (!exists)
                {
                    using var alter = new SQLiteCommand(
                        "ALTER TABLE Basvurular ADD COLUMN RaporDosyaYolu TEXT;", con);
                    alter.ExecuteNonQuery();
                }
            }
        }

        private void UC_Raporlar_Load(object sender, EventArgs e)
        {
            RaporKolonuYoksaEkle();  
            ListeleRaporBasvurulari();
            dgvRaporBasvurular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRaporBasvurular.MultiSelect = false;
            dgvRaporBasvurular.ReadOnly = true;

            ListeleRaporBasvurulari();
        }
        private int? SeciliBasvuruId()
        {
            if (dgvRaporBasvurular.CurrentRow == null) return null;
            var cell = dgvRaporBasvurular.CurrentRow.Cells["ID"];
            if (cell == null || cell.Value == null) return null;
            if (int.TryParse(cell.Value.ToString(), out int id)) return id;
            return null;
        }
        private void ListeleRaporBasvurulari()
        {
            if (string.IsNullOrEmpty(AktifKullanici.Email)) return;

            using (var con = VeritabaniYardimcisi.BaglantiOlustur())
            {
                con.Open();

                string sql = @"
            SELECT 
                ID,
                StajTuru,
                KurumAdi,
                BaslangicTarih,
                BitisTarih,
                Durum
            FROM Basvurular
            WHERE OgrenciEmail = @email
              AND Durum IN ('Onaylandı', 'Rapor Revize')
            ORDER BY BaslangicTarih DESC;";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@email", AktifKullanici.Email);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        dgvRaporBasvurular.AutoGenerateColumns = true;
                        dgvRaporBasvurular.DataSource = dt;

                        if (dgvRaporBasvurular.Columns.Contains("ID"))
                            dgvRaporBasvurular.Columns["ID"].Visible = false;
                    }
                }
            }
        }

        private void btnGüncelleme_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Rapor dosyası seç",
                Filter = "PDF dosyaları (*.pdf)|*.pdf|Tüm dosyalar (*.*)|*.*",
                Multiselect = false
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _secilenDosyaYolu = ofd.FileName;
                lblDosyaYolu.Text = _secilenDosyaYolu;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var basvuruId = SeciliBasvuruId();
            if (basvuruId == null)
            {
                MessageBox.Show("Lütfen listeden bir başvuru seçin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_secilenDosyaYolu) || !File.Exists(_secilenDosyaYolu))
            {
                MessageBox.Show("Lütfen önce 'Dosya Seç' ile bir dosya seçin.");
                return;
            }

            try
            {
                
                string hedefKlasor = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Raporlar");
                Directory.CreateDirectory(hedefKlasor);                
                string hedefDosyaAdi = $"{basvuruId.Value}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(_secilenDosyaYolu)}";
                string hedefDosyaYolu = Path.Combine(hedefKlasor, hedefDosyaAdi);
                File.Copy(_secilenDosyaYolu, hedefDosyaYolu, overwrite: true);
                using var con = VeritabaniYardimcisi.BaglantiOlustur();
                con.Open();

                string sql = @"
            UPDATE Basvurular
               SET RaporDosyaYolu = @yol,
                   Durum          = 'Rapor Gönderildi'
             WHERE ID            = @id
               AND OgrenciEmail  = @ogrEmail;";

                using var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@yol", hedefDosyaYolu);
                cmd.Parameters.AddWithValue("@id", basvuruId.Value);
                cmd.Parameters.AddWithValue("@ogrEmail", AktifKullanici.Email);

                int etkilenen = cmd.ExecuteNonQuery();

                if (etkilenen > 0)
                {
                    MessageBox.Show("Rapor yüklendi ve durum güncellendi.");
                    _secilenDosyaYolu = null;                   
                    ListeleRaporBasvurulari();
                }
                else
                {
                    MessageBox.Show("Güncelleme yapılamadı. Kayıt/Yetki kontrol edin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yükleme sırasında hata: " + ex.Message);
            }
        }
    }
}
