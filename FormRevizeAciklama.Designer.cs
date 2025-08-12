namespace StajSIS
{
    partial class FormRevizeAciklama
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            rtbAciklama = new RichTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(25, 34);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 2;
            label1.Text = "Açıklama :";
            // 
            // rtbAciklama
            // 
            rtbAciklama.Location = new Point(98, 34);
            rtbAciklama.Name = "rtbAciklama";
            rtbAciklama.Size = new Size(363, 175);
            rtbAciklama.TabIndex = 3;
            rtbAciklama.Text = "";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(366, 231);
            button1.Name = "button1";
            button1.Size = new Size(95, 26);
            button1.TabIndex = 5;
            button1.Text = "Gönder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormRevizeAciklama
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 284);
            Controls.Add(button1);
            Controls.Add(rtbAciklama);
            Controls.Add(label1);
            Name = "FormRevizeAciklama";
            Text = "FormRevizeAciklama";
            Load += FormRevizeAciklama_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox rtbAciklama;
        private Button button1;
    }
}