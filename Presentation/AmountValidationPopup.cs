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
        ReceiptVM receipt;
        Receipting receiptForm;
        decimal remainingAmount;
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
                txtGivenAmount.Enabled = true;

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
                    this.receiptReference = txtReceiptReferene.Text;
                    this.retrunReference = receiptBLL.AddReceiptDetails(receipt);
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
                remainingAmount = Convert.ToDecimal(tb.Text) - receipt.TotalAmount;
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
        }
    }
}
