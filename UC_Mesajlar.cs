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
    public partial class UC_Mesajlar : UserControl
    {
        public UC_Mesajlar()
        {
            InitializeComponent();
        }
        private void SatirIcerikGoster(DataGridView grid, RichTextBox rtb)
        {
            rtb.Text = "";

            if (grid.CurrentRow == null) return;

            
            if (grid.CurrentRow.DataBoundItem is DataRowView row)
            {
                
                if (row.Row.Table.Columns.Contains("Icerik"))
                    rtb.Text = row["Icerik"]?.ToString() ?? "";
                return;
            }

            
            var cell = grid.CurrentRow.Cells
                .Cast<DataGridViewCell>()
                .FirstOrDefault(c =>
                    string.Equals(c.OwningColumn.DataPropertyName, "Icerik", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.OwningColumn.Name, "Icerik", StringComparison.OrdinalIgnoreCase));

            if (cell != null)
                rtb.Text = cell.Value?.ToString() ?? "";
        }


        private void dataGridViewGelen_SelectionChanged(object sender, EventArgs e)
    => SatirIcerikGoster(dataGridViewGelen, rtbIcerikGoruntule);

        private void dataGridViewGelen_CellClick(object sender, DataGridViewCellEventArgs e)
            => SatirIcerikGoster(dataGridViewGelen, rtbIcerikGoruntule);

        private void dataGridViewGiden_SelectionChanged(object sender, EventArgs e)
            => SatirIcerikGoster(dataGridViewGiden, rtbIcerikGoruntule1);

        private void dataGridViewGiden_CellClick(object sender, DataGridViewCellEventArgs e)
            => SatirIcerikGoster(dataGridViewGiden, rtbIcerikGoruntule1);
        private void GelenKutusuListele()
        {
            using var conn = new SQLiteConnection(VeritabaniYardimcisi.BaglantiOlustur());
            conn.Open();

            const string sql = @"
                SELECT Id, GonderenEmail AS Kimden, Konu, Icerik, Tarih
                FROM Mesajlar
                WHERE AliciEmail = @email
                ORDER BY datetime(Tarih) DESC";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@email", AktifKullanici.Email);
            using var da = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            

            dataGridViewGelen.DataSource = null;
            dataGridViewGelen.Columns.Clear();
            dataGridViewGelen.AutoGenerateColumns = true;
            dataGridViewGelen.DataSource = dt;
        }
        private void GidenKutusuListele()
        {
            using var conn = new SQLiteConnection(VeritabaniYardimcisi.BaglantiOlustur());
            conn.Open();

            const string sql = @"
                SELECT Id, AliciEmail AS Alici, Konu, Icerik, Tarih
                FROM Mesajlar
                WHERE GonderenEmail = @email
                ORDER BY datetime(Tarih) DESC";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@email", AktifKullanici.Email);
            using var da = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            

            dataGridViewGiden.DataSource = null;
            dataGridViewGiden.Columns.Clear();
            dataGridViewGiden.AutoGenerateColumns = true;
            dataGridViewGiden.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var konu = txtKonu.Text?.Trim() ?? string.Empty;      
            var icerik = rtbIcerik.Text?.Trim() ?? string.Empty;

            if (cmbAlici.SelectedIndex < 0 || konu.Length == 0 || icerik.Length == 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            var aliciEmail = cmbAlici.SelectedItem!.ToString();  
            var gonderenEmail = AktifKullanici.Email;

            using var conn = new SQLiteConnection(VeritabaniYardimcisi.BaglantiOlustur());
            conn.Open();

            

            const string sql = @"INSERT INTO Mesajlar
        (GonderenEmail, AliciEmail, Konu, Icerik, Tarih)
        VALUES (@g, @a, @k, @i, @t)";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@g", gonderenEmail);
            cmd.Parameters.AddWithValue("@a", aliciEmail);
            cmd.Parameters.AddWithValue("@k", konu);
            cmd.Parameters.AddWithValue("@i", icerik);
            cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.ExecuteNonQuery();

            MessageBox.Show("Mesaj başarıyla gönderildi.");
            cmbAlici.SelectedIndex = -1; 
            txtKonu.Clear();
            rtbIcerikGoruntule.Clear();

            
            if (tabControl1.SelectedTab == tabPageGiden) GidenKutusuListele();
            else if (tabControl1.SelectedTab == tabPageGelen) GelenKutusuListele();
        }

        private void UC_Mesajlar_Load(object sender, EventArgs e)
        {
            
            cmbAlici.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlici.Items.Clear();

            using var conn = new SQLiteConnection(VeritabaniYardimcisi.BaglantiOlustur());
            conn.Open();

            using var cmd = new SQLiteCommand(
                "SELECT Email FROM Kullanicilar WHERE Email <> @me", conn);
            cmd.Parameters.AddWithValue("@me", AktifKullanici.Email);

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr.IsDBNull(0)) continue;     
                string email = rdr.GetString(0);   
                if (!string.IsNullOrWhiteSpace(email))
                    cmbAlici.Items.Add(email);
            }

            
            this.BeginInvoke(new Action(() =>
            {
                tabControl1.SelectedTab = tabPageGelen; 
                GelenKutusuListele();
            }));
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageGelen)
                GelenKutusuListele();
            else if (tabControl1.SelectedTab == tabPageGiden)
                GidenKutusuListele();
        }

        private void tabPageYaz_Click(object sender, EventArgs e)
        {
            cmbAlici.Items.Clear();

            using (SQLiteConnection conn = VeritabaniYardimcisi.BaglantiOlustur())
            {
                conn.Open();
                string sql = "SELECT Email FROM Kullanicilar WHERE Email != @email";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@email", AktifKullanici.Email);
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int ix = dr.GetOrdinal("Email");
                            if (dr.IsDBNull(ix)) continue; 

                            string email = dr.GetString(ix); 
                            if (!string.IsNullOrWhiteSpace(email))
                                cmbAlici.Items.Add(email);
                        }
                    }
                }
            }
        }

        private void rtbIcerikGoruntule1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var grid = dataGridViewGelen.Focused ? dataGridViewGelen :
                dataGridViewGiden.Focused ? dataGridViewGiden : dataGridViewGelen;

            if (grid.CurrentRow == null || grid.CurrentRow.Cells["Id"].Value == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz mesajı seçin.");
                return;
            }

            int mesajId = Convert.ToInt32(grid.CurrentRow.Cells["Id"].Value);

            if (MessageBox.Show("Bu mesajı silmek istiyor musunuz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (var conn = VeritabaniYardimcisi.BaglantiOlustur())
            using (var cmd = new SQLiteCommand("DELETE FROM Mesajlar WHERE Id=@Id", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", mesajId);
                cmd.ExecuteNonQuery();
            }

            
            if (grid == dataGridViewGelen) GelenKutusuListele(); else GidenKutusuListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var grid = dataGridViewGelen.SelectedRows.Count > 0 ? dataGridViewGelen :
               dataGridViewGiden.SelectedRows.Count > 0 ? dataGridViewGiden : dataGridViewGelen;

            if (grid.CurrentRow == null || grid.CurrentRow.Cells["Id"].Value == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz mesajı seçin.");
                return;
            }

            int mesajId = Convert.ToInt32(grid.CurrentRow.Cells["Id"].Value);

            if (MessageBox.Show("Bu mesajı silmek istiyor musunuz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (var conn = VeritabaniYardimcisi.BaglantiOlustur())  
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("DELETE FROM Mesajlar WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", mesajId);
                    cmd.ExecuteNonQuery();
                }
            }

            if (grid == dataGridViewGelen) GelenKutusuListele(); else GidenKutusuListele();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var grid = dataGridViewGelen.SelectedRows.Count > 0 ? dataGridViewGelen :
               dataGridViewGiden.SelectedRows.Count > 0 ? dataGridViewGiden : dataGridViewGelen;

            if (grid.CurrentRow == null || grid.CurrentRow.Cells["Id"].Value == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz mesajı seçin.");
                return;
            }

            int mesajId = Convert.ToInt32(grid.CurrentRow.Cells["Id"].Value);

            if (MessageBox.Show("Bu mesajı silmek istiyor musunuz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (var conn = VeritabaniYardimcisi.BaglantiOlustur())  
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("DELETE FROM Mesajlar WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", mesajId);
                    cmd.ExecuteNonQuery();
                }
            }

            if (grid == dataGridViewGelen) GelenKutusuListele(); else GidenKutusuListele();
        }
    }
}
