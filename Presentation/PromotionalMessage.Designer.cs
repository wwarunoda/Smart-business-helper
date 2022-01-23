namespace PizzaBox_Receipt_Management.Presentation
{
    partial class PromotionalMessage
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
            this.lblContacts = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gridContact = new System.Windows.Forms.DataGridView();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSubmitChanges = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalContacts = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMessageLenght = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridContact)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContacts
            // 
            this.lblContacts.AutoSize = true;
            this.lblContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContacts.Location = new System.Drawing.Point(287, 29);
            this.lblContacts.Name = "lblContacts";
            this.lblContacts.Size = new System.Drawing.Size(135, 32);
            this.lblContacts.TabIndex = 12;
            this.lblContacts.Text = "Contacts";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(1160, 29);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(137, 32);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "Message";
            // 
            // gridContact
            // 
            this.gridContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContact.Location = new System.Drawing.Point(36, 89);
            this.gridContact.Name = "gridContact";
            this.gridContact.RowHeadersWidth = 51;
            this.gridContact.RowTemplate.Height = 24;
            this.gridContact.Size = new System.Drawing.Size(970, 571);
            this.gridContact.TabIndex = 14;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(1024, 89);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(394, 297);
            this.txtMessage.TabIndex = 15;
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(1296, 402);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(122, 52);
            this.btnSendMessage.TabIndex = 16;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1296, 680);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 52);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSubmitChanges
            // 
            this.btnSubmitChanges.Location = new System.Drawing.Point(884, 680);
            this.btnSubmitChanges.Name = "btnSubmitChanges";
            this.btnSubmitChanges.Size = new System.Drawing.Size(122, 52);
            this.btnSubmitChanges.TabIndex = 18;
            this.btnSubmitChanges.Text = "Submit Changes";
            this.btnSubmitChanges.UseVisualStyleBackColor = true;
            this.btnSubmitChanges.Click += new System.EventHandler(this.btnSubmitChanges_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(756, 680);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(122, 52);
            this.btnExcel.TabIndex = 19;
            this.btnExcel.Text = "Save Clipboard";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 698);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Total Contacts: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 698);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Messageable Contacts: ";
            // 
            // lblTotalContacts
            // 
            this.lblTotalContacts.AutoSize = true;
            this.lblTotalContacts.Location = new System.Drawing.Point(162, 698);
            this.lblTotalContacts.Name = "lblTotalContacts";
            this.lblTotalContacts.Size = new System.Drawing.Size(107, 17);
            this.lblTotalContacts.TabIndex = 22;
            this.lblTotalContacts.Text = "Total Contacts: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(477, 698);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Total Contacts: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1024, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Lenght: ";
            // 
            // lblMessageLenght
            // 
            this.lblMessageLenght.AutoSize = true;
            this.lblMessageLenght.Location = new System.Drawing.Point(1099, 421);
            this.lblMessageLenght.Name = "lblMessageLenght";
            this.lblMessageLenght.Size = new System.Drawing.Size(16, 17);
            this.lblMessageLenght.TabIndex = 25;
            this.lblMessageLenght.Text = "0";
            // 
            // PromotionalMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 789);
            this.ControlBox = false;
            this.Controls.Add(this.lblMessageLenght);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalContacts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSubmitChanges);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.gridContact);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblContacts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromotionalMessage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PromotionalMessage";
            this.Load += new System.EventHandler(this.PromotionalMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContacts;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.DataGridView gridContact;
        private System.Windows.Forms.Button btnSubmitChanges;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalContacts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMessageLenght;
    }
}