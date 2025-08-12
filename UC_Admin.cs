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
    public partial class UC_Admin : UserControl
    {
        private void GosterKontrol(UserControl gelenKontrol)
        {
            panelAdminGoster.Controls.Clear();
            gelenKontrol.Dock = DockStyle.Fill;
            panelAdminGoster.Controls.Add(gelenKontrol);
        }

        private Anaform anaform;
        public UC_Admin(Anaform anaform)
        {
            InitializeComponent();
            this.anaform = anaform;
        }

        private void UC_Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GosterKontrol(new UC_Kullanicilar());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            anaform.GosterKontrol(new UC_Giris(anaform));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UC_Mesajlar mesajlar = new UC_Mesajlar();
            mesajlar.Dock = DockStyle.Fill;
            panelAdminGoster.Controls.Clear();
            panelAdminGoster.Controls.Add(mesajlar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_RaporAdmin rapor = new UC_RaporAdmin();
            rapor.Dock = DockStyle.Fill;
            panelAdminGoster.Controls.Clear();
            panelAdminGoster.Controls.Add(rapor);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UC_SistemKayitlari sistemkayitlari = new UC_SistemKayitlari();
            sistemkayitlari.Dock = DockStyle.Fill;
            panelAdminGoster.Controls.Clear();
            panelAdminGoster.Controls.Add(sistemkayitlari);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            UC_UyelikKaydi uyelikkaydı = new UC_UyelikKaydi();
            uyelikkaydı.Dock = DockStyle.Fill;
            panelAdminGoster.Controls.Clear();
            panelAdminGoster.Controls.Add(uyelikkaydı);
        }
    }
}
