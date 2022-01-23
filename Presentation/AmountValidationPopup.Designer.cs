namespace PizzaBox_Receipt_Management.Presentation
{
    partial class AmountValidationPopup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRecepitAmount = new System.Windows.Forms.TextBox();
            this.txtGivenAmount = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReceiptReferene = new System.Windows.Forms.TextBox();
            this.txtSpecialDiscount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSpecialDiscountRate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscountedAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bill Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Given Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Balance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = ":- Rs.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = ":- Rs.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = ":- Rs.";
            // 
            // txtRecepitAmount
            // 
            this.txtRecepitAmount.Enabled = false;
            this.txtRecepitAmount.Location = new System.Drawing.Point(226, 47);
            this.txtRecepitAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecepitAmount.Name = "txtRecepitAmount";
            this.txtRecepitAmount.Size = new System.Drawing.Size(213, 22);
            this.txtRecepitAmount.TabIndex = 8;
            // 
            // txtGivenAmount
            // 
            this.txtGivenAmount.Location = new System.Drawing.Point(226, 197);
            this.txtGivenAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGivenAmount.Name = "txtGivenAmount";
            this.txtGivenAmount.Size = new System.Drawing.Size(213, 22);
            this.txtGivenAmount.TabIndex = 9;
            this.txtGivenAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGivenAmount_KeyPress);
            this.txtGivenAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtGivenAmount_KeyUp);
            // 
            // txtBalance
            // 
            this.txtBalance.Enabled = false;
            this.txtBalance.Location = new System.Drawing.Point(226, 248);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(213, 22);
            this.txtBalance.TabIndex = 10;
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(112, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 32);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cash Balance";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(336, 343);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 71);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Print";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(226, 343);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 71);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Reference";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = ":-";
            // 
            // txtReceiptReferene
            // 
            this.txtReceiptReferene.Location = new System.Drawing.Point(226, 297);
            this.txtReceiptReferene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiptReferene.MaxLength = 30;
            this.txtReceiptReferene.Name = "txtReceiptReferene";
            this.txtReceiptReferene.Size = new System.Drawing.Size(213, 22);
            this.txtReceiptReferene.TabIndex = 14;
            // 
            // txtSpecialDiscount
            // 
            this.txtSpecialDiscount.Location = new System.Drawing.Point(226, 96);
            this.txtSpecialDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSpecialDiscount.Name = "txtSpecialDiscount";
            this.txtSpecialDiscount.Size = new System.Drawing.Size(113, 22);
            this.txtSpecialDiscount.TabIndex = 17;
            this.txtSpecialDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpecialDiscount_KeyPress);
            this.txtSpecialDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSpecialDiscount_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = ":- Rs.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Special Discount";
            // 
            // txtSpecialDiscountRate
            // 
            this.txtSpecialDiscountRate.Location = new System.Drawing.Point(345, 96);
            this.txtSpecialDiscountRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSpecialDiscountRate.Name = "txtSpecialDiscountRate";
            this.txtSpecialDiscountRate.Size = new System.Drawing.Size(66, 22);
            this.txtSpecialDiscountRate.TabIndex = 18;
            this.txtSpecialDiscountRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpecialDiscountRate_KeyPress);
            this.txtSpecialDiscountRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSpecialDiscountRate_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(417, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 17);
            this.label12.TabIndex = 19;
            this.label12.Text = "%";
            // 
            // txtDiscountedAmount
            // 
            this.txtDiscountedAmount.Enabled = false;
            this.txtDiscountedAmount.Location = new System.Drawing.Point(226, 147);
            this.txtDiscountedAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountedAmount.Name = "txtDiscountedAmount";
            this.txtDiscountedAmount.Size = new System.Drawing.Size(213, 22);
            this.txtDiscountedAmount.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(178, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = ":- Rs.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "Discounted Amount";
            // 
            // AmountValidationPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 427);
            this.ControlBox = false;
            this.Controls.Add(this.txtDiscountedAmount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSpecialDiscountRate);
            this.Controls.Add(this.txtSpecialDiscount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtReceiptReferene);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtGivenAmount);
            this.Controls.Add(this.txtRecepitAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AmountValidationPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amount Validation";
            this.Load += new System.EventHandler(this.AmountValidationPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRecepitAmount;
        private System.Windows.Forms.TextBox txtGivenAmount;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReceiptReferene;
        private System.Windows.Forms.TextBox txtSpecialDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSpecialDiscountRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiscountedAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}