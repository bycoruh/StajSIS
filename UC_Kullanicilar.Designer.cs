namespace StajSIS
{
    partial class UC_Kullanicilar
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
            dataGridViewKullanicilar = new DataGridView();
            comboBoxRol = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKullanicilar).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewKullanicilar
            // 
            dataGridViewKullanicilar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKullanicilar.Location = new Point(3, 3);
            dataGridViewKullanicilar.Name = "dataGridViewKullanicilar";
            dataGridViewKullanicilar.Size = new Size(587, 345);
            dataGridViewKullanicilar.TabIndex = 0;
            dataGridViewKullanicilar.CellContentClick += dataGridViewKullanicilar_CellContentClick;
            // 
            // comboBoxRol
            // 
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Location = new Point(103, 364);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(121, 23);
            comboBoxRol.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(3, 367);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 2;
            label1.Text = "Yeni Rol Seçin :";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(242, 361);
            button1.Name = "button1";
            button1.Size = new Size(166, 26);
            button1.TabIndex = 3;
            button1.Text = "Güncelle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.Location = new Point(424, 361);
            button2.Name = "button2";
            button2.Size = new Size(166, 26);
            button2.TabIndex = 4;
            button2.Text = "Kullanıcıyı Sil";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UC_Kullanicilar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBoxRol);
            Controls.Add(dataGridViewKullanicilar);
            Name = "UC_Kullanicilar";
            Size = new Size(707, 480);
            Load += UC_Kullanicilar_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewKullanicilar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewKullanicilar;
        private ComboBox comboBoxRol;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}
