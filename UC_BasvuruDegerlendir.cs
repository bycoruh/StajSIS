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
    public partial class UC_BasvuruDegerlendir : UserControl
    {
        public UC_BasvuruDegerlendir()
        {
            InitializeComponent();
        }

        private void UC_BasvuruDegerlendir_Load(object sender, EventArgs e)
        {
            string sql = "SELECT Id, OgrenciEmail, StajTuru, KurumAdi, BaslangicTarih, BitisTarih, Durum FROM Basvurular WHERE Durum = 'Beklemede'";

            using (SQLiteConnection conn = VeritabaniYardimcisi.BaglantiOlustur())
            {
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (SQLiteConnection conn = VeritabaniYardimcisi.BaglantiOlustur())
                {
                    conn.Open();
                    string sql = "UPDATE Basvurular SET Durum = 'Onaylandı' WHERE Id = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Başvuru onaylandı.");
                UC_BasvuruDegerlendir_Load(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (SQLiteConnection conn = VeritabaniYardimcisi.BaglantiOlustur())
                {
                    conn.Open();
                    string sql = "UPDATE Basvurular SET Durum = 'Reddedildi' WHERE Id = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Başvuru reddedildi.");
                UC_BasvuruDegerlendir_Load(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen bir başvuru seçin.");
                return;
            }
            if (string.IsNullOrWhiteSpace(rtbAciklama.Text))
            {
                MessageBox.Show("Revize açıklaması boş olamaz.");
                return;
            }

            int basvuruId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            string alici = Convert.ToString(dataGridView1.CurrentRow.Cells["OgrenciEmail"].Value);
            string gonderen = AktifKullanici.Email;
            string aciklama = rtbAciklama.Text.Trim();

            using (var conn = VeritabaniYardimcisi.BaglantiOlustur())
            {
                conn.Open();
                using (var tr = conn.BeginTransaction())
                {
                    
                    using (var cmd = new SQLiteCommand(@"
                INSERT INTO Mesajlar
                (GonderenEmail, AliciEmail, Konu, Icerik, Tarih)
                VALUES (@g,@a,@k,@i,@t);", conn, tr))
                    {
                        cmd.Parameters.AddWithValue("@g", gonderen);
                        cmd.Parameters.AddWithValue("@a", alici);
                        cmd.Parameters.AddWithValue("@k", $"Staj Başvurusu #{basvuruId} - Revizyon");
                        cmd.Parameters.AddWithValue("@i", aciklama);
                        cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        cmd.ExecuteNonQuery();
                    }

                    
                    using (var cmd = new SQLiteCommand(
                        "UPDATE Basvurular SET Durum = 'Revize' WHERE ID = @id;", conn, tr))
                    {
                        cmd.Parameters.AddWithValue("@id", basvuruId);
                        cmd.ExecuteNonQuery();
                    }

                    tr.Commit();
                }
            }

            MessageBox.Show("Revize mesajı gönderildi ve durum 'Revize' olarak güncellendi.");
            rtbAciklama.Clear();

            
            UC_BasvuruDegerlendir_Load(null, null);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
