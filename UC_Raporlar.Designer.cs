namespace StajSIS
{
    partial class UC_Raporlar
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
            btnSil = new Button();
            btnGüncelleme = new Button();
            dgvRaporBasvurular = new DataGridView();
            lblDosyaYolu = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRaporBasvurular).BeginInit();
            SuspendLayout();
            // 
            // btnSil
            // 
            btnSil.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnSil.Location = new Point(528, 350);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(135, 35);
            btnSil.TabIndex = 4;
            btnSil.Text = "Yükle";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGüncelleme
            // 
            btnGüncelleme.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnGüncelleme.Location = new Point(3, 350);
            btnGüncelleme.Name = "btnGüncelleme";
            btnGüncelleme.Size = new Size(135, 35);
            btnGüncelleme.TabIndex = 3;
            btnGüncelleme.Text = "Dosya Seç";
            btnGüncelleme.UseVisualStyleBackColor = true;
            btnGüncelleme.Click += btnGüncelleme_Click;
            // 
            // dgvRaporBasvurular
            // 
            dgvRaporBasvurular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRaporBasvurular.Location = new Point(3, 3);
            dgvRaporBasvurular.MultiSelect = false;
            dgvRaporBasvurular.Name = "dgvRaporBasvurular";
            dgvRaporBasvurular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRaporBasvurular.Size = new Size(660, 323);
            dgvRaporBasvurular.TabIndex = 5;
            // 
            // lblDosyaYolu
            // 
            lblDosyaYolu.AutoSize = true;
            lblDosyaYolu.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDosyaYolu.Location = new Point(3, 415);
            lblDosyaYolu.Name = "lblDosyaYolu";
            lblDosyaYolu.Size = new Size(67, 15);
            lblDosyaYolu.TabIndex = 6;
            lblDosyaYolu.Text = "Dosya Yolu";
            // 
            // UC_Raporlar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(lblDosyaYolu);
            Controls.Add(dgvRaporBasvurular);
            Controls.Add(btnSil);
            Controls.Add(btnGüncelleme);
            Name = "UC_Raporlar";
            Size = new Size(794, 586);
            Load += UC_Raporlar_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRaporBasvurular).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSil;
        private Button btnGüncelleme;
        private DataGridView dgvRaporBasvurular;
        private Label lblDosyaYolu;
    }
}
