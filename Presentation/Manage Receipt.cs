using PizzaBox_Receipt_Management.BLL;
using PizzaBox_Receipt_Management.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaBox_Receipt_Management
{
    public partial class ManageReceipt : Form
    {
        public ManageReceipt()
        {
            InitializeComponent();           
        }

        private void ManageReceipt_Load(object sender, EventArgs e)
        {
            this.loadPrintPate();
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            Password passowrdForm = new Password();
            if (passowrdForm.ShowDialog() == DialogResult.OK)
            {                
                AddUpdateItem addUpdateItemForm = new AddUpdateItem();
                addUpdateItemForm.MdiParent = this;
                addUpdateItemForm.Show();
            } else
            {
                MessageBox.Show("You do not have privilage to access");
            }

            
                
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.loadPrintPate();
        }

        private void loadPrintPate()
        {
            Receipting printReceiptForm = new Receipting();
            printReceiptForm.MdiParent = this;
            printReceiptForm.Show();
        }
    }
}
