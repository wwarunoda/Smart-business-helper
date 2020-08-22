using PizzaBox_Receipt_Management.BLL;
using PizzaBox_Receipt_Management.DML;
using PizzaBox_Receipt_Management.Enums;
using PizzaBox_Receipt_Management.Models;
using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Forms;

namespace PizzaBox_Receipt_Management.Presentation
{
    public partial class AddUpdateItem : Form
    {
        DataTable productTable;
        DataTable priceTable;
        // member variable used to keep dollar value
        private Decimal mDollarValue;
        int productId = 0;
        int priceId = 0;
        bool isProductUpdate = false;
        bool isPriceUpdate = false;
        IEnumerable<MultiPurposeTagVM> SizeList;
        IEnumerable<MultiPurposeTagVM> SelectedSizeList;
        IEnumerable<MultiPurposeTagVM> CategoryList;
        IEnumerable<MultiPurposeTagVM> StatusList;
        IEnumerable<MultiPurposeTagVM> PortionList;
        List<ProductVM> products;
        DataGridViewRow updatedRow;
        public AddUpdateItem()
        {
            InitializeComponent();
            this.SizeList = new List<MultiPurposeTagVM>();
            this.CategoryList = new List<MultiPurposeTagVM>();
            this.StatusList = new List<MultiPurposeTagVM>();
            this.PortionList = new List<MultiPurposeTagVM>();
            this.products = new List<ProductVM>();
            this.SelectedSizeList = new List<MultiPurposeTagVM>();
        }
        // default OnPaint

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        private void AddUpdateItem_Load(object sender, EventArgs e)
        { 
            this.productTable = new DataTable();
            this.priceTable = new DataTable();

            productTable.Columns.Add("Name");
            productTable.Columns.Add("Code");
            productTable.Columns.Add("Category");
            productTable.Columns.Add("Id");
            productTable.Columns.Add("CategoryEnum");

            priceTable.Columns.Add("Size");
            priceTable.Columns.Add("Price (Rs.)");
            priceTable.Columns.Add("Discount (%)");
            priceTable.Columns.Add("Discounted Price (Rs.)");
            priceTable.Columns.Add("SizeEnum");
            priceTable.Columns.Add("ProductId");
            priceTable.Columns.Add("Id");

            productGridView.DataSource = productTable;
            gridViewSpecifications.DataSource = priceTable;

            productGridView.Columns["Id"].Visible = false;
            productGridView.Columns["CategoryEnum"].Visible = false;
            gridViewSpecifications.Columns["SizeEnum"].Visible = false;
            gridViewSpecifications.Columns["ProductId"].Visible = false;
            gridViewSpecifications.Columns["Id"].Visible = false;

            var viewButton = new DataGridViewButtonColumn();
            viewButton.Name = "dataGridViewButton";
            viewButton.HeaderText = "View";
            viewButton.Text = "View";
            viewButton.UseColumnTextForButtonValue = true;
            productGridView.Columns.Add(viewButton);

            var editButton = new DataGridViewButtonColumn();
            editButton.Name = "dataGridViewEditButton";
            editButton.HeaderText = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            productGridView.Columns.Add(editButton);

            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            productGridView.Columns.Add(deleteButton);

            var specEditButton = new DataGridViewButtonColumn();
            specEditButton.Name = "specificationEditButton";
            specEditButton.HeaderText = "Edit";
            specEditButton.Text = "Edit";
            specEditButton.UseColumnTextForButtonValue = true;
            gridViewSpecifications.Columns.Add(specEditButton);

            var specDeleteButton = new DataGridViewButtonColumn();
            specDeleteButton.Name = "specificationDeleteButton";
            specDeleteButton.HeaderText = "Delete";
            specDeleteButton.Text = "Delete";
            specDeleteButton.UseColumnTextForButtonValue = true;
            gridViewSpecifications.Columns.Add(specDeleteButton);

            productGridView.Columns[0].Width = 210;
            productGridView.Columns[1].Width = 155;
            productGridView.Columns[2].Width = 150;

            gridViewSpecifications.Columns[0].Width = 115;
            gridViewSpecifications.Columns[1].Width = 80;
            gridViewSpecifications.Columns[2].Width = 80;
            gridViewSpecifications.Columns[3].Width = 80;

            using (CommonServiceBLL commonServiceBLL = new CommonServiceBLL())
            {
                CommonDataResponse commonDataResponse = commonServiceBLL.GetMasterData();
                this.SizeList = commonDataResponse.Sizes;
                this.CategoryList = commonDataResponse.Categories;
                this.StatusList = commonDataResponse.Status;
                this.PortionList = commonDataResponse.Portions;

                this.getProducts(); // get products from db

                // Set combobox data
                cmbSelectSize.DisplayMember = cmbCategory.DisplayMember = cmbSelectCategory.DisplayMember = "Name";
                cmbSelectSize.ValueMember = cmbCategory.ValueMember = cmbSelectCategory.ValueMember = "Data";
                cmbSelectProduct.DisplayMember = "Name";
                cmbSelectProduct.ValueMember = "Id";
                cmbCategory.DataSource = this.CategoryList;
                cmbSelectCategory.DataSource = this.CategoryList;
                cmbSelectSize.DataSource = this.SelectedSizeList;
                cmbCategory.SelectedIndex = 0;
                cmbSelectCategory.SelectedIndex = 0;
                cmbSelectProduct.SelectedIndex = -1;
                cmbSelectSize.SelectedIndex = -1;

                foreach (ProductVM product in products)
                {
                    DataRow itemDataRow = this.productTable.NewRow();
                    itemDataRow[0] = product.Name;
                    itemDataRow[1] = product.Code;
                    itemDataRow[2] = product.CategoryName;
                    itemDataRow[3] = product.Id;
                    itemDataRow[4] = product.mpt_CategoryEnum;
                    this.productTable.Rows.Add(itemDataRow);
                }
            }

            productGridView.RowHeadersVisible = false;
            this.ProductFormFieldValidation(); // validate product from
            this.PriceFormFieldValidation(); // validate price form
            this.txtDiscount.Text = "0.0";
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            DataRow itemDataRow = this.productTable.NewRow();
            itemDataRow[0] = this.txtItemName.Text;
            itemDataRow[1] = this.txtCode.Text;
            itemDataRow[2] = ((MultiPurposeTagVM)cmbCategory.SelectedItem).Name;
            itemDataRow[3] = this.productId; 
            itemDataRow[4] = cmbCategory.SelectedValue; 
            using (ProductBLL productBll = new ProductBLL())
            {
                ProductVM product = new ProductVM() {
                    Id = this.productId,
                    Name = this.txtItemName.Text,
                    Code = this.txtCode.Text,
                    mpt_CategoryEnum = Convert.ToInt32(cmbCategory.SelectedValue),
                    mpt_StatusEnum = 1
                };

                int response = productBll.ManageProduct(product);
                if (response > 0)
                {
                    itemDataRow[3] = response;
                    if (!isProductUpdate)
                        this.productTable.Rows.Add(itemDataRow);
                    else
                    {
                        this.productGridView.Rows.Remove(this.updatedRow);
                        this.productTable.Rows.Add(itemDataRow);
                    }
                    this.getProducts();
                    this.ProductFormInputReset();
                } else
                {
                    MessageBox.Show("Item Insert Error");
                }
            }
            this.btnAddUpdate.Text = "Add";
            this.isProductUpdate = false;
        }
        private decimal GetDiscountedPrice()
        {
            string price = String.IsNullOrWhiteSpace(this.txtPrice.Text) ? "0.00" : this.txtPrice.Text;
            string percentage = String.IsNullOrWhiteSpace(this.txtDiscount.Text) ? "0.00" : this.txtDiscount.Text;
            decimal priceValue = Convert.ToDecimal(price);
            decimal percentageValue = Convert.ToDecimal(percentage);
            using(CommonServiceBLL comService = new CommonServiceBLL())
            {
                return comService.GetDiscountedPrice(priceValue, percentageValue);
            }
        }

        private void ProductFormFieldValidation()
        {
            this.txtCode.Enabled = !String.IsNullOrWhiteSpace(this.txtItemName.Text);
            this.cmbCategory.Enabled = !String.IsNullOrWhiteSpace(this.txtCode.Text);
            this.btnAddUpdate.Enabled = this.cmbCategory.SelectedIndex > -1 && this.cmbCategory.Enabled;
        }

        private void PriceFormFieldValidation()
        {
            this.cmbSelectProduct.Enabled = this.cmbSelectCategory.SelectedIndex > -1;
            this.cmbSelectSize.Enabled = this.cmbSelectProduct.SelectedIndex > -1;
            this.txtPrice.Enabled = this.cmbSelectSize.SelectedIndex > -1;
            this.txtDiscount.Enabled = !String.IsNullOrWhiteSpace(this.txtPrice.Text);
            this.btnSelectPriceAdd.Enabled = !String.IsNullOrWhiteSpace(this.txtDiscount.Text);
        }

        private void ProductFormInputReset()
        {
            this.txtItemName.Clear();
            this.txtCode.Clear();
            this.cmbCategory.SelectedIndex = 0;
            this.ProductFormFieldValidation();
        }

        private void PriceFormInputReset()
        {
            this.txtDiscount.Clear();
            this.txtPrice.Clear();
            this.cmbSelectProduct.SelectedIndex = -1;
            this.cmbSelectCategory.SelectedIndex = 0;
            this.cmbSelectSize.SelectedIndex = -1;
            this.lblFinalPrice.Text = "0.00";
            this.txtDiscount.Text = "0.0";
            this.PriceFormFieldValidation();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ProductFormInputReset();
        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            this.ProductFormFieldValidation();
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            this.ProductFormFieldValidation();
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            this.ProductFormFieldValidation();
            decimal discountedPrice = this.GetDiscountedPrice();
            this.lblFinalPrice.Text = String.Format("{0:0.00}", discountedPrice);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only numbers, decimals and control characters
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.') {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && this.txtPrice.Text.Contains(".")) {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && this.txtPrice.Text.Length < 1) {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtPrice.Text, @"\.\d\d")) {
                e.Handled = true;
            }
        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            try {
                // format the value as currency
                Decimal dTmp = Convert.ToDecimal(this.Text);
                this.Text = dTmp.ToString("C");            }
            catch { }
        }

        private void txtPrice_Click(object sender, EventArgs e)
        {
            this.Text = mDollarValue.ToString();
            if (this.Text == "0")
                this.txtPrice.Clear();
            this.txtPrice.SelectionStart = this.Text.Length;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try {
                string value = txtPrice.Text.Replace(",", "");
                ulong ul;
                if (ulong.TryParse(value, out ul))
                {
                    txtPrice.TextChanged -= txtPrice_TextChanged;
                    txtPrice.Text = string.Format("{0:#,#}", ul);
                    txtPrice.SelectionStart = txtPrice.Text.Length;
                    txtPrice.TextChanged += txtPrice_TextChanged;
                }
                this.PriceFormFieldValidation();
            } catch { }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only numbers, decimals and control characters
            decimal userVal;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.') {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && this.txtDiscount.Text.Contains(".")) {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && this.txtDiscount.Text.Length < 0) {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtDiscount.Text, @"\.\d\d")) {
                e.Handled = true;
            }
            if (String.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                txtDiscount.Text = ".0";
            }
            if (Convert.ToDecimal(txtDiscount.Text) > 100) {
                txtDiscount.Text = "100.0";
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try {
                string value = txtDiscount.Text.Replace(",", "");
                ulong ul;
                if (ulong.TryParse(value, out ul))
                {
                    txtDiscount.TextChanged -= txtDiscount_TextChanged;
                    txtDiscount.Text = string.Format("{0:#,#}", ul);
                    txtDiscount.SelectionStart = txtPrice.Text.Length;
                    txtDiscount.TextChanged += txtDiscount_TextChanged;
                }
                this.PriceFormFieldValidation();
            } catch { }
        }

        private void txtDiscount_Click(object sender, EventArgs e)
        {
            this.Text = mDollarValue.ToString();
            if (this.Text == "0")
                this.txtDiscount.Clear();
            this.txtDiscount.SelectionStart = this.Text.Length;
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            this.ProductFormFieldValidation();
            if (!String.IsNullOrWhiteSpace(txtDiscount.Text) && Convert.ToDecimal(txtDiscount.Text) > 100)
            {
                txtDiscount.Text = "100.0";
            }

            decimal discountedPrice = this.GetDiscountedPrice();
            this.lblFinalPrice.Text = String.Format("{0:0.00}", discountedPrice);
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            decimal discountedPrice = this.GetDiscountedPrice();
            this.lblFinalPrice.Text = String.Format("{0:0.00}", discountedPrice);
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            decimal discountedPrice = this.GetDiscountedPrice();
            this.lblFinalPrice.Text = String.Format("{0:0.00}", discountedPrice);
        }

        private void dataGridItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == productGridView.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == productGridView.Columns["dataGridViewDeleteButton"].Index)
            {
                DataRowView data = (DataRowView)productGridView.Rows[e.RowIndex].DataBoundItem;
                ProductVM productVM = MapDataRowViewToProductVM(data);
                using (ProductBLL productBLL = new ProductBLL())
                {
                    productVM.mpt_StatusEnum = 2;
                    int response = productBLL.ManageProduct(productVM);
                    if (response != 0)
                        productGridView.Rows.Remove(productGridView.Rows[e.RowIndex]);
                    else
                        MessageBox.Show("Unable to delete the item");
                }
            }
            else if (e.ColumnIndex == productGridView.Columns["dataGridViewEditButton"].Index)
            {
                DataRowView data = (DataRowView)productGridView.Rows[e.RowIndex].DataBoundItem;
                ProductVM productVM = MapDataRowViewToProductVM(data);
                this.productId = productVM.Id;
                SetDataToForm(productVM);
                this.btnAddUpdate.Text = "Update";
                this.isProductUpdate = true;
                this.updatedRow = productGridView.Rows[e.RowIndex];
            }
            else if (e.ColumnIndex == productGridView.Columns["dataGridViewButton"].Index)
            {
                using (CommonServiceBLL commonServiceBLL = new CommonServiceBLL())
                {
                    DataRowView data = (DataRowView)productGridView.Rows[e.RowIndex].DataBoundItem;
                    ProductVM productVM = MapDataRowViewToProductVM(data);
                    productVM = this.products.Find(item => item.Id == productVM.Id);
                    this.priceTable.Clear();
                    foreach (ProductPriceVM productPrice in productVM.PriceList)
                    {
                        DataRow itemDataRow = this.priceTable.NewRow();
                        itemDataRow[0] = productPrice.SizeName;
                        itemDataRow[1] = productPrice.Price;
                        itemDataRow[2] = productPrice.Discount;
                        itemDataRow[3] = commonServiceBLL.GetDiscountedPrice(productPrice.Price, productPrice.Discount);
                        itemDataRow[4] = productPrice.mpt_SizeEnum;
                        itemDataRow[5] = productPrice.ProductId;
                        itemDataRow[6] = productPrice.Id;
                        this.priceTable.Rows.Add(itemDataRow);
                    }
                    this.lblShowSelectedProduct.Text = productVM.Name;

                }
            }
        }

        private void SetDataToForm(ProductVM product)
        {
            this.txtItemName.Text = product.Name;
            this.txtCode.Text = product.Code;
            this.cmbCategory.SelectedIndex = product.mpt_CategoryEnum - 1;
            this.ProductFormFieldValidation();
        }

        private void SetDataToPriceForm(ProductPriceVM product)
        {
            decimal finalPrice;
            using (CommonServiceBLL common = new CommonServiceBLL())
            {
                finalPrice = common.GetDiscountedPrice(product.Price, product.Discount);
            }
            ProductVM selectedProduct = this.products.Find(pro => pro.Id == product.ProductId);
            if (selectedProduct != null)
            {                
                this.txtPrice.Text = product.Price.ToString();
                this.txtDiscount.Text = product.Discount.ToString();
                this.lblFinalPrice.Text = finalPrice.ToString();
                this.cmbSelectCategory.SelectedIndex = selectedProduct.mpt_CategoryEnum - 1;
                this.cmbSelectProduct.SelectedItem = selectedProduct;
                this.cmbSelectSize.DataSource = this.SizeList.Where(s => s.Data == product.mpt_SizeEnum).ToList();
                this.cmbSelectSize.SelectedIndex = 0;
            }
            this.PriceFormFieldValidation();
        }

        private ProductVM MapDataRowViewToProductVM(DataRowView itemDataRow)
        {
            ProductVM productVM = new ProductVM();
            productVM.Name  = itemDataRow[0].ToString();
            productVM.Code  = itemDataRow[1].ToString();
            productVM.mpt_CategoryEnum  = Convert.ToInt32(!String.IsNullOrEmpty(itemDataRow[4].ToString()) ? itemDataRow[4] : 0);
            productVM.Id = Convert.ToInt32(!String.IsNullOrEmpty(itemDataRow[3].ToString()) ? itemDataRow[3] : 0);
            return productVM;
        }

        private ProductPriceVM MapDataRowViewToPriceVM(DataRowView itemDataRow)
        {
            ProductPriceVM productPriceVM = new ProductPriceVM();
            productPriceVM.SizeName = itemDataRow[0].ToString();
            productPriceVM.Price = Convert.ToDecimal(!String.IsNullOrEmpty(itemDataRow[1].ToString()) ? itemDataRow[1] : 0);
            productPriceVM.Discount = Convert.ToDecimal(!String.IsNullOrEmpty(itemDataRow[2].ToString()) ? itemDataRow[2] : 0);
            productPriceVM.mpt_SizeEnum = Convert.ToInt32(!String.IsNullOrEmpty(itemDataRow[4].ToString()) ? itemDataRow[4] : 0);
            productPriceVM.ProductId = Convert.ToInt32(!String.IsNullOrEmpty(itemDataRow[5].ToString()) ? itemDataRow[5] : 0);
            productPriceVM.Id = Convert.ToInt32(!String.IsNullOrEmpty(itemDataRow[6].ToString()) ? itemDataRow[6] : 0);
            return productPriceVM;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = Convert.ToInt32(cmbCategory.SelectedValue) -1; // to map with enum
            if (selectedValue != (int)PizzaBox_Receipt_Management.Enums.CommonEnums.CategoryEnum.Bite)
            {
                this.cmbSelectSize.DataSource = this.SizeList;
                this.lblSize.Text = "Size";
            } else
            {
                this.cmbSelectSize.DataSource = this.PortionList;
                this.lblSize.Text = "Portion";
            }          
            
            this.cmbSelectSize.SelectedIndex = 0;

            this.PriceFormFieldValidation();
        }

        private void btnSelectPriceAdd_Click(object sender, EventArgs e)
        {
            using (ProductBLL productBll = new ProductBLL())
            {
                string discount = String.IsNullOrWhiteSpace(this.txtDiscount.Text) ? "0.00" : Convert.ToDecimal(this.txtDiscount.Text) == 0 ? "0.00" : this.txtDiscount.Text;
                ProductPriceVM productPrice = new ProductPriceVM()
                {
                    Id = !isPriceUpdate ? 0 : MapDataRowViewToPriceVM((DataRowView)this.updatedRow.DataBoundItem).Id,
                    mpt_SizeEnum = Convert.ToInt32(this.cmbSelectSize.SelectedValue),
                    Price = Convert.ToDecimal(this.lblFinalPrice.Text),
                    Discount = Convert.ToDecimal(discount),
                    ProductId = Convert.ToInt32(cmbSelectProduct.SelectedValue)
                };

                int response = productBll.ManageProductPriceMap(productPrice);
                if (response > 0)
                {
                    this.getProducts();
                    this.PriceFormInputReset();
                    MessageBox.Show("Item added succesfully");
                }
                else
                {
                    MessageBox.Show("Item Insert Error");
                }
            }
            this.btnSelectPriceAdd.Text = "Add";
            this.isPriceUpdate = false;
        }

        private void cmbSelectCategory_Leave(object sender, EventArgs e)
        {
            this.PriceFormFieldValidation();
        }

        private void getProducts()
        {
            using (ProductBLL productBll = new ProductBLL())
            {
                this.products = productBll.GetProducts();
            }
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
                        this.SelectedSizeList = this.SelectedSizeList.Where(selectSize => selectSize.Data != size.mpt_SizeEnum).ToList();
                }
            }
            this.cmbSelectSize.DataSource = this.SelectedSizeList;
            this.PriceFormFieldValidation();
        }

        private void cmbSelectSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PriceFormFieldValidation();
        }

        private void btnSelectPriceClear_Click(object sender, EventArgs e)
        {
            this.PriceFormInputReset();
        }

        private void cmbSelectProduct_Leave(object sender, EventArgs e)
        {
            if (this.SelectedSizeList.Count() == 0 && this.isPriceUpdate != true)
            {
                MessageBox.Show("All product sizes are already allocated");
                this.cmbSelectSize.Enabled = false;
            }
        }

        private void btnResetSpec_Click(object sender, EventArgs e)
        {
            this.priceTable.Clear();
            this.lblShowSelectedProduct.ResetText();
        }

        private void gridViewSpecifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridViewSpecifications.Columns["specificationEditButton"].Index)
            {
                DataRowView data = (DataRowView)gridViewSpecifications.Rows[e.RowIndex].DataBoundItem;
                ProductPriceVM productVM = MapDataRowViewToPriceVM(data);
                this.productId = productVM.ProductId;
                SetDataToPriceForm(productVM);
                this.btnSelectPriceAdd.Text = "Update";
                this.isPriceUpdate = true;
                this.priceId = productVM.Id;
                this.updatedRow = gridViewSpecifications.Rows[e.RowIndex];
            }
            else if (e.ColumnIndex == gridViewSpecifications.Columns["specificationDeleteButton"].Index)
            {
                using(ProductBLL product = new ProductBLL())
                {
                    DataRowView data = (DataRowView)gridViewSpecifications.Rows[e.RowIndex].DataBoundItem;
                    ProductPriceVM productVM = MapDataRowViewToPriceVM(data);
                    product.DeleteProductPriceMapping(productVM.Id);
                    gridViewSpecifications.Rows.Remove(gridViewSpecifications.Rows[e.RowIndex]);
                    this.getProducts();
                }
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
        }
    }


}
