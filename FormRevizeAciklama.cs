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
    public partial class FormRevizeAciklama : Form
    {
        public string GirilenAciklama { get; private set; }
        public FormRevizeAciklama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirilenAciklama = rtbAciklama.Text.Trim();
            if (string.IsNullOrWhiteSpace(GirilenAciklama))
            {
                MessageBox.Show("Açıklama boş olamaz.");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormRevizeAciklama_Load(object sender, EventArgs e)
        {

        }
    }
}
