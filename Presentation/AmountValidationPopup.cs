using PizzaBox_Receipt_Management.BLL;
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

namespace PizzaBox_Receipt_Management.Presentation
{
    public partial class AmountValidationPopup : Form
    {
        public int retrunValue { get; set; }
        public string retrunReference { get; set; }
        public string receiptReference { get; set; }
        public decimal specialDiscount { get; set; }
        public decimal CustomerBalance { get; set; }
        ReceiptVM receipt;
        Receipting receiptForm;
        decimal remainingAmount;
        decimal discountedAmount;
        decimal givenAmount = 0;
        public AmountValidationPopup(ReceiptVM newReceipt, Receipting newReceiptForm)
        {
            receipt = newReceipt;
            receiptForm = newReceiptForm;
            InitializeComponent();
        }

        private void AmountValidationPopup_Load(object sender, EventArgs e)
        {
            remainingAmount = 0;
            receiptForm.Enabled = false;
            btnOk.Enabled = false;
            if (receipt != null)
            {
                txtRecepitAmount.Text = String.Format("{0:0.00}", receipt.TotalAmount);
                txtDiscountedAmount.Text = String.Format("{0:0.00}", receipt.TotalAmount);
                txtGivenAmount.Enabled = true;
                txtSpecialDiscount.Text = String.Format("{0:0.00}", 0);
                txtSpecialDiscountRate.Text = "0";
                this.discountedAmount = receipt.TotalAmount;
            } else
            {
                txtGivenAmount.Enabled = false;
            }

            txtGivenAmount.Select();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (ReceiptBLL receiptBLL = new ReceiptBLL())
            {
                if (remainingAmount >= 0)
                {
                    receipt.GivenAmount = Convert.ToDecimal(txtGivenAmount.Text);
                    receipt.ReceiptReference = txtReceiptReferene.Text;
                    receipt.SpecialDiscount = Convert.ToDecimal(txtSpecialDiscount.Text);
                    receipt.CustomerBalance = remainingAmount;
                    this.receiptReference = txtReceiptReferene.Text;
                    this.retrunReference = receiptBLL.AddReceiptDetails(receipt);
                    this.specialDiscount = Convert.ToDecimal(txtSpecialDiscount.Text);
                    this.CustomerBalance = remainingAmount;
                    var returnValue = Convert.ToInt32(this.retrunReference);
                    if (returnValue > 0)
                    {
                        MessageBox.Show("Receipt printed succesful");
                        this.retrunValue = returnValue;
                        receiptForm.Enabled = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.retrunValue = 0;
                        MessageBox.Show("Receipt print faild");
                    }
                } else
                {
                    this.retrunValue = 0;
                    MessageBox.Show("Customer Given amount should be greater than receipt amount");
                }
            }
        }

        private void txtGivenAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnOk.Focus();
            }            
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.retrunValue = 0;
            receiptForm.Enabled = true;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtGivenAmount_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            decimal restult;
            if (Decimal.TryParse(tb.Text, out restult))
            {
                givenAmount = Convert.ToDecimal(tb.Text);
                setGivenAmount();
            }
        }

        private void setGivenAmount()
        {
            remainingAmount = givenAmount - discountedAmount;
            txtBalance.Text = String.Format("{0:0.00}", remainingAmount);
            if (remainingAmount >= 0)
            {
                btnOk.Enabled = true;
            }
            else
            {
                btnOk.Enabled = false;
            }
        }

        private void txtSpecialDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtGivenAmount.Focus();
            }
        }

        private void txtSpecialDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtGivenAmount.Focus();
            }
        }

        private void txtSpecialDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            decimal restult;
            decimal specialDiscount;            
            decimal discountedRate;
            if (Decimal.TryParse(tb.Text, out restult))
            {
                specialDiscount = Convert.ToDecimal(tb.Text);
                discountedAmount = receipt.TotalAmount - specialDiscount;
                discountedRate = specialDiscount != 0 ? ((specialDiscount * 100) / receipt.TotalAmount) : 0;
                if(discountedAmount < 0)
                {
                    MessageBox.Show("Error !!!, Discounted amout is grater than bill amount. System Auto reset discount");
                    discountedAmount = receipt.TotalAmount;
                    discountedRate = 0;
                    txtSpecialDiscount.Text = String.Format("{0:0.00}", 0);
                }
                txtDiscountedAmount.Text = String.Format("{0:0.00}", discountedAmount);   
                txtSpecialDiscountRate.Text = String.Format("{0:0.00}", discountedRate);
            }
            else
            {
                discountedAmount = receipt.TotalAmount;
                specialDiscount = 0;
                txtDiscountedAmount.Text = String.Format("{0:0.00}", discountedAmount);
                txtSpecialDiscount.Text = String.Format("{0:0.00}", specialDiscount);
                txtSpecialDiscountRate.Text = String.Format("{0:0.00}", 0);
            }
            setGivenAmount();
        }

        private void txtSpecialDiscountRate_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            decimal restult;
            decimal specialDiscount;
            decimal discountedRate;
            if (Decimal.TryParse(tb.Text, out restult))
            {
                discountedRate = Convert.ToDecimal(tb.Text);
                specialDiscount = (receipt.TotalAmount * discountedRate) / 100;
                discountedAmount = receipt.TotalAmount - specialDiscount;
                if (discountedAmount < 0)
                {
                    MessageBox.Show("Error !!!, Discounted rate is grater than bill amount. System Auto reset discount");
                    discountedAmount = receipt.TotalAmount;
                    specialDiscount = 0;
                    txtSpecialDiscountRate.Text = String.Format("{0:0.00}", 0);
                }
                txtDiscountedAmount.Text = String.Format("{0:0.00}", discountedAmount);
                txtSpecialDiscount.Text = String.Format("{0:0.00}", specialDiscount);
            } else
            {
                discountedAmount = receipt.TotalAmount;
                specialDiscount = 0;
                txtDiscountedAmount.Text = String.Format("{0:0.00}", discountedAmount);
                txtSpecialDiscount.Text = String.Format("{0:0.00}", specialDiscount);
                txtSpecialDiscountRate.Text = String.Format("{0:0.00}", 0);
            }
            setGivenAmount(); 
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
