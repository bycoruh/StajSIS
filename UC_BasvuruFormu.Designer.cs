namespace StajSIS
{
    partial class UC_BasvuruFormu
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
            cmbStajTuru = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtKurumAdi = new TextBox();
            txtKurumAdresi = new TextBox();
            dtBaslangic = new DateTimePicker();
            dtBitis = new DateTimePicker();
            button1 = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbStajTuru
            // 
            cmbStajTuru.FormattingEnabled = true;
            cmbStajTuru.Location = new Point(238, 36);
            cmbStajTuru.Name = "cmbStajTuru";
            cmbStajTuru.Size = new Size(186, 23);
            cmbStajTuru.TabIndex = 0;
            cmbStajTuru.SelectedIndexChanged += cmbStajTuru_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(165, 39);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 1;
            label1.Text = "Staj Türü :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(158, 80);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "Kurum Adı :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(140, 123);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 3;
            label3.Text = "Kurum Adresi :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(126, 165);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 4;
            label4.Text = "Başlangıç Tarihi :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(154, 212);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 5;
            label5.Text = "Bitiş Tarihi :";
            // 
            // txtKurumAdi
            // 
            txtKurumAdi.Location = new Point(238, 77);
            txtKurumAdi.Name = "txtKurumAdi";
            txtKurumAdi.Size = new Size(186, 23);
            txtKurumAdi.TabIndex = 6;
            // 
            // txtKurumAdresi
            // 
            txtKurumAdresi.Location = new Point(238, 120);
            txtKurumAdresi.Name = "txtKurumAdresi";
            txtKurumAdresi.Size = new Size(186, 23);
            txtKurumAdresi.TabIndex = 7;
            // 
            // dtBaslangic
            // 
            dtBaslangic.Location = new Point(238, 159);
            dtBaslangic.Name = "dtBaslangic";
            dtBaslangic.Size = new Size(186, 23);
            dtBaslangic.TabIndex = 8;
            // 
            // dtBitis
            // 
            dtBitis.Location = new Point(238, 206);
            dtBitis.Name = "dtBitis";
            dtBitis.Size = new Size(186, 23);
            dtBitis.TabIndex = 9;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(282, 328);
            button1.Name = "button1";
            button1.Size = new Size(142, 30);
            button1.TabIndex = 10;
            button1.Text = "Başvuru Gönder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(cmbStajTuru);
            groupBox1.Controls.Add(dtBitis);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtBaslangic);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtKurumAdresi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtKurumAdi);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(661, 389);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Staj Başvurusu";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // UC_BasvuruFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(groupBox1);
            Name = "UC_BasvuruFormu";
            Size = new Size(682, 447);
            Load += UC_BasvuruFormu_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbStajTuru;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtKurumAdi;
        private TextBox txtKurumAdresi;
        private DateTimePicker dtBaslangic;
        private DateTimePicker dtBitis;
        private Button button1;
        private GroupBox groupBox1;
    }
}
