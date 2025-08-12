namespace StajSIS
{
    partial class UC_Mesajlar
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
            tabControl1 = new TabControl();
            tabPageGelen = new TabPage();
            label1 = new Label();
            rtbIcerikGoruntule = new RichTextBox();
            button2 = new Button();
            dataGridViewGelen = new DataGridView();
            tabPageGiden = new TabPage();
            label2 = new Label();
            rtbIcerikGoruntule1 = new RichTextBox();
            button3 = new Button();
            dataGridViewGiden = new DataGridView();
            tabPageYaz = new TabPage();
            rtbIcerik = new RichTextBox();
            txtKonu = new TextBox();
            button5 = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cmbAlici = new ComboBox();
            tabControl1.SuspendLayout();
            tabPageGelen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGelen).BeginInit();
            tabPageGiden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGiden).BeginInit();
            tabPageYaz.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageGelen);
            tabControl1.Controls.Add(tabPageGiden);
            tabControl1.Controls.Add(tabPageYaz);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(733, 395);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPageGelen
            // 
            tabPageGelen.BackColor = SystemColors.ActiveCaption;
            tabPageGelen.Controls.Add(label1);
            tabPageGelen.Controls.Add(rtbIcerikGoruntule);
            tabPageGelen.Controls.Add(button2);
            tabPageGelen.Controls.Add(dataGridViewGelen);
            tabPageGelen.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabPageGelen.Location = new Point(4, 24);
            tabPageGelen.Name = "tabPageGelen";
            tabPageGelen.Padding = new Padding(3);
            tabPageGelen.Size = new Size(725, 367);
            tabPageGelen.TabIndex = 0;
            tabPageGelen.Text = "Gelen Kutusu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 217);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 4;
            label1.Text = "İçeriği :";
            // 
            // rtbIcerikGoruntule
            // 
            rtbIcerikGoruntule.Location = new Point(6, 235);
            rtbIcerikGoruntule.Name = "rtbIcerikGoruntule";
            rtbIcerikGoruntule.Size = new Size(713, 96);
            rtbIcerikGoruntule.TabIndex = 3;
            rtbIcerikGoruntule.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(602, 337);
            button2.Name = "button2";
            button2.Size = new Size(117, 23);
            button2.TabIndex = 2;
            button2.Text = "Sil";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridViewGelen
            // 
            dataGridViewGelen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGelen.Location = new Point(0, 0);
            dataGridViewGelen.MultiSelect = false;
            dataGridViewGelen.Name = "dataGridViewGelen";
            dataGridViewGelen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGelen.Size = new Size(725, 214);
            dataGridViewGelen.TabIndex = 0;
            dataGridViewGelen.CellEnter += dataGridViewGelen_CellClick;
            dataGridViewGelen.CurrentCellChanged += dataGridViewGelen_SelectionChanged;
            // 
            // tabPageGiden
            // 
            tabPageGiden.BackColor = SystemColors.ActiveCaption;
            tabPageGiden.Controls.Add(label2);
            tabPageGiden.Controls.Add(rtbIcerikGoruntule1);
            tabPageGiden.Controls.Add(button3);
            tabPageGiden.Controls.Add(dataGridViewGiden);
            tabPageGiden.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabPageGiden.ForeColor = SystemColors.ControlText;
            tabPageGiden.Location = new Point(4, 24);
            tabPageGiden.Name = "tabPageGiden";
            tabPageGiden.Padding = new Padding(3);
            tabPageGiden.Size = new Size(725, 367);
            tabPageGiden.TabIndex = 1;
            tabPageGiden.Text = "Giden Kutusu";
            tabPageGiden.Click += tabPage2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 220);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 9;
            label2.Text = "İçeriği :";
            // 
            // rtbIcerikGoruntule1
            // 
            rtbIcerikGoruntule1.Location = new Point(6, 238);
            rtbIcerikGoruntule1.Name = "rtbIcerikGoruntule1";
            rtbIcerikGoruntule1.Size = new Size(713, 96);
            rtbIcerikGoruntule1.TabIndex = 8;
            rtbIcerikGoruntule1.Text = "";
            rtbIcerikGoruntule1.TextChanged += rtbIcerikGoruntule1_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(602, 340);
            button3.Name = "button3";
            button3.Size = new Size(117, 23);
            button3.TabIndex = 7;
            button3.Text = "Sil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // dataGridViewGiden
            // 
            dataGridViewGiden.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGiden.Location = new Point(0, 3);
            dataGridViewGiden.MultiSelect = false;
            dataGridViewGiden.Name = "dataGridViewGiden";
            dataGridViewGiden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGiden.Size = new Size(725, 214);
            dataGridViewGiden.TabIndex = 5;
            dataGridViewGiden.CellEnter += dataGridViewGiden_CellClick;
            dataGridViewGiden.CurrentCellChanged += dataGridViewGiden_SelectionChanged;
            // 
            // tabPageYaz
            // 
            tabPageYaz.BackColor = SystemColors.ActiveCaption;
            tabPageYaz.Controls.Add(rtbIcerik);
            tabPageYaz.Controls.Add(txtKonu);
            tabPageYaz.Controls.Add(button5);
            tabPageYaz.Controls.Add(label5);
            tabPageYaz.Controls.Add(label4);
            tabPageYaz.Controls.Add(label3);
            tabPageYaz.Controls.Add(cmbAlici);
            tabPageYaz.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabPageYaz.Location = new Point(4, 24);
            tabPageYaz.Name = "tabPageYaz";
            tabPageYaz.Padding = new Padding(3);
            tabPageYaz.Size = new Size(725, 367);
            tabPageYaz.TabIndex = 2;
            tabPageYaz.Text = "Mesaj Yaz";
            tabPageYaz.Click += tabPageYaz_Click;
            // 
            // rtbIcerik
            // 
            rtbIcerik.Location = new Point(139, 117);
            rtbIcerik.Name = "rtbIcerik";
            rtbIcerik.Size = new Size(503, 175);
            rtbIcerik.TabIndex = 9;
            rtbIcerik.Text = "";
            // 
            // txtKonu
            // 
            txtKonu.Location = new Point(140, 77);
            txtKonu.Name = "txtKonu";
            txtKonu.Size = new Size(217, 22);
            txtKonu.TabIndex = 8;
            // 
            // button5
            // 
            button5.Location = new Point(525, 298);
            button5.Name = "button5";
            button5.Size = new Size(117, 23);
            button5.TabIndex = 7;
            button5.Text = "Gönder";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(82, 119);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 3;
            label5.Text = "İçeriği :";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 80);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 2;
            label4.Text = "Konu :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 44);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 1;
            label3.Text = "Alıcı :";
            // 
            // cmbAlici
            // 
            cmbAlici.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlici.FormattingEnabled = true;
            cmbAlici.Location = new Point(139, 41);
            cmbAlici.Name = "cmbAlici";
            cmbAlici.Size = new Size(218, 23);
            cmbAlici.TabIndex = 0;
            // 
            // UC_Mesajlar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(tabControl1);
            Name = "UC_Mesajlar";
            Size = new Size(809, 447);
            Load += UC_Mesajlar_Load;
            tabControl1.ResumeLayout(false);
            tabPageGelen.ResumeLayout(false);
            tabPageGelen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGelen).EndInit();
            tabPageGiden.ResumeLayout(false);
            tabPageGiden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGiden).EndInit();
            tabPageYaz.ResumeLayout(false);
            tabPageYaz.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageGelen;
        private TabPage tabPageGiden;
        private TabPage tabPageYaz;
        private Button button2;
        private DataGridView dataGridViewGelen;
        private Label label1;
        private RichTextBox rtbIcerikGoruntule;
        private Label label2;
        private RichTextBox rtbIcerikGoruntule1;
        private Button button3;
        private DataGridView dataGridViewGiden;
        private Label label4;
        private Label label3;
        private ComboBox cmbAlici;
        private TextBox txtKonu;
        private Button button5;
        private Label label5;
        private RichTextBox rtbIcerik;
    }
}
