using PizzaBox_Receipt_Management.BLL;
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

namespace PizzaBox_Receipt_Management.Presentation
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            using (CommonServiceBLL common = new CommonServiceBLL())
            {
                string password = ConfigurationManager.ConnectionStrings["Passowrd"].ConnectionString;
                string Newpassword = common.ComputeSha256Hash(txtPassword.Text);

                if (password.Equals(Newpassword))
                {
                    // The password is ok.
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // The password is invalid.
                    txtPassword.Clear();
                    MessageBox.Show("Inivalid password.");
                    txtPassword.Focus();
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                e.Handled = true; // Mark the event as handled
            }
        }
    }
}
