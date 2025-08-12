namespace StajSIS
{
    partial class UC_RaporlarDanısman
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
            label1 = new Label();
            dgvDanismanRaporlar = new DataGridView();
            btnRed = new Button();
            btnRevize = new Button();
            rtbRevizyonAciklama = new RichTextBox();
            btnAc = new Button();
            btnIndir = new Button();
            btnOnayla = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDanismanRaporlar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(3, 307);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 10;
            label1.Text = "Revizyon İçin Açıklama :";
            // 
            // dgvDanismanRaporlar
            // 
            dgvDanismanRaporlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanismanRaporlar.Location = new Point(3, 3);
            dgvDanismanRaporlar.MultiSelect = false;
            dgvDanismanRaporlar.Name = "dgvDanismanRaporlar";
            dgvDanismanRaporlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanismanRaporlar.Size = new Size(739, 278);
            dgvDanismanRaporlar.TabIndex = 9;
            // 
            // btnRed
            // 
            btnRed.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnRed.Location = new Point(145, 435);
            btnRed.Name = "btnRed";
            btnRed.Size = new Size(135, 35);
            btnRed.TabIndex = 8;
            btnRed.Text = "Reddet";
            btnRed.UseVisualStyleBackColor = true;
            btnRed.Click += btnRed_Click;
            // 
            // btnRevize
            // 
            btnRevize.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnRevize.Location = new Point(286, 435);
            btnRevize.Name = "btnRevize";
            btnRevize.Size = new Size(135, 35);
            btnRevize.TabIndex = 11;
            btnRevize.Text = "Revizyon İste";
            btnRevize.UseVisualStyleBackColor = true;
            btnRevize.Click += btnRevize_Click_1;
            // 
            // rtbRevizyonAciklama
            // 
            rtbRevizyonAciklama.Location = new Point(3, 325);
            rtbRevizyonAciklama.Name = "rtbRevizyonAciklama";
            rtbRevizyonAciklama.Size = new Size(571, 104);
            rtbRevizyonAciklama.TabIndex = 12;
            rtbRevizyonAciklama.Text = "";
            // 
            // btnAc
            // 
            btnAc.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnAc.Location = new Point(467, 284);
            btnAc.Name = "btnAc";
            btnAc.Size = new Size(135, 35);
            btnAc.TabIndex = 14;
            btnAc.Text = "Raporu Aç";
            btnAc.UseVisualStyleBackColor = true;
            btnAc.Click += btnAc_Click;
            // 
            // btnIndir
            // 
            btnIndir.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnIndir.Location = new Point(608, 284);
            btnIndir.Name = "btnIndir";
            btnIndir.Size = new Size(135, 35);
            btnIndir.TabIndex = 13;
            btnIndir.Text = "Raporu İndir";
            btnIndir.UseVisualStyleBackColor = true;
            btnIndir.Click += btnIndir_Click;
            // 
            // btnOnayla
            // 
            btnOnayla.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnOnayla.Location = new Point(4, 435);
            btnOnayla.Name = "btnOnayla";
            btnOnayla.Size = new Size(135, 35);
            btnOnayla.TabIndex = 15;
            btnOnayla.Text = "Onayla";
            btnOnayla.UseVisualStyleBackColor = true;
            btnOnayla.Click += btnOnayla_Click;
            // 
            // UC_RaporlarDanısman
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(btnOnayla);
            Controls.Add(btnAc);
            Controls.Add(btnIndir);
            Controls.Add(rtbRevizyonAciklama);
            Controls.Add(btnRevize);
            Controls.Add(label1);
            Controls.Add(dgvDanismanRaporlar);
            Controls.Add(btnRed);
            Name = "UC_RaporlarDanısman";
            Size = new Size(1035, 581);
            Load += UC_RaporlarDanısman_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanismanRaporlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvDanismanRaporlar;
        private Button btnRed;
        private Button btnRevize;
        private RichTextBox rtbRevizyonAciklama;
        private Button btnAc;
        private Button btnIndir;
        private Button btnOnayla;
    }
}
