namespace StajSIS
{
    partial class Anaform
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
            PanelMain = new Panel();
            SuspendLayout();
            // 
            // PanelMain
            // 
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Location = new Point(0, 0);
            PanelMain.Name = "PanelMain";
            PanelMain.Size = new Size(1023, 541);
            PanelMain.TabIndex = 0;
            // 
            // Anaform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 541);
            Controls.Add(PanelMain);
            Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Anaform";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "STAJSIS";
            Load += Anaform_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMain;
    }
}