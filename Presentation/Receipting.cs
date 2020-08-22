using Newtonsoft.Json;
using PizzaBox_Receipt_Management.BLL;
using PizzaBox_Receipt_Management.Models;
using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PizzaBox_Receipt_Management.Enums.CommonEnums;

namespace PizzaBox_Receipt_Management.Presentation
{
    public partial class Receipting : Form
    {
        bool isBusinessPartnerAvailable = false;
        bool isReceiptFormEnable = false;
        BusinessPartnerVM selectedBSP = new BusinessPartnerVM();
        IEnumerable<MultiPurposeTagVM> SizeList;
        IEnumerable<MultiPurposeTagVM> SelectedSizeList;
        IEnumerable<MultiPurposeTagVM> CategoryList;
        IEnumerable<MultiPurposeTagVM> StatusList;
        IEnumerable<MultiPurposeTagVM> PortionList;
        IEnumerable<BusinessPartnerContactDetails> contacts;
        List<ProductVM> products;
        DataTable receiptTable;
        public Receipting()
        {
            InitializeComponent();
            this.SizeList = new List<MultiPurposeTagVM>();
            this.CategoryList = new List<MultiPurposeTagVM>();
            this.StatusList = new List<MultiPurposeTagVM>();
            this.PortionList = new List<MultiPurposeTagVM>();
            this.products = new List<ProductVM>();
            this.SelectedSizeList = new List<MultiPurposeTagVM>();
        }

        private void Receipting_Load(object sender, EventArgs e)
        {
            this.contacts = new List<BusinessPartnerContactDetails>();
            
            this.BusinessPartnerFormFieldValidation();
            this.ProductFormFieldValidation();

            this.getProductMasterData();
            this.initializeCustomerForm();
            this.initializeProductDropdowns();
            this.initializeReceptTable();
            this.btnSubmitAll.Enabled = false;
        }

        private void getProductMasterData()
        {
            using (CommonServiceBLL commonServiceBLL = new CommonServiceBLL())
            {
                CommonDataResponse commonDataResponse = commonServiceBLL.GetMasterData();
                this.SizeList = commonDataResponse.Sizes;
                this.CategoryList = commonDataResponse.Categories;
                this.StatusList = commonDataResponse.Status;
                this.PortionList = commonDataResponse.Portions;
                this.getProducts();
                
            }
        }

        private void initializeProductDropdowns()
        {
            // Set combobox data
            cmbSize.DisplayMember = cmbSelectCategory.DisplayMember = cmbSelectCategory.DisplayMember = "Name";
            cmbSize.ValueMember = cmbSelectCategory.ValueMember = cmbSelectCategory.ValueMember = "Data";
            cmbSelectProduct.DisplayMember = "Name";
            cmbSelectProduct.ValueMember = "Id";
            cmbSelectCategory.DataSource = CategoryList;
            cmbSize.DataSource = StatusList;
            cmbSelectCategory.SelectedIndex = 0;
            cmbSelectProduct.SelectedIndex = -1;
            cmbSize.SelectedIndex = -1;
            cmbSelectCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSize.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void initializeCustomerForm()
        {
            cmbPhoneNumber.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            cmbPhoneNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPhoneNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            ProductVM product = (ProductVM)cmbSelectProduct.SelectedItem;
            if(product.PriceList.Count() == 0)
            {
                MessageBox.Show("Please define price before add");
                return;
            }
            
            ProductPriceVM productPrice = product.PriceList.First(price => price.mpt_SizeEnum == (int)cmbSize.SelectedValue);
            decimal discountedPrice = productPrice.Price * (100 - productPrice.Discount) / 100;
            decimal totalPrice = Convert.ToInt32(txtSelectQuantity.Text) * discountedPrice;
            DataRow itemDataRow = this.receiptTable.NewRow();
            itemDataRow[0] = product.CategoryName;
            itemDataRow[1] = product.Name;
            itemDataRow[2] = cmbSize.Text;
            itemDataRow[3] = txtSelectQuantity.Text;
            itemDataRow[4] = String.Format("{0:0.00}", productPrice.Price);
            itemDataRow[5] = productPrice.Discount;
            itemDataRow[6] = String.Format("{0:0.00}", discountedPrice);
            itemDataRow[7] = String.Format("{0:0.00}", totalPrice); 
            itemDataRow[8] = JsonConvert.SerializeObject(product);
            itemDataRow[9] = JsonConvert.SerializeObject(productPrice);
            this.receiptTable.Rows.Add(itemDataRow);
            this.clearProductFormAddBtn();
        }

        private void initializeReceptTable()
        {
            receiptTable = new DataTable();
            receiptTable.Columns.Add("Product Category");
            receiptTable.Columns.Add("Product Name");
            receiptTable.Columns.Add("Size");
            receiptTable.Columns.Add("Quantity");
            receiptTable.Columns.Add("Item Price");
            receiptTable.Columns.Add("Discount");
            receiptTable.Columns.Add("Discounted Price");
            receiptTable.Columns.Add("Total");
            receiptTable.Columns.Add("Product");
            receiptTable.Columns.Add("ProductPrice");

            receiptGridView.DataSource = receiptTable;
            receiptGridView.Columns["Product"].Visible = false;
            receiptGridView.Columns["ProductPrice"].Visible = false;

            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            receiptGridView.Columns.Add(deleteButton);

            receiptGridView.Columns[0].Width = 130;
            receiptGridView.Columns[1].Width = 130;
            receiptGridView.Columns[2].Width = 100;
            receiptGridView.Columns[3].Width = 100;
            receiptGridView.Columns[4].Width = 100;
            receiptGridView.Columns[5].Width = 75;
            receiptGridView.Columns[6].Width = 120;
            receiptGridView.Columns[7].Width = 120;

            receiptTable.RowChanged += new DataRowChangeEventHandler(OnReceiptRowChanged);
        }

        private void getProducts()
        {
            using (ProductBLL productBll = new ProductBLL())
            {
                this.products = productBll.GetProducts();
            }
        }

        private void BusinessPartnerFormFieldValidation()
        {
            this.txtName.Enabled = this.txtAddress.Enabled = this.cmbPhoneNumber.SelectedIndex != -1 || this.cmbPhoneNumber.Text.Trim().Length >= 10;
            this.btnCustomerAdd.Enabled = this.txtAddress.Text.Length > 0;
        }

        private void ProductFormFieldValidation()
        {
            this.cmbSelectCategory.Enabled = isReceiptFormEnable;
            this.cmbSelectProduct.Enabled = this.cmbSelectCategory.SelectedIndex > -1 && this.cmbSelectCategory.Enabled;
            this.cmbSize.Enabled = this.cmbSelectProduct.SelectedIndex > -1;
            this.txtSelectQuantity.Enabled = this.cmbSize.SelectedIndex > -1;
            this.btnProductAdd.Enabled = this.txtSelectQuantity.Text.Length > 0;
        }

        private void cmbPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cmbPhoneNumber.Text.Trim();
            if (text.Length > 3)
            {
                using(ReceiptBLL recipt = new ReceiptBLL())
                {
                    this.contacts = recipt.GetContact(text);
                    string[] stringContact = this.contacts.Select(contact => contact.PhoneNumber).ToArray();
                    if (stringContact.Length > 0)
                    {
                        cmbPhoneNumber.AutoCompleteCustomSource.AddRange(stringContact);
                    }
                }
            }
            if (e.KeyCode == Keys.Enter &&
                text.Length > 9)
            {
                this.phoneNumberValidateValue();
                this.BusinessPartnerFormFieldValidation();
                this.txtName.Focus();
            }
        }

        private void cmbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            isReceiptFormEnable = false;
            if (!isBusinessPartnerAvailable) {
                if (txtName.Text.Trim().Length > 0 &&
                    txtAddress.Text.Trim().Length > 0 &&
                    cmbPhoneNumber.Text.Trim().Length >= 10 &&
                    cmbPhoneNumber.Text.Trim().Length <= 12)
                {
                    BusinessPartnerVM bspVM = new BusinessPartnerVM() {
                        contacts = new List<BusinessPartnerContactDetails>(),
                        addresses = new List<BusinessPartnerAddressDetails>()
                    };
                    BusinessPartnerContactDetails bspContactVM;
                    BusinessPartnerAddressDetails bspAddressVM = new BusinessPartnerAddressDetails();
                    bspContactVM = this.contacts.Where(selectContact => selectContact.PhoneNumber.Trim().ToUpper() == cmbPhoneNumber.Text.Trim().ToUpper()).FirstOrDefault();
                    if (bspContactVM != null)
                    {
                        bspVM.Id = bspContactVM.BusinessPartnerId;                       
                        bspVM.mpt_StatusEnum = (int)BusinessPartnerStatusEnum.Active;                        
                        bspAddressVM.Id = this.selectedBSP.addresses.FirstOrDefault().Id;                        
                    } else
                    {
                        bspContactVM = new BusinessPartnerContactDetails();
                        bspAddressVM = new BusinessPartnerAddressDetails();
                        bspContactVM.Id = 0;
                        bspContactVM.PhoneNumber = cmbPhoneNumber.Text;
                        bspContactVM.Email = "";
                        bspAddressVM.Id = 0;
                    }
                    bspVM.Name = txtName.Text;
                    bspAddressVM.Address = txtAddress.Text;

                    bspVM.contacts = bspVM.contacts.Append(bspContactVM);
                    bspVM.addresses = bspVM.addresses.Append(bspAddressVM);

                    using (ReceiptBLL receipt = new ReceiptBLL())
                    {
                        BusinessPartnerResponse bspResponse = receipt.ManageBusinessPartner(bspVM);
                        bspVM.Id = bspResponse.BusinessPartnerId;

                        bspContactVM = (from contact in bspVM.contacts
                                       select contact).FirstOrDefault();

                        bspAddressVM = (from address in bspVM.addresses
                                        select address).FirstOrDefault();
                        bspContactVM.BusinessPartnerId = bspResponse.BusinessPartnerId;
                        bspContactVM.Id = bspResponse.ContactId;
                        bspAddressVM.BusinessPartnerId = bspResponse.BusinessPartnerId;
                        bspAddressVM.Id = bspResponse.AddressId;

                        this.selectedBSP = bspVM;
                        this.setBspLables(this.selectedBSP);
                        this.btnCustomerAdd.Enabled = false;
                        this.btnCustomerReset.Enabled = false;
                    }
                } else
                {
                    MessageBox.Show("Mandatory fields are missing");
                }
            } else
            {
                this.setBspLables(this.selectedBSP);
            }
        }

        private void setBspLables(BusinessPartnerVM businessPartner)
        {
            isReceiptFormEnable = true;
            lblSelectedName.Text = businessPartner.Name;
            lblSelectedPhoneNumber.Text = businessPartner.contacts.First().PhoneNumber;
            lblSelectedAddress.Text = businessPartner.addresses.First().Address;
            ProductFormFieldValidation();
            cmbPhoneNumber.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
        }

        private void cmbPhoneNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.phoneNumberValidateValue();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCustomerAdd.Focus();
            }
        }

        private void cmbSelectCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = 0;
            ComboBox cmbSelectedCategory = (ComboBox)sender;
            int selectedIndex = cmbSelectedCategory.SelectedIndex;
            if (selectedIndex != -1)
                selectedValue = (int)cmbSelectedCategory.SelectedValue;
            List<ProductVM> filterdPorduct = this.products.FindAll(product => product.mpt_CategoryEnum == selectedValue);

            this.cmbSelectProduct.DataSource = filterdPorduct;
            this.ProductFormFieldValidation();
        }

        private void cmbSelectProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = 0;
            SelectedSizeList = this.SizeList;
            ComboBox cmbProduct = (ComboBox)sender;
            int selectedIndex = cmbProduct.SelectedIndex;
            if (selectedIndex != -1)
                selectedValue = (int)cmbProduct.SelectedValue;
            ProductVM filterdPorduct = this.products.Find(product => product.Id == selectedValue);
            if (filterdPorduct != null)
            {
                foreach (ProductPriceVM size in filterdPorduct.PriceList)
                {
                    if (size.mpt_SizeEnum != 0)
                        this.SelectedSizeList = this.SelectedSizeList.Where(selectSize => selectSize.Data == size.mpt_SizeEnum).ToList();
                }
            }
            this.cmbSize.DataSource = this.SelectedSizeList;
            this.ProductFormFieldValidation();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ProductFormFieldValidation();
        }

        private void txtSelectQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnProductAdd.Focus();
            }
        }

        private void phoneNumberValidateValue()
        {
            this.BusinessPartnerFormFieldValidation();
            using (ReceiptBLL receipt = new ReceiptBLL())
            {
                BusinessPartnerContactDetails contact = this.contacts.Where(selectContact => selectContact.PhoneNumber.Trim().ToUpper() == cmbPhoneNumber.Text.Trim().ToUpper()).FirstOrDefault();
                if (contact != null)
                {
                    this.selectedBSP = receipt.GetBusinessPartnerByBSPId(contact.BusinessPartnerId);

                    txtName.Text = this.selectedBSP.Name;
                    txtAddress.Text = this.selectedBSP.addresses.First().Address;
                }
            }
        }

        private void txtSelectQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text.Trim().Length > 0)
                this.ProductFormFieldValidation();
        }

        private void receiptGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == receiptGridView.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == receiptGridView.Columns["dataGridViewDeleteButton"].Index)
            {
                receiptGridView.Rows.Remove(receiptGridView.Rows[e.RowIndex]);
            }
        }

        private void btnProductReset_Click(object sender, EventArgs e)
        {
            this.clearProductForm();
            this.resetTable();
        }
        private void clearProductFormAddBtn()
        {
            cmbSelectCategory.SelectedIndex = 0;
            cmbSelectProduct.SelectedIndex = -1;
            cmbSize.SelectedIndex = -1;
            txtSelectQuantity.ResetText();
            btnProductAdd.Enabled = false;
        }

        private void clearProductForm()
        {
            this.clearProductFormAddBtn();
            btnProductAdd.Enabled = false;
            this.bspFormReset();
            this.resetBspLables();
        }

        private void btnSubmitAll_Click(object sender, EventArgs e)
        {
            ProductReceiptMapVM tempProductReceipt = new ProductReceiptMapVM();
            ReceiptVM receipt = new ReceiptVM() {
                Id = 0,
                BSPId = this.selectedBSP.Id,
                Remark = "",
                Products = new List<ProductReceiptMapVM>()
            };

            foreach (DataGridViewRow row in receiptGridView.Rows)
            {
                ProductVM product = JsonConvert.DeserializeObject<ProductVM>(row.Cells[9].Value.ToString());
                receipt.TotalAmount += Convert.ToDecimal(row.Cells[8].Value);
                tempProductReceipt.ProductId = product.Id;
                tempProductReceipt.ReceiptId = 0;
                tempProductReceipt.Quantity = Convert.ToInt32(row.Cells[4].Value);
                receipt.Products = receipt.Products.Append(tempProductReceipt).ToList();
            }

            using (var amountValidation = new AmountValidationPopup(receipt, this))
            {
                var result = amountValidation.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int returnValue = amountValidation.retrunValue; 

                    if (returnValue > 0)
                    {
                        this.clearProductForm();
                        this.ProductFormFieldValidation();
                        isReceiptFormEnable = false;
                        cmbPhoneNumber.Enabled = true;
                        txtName.Enabled = true;
                        txtAddress.Enabled = true;
                        this.initializeProductDropdowns();
                        this.initializeReceptTable();
                        this.bspFormReset();
                        this.resetTable();

                    } else
                    {
                        MessageBox.Show("Some error happen. Please try again");
                    }
                }
            }         

        }

        private void btnCustomerReset_Click(object sender, EventArgs e)
        {
            this.bspFormReset();
        }

        private void bspFormReset()
        {
            cmbPhoneNumber.AutoCompleteCustomSource = null;
            cmbPhoneNumber.Text = "";
            txtAddress.Clear();
            txtName.Clear();
            btnCustomerReset.Enabled = true;
            this.BusinessPartnerFormFieldValidation();
        }

        private void resetBspLables()
        {
            isReceiptFormEnable = false;
            lblSelectedName.ResetText();
            lblSelectedPhoneNumber.ResetText();
            lblSelectedAddress.ResetText();
            ProductFormFieldValidation();
            cmbPhoneNumber.Enabled = true;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            cmbSelectCategory.Enabled = false;
            cmbSelectProduct.Enabled = false;
        }

        private void resetTable()
        {
            this.receiptTable.Rows.Clear();
            btnSubmitAll.Enabled = false;
        }

        protected void OnReceiptRowChanged(object sender, DataRowChangeEventArgs args)
        {
            if (args.Action != DataRowAction.Nothing && this.receiptTable.Rows.Count > 0)
            {
                btnSubmitAll.Enabled = true;
            } else
            {
                btnSubmitAll.Enabled = false;
            }

        }
    }
}
