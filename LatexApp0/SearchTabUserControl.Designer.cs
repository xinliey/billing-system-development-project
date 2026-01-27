namespace LatexApp0
{
    partial class SearchTabUserControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.SearchNameText = new System.Windows.Forms.TextBox();
            this.searchreporttextbox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(660, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "ค้นหา";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SearchNameText
            // 
            this.SearchNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchNameText.Location = new System.Drawing.Point(45, 86);
            this.SearchNameText.Name = "SearchNameText";
            this.SearchNameText.Size = new System.Drawing.Size(599, 38);
            this.SearchNameText.TabIndex = 3;
            this.SearchNameText.TextChanged += new System.EventHandler(this.SearchNameText_TextChanged);
            // 
            // searchreporttextbox
            // 
            this.searchreporttextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchreporttextbox.Location = new System.Drawing.Point(45, 149);
            this.searchreporttextbox.Name = "searchreporttextbox";
            this.searchreporttextbox.Size = new System.Drawing.Size(854, 656);
            this.searchreporttextbox.TabIndex = 4;
            this.searchreporttextbox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "ค้นหาข้อมูลลูกค้า";
            // 
            // SearchTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchreporttextbox);
            this.Controls.Add(this.SearchNameText);
            this.Controls.Add(this.button1);
            this.Name = "SearchTabUserControl";
            this.Size = new System.Drawing.Size(949, 825);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SearchNameText;
        private System.Windows.Forms.RichTextBox searchreporttextbox;
        private System.Windows.Forms.Label label1;
    }
}
