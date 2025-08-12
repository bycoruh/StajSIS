namespace StajSIS
{
    partial class UC_RaporAdmin
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
            dgvAdminRaporlar = new DataGridView();
            btnIndir = new Button();
            btnAc = new Button();
            btnAra = new Button();
            btnTemizle = new Button();
            cmbDurum = new ComboBox();
            label3 = new Label();
            cmbStajTuru = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAdminRaporlar).BeginInit();
            SuspendLayout();
            // 
            // dgvAdminRaporlar
            // 
            dgvAdminRaporlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdminRaporlar.Location = new Point(3, 52);
            dgvAdminRaporlar.MultiSelect = false;
            dgvAdminRaporlar.Name = "dgvAdminRaporlar";
            dgvAdminRaporlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdminRaporlar.Size = new Size(777, 362);
            dgvAdminRaporlar.TabIndex = 9;
            // 
            // btnIndir
            // 
            btnIndir.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnIndir.Location = new Point(645, 420);
            btnIndir.Name = "btnIndir";
            btnIndir.Size = new Size(135, 35);
            btnIndir.TabIndex = 10;
            btnIndir.Text = "Raporu İndir";
            btnIndir.UseVisualStyleBackColor = true;
            btnIndir.Click += btnIndir_Click;
            // 
            // btnAc
            // 
            btnAc.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnAc.Location = new Point(504, 420);
            btnAc.Name = "btnAc";
            btnAc.Size = new Size(135, 35);
            btnAc.TabIndex = 11;
            btnAc.Text = "Raporu Aç";
            btnAc.UseVisualStyleBackColor = true;
            btnAc.Click += btnAc_Click;
            // 
            // btnAra
            // 
            btnAra.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnAra.Location = new Point(645, 21);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(133, 25);
            btnAra.TabIndex = 28;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnTemizle.Location = new Point(504, 21);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(133, 25);
            btnTemizle.TabIndex = 27;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // cmbDurum
            // 
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Location = new Point(283, 23);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(137, 23);
            cmbDurum.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(217, 26);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 25;
            label3.Text = "Durumu :";
            // 
            // cmbStajTuru
            // 
            cmbStajTuru.FormattingEnabled = true;
            cmbStajTuru.Location = new Point(76, 23);
            cmbStajTuru.Name = "cmbStajTuru";
            cmbStajTuru.Size = new Size(92, 23);
            cmbStajTuru.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(3, 26);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 23;
            label2.Text = "Staj Türü :";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            button1.Location = new Point(3, 420);
            button1.Name = "button1";
            button1.Size = new Size(135, 35);
            button1.TabIndex = 29;
            button1.Text = "Rapor Al";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UC_RaporAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(button1);
            Controls.Add(btnAra);
            Controls.Add(btnTemizle);
            Controls.Add(cmbDurum);
            Controls.Add(label3);
            Controls.Add(cmbStajTuru);
            Controls.Add(label2);
            Controls.Add(btnAc);
            Controls.Add(btnIndir);
            Controls.Add(dgvAdminRaporlar);
            Name = "UC_RaporAdmin";
            Size = new Size(928, 597);
            Load += UC_RaporAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAdminRaporlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAdminRaporlar;
        private Button btnIndir;
        private Button btnAc;
        private Button btnAra;
        private Button btnTemizle;
        private ComboBox cmbDurum;
        private Label label3;
        private ComboBox cmbStajTuru;
        private Label label2;
        private Button button1;
    }
}
