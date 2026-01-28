namespace LatexApp0
{
    partial class EditCustomerUserControl
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
            this.cancelbtn = new System.Windows.Forms.Button();
            this.NewCustomerSaveBtn = new System.Windows.Forms.Button();
            this.customerremark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.preferred_payment = new System.Windows.Forms.ComboBox();
            this.CarFee = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EditEmployee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomerBossSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelbtn
            // 
            this.cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.Location = new System.Drawing.Point(548, 568);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(140, 47);
            this.cancelbtn.TabIndex = 34;
            this.cancelbtn.Text = "ยกเลิก";
            this.cancelbtn.UseVisualStyleBackColor = true;
            // 
            // NewCustomerSaveBtn
            // 
            this.NewCustomerSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerSaveBtn.Location = new System.Drawing.Point(694, 568);
            this.NewCustomerSaveBtn.Name = "NewCustomerSaveBtn";
            this.NewCustomerSaveBtn.Size = new System.Drawing.Size(140, 47);
            this.NewCustomerSaveBtn.TabIndex = 33;
            this.NewCustomerSaveBtn.Text = "บันทึก";
            this.NewCustomerSaveBtn.UseVisualStyleBackColor = true;
            this.NewCustomerSaveBtn.Click += new System.EventHandler(this.NewCustomerSaveBtn_Click);
            // 
            // customerremark
            // 
            this.customerremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerremark.Location = new System.Drawing.Point(224, 369);
            this.customerremark.Name = "customerremark";
            this.customerremark.Size = new System.Drawing.Size(610, 41);
            this.customerremark.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(83, 372);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 36);
            this.label6.TabIndex = 31;
            this.label6.Text = "หมายเหตุ";
            // 
            // preferred_payment
            // 
            this.preferred_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preferred_payment.FormattingEnabled = true;
            this.preferred_payment.Items.AddRange(new object[] {
            "100",
            "60_40",
            "50_50",
            "55_45"});
            this.preferred_payment.Location = new System.Drawing.Point(224, 277);
            this.preferred_payment.Name = "preferred_payment";
            this.preferred_payment.Size = new System.Drawing.Size(227, 44);
            this.preferred_payment.TabIndex = 28;
            // 
            // CarFee
            // 
            this.CarFee.AutoSize = true;
            this.CarFee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CarFee.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CarFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CarFee.Location = new System.Drawing.Point(491, 281);
            this.CarFee.Name = "CarFee";
            this.CarFee.Size = new System.Drawing.Size(107, 41);
            this.CarFee.TabIndex = 27;
            this.CarFee.Text = "ค่ารถ";
            this.CarFee.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(83, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 36);
            this.label5.TabIndex = 26;
            this.label5.Text = "แบ่ง";
            // 
            // EditEmployee
            // 
            this.EditEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditEmployee.Location = new System.Drawing.Point(224, 194);
            this.EditEmployee.Name = "EditEmployee";
            this.EditEmployee.Size = new System.Drawing.Size(610, 41);
            this.EditEmployee.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 36);
            this.label3.TabIndex = 24;
            this.label3.Text = "ลูกน้อง";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 36);
            this.label2.TabIndex = 23;
            this.label2.Text = "เถ้าแก่";
            // 
            // CustomerBossSearch
            // 
            this.CustomerBossSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerBossSearch.Location = new System.Drawing.Point(224, 113);
            this.CustomerBossSearch.Name = "CustomerBossSearch";
            this.CustomerBossSearch.Size = new System.Drawing.Size(610, 41);
            this.CustomerBossSearch.TabIndex = 22;
            this.CustomerBossSearch.TextChanged += new System.EventHandler(this.CustomerBossSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 38);
            this.label1.TabIndex = 21;
            this.label1.Text = "แก้ไขรายชื่อลูกค้า";
            // 
            // EditCustomerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.NewCustomerSaveBtn);
            this.Controls.Add(this.customerremark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.preferred_payment);
            this.Controls.Add(this.CarFee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EditEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CustomerBossSearch);
            this.Controls.Add(this.label1);
            this.Name = "EditCustomerUserControl";
            this.Size = new System.Drawing.Size(961, 758);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button NewCustomerSaveBtn;
        private System.Windows.Forms.TextBox customerremark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox preferred_payment;
        private System.Windows.Forms.CheckBox CarFee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EditEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CustomerBossSearch;
        private System.Windows.Forms.Label label1;
    }
}
