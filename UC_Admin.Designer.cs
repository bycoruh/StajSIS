﻿namespace StajSIS
{
    partial class UC_Admin
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
            panel1 = new Panel();
            button4 = new Button();
            button6 = new Button();
            button5 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panelAdminGoster = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(142, 513);
            panel1.TabIndex = 0;
            // 
            // button4
            // 
            button4.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button4.Location = new Point(15, 77);
            button4.Name = "button4";
            button4.Size = new Size(113, 39);
            button4.TabIndex = 6;
            button4.Text = "Üyelik Kaydı";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button6
            // 
            button6.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button6.Location = new Point(15, 257);
            button6.Name = "button6";
            button6.Size = new Size(113, 39);
            button6.TabIndex = 5;
            button6.Text = "Çıkış";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button5.Location = new Point(15, 212);
            button5.Name = "button5";
            button5.Size = new Size(113, 39);
            button5.TabIndex = 4;
            button5.Text = "Sistem Kayıtları";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button3.Location = new Point(15, 167);
            button3.Name = "button3";
            button3.Size = new Size(113, 39);
            button3.TabIndex = 2;
            button3.Text = "Mesajlar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.Location = new Point(15, 122);
            button2.Name = "button2";
            button2.Size = new Size(113, 39);
            button2.TabIndex = 1;
            button2.Text = "Stajlar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(15, 32);
            button1.Name = "button1";
            button1.Size = new Size(113, 39);
            button1.TabIndex = 0;
            button1.Text = "Kullanıcı Listesi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelAdminGoster
            // 
            panelAdminGoster.Location = new Point(148, 32);
            panelAdminGoster.Name = "panelAdminGoster";
            panelAdminGoster.Size = new Size(805, 481);
            panelAdminGoster.TabIndex = 1;
            // 
            // UC_Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(panelAdminGoster);
            Controls.Add(panel1);
            Name = "UC_Admin";
            Size = new Size(953, 514);
            Load += UC_Admin_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button6;
        private Button button5;
        private Button button3;
        private Button button2;
        private Panel panelAdminGoster;
        private Button button4;
    }
}
