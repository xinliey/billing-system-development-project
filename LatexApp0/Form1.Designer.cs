namespace LatexApp0
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.latexprintbill = new System.Windows.Forms.ToolStripMenuItem();
            this.dryprintbill = new System.Windows.Forms.ToolStripMenuItem();
            this.carprintbill = new System.Windows.Forms.ToolStripMenuItem();
            this.billprintpanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.latexprintbill,
            this.dryprintbill,
            this.carprintbill});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // latexprintbill
            // 
            this.latexprintbill.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latexprintbill.Name = "latexprintbill";
            this.latexprintbill.Size = new System.Drawing.Size(131, 42);
            this.latexprintbill.Text = "บิลน้ำยาง";
            this.latexprintbill.Click += new System.EventHandler(this.latexprintbill_Click);
            // 
            // dryprintbill
            // 
            this.dryprintbill.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dryprintbill.Name = "dryprintbill";
            this.dryprintbill.Size = new System.Drawing.Size(118, 42);
            this.dryprintbill.Text = "บิลขี้ยาง";
            // 
            // carprintbill
            // 
            this.carprintbill.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carprintbill.Name = "carprintbill";
            this.carprintbill.Size = new System.Drawing.Size(88, 42);
            this.carprintbill.Text = "ค่ารถ";
            // 
            // billprintpanel
            // 
            this.billprintpanel.Location = new System.Drawing.Point(12, 49);
            this.billprintpanel.Name = "billprintpanel";
            this.billprintpanel.Size = new System.Drawing.Size(957, 902);
            this.billprintpanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 902);
            this.Controls.Add(this.billprintpanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem latexprintbill;
        private System.Windows.Forms.ToolStripMenuItem dryprintbill;
        private System.Windows.Forms.ToolStripMenuItem carprintbill;
        private System.Windows.Forms.Panel billprintpanel;
    }
}