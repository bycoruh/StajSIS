using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajSIS
{
    public partial class UC_Ogrenci : UserControl
    {
        private Anaform anaform;
        public UC_Ogrenci(Anaform anaform)
        {
            InitializeComponent();
            this.anaform = anaform;
        }

        private void UC_Ogrenci_Load(object sender, EventArgs e)
        {

        }

        private void btnBasvuru_Click(object sender, EventArgs e)
        {
            PanelGoster.Controls.Clear();
            UC_BasvuruFormu basvuru = new UC_BasvuruFormu(anaform);
            basvuru.Dock = DockStyle.Fill;
            PanelGoster.Controls.Add(basvuru);
        }

        private void btnStajlarim_Click(object sender, EventArgs e)
        {
            PanelGoster.Controls.Clear();
            UC_Stajlarim stajlarim = new UC_Stajlarim(anaform);
            stajlarim.Dock = DockStyle.Fill;
            PanelGoster.Controls.Add(stajlarim);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UC_Mesajlar mesajlar = new UC_Mesajlar();
            mesajlar.Dock = DockStyle.Fill;
            PanelGoster.Controls.Clear();
            PanelGoster.Controls.Add(mesajlar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaform.GosterKontrol(new UC_Giris(anaform));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelGoster.Controls.Clear();
            UC_Raporlar rapor = new UC_Raporlar();
            rapor.Dock = DockStyle.Fill;
            PanelGoster.Controls.Add(rapor);
        }
    }
}
