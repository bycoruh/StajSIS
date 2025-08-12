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
    public partial class UC_Danisman : UserControl
    {
        private Anaform anaform;
        public UC_Danisman(Anaform anaform)
        {
            InitializeComponent();
            this.anaform = anaform;
        }
        private void GosterKontrol(UserControl kontrol)
        {
            panelDanismanGoster.Controls.Clear();
            kontrol.Dock = DockStyle.Fill;
            panelDanismanGoster.Controls.Add(kontrol);
        }

        private void UC_Danisman_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            anaform.GosterKontrol(new UC_Giris(anaform));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GosterKontrol(new UC_BasvuruDegerlendir());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UC_Mesajlar mesajlar = new UC_Mesajlar();
            mesajlar.Dock = DockStyle.Fill;
            panelDanismanGoster.Controls.Clear();
            panelDanismanGoster.Controls.Add(mesajlar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelDanismanGoster.Controls.Clear();
            UC_RaporlarDanısman rapor = new UC_RaporlarDanısman();
            rapor.Dock = DockStyle.Fill;
            panelDanismanGoster.Controls.Add(rapor);
        }
    }
}
