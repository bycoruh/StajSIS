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
    public partial class UC_Stajlarim : UserControl
    {
        private Anaform anaform;
        public UC_Stajlarim(Anaform anaform)
        {
            InitializeComponent();
            this.anaform = anaform;
            this.Load += UC_Stajlarim_Load;
        }

        private void CombosYukle()
        {
           
            cmbStajTuru.BeginUpdate();
            cmbStajTuru.Items.Clear();
            cmbStajTuru.Items.Add("Tümü");

            
            using (var conn = VeritabaniYardimcisi.BaglantiOlustur())
            using (var cmd = new SQLiteCommand("SELECT DISTINCT StajTuru FROM Basvurular ORDER BY StajTuru", conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) cmbStajTuru.Items.Add(r.GetString(0));
            }
            

            cmbStajTuru.SelectedIndex = 0;
            cmbStajTuru.EndUpdate();
            cmbStajTuru.DropDownStyle = ComboBoxStyle.DropDownList;

            
            cmbDurum.BeginUpdate();
            cmbDurum.Items.Clear();
            cmbDurum.Items.AddRange(new object[] {
        "Tümü", "Beklemede", "Rapor Gönderildi", "Revize", "Tamamlandı"
    });
            cmbDurum.SelectedIndex = 0;
            cmbDurum.EndUpdate();
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ListeleFiltreli()
        {
            string email = anaform.GirisYapanEmail;

            string sql = @"SELECT ID, StajTuru, KurumAdi, KurumAdresi, 
                          BaslangicTarih, BitisTarih, Durum
                   FROM Basvurular
                   WHERE OgrenciEmail = @Email";

            var prms = new List<SQLiteParameter> { new SQLiteParameter("@Email", email) };

            
            if (!string.IsNullOrWhiteSpace(cmbStajTuru.Text) && cmbStajTuru.Text != "Tümü")
            {
                sql += " AND StajTuru = @st";
                prms.Add(new SQLiteParameter("@st", cmbStajTuru.Text));
            }

            
            if (!string.IsNullOrWhiteSpace(cmbDurum.Text) && cmbDurum.Text != "Tümü")
            {
                sql += " AND Durum = @drm";
                prms.Add(new SQLiteParameter("@drm", cmbDurum.Text));
            }

            using (var conn = VeritabaniYardimcisi.BaglantiOlustur())
            using (var cmd = new SQLiteCommand(sql, conn))
            using (var da = new SQLiteDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(prms.ToArray());
                var dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                dataGridViewBasvurular.DataSource = dt;
            }
        }
        private void YukleStajlar()
        {
            string email = anaform.GirisYapanEmail;

            using (SQLiteConnection conn = VeritabaniYardimcisi.BaglantiOlustur())
            {
                conn.Open();

                string sql = "SELECT ID, StajTuru, KurumAdi, KurumAdresi, BaslangicTarih, BitisTarih, Durum FROM Basvurular WHERE OgrenciEmail = @Email";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewBasvurular.DataSource = dt;
                    }
                }
            }
        }
        private void UC_Stajlarim_Load(object sender, EventArgs e)
        {
            CombosYukle();

            string email = anaform.GirisYapanEmail;

            using (SQLiteConnection conn = VeritabaniYardimcisi.BaglantiOlustur())
            {
                conn.Open();
                string sql = "SELECT ID, StajTuru, KurumAdi, KurumAdresi, BaslangicTarih, BitisTarih, Durum FROM Basvurular WHERE OgrenciEmail = @Email";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewBasvurular.DataSource = dt;
                }
            }
        }

        private void btnGüncelleme_Click(object sender, EventArgs e)
        {
            if (dataGridViewBasvurular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellemek istediğiniz stajı seçiniz.");
                return;
            }
            string durum = dataGridViewBasvurular.SelectedRows[0].Cells["Durum"].Value?.ToString() ?? "";
            if (durum != "Revize" && durum != "Beklemede")
            {
                MessageBox.Show("Sadece 'Revize' veya 'Beklemede' durumundaki başvurular güncellenebilir.",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int seciliBasvuruID = Convert.ToInt32(dataGridViewBasvurular.SelectedRows[0].Cells["ID"].Value);
            string stajTuru = dataGridViewBasvurular.SelectedRows[0].Cells["StajTuru"].Value.ToString();
            string kurumAdi = dataGridViewBasvurular.SelectedRows[0].Cells["KurumAdi"].Value.ToString();
            string kurumAdresi = dataGridViewBasvurular.SelectedRows[0].Cells["KurumAdresi"].Value.ToString();
            string baslangic = dataGridViewBasvurular.SelectedRows[0].Cells["BaslangicTarih"].Value.ToString();
            string bitis = dataGridViewBasvurular.SelectedRows[0].Cells["BitisTarih"].Value.ToString();


            anaform.GosterKontrol(new UC_BasvuruDuzenle(anaform, seciliBasvuruID, stajTuru, kurumAdi, kurumAdresi, baslangic, bitis));
        }

        private void dataGridViewBasvurular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewBasvurular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz staj başvurusunu seçiniz.");
                return;
            }


            string durum = dataGridViewBasvurular.SelectedRows[0].Cells["Durum"].Value.ToString();


            if (durum != "Beklemede")
            {
                MessageBox.Show("Sadece 'Beklemede' durumundaki başvurular silinebilir.");
                return;
            }


            int seciliBasvuruID = Convert.ToInt32(dataGridViewBasvurular.SelectedRows[0].Cells["ID"].Value);

            DialogResult onay = MessageBox.Show("Seçilen başvuruyu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                using (SQLiteConnection conn = VeritabaniYardimcisi.BaglantiOlustur())
                {
                    conn.Open();
                    string silSorgu = "DELETE FROM Basvurular WHERE ID = @ID";

                    using (SQLiteCommand cmd = new SQLiteCommand(silSorgu, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", seciliBasvuruID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Başvuru başarıyla silindi.");

                YukleStajlar();

            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cmbStajTuru.SelectedIndex = -1;
            cmbDurum.SelectedIndex = -1;
            ListeleFiltreli();
        }

        private void btnAra_Click_1(object sender, EventArgs e)
        {
            ListeleFiltreli();
        }
    }
}
