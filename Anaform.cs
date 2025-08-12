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
    public partial class Anaform : Form
    {
        public string GirisYapanEmail { get; set; } = string.Empty;
        public void GosterKontrol(UserControl kontrol)
        {
            PanelMain.Controls.Clear();
            kontrol.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(kontrol);
        }
        public Anaform()
        {
            InitializeComponent();
        }

        private void Anaform_Load(object sender, EventArgs e)
        {
            GosterKontrol(new UC_Giris(this));
        }
    }
}
