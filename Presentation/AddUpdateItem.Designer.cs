using System.Windows.Forms;

namespace PizzaBox_Receipt_Management.Presentation
{
    partial class AddUpdateItem
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
            this.ConfigItemPanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.lblDiscountedPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.ItemDetails = new System.Windows.Forms.Panel();
            this.productGridView = new System.Windows.Forms.DataGridView();
            this.titleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectPriceAdd = new System.Windows.Forms.Button();
            this.btnSelectPriceClear = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSelectCategory = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbSelectProduct = new System.Windows.Forms.ComboBox();
            this.cmbSelectSize = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gridViewSpecifications = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblShowSelectedProduct = new System.Windows.Forms.Label();
            this.btnResetSpec = new System.Windows.Forms.Button();
            this.ConfigItemPanel.SuspendLayout();
            this.ItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSpecifications)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfigItemPanel
            // 
            this.ConfigItemPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfigItemPanel.Controls.Add(this.label13);
            this.ConfigItemPanel.Controls.Add(this.btnAddUpdate);
            this.ConfigItemPanel.Controls.Add(this.btnClear);
            this.ConfigItemPanel.Controls.Add(this.label3);
            this.ConfigItemPanel.Controls.Add(this.label2);
            this.ConfigItemPanel.Controls.Add(this.label1);
            this.ConfigItemPanel.Controls.Add(this.cmbCategory);
            this.ConfigItemPanel.Controls.Add(this.lblCategory);
            this.ConfigItemPanel.Controls.Add(this.txtCode);
            this.ConfigItemPanel.Controls.Add(this.lblCode);
            this.ConfigItemPanel.Controls.Add(this.txtItemName);
            this.ConfigItemPanel.Controls.Add(this.lblName);
            this.ConfigItemPanel.Location = new System.Drawing.Point(-1, 0);
            this.ConfigItemPanel.Name = "ConfigItemPanel";
            this.ConfigItemPanel.Size = new System.Drawing.Size(547, 255);
            this.ConfigItemPanel.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 17);
            this.label13.TabIndex = 26;
            this.label13.Text = "Product Management";
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.Location = new System.Drawing.Point(444, 189);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(89, 57);
            this.btnAddUpdate.TabIndex = 16;
            this.btnAddUpdate.Text = "Add";
            this.btnAddUpdate.UseVisualStyleBackColor = true;
            this.btnAddUpdate.Click += new System.EventHandler(this.btnAddUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(349, 189);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 57);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = ":-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = ":-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = ":-";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(115, 29);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(189, 24);
            this.cmbCategory.TabIndex = 5;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 32);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 17);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Category";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(115, 91);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(189, 22);
            this.txtCode.TabIndex = 3;
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 94);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(41, 17);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Code";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(115, 61);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(340, 22);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyUp);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "%";
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.AutoSize = true;
            this.lblFinalPrice.Location = new System.Drawing.Point(125, 209);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(36, 17);
            this.lblFinalPrice.TabIndex = 18;
            this.lblFinalPrice.Text = "0.00";
            // 
            // lblDiscountedPrice
            // 
            this.lblDiscountedPrice.AutoSize = true;
            this.lblDiscountedPrice.Location = new System.Drawing.Point(7, 209);
            this.lblDiscountedPrice.Name = "lblDiscountedPrice";
            this.lblDiscountedPrice.Size = new System.Drawing.Size(112, 17);
            this.lblDiscountedPrice.TabIndex = 17;
            this.lblDiscountedPrice.Text = "Discount Price :-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = ":-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = ":- Rs.";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(118, 145);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(227, 22);
            this.txtDiscount.TabIndex = 9;
            this.txtDiscount.Click += new System.EventHandler(this.txtDiscount_Click);
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            this.txtDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyUp);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            this.txtDiscount.Validated += new System.EventHandler(this.txtPrice_Validated);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(7, 145);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(63, 17);
            this.lblDiscount.TabIndex = 8;
            this.lblDiscount.Text = "Discount";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(118, 117);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(253, 22);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.Click += new System.EventHandler(this.txtPrice_Click);
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyUp);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            this.txtPrice.Validated += new System.EventHandler(this.txtPrice_Validated);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(7, 120);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(40, 17);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price";
            // 
            // ItemDetails
            // 
            this.ItemDetails.Controls.Add(this.productGridView);
            this.ItemDetails.Location = new System.Drawing.Point(-1, 284);
            this.ItemDetails.Name = "ItemDetails";
            this.ItemDetails.Size = new System.Drawing.Size(1101, 435);
            this.ItemDetails.TabIndex = 1;
            // 
            // productGridView
            // 
            this.productGridView.AllowUserToAddRows = false;
            this.productGridView.AllowUserToDeleteRows = false;
            this.productGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.productGridView.ColumnHeadersHeight = 29;
            this.productGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.productGridView.Location = new System.Drawing.Point(7, 0);
            this.productGridView.Name = "productGridView";
            this.productGridView.RowHeadersWidth = 51;
            this.productGridView.RowTemplate.Height = 24;
            this.productGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.productGridView.Size = new System.Drawing.Size(1039, 432);
            this.productGridView.TabIndex = 0;
            this.productGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridItems_CellClick);
            // 
            // titleColumn
            // 
            this.titleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.titleColumn.HeaderText = "Config";
            this.titleColumn.MinimumWidth = 6;
            this.titleColumn.Name = "titleColumn";
            this.titleColumn.Width = 125;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSelectPriceAdd);
            this.panel1.Controls.Add(this.btnSelectPriceClear);
            this.panel1.Controls.Add(this.lblFinalPrice);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblDiscountedPrice);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbSelectCategory);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cmbSelectProduct);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbSelectSize);
            this.panel1.Controls.Add(this.lblSize);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.lblDiscount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Location = new System.Drawing.Point(553, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 255);
            this.panel1.TabIndex = 2;
            // 
            // btnSelectPriceAdd
            // 
            this.btnSelectPriceAdd.Location = new System.Drawing.Point(442, 189);
            this.btnSelectPriceAdd.Name = "btnSelectPriceAdd";
            this.btnSelectPriceAdd.Size = new System.Drawing.Size(89, 57);
            this.btnSelectPriceAdd.TabIndex = 18;
            this.btnSelectPriceAdd.Text = "Add";
            this.btnSelectPriceAdd.UseVisualStyleBackColor = true;
            this.btnSelectPriceAdd.Click += new System.EventHandler(this.btnSelectPriceAdd_Click);
            // 
            // btnSelectPriceClear
            // 
            this.btnSelectPriceClear.Location = new System.Drawing.Point(347, 189);
            this.btnSelectPriceClear.Name = "btnSelectPriceClear";
            this.btnSelectPriceClear.Size = new System.Drawing.Size(89, 57);
            this.btnSelectPriceClear.TabIndex = 17;
            this.btnSelectPriceClear.Text = "Clear";
            this.btnSelectPriceClear.UseVisualStyleBackColor = true;
            this.btnSelectPriceClear.Click += new System.EventHandler(this.btnSelectPriceClear_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(70, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = ":-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = ":-";
            // 
            // cmbSelectCategory
            // 
            this.cmbSelectCategory.FormattingEnabled = true;
            this.cmbSelectCategory.Location = new System.Drawing.Point(94, 27);
            this.cmbSelectCategory.Name = "cmbSelectCategory";
            this.cmbSelectCategory.Size = new System.Drawing.Size(277, 24);
            this.cmbSelectCategory.TabIndex = 21;
            this.cmbSelectCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSelectCategory_SelectedIndexChanged);
            this.cmbSelectCategory.Leave += new System.EventHandler(this.cmbSelectCategory_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Category";
            // 
            // cmbSelectProduct
            // 
            this.cmbSelectProduct.FormattingEnabled = true;
            this.cmbSelectProduct.Location = new System.Drawing.Point(94, 57);
            this.cmbSelectProduct.Name = "cmbSelectProduct";
            this.cmbSelectProduct.Size = new System.Drawing.Size(277, 24);
            this.cmbSelectProduct.TabIndex = 24;
            this.cmbSelectProduct.SelectedIndexChanged += new System.EventHandler(this.cmbSelectProduct_SelectedIndexChanged);
            this.cmbSelectProduct.Leave += new System.EventHandler(this.cmbSelectProduct_Leave);
            // 
            // cmbSelectSize
            // 
            this.cmbSelectSize.FormattingEnabled = true;
            this.cmbSelectSize.Location = new System.Drawing.Point(94, 87);
            this.cmbSelectSize.Name = "cmbSelectSize";
            this.cmbSelectSize.Size = new System.Drawing.Size(277, 24);
            this.cmbSelectSize.TabIndex = 24;
            this.cmbSelectSize.SelectedIndexChanged += new System.EventHandler(this.cmbSelectSize_SelectedIndexChanged);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(7, 89);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(35, 17);
            this.lblSize.TabIndex = 23;
            this.lblSize.Text = "Size";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(70, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = ":-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Product";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Price Management";
            // 
            // gridViewSpecifications
            // 
            this.gridViewSpecifications.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridViewSpecifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewSpecifications.Location = new System.Drawing.Point(1051, 284);
            this.gridViewSpecifications.Name = "gridViewSpecifications";
            this.gridViewSpecifications.RowHeadersWidth = 51;
            this.gridViewSpecifications.RowTemplate.Height = 24;
            this.gridViewSpecifications.Size = new System.Drawing.Size(763, 432);
            this.gridViewSpecifications.TabIndex = 3;
            this.gridViewSpecifications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewSpecifications_CellClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 264);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Product Table";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1103, 264);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(181, 17);
            this.label15.TabIndex = 5;
            this.label15.Text = "Product Specification Table";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1311, 264);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "Selected Product is :- ";
            // 
            // lblShowSelectedProduct
            // 
            this.lblShowSelectedProduct.AutoSize = true;
            this.lblShowSelectedProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowSelectedProduct.ForeColor = System.Drawing.Color.Brown;
            this.lblShowSelectedProduct.Location = new System.Drawing.Point(1451, 264);
            this.lblShowSelectedProduct.Name = "lblShowSelectedProduct";
            this.lblShowSelectedProduct.Size = new System.Drawing.Size(0, 17);
            this.lblShowSelectedProduct.TabIndex = 7;
            // 
            // btnResetSpec
            // 
            this.btnResetSpec.Location = new System.Drawing.Point(1651, 722);
            this.btnResetSpec.Name = "btnResetSpec";
            this.btnResetSpec.Size = new System.Drawing.Size(163, 45);
            this.btnResetSpec.TabIndex = 8;
            this.btnResetSpec.Text = "Reset Specifications";
            this.btnResetSpec.UseVisualStyleBackColor = true;
            this.btnResetSpec.Click += new System.EventHandler(this.btnResetSpec_Click);
            // 
            // AddUpdateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1020);
            this.Controls.Add(this.btnResetSpec);
            this.Controls.Add(this.lblShowSelectedProduct);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.gridViewSpecifications);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ItemDetails);
            this.Controls.Add(this.ConfigItemPanel);
            this.MinimizeBox = false;
            this.Name = "AddUpdateItem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Manage Items";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddUpdateItem_Load);
            this.ConfigItemPanel.ResumeLayout(false);
            this.ConfigItemPanel.PerformLayout();
            this.ItemDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSpecifications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ConfigItemPanel;
        private System.Windows.Forms.Panel ItemDetails;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.Label lblDiscountedPrice;
        private DataGridViewTextBoxColumn titleColumn;
        private DataGridView productGridView;
        private Label label6;
        private Panel panel1;
        private Label label7;
        private ComboBox cmbSelectProduct;
        private Label lblSize;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button btnSelectPriceAdd;
        private Button btnSelectPriceClear;
        private Label label11;
        private ComboBox cmbSelectCategory;
        private Label label12;
        private Label label13;
        private DataGridView gridViewSpecifications;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label lblShowSelectedProduct;
        private Button btnResetSpec;
        private ComboBox cmbSelectSize;
    }
}