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
    public partial class UC_UyelikKaydi : UserControl
    {
        public UC_UyelikKaydi()
        {
            InitializeComponent();
            this.Load += UC_UyelikKaydi_Load;
            btnOnayla.Click += btnOnayla_Click;
            btnReddet.Click += btnReddet_Click;
            dgvUyelikKayitlari.SelectionChanged += (_, __) => ButonDurum();
        }
        private void ButonDurum()
        {
            bool secimVar = dgvUyelikKayitlari.CurrentRow != null;
            btnOnayla.Enabled = secimVar;
            btnReddet.Enabled = secimVar;
        }
        private int? SeciliKayitID()
        {
            if (dgvUyelikKayitlari.CurrentRow == null) return null;
            if (dgvUyelikKayitlari.CurrentRow.Cells["KayitID"].Value == null) return null;
            return Convert.ToInt32(dgvUyelikKayitlari.CurrentRow.Cells["KayitID"].Value);
        }

        private void UyelikKayitlariniListele()
        {
            using var con = VeritabaniYardimcisi.BaglantiOlustur();
            con.Open();
            using var da = new SQLiteDataAdapter(@"
            SELECT KayitID, Ad, Soyad, Email, Rol, Durum, KayitTarihi
            FROM UyelikKaydi
            WHERE Durum='Beklemede'
            ORDER BY KayitTarihi DESC;", con);

            var dt = new DataTable();
            da.Fill(dt);
            dgvUyelikKayitlari.DataSource = dt;

            if (dgvUyelikKayitlari.Columns["KayitID"] != null)
                dgvUyelikKayitlari.Columns["KayitID"].Width = 70;

            ButonDurum();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            var id = SeciliKayitID();
            if (id == null) { MessageBox.Show("Lütfen bir başvuru seçin."); return; }

            try
            {
                using var con = VeritabaniYardimcisi.BaglantiOlustur();
                con.Open();
                using var tx = con.BeginTransaction();

                var sel = new SQLiteCommand(
                    "SELECT Ad,Soyad,Email,Sifre,Rol,Durum FROM UyelikKaydi WHERE KayitID=@id;", con, tx);
                sel.Parameters.AddWithValue("@id", id);
                using var r = sel.ExecuteReader();
                if (!r.Read()) { tx.Rollback(); MessageBox.Show("Kayıt bulunamadı."); return; }
                if (r["Durum"]?.ToString() != "Beklemede")
                { tx.Rollback(); MessageBox.Show("Bu başvuru daha önce değerlendirilmiş."); return; }

                string email = r["Email"].ToString();

                var say = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Kullanicilar WHERE LOWER(Email)=LOWER(@e);", con, tx);
                say.Parameters.AddWithValue("@e", email);
                if (Convert.ToInt32(say.ExecuteScalar()) == 0)
                {
                    var ins = new SQLiteCommand(@"
                    INSERT INTO Kullanicilar(Ad,Soyad,Email,Sifre,Rol)
                    VALUES (@ad,@soyad,@mail,@sifre,@rol);", con, tx);
                    ins.Parameters.AddWithValue("@ad", r["Ad"]);
                    ins.Parameters.AddWithValue("@soyad", r["Soyad"]);
                    ins.Parameters.AddWithValue("@mail", email);
                    ins.Parameters.AddWithValue("@sifre", r["Sifre"]);
                    ins.Parameters.AddWithValue("@rol", r["Rol"]); 
                    ins.ExecuteNonQuery();
                }

                var up = new SQLiteCommand(
                    "UPDATE UyelikKaydi SET Durum='Onaylandı' WHERE KayitID=@id;", con, tx);
                up.Parameters.AddWithValue("@id", id);
                up.ExecuteNonQuery();

                tx.Commit();
                MessageBox.Show("Başvuru onaylandı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                UyelikKayitlariniListele();
            }
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            var id = SeciliKayitID();
            if (id == null) { MessageBox.Show("Lütfen bir başvuru seçin."); return; }

            try
            {
                using var con = VeritabaniYardimcisi.BaglantiOlustur();
                con.Open();
                using var cmd = new SQLiteCommand(
                    "UPDATE UyelikKaydi SET Durum='Reddedildi' WHERE KayitID=@id;", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Başvuru reddedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                UyelikKayitlariniListele();
            }
        }


        private void UC_UyelikKaydi_Load(object sender, EventArgs e)
        {
            UyelikKayitlariniListele();
        }

        private void btnOnayla_Click_1(object sender, EventArgs e)
        {

        }
    }
}
