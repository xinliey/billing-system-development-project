namespace LatexApp0
{
    partial class RecordSearchUserControl
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.netweightrecord = new System.Windows.Forms.TextBox();
            this.latexrecord = new System.Windows.Forms.TextBox();
            this.dryrecord = new System.Windows.Forms.TextBox();
            this.totalcostrecord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 38);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "บิลวันที่";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "น้ำหนักรวม";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "รวมบิลน้ำยาง";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "รวมบิลขี้ยาง";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 36);
            this.label5.TabIndex = 5;
            this.label5.Text = "รวมยอดเงิน";
            // 
            // netweightrecord
            // 
            this.netweightrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netweightrecord.Location = new System.Drawing.Point(258, 126);
            this.netweightrecord.Name = "netweightrecord";
            this.netweightrecord.Size = new System.Drawing.Size(283, 41);
            this.netweightrecord.TabIndex = 6;
            // 
            // latexrecord
            // 
            this.latexrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latexrecord.Location = new System.Drawing.Point(258, 212);
            this.latexrecord.Name = "latexrecord";
            this.latexrecord.Size = new System.Drawing.Size(283, 41);
            this.latexrecord.TabIndex = 7;
            // 
            // dryrecord
            // 
            this.dryrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dryrecord.Location = new System.Drawing.Point(258, 306);
            this.dryrecord.Name = "dryrecord";
            this.dryrecord.Size = new System.Drawing.Size(283, 41);
            this.dryrecord.TabIndex = 8;
            // 
            // totalcostrecord
            // 
            this.totalcostrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalcostrecord.Location = new System.Drawing.Point(258, 408);
            this.totalcostrecord.Name = "totalcostrecord";
            this.totalcostrecord.Size = new System.Drawing.Size(283, 41);
            this.totalcostrecord.TabIndex = 9;
            // 
            // RecordSearchUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.totalcostrecord);
            this.Controls.Add(this.dryrecord);
            this.Controls.Add(this.latexrecord);
            this.Controls.Add(this.netweightrecord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "RecordSearchUserControl";
            this.Size = new System.Drawing.Size(908, 697);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox netweightrecord;
        private System.Windows.Forms.TextBox latexrecord;
        private System.Windows.Forms.TextBox dryrecord;
        private System.Windows.Forms.TextBox totalcostrecord;
    }
}
