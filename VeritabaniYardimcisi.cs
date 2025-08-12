using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace StajSIS
{
    
    internal class VeritabaniYardimcisi
    {
        public static void KolonYoksaEkle(SQLiteConnection con, string table, string column, string type)
        {
            using var check = new SQLiteCommand(
                "SELECT COUNT(*) FROM pragma_table_info(@t) WHERE name=@c;", con);
            check.Parameters.AddWithValue("@t", table);
            check.Parameters.AddWithValue("@c", column);
            var exists = Convert.ToInt32(check.ExecuteScalar()) > 0;
            if (!exists)
            {
                using var alter = new SQLiteCommand(
                    $"ALTER TABLE {table} ADD COLUMN {column} {type};", con);
                alter.ExecuteNonQuery();
            }
        }
        public static void VeritabaniOlustur()
        {
            string dosyaYolu = Path.Combine(Application.StartupPath, "veritabani.db");

            if (!File.Exists(dosyaYolu))
            {
                SQLiteConnection.CreateFile(dosyaYolu);
            }

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dosyaYolu};Version=3;"))
            {
                conn.Open();

                
                string tabloSql = @"CREATE TABLE IF NOT EXISTS Kullanicilar (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                Ad TEXT NOT NULL,
                Soyad TEXT NOT NULL,
                Email TEXT NOT NULL UNIQUE,
                Sifre TEXT NOT NULL,
                Rol TEXT NOT NULL CHECK(Rol IN ('Öğrenci', 'Danisman', 'Admin'))
             );";

                new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS UyelikKaydi(
                    KayitID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Ad    TEXT NOT NULL,
                    Soyad TEXT NOT NULL,
                    Email TEXT NOT NULL UNIQUE,
                    Sifre TEXT NOT NULL,
                    Rol   TEXT NOT NULL CHECK (Rol IN ('Öğrenci','Danisman','Admin')),
                    Durum TEXT NOT NULL DEFAULT 'Beklemede' CHECK (Durum IN ('Beklemede','Onaylandı','Reddedildi')),
                    KayitTarihi TEXT DEFAULT CURRENT_TIMESTAMP
);", conn).ExecuteNonQuery();
                using (SQLiteCommand cmd = new SQLiteCommand(tabloSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string kontrolSql = "SELECT COUNT(*) FROM Kullanicilar WHERE Email = 'admin';";
                using (SQLiteCommand cmdKontrol = new SQLiteCommand(kontrolSql, conn))
                {
                    int adminVarMi = Convert.ToInt32(cmdKontrol.ExecuteScalar());

                    if (adminVarMi == 0)
                    {
                        string ekleSql = @"INSERT INTO Kullanicilar (Ad, Soyad, Email, Sifre, Rol)
                           VALUES ('admin', 'admin', 'admin', 'admin', 'Admin');";
                        using (SQLiteCommand cmdEkle = new SQLiteCommand(ekleSql, conn))
                        {
                            cmdEkle.ExecuteNonQuery();
                        }

                        
                        string basvuruSql = @"CREATE TABLE IF NOT EXISTS Basvurular (
                             ID INTEGER PRIMARY KEY AUTOINCREMENT,
                             OgrenciEmail TEXT NOT NULL,
                             StajTuru TEXT NOT NULL,
                             KurumAdi TEXT NOT NULL,
                             KurumAdresi TEXT NOT NULL,
                             BaslangicTarih TEXT NOT NULL,
                             BitisTarih TEXT NOT NULL,
                             Durum TEXT NOT NULL
                         );";

                        using (SQLiteCommand cmdBasvuru = new SQLiteCommand(basvuruSql, conn))
                        {
                            cmdBasvuru.ExecuteNonQuery();
                        }
                        
                        string sql = @"CREATE TABLE IF NOT EXISTS Mesajlar (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            GonderenEmail TEXT,
                            AliciEmail TEXT,
                            Konu TEXT,
                            Icerik TEXT,
                            Tarih TEXT)";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                }
                        conn.Close();
                
            }
        }
        public static SQLiteConnection BaglantiOlustur()
        {
            string yol = Path.Combine(Application.StartupPath, "veritabani.db");
            return new SQLiteConnection($"Data Source={yol};Version=3;");
        }
    }
}
