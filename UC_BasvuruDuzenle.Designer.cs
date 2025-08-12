namespace StajSIS
{
    partial class UC_BasvuruDuzenle
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
            button1 = new Button();
            dtBitis = new DateTimePicker();
            dtBaslangic = new DateTimePicker();
            txtKurumAdresi = new TextBox();
            txtKurumAdi = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbStajTuru = new ComboBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(323, 295);
            button1.Name = "button1";
            button1.Size = new Size(142, 30);
            button1.TabIndex = 21;
            button1.Text = "Güncelle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtBitis
            // 
            dtBitis.Location = new Point(279, 219);
            dtBitis.Name = "dtBitis";
            dtBitis.Size = new Size(186, 23);
            dtBitis.TabIndex = 20;
            // 
            // dtBaslangic
            // 
            dtBaslangic.Location = new Point(279, 172);
            dtBaslangic.Name = "dtBaslangic";
            dtBaslangic.Size = new Size(186, 23);
            dtBaslangic.TabIndex = 19;
            // 
            // txtKurumAdresi
            // 
            txtKurumAdresi.Location = new Point(279, 133);
            txtKurumAdresi.Name = "txtKurumAdresi";
            txtKurumAdresi.Size = new Size(186, 23);
            txtKurumAdresi.TabIndex = 18;
            // 
            // txtKurumAdi
            // 
            txtKurumAdi.Location = new Point(279, 90);
            txtKurumAdi.Name = "txtKurumAdi";
            txtKurumAdi.Size = new Size(186, 23);
            txtKurumAdi.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(195, 225);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 16;
            label5.Text = "Bitiş Tarihi :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(167, 178);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 15;
            label4.Text = "Başlangıç Tarihi :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(181, 136);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 14;
            label3.Text = "Kurum Adresi :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(199, 93);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 13;
            label2.Text = "Kurum Adı :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(206, 52);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 12;
            label1.Text = "Staj Türü :";
            // 
            // cmbStajTuru
            // 
            cmbStajTuru.FormattingEnabled = true;
            cmbStajTuru.Location = new Point(279, 49);
            cmbStajTuru.Name = "cmbStajTuru";
            cmbStajTuru.Size = new Size(186, 23);
            cmbStajTuru.TabIndex = 11;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.Location = new Point(593, 429);
            button2.Name = "button2";
            button2.Size = new Size(142, 30);
            button2.TabIndex = 22;
            button2.Text = "İptal";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UC_BasvuruDuzenle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dtBitis);
            Controls.Add(dtBaslangic);
            Controls.Add(txtKurumAdresi);
            Controls.Add(txtKurumAdi);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbStajTuru);
            Name = "UC_BasvuruDuzenle";
            Size = new Size(758, 479);
            Load += UC_BasvuruDuzenle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DateTimePicker dtBitis;
        private DateTimePicker dtBaslangic;
        private TextBox txtKurumAdresi;
        private TextBox txtKurumAdi;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbStajTuru;
        private Button button2;
    }
}
