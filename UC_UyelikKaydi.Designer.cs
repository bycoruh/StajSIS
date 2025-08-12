namespace StajSIS
{
    partial class UC_UyelikKaydi
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvUyelikKayitlari = new DataGridView();
            btnOnayla = new Button();
            btnReddet = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUyelikKayitlari).BeginInit();
            SuspendLayout();
            // 
            // dgvUyelikKayitlari
            // 
            dgvUyelikKayitlari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUyelikKayitlari.Location = new Point(13, 14);
            dgvUyelikKayitlari.Name = "dgvUyelikKayitlari";
            dgvUyelikKayitlari.Size = new Size(725, 383);
            dgvUyelikKayitlari.TabIndex = 0;
            // 
            // btnOnayla
            // 
            btnOnayla.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnOnayla.Location = new Point(488, 403);
            btnOnayla.Name = "btnOnayla";
            btnOnayla.Size = new Size(122, 34);
            btnOnayla.TabIndex = 1;
            btnOnayla.Text = "Onayla";
            btnOnayla.UseVisualStyleBackColor = true;
            btnOnayla.Click += btnOnayla_Click_1;
            // 
            // btnReddet
            // 
            btnReddet.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnReddet.Location = new Point(616, 403);
            btnReddet.Name = "btnReddet";
            btnReddet.Size = new Size(122, 34);
            btnReddet.TabIndex = 2;
            btnReddet.Text = "Reddet";
            btnReddet.UseVisualStyleBackColor = true;
            // 
            // UC_UyelikKaydi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnReddet);
            Controls.Add(btnOnayla);
            Controls.Add(dgvUyelikKayitlari);
            Name = "UC_UyelikKaydi";
            Size = new Size(1006, 579);
            Load += UC_UyelikKaydi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUyelikKayitlari).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUyelikKayitlari;
        private Button btnOnayla;
        private Button btnReddet;
    }
}
