namespace StajSIS
{
    partial class UC_Ogrenci
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
            PanelButon = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            btnStajlarim = new Button();
            btnBasvuru = new Button();
            PanelGoster = new Panel();
            PanelButon.SuspendLayout();
            SuspendLayout();
            // 
            // PanelButon
            // 
            PanelButon.Controls.Add(button3);
            PanelButon.Controls.Add(button2);
            PanelButon.Controls.Add(button1);
            PanelButon.Controls.Add(btnStajlarim);
            PanelButon.Controls.Add(btnBasvuru);
            PanelButon.Location = new Point(1, 0);
            PanelButon.Name = "PanelButon";
            PanelButon.Size = new Size(179, 524);
            PanelButon.TabIndex = 0;
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            button3.Location = new Point(18, 129);
            button3.Name = "button3";
            button3.Size = new Size(139, 34);
            button3.TabIndex = 4;
            button3.Text = "Raporlar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            button2.Location = new Point(18, 209);
            button2.Name = "button2";
            button2.Size = new Size(139, 34);
            button2.TabIndex = 3;
            button2.Text = "Çıkış";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            button1.Location = new Point(18, 169);
            button1.Name = "button1";
            button1.Size = new Size(139, 34);
            button1.TabIndex = 2;
            button1.Text = "Mesajlar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnStajlarim
            // 
            btnStajlarim.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnStajlarim.Location = new Point(18, 89);
            btnStajlarim.Name = "btnStajlarim";
            btnStajlarim.Size = new Size(139, 34);
            btnStajlarim.TabIndex = 1;
            btnStajlarim.Text = "Stajlarım";
            btnStajlarim.UseVisualStyleBackColor = true;
            btnStajlarim.Click += btnStajlarim_Click;
            // 
            // btnBasvuru
            // 
            btnBasvuru.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btnBasvuru.Location = new Point(18, 49);
            btnBasvuru.Name = "btnBasvuru";
            btnBasvuru.Size = new Size(139, 34);
            btnBasvuru.TabIndex = 0;
            btnBasvuru.Text = "Staj Başvurusu";
            btnBasvuru.UseVisualStyleBackColor = true;
            btnBasvuru.Click += btnBasvuru_Click;
            // 
            // PanelGoster
            // 
            PanelGoster.Location = new Point(186, 49);
            PanelGoster.Name = "PanelGoster";
            PanelGoster.Size = new Size(772, 475);
            PanelGoster.TabIndex = 1;
            // 
            // UC_Ogrenci
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(PanelGoster);
            Controls.Add(PanelButon);
            Name = "UC_Ogrenci";
            Size = new Size(1022, 591);
            Load += UC_Ogrenci_Load;
            PanelButon.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelButon;
        private Button btnStajlarim;
        private Button btnBasvuru;
        private Panel PanelGoster;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
