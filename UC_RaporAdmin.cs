using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajSIS
{
    public partial class UC_RaporAdmin : UserControl
    {
        public void ExportDataGridViewToPdf(DataGridView dgv, string filePath)
        {
            try
            {
                
                Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                
                PdfPTable table = new PdfPTable(dgv.Columns.Count);

                
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    table.AddCell(new Phrase(column.HeaderText));
                }

                
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow) 
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value?.ToString() ?? "");
                        }
                    }
                }

                doc.Add(table);
                doc.Close();

                MessageBox.Show("PDF dosyası başarıyla oluşturuldu!", "Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int? SeciliBasvuruId()
        {
            if (dgvAdminRaporlar.CurrentRow == null) return null;
            var cell = dgvAdminRaporlar.CurrentRow.Cells["ID"];
            return cell?.Value != null && int.TryParse(cell.Value.ToString(), out var id) ? id : (int?)null;
        }
        private string? SeciliRaporYolu()
        {
            if (dgvAdminRaporlar.CurrentRow == null) return null;
            return dgvAdminRaporlar.CurrentRow.Cells["RaporDosyaYolu"]?.Value?.ToString();
        }
        private void CombosYukle_Admin()
        {
            
            cmbStajTuru.BeginUpdate();
            cmbStajTuru.Items.Clear();
            cmbStajTuru.Items.Add("Tümü");

            using (var con = VeritabaniYardimcisi.BaglantiOlustur())
            using (var cmd = new SQLiteCommand(@"
        SELECT DISTINCT TRIM(StajTuru) AS StajTuru
        FROM Basvurular
        WHERE StajTuru IS NOT NULL AND TRIM(StajTuru) <> ''
        ORDER BY 
          CASE TRIM(StajTuru)
            WHEN '15 Gün' THEN 1
            WHEN '30 Gün' THEN 2
            ELSE 3
          END, TRIM(StajTuru);", con))
            {
                con.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        cmbStajTuru.Items.Add(r.GetString(0));
            }

            cmbStajTuru.SelectedIndex = 0;
            cmbStajTuru.EndUpdate();
            cmbStajTuru.DropDownStyle = ComboBoxStyle.DropDownList;


            
            cmbDurum.BeginUpdate();
            cmbDurum.Items.Clear();
            cmbDurum.Items.Add("Tümü");

            using (var con = VeritabaniYardimcisi.BaglantiOlustur())
            using (var cmd = new SQLiteCommand(@"
        SELECT DISTINCT
          CASE TRIM(Durum)
            WHEN 'Onaylanan'      THEN 'Onaylandı'
            WHEN 'Onaylı'         THEN 'Onaylandı'
            WHEN 'Red'            THEN 'Reddedildi'
            WHEN 'Reddedilen'     THEN 'Reddedildi'
            WHEN 'Rapor Revize'   THEN 'Revize'
            WHEN 'Revize İstendi' THEN 'Revize'
            WHEN 'Gönderildi'     THEN 'Rapor Gönderildi'
            ELSE TRIM(Durum)
          END AS DurumNorm
        FROM Basvurular
        WHERE Durum IS NOT NULL AND TRIM(Durum) <> ''
        ORDER BY 
          CASE DurumNorm
            WHEN 'Beklemede'        THEN 1
            WHEN 'Rapor Gönderildi' THEN 2
            WHEN 'Revize'           THEN 3
            WHEN 'Onaylandı'        THEN 4
            WHEN 'Tamamlandı'       THEN 5
            WHEN 'Reddedildi'       THEN 6
            ELSE 99
          END, DurumNorm;", con))
            {
                con.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        cmbDurum.Items.Add(r.GetString(0));
            }

            cmbDurum.SelectedIndex = 0;
            cmbDurum.EndUpdate();
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;

            
            btnAra.Click -= btnAra_Click; btnAra.Click += btnAra_Click;
            btnTemizle.Click -= btnTemizle_Click; btnTemizle.Click += btnTemizle_Click;
        }

        private void Listele_Admin(string where = "", List<SQLiteParameter> prms = null)
        {
            string sql = @"
        SELECT ID, OgrenciEmail, StajTuru, KurumAdi, BaslangicTarih, BitisTarih, Durum, RaporDosyaYolu
        FROM Basvurular";

            if (!string.IsNullOrWhiteSpace(where))
                sql += " WHERE " + where;

            sql += " ORDER BY BaslangicTarih DESC;";

            using var con = VeritabaniYardimcisi.BaglantiOlustur();
            using var cmd = new SQLiteCommand(sql, con);
            if (prms != null && prms.Count > 0) cmd.Parameters.AddRange(prms.ToArray());

            using var da = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            con.Open(); da.Fill(dt);
            dgvAdminRaporlar.AutoGenerateColumns = true;
            dgvAdminRaporlar.DataSource = dt;
        }
        public UC_RaporAdmin()
        {
            InitializeComponent();
        }

        private void UC_RaporAdmin_Load(object sender, EventArgs e)
        {

            using (var con = VeritabaniYardimcisi.BaglantiOlustur())
            {
                con.Open();
                VeritabaniYardimcisi.KolonYoksaEkle(con, "Basvurular", "RaporDosyaYolu", "TEXT");
            }
            CombosYukle_Admin();
            Listele_Admin();
            dgvAdminRaporlar.SelectionChanged += dgvAdminRaporlar_SelectionChanged;
            dgvAdminRaporlar_SelectionChanged(null, EventArgs.Empty);
        }
        private void dgvAdminRaporlar_SelectionChanged(object sender, EventArgs e)
        {
            var yol = SeciliRaporYolu();
            bool hazir = !string.IsNullOrWhiteSpace(yol) && File.Exists(yol);
            btnAc.Enabled = hazir;
            btnIndir.Enabled = hazir;
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            var kosullar = new List<string>();
            var prms = new List<SQLiteParameter>();

            if (cmbStajTuru.Text != "Tümü" && !string.IsNullOrWhiteSpace(cmbStajTuru.Text))
            { kosullar.Add("StajTuru = @st"); prms.Add(new SQLiteParameter("@st", cmbStajTuru.Text)); }

            if (cmbDurum.Text != "Tümü" && !string.IsNullOrWhiteSpace(cmbDurum.Text))
            { kosullar.Add("Durum = @drm"); prms.Add(new SQLiteParameter("@drm", cmbDurum.Text)); }

            Listele_Admin(string.Join(" AND ", kosullar), prms);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cmbStajTuru.SelectedIndex = 0;
            cmbDurum.SelectedIndex = 0;
            Listele_Admin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF Dosyası|*.pdf";
            saveFile.Title = "PDF Olarak Kaydet";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                ExportDataGridViewToPdf(dgvAdminRaporlar, saveFile.FileName);
            }
        }
    }
}
