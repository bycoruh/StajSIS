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
    public partial class UC_Kullanicilar : UserControl
    {
        private void KullanicilariListele()
        {
            using (SQLiteConnection conn = new SQLiteConnection(VeritabaniYardimcisi.BaglantiOlustur()))
            {
                conn.Open();
                string sql = "SELECT ID, Ad, Soyad, Email, Rol FROM Kullanicilar";
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewKullanicilar.DataSource = dt;
                }
            }

            
            dataGridViewKullanicilar.ReadOnly = true;
            dataGridViewKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public UC_Kullanicilar()
        {
            InitializeComponent();
        }

        private void UC_Kullanicilar_Load(object sender, EventArgs e)
        {
            comboBoxRol.Items.Clear();
            comboBoxRol.Items.Add("Öğrenci");
            comboBoxRol.Items.Add("Danisman");
            comboBoxRol.SelectedIndex = 0;

            KullanicilariListele();
        }

        private void dataGridViewKullanicilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string rol = dataGridViewKullanicilar.Rows[e.RowIndex].Cells["Rol"].Value.ToString();
                comboBoxRol.SelectedItem = rol;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
                return;
            }

            int seciliId = Convert.ToInt32(dataGridViewKullanicilar.SelectedRows[0].Cells["ID"].Value);
            string yeniRol = comboBoxRol.SelectedItem.ToString();

            if (yeniRol == "Admin")
            {
                MessageBox.Show("Admin yetkisini bu panelden değiştiremezsiniz.");
                return;
            }

            using (var conn = VeritabaniYardimcisi.BaglantiOlustur())
            {
                conn.Open();
                string sql = "UPDATE Kullanicilar SET Rol = @rol WHERE ID = @id AND Rol != 'Admin'";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@rol", yeniRol);
                    cmd.Parameters.AddWithValue("@id", seciliId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Rol başarıyla güncellendi.");
            KullanicilariListele(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
                return;
            }

            int seciliId = Convert.ToInt32(dataGridViewKullanicilar.SelectedRows[0].Cells["ID"].Value);
            string rol = dataGridViewKullanicilar.SelectedRows[0].Cells["Rol"].Value.ToString();

            if (rol == "Admin")
            {
                MessageBox.Show("Admin kullanıcısı silinemez.");
                return;
            }

            DialogResult sonuc = MessageBox.Show("Kullanıcıyı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                using (var conn = VeritabaniYardimcisi.BaglantiOlustur())
                {
                    conn.Open();
                    string sql = "DELETE FROM Kullanicilar WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", seciliId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kullanıcı silindi.");
                KullanicilariListele();
            }
        }
    }
}
