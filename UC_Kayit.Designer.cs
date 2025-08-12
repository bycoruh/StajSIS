using System.Runtime.CompilerServices;

namespace StajSIS
{
    partial class UC_Kayit
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
            txtSifre = new TextBox();
            txtEmail = new TextBox();
            txtSoyad = new TextBox();
            txtAd = new TextBox();
            Label_4 = new Label();
            Label_3 = new Label();
            Label_2 = new Label();
            label_1 = new Label();
            btnBack = new Button();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            cmbRol = new ComboBox();
            label2 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(390, 400);
            button1.Name = "button1";
            button1.Size = new Size(129, 23);
            button1.TabIndex = 17;
            button1.Text = "Kayıt Ol";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(390, 219);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(129, 23);
            txtSifre.TabIndex = 16;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(390, 188);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(129, 23);
            txtEmail.TabIndex = 15;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(390, 159);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(129, 23);
            txtSoyad.TabIndex = 14;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(390, 128);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(129, 23);
            txtAd.TabIndex = 13;
            // 
            // Label_4
            // 
            Label_4.AutoSize = true;
            Label_4.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Label_4.Location = new Point(342, 227);
            Label_4.Name = "Label_4";
            Label_4.Size = new Size(42, 15);
            Label_4.TabIndex = 12;
            Label_4.Text = "Şifre :";
            // 
            // Label_3
            // 
            Label_3.AutoSize = true;
            Label_3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Label_3.Location = new Point(329, 196);
            Label_3.Name = "Label_3";
            Label_3.Size = new Size(55, 15);
            Label_3.TabIndex = 11;
            Label_3.Text = "E-Posta :";
            // 
            // Label_2
            // 
            Label_2.AutoSize = true;
            Label_2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Label_2.Location = new Point(338, 167);
            Label_2.Name = "Label_2";
            Label_2.Size = new Size(46, 15);
            Label_2.TabIndex = 10;
            Label_2.Text = "Soyad :";
            // 
            // label_1
            // 
            label_1.AutoSize = true;
            label_1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label_1.Location = new Point(355, 131);
            label_1.Name = "label_1";
            label_1.Size = new Size(29, 15);
            label_1.TabIndex = 9;
            label_1.Text = "Ad :";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBack.Location = new Point(784, 458);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(90, 23);
            btnBack.TabIndex = 18;
            btnBack.Text = "Geri";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 15F);
            label4.Location = new Point(377, 75);
            label4.Name = "label4";
            label4.Size = new Size(157, 22);
            label4.TabIndex = 20;
            label4.Text = "Bir Staj Projesidir";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 24.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(377, 30);
            label1.Name = "label1";
            label1.Size = new Size(151, 45);
            label1.TabIndex = 19;
            label1.Text = "STAJSIS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(351, 302);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 22;
            label3.Text = "Rol :";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(390, 294);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(129, 23);
            cmbRol.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(377, 250);
            label2.Name = "label2";
            label2.Size = new Size(196, 15);
            label2.TabIndex = 24;
            label2.Text = "*Şifreniz en az 6 haneli bir büyük,";
            label2.Click += label2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(390, 265);
            label5.Name = "label5";
            label5.Size = new Size(204, 15);
            label5.TabIndex = 25;
            label5.Text = "bir küçük ve bir  rakam içermelidir.";
            // 
            // UC_Kayit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(cmbRol);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(button1);
            Controls.Add(txtSifre);
            Controls.Add(txtEmail);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(Label_4);
            Controls.Add(Label_3);
            Controls.Add(Label_2);
            Controls.Add(label_1);
            Name = "UC_Kayit";
            Size = new Size(916, 510);
            Load += UC_Kayit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtSifre;
        private TextBox txtEmail;
        private TextBox txtSoyad;
        private TextBox txtAd;
        private Label Label_4;
        private Label Label_3;
        private Label Label_2;
        private Label label_1;
        private Button btnBack;
        private Label label4;
        private Label label1;
        private Label label3;
        private ComboBox cmbRol;
        private Label label2;
        private Label label5;
        
    }
}
