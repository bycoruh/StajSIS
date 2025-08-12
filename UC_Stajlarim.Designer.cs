namespace StajSIS
{
    partial class UC_Stajlarim
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
            dataGridViewBasvurular = new DataGridView();
            btnGüncelleme = new Button();
            btnSil = new Button();
            cmbDurum = new ComboBox();
            label3 = new Label();
            cmbStajTuru = new ComboBox();
            label2 = new Label();
            btnTemizle = new Button();
            btnAra = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBasvurular).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBasvurular
            // 
            dataGridViewBasvurular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBasvurular.Location = new Point(3, 66);
            dataGridViewBasvurular.Name = "dataGridViewBasvurular";
            dataGridViewBasvurular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBasvurular.Size = new Size(760, 290);
            dataGridViewBasvurular.TabIndex = 0;
            dataGridViewBasvurular.CellContentClick += dataGridViewBasvurular_CellContentClick;
            // 
            // btnGüncelleme
            // 
            btnGüncelleme.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnGüncelleme.Location = new Point(487, 362);
            btnGüncelleme.Name = "btnGüncelleme";
            btnGüncelleme.Size = new Size(135, 35);
            btnGüncelleme.TabIndex = 1;
            btnGüncelleme.Text = "Güncelleme";
            btnGüncelleme.UseVisualStyleBackColor = true;
            btnGüncelleme.Click += btnGüncelleme_Click;
            // 
            // btnSil
            // 
            btnSil.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnSil.Location = new Point(628, 362);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(135, 35);
            btnSil.TabIndex = 2;
            btnSil.Text = "Silme";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // cmbDurum
            // 
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Location = new Point(294, 37);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(137, 23);
            cmbDurum.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(228, 40);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 19;
            label3.Text = "Durumu :";
            // 
            // cmbStajTuru
            // 
            cmbStajTuru.FormattingEnabled = true;
            cmbStajTuru.Location = new Point(87, 37);
            cmbStajTuru.Name = "cmbStajTuru";
            cmbStajTuru.Size = new Size(92, 23);
            cmbStajTuru.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(14, 40);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 17;
            label2.Text = "Staj Türü :";
            // 
            // btnTemizle
            // 
            btnTemizle.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnTemizle.Location = new Point(482, 35);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(133, 25);
            btnTemizle.TabIndex = 21;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnAra
            // 
            btnAra.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnAra.Location = new Point(625, 35);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(133, 25);
            btnAra.TabIndex = 22;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click_1;
            // 
            // UC_Stajlarim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(btnAra);
            Controls.Add(btnTemizle);
            Controls.Add(cmbDurum);
            Controls.Add(label3);
            Controls.Add(cmbStajTuru);
            Controls.Add(label2);
            Controls.Add(btnSil);
            Controls.Add(btnGüncelleme);
            Controls.Add(dataGridViewBasvurular);
            Name = "UC_Stajlarim";
            Size = new Size(1018, 577);
            Load += UC_Stajlarim_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBasvurular).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewBasvurular;
        private Button btnGüncelleme;
        private Button btnSil;
        private ComboBox cmbDurum;
        private Label label3;
        private ComboBox cmbStajTuru;
        private Label label2;
        private Button btnTemizle;
        private Button btnAra;
    }
}
