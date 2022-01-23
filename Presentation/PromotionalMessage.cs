using PizzaBox_Receipt_Management.BLL;
using PizzaBox_Receipt_Management.Models;
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
    public partial class PromotionalMessage : Form
    {
        Microsoft.Office.Interop.Excel.Application excel;
        Microsoft.Office.Interop.Excel.Workbook excelworkBook;
        Microsoft.Office.Interop.Excel.Worksheet excelSheet;
        Microsoft.Office.Interop.Excel.Range excelCellrange;

        AddUpdateItem itemForm;
        List<Contact> contacts;
        public PromotionalMessage(AddUpdateItem item)
        {
            this.itemForm = item;
            InitializeComponent();
        }

        private void PromotionalMessage_Load(object sender, EventArgs e)
        {
            using (PromotionalMessageBLL productDal = new PromotionalMessageBLL())
            {
                List<Contact> tableContact;
                contacts = productDal.GetContacts();
                tableContact = contacts.ConvertAll(x => new Contact(x));
                gridContact.DataSource = tableContact;
                gridContact.Columns["BusinessPartnerId"].Visible = false;
                gridContact.Columns["ID"].Visible = false;
                this.setContactDetails(contacts);
            }
        }

        private void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            List<Contact> updatedContacts = new List<Contact>();
            List<Contact> editedContancts = gridContact.DataSource as List<Contact>;
            List<Contact> difference = editedContancts.Where(x => contacts.FirstOrDefault(z => z.ID == x.ID).IsPromotionalMessageEnable != x.IsPromotionalMessageEnable ).ToList();
            using (PromotionalMessageBLL productBal = new PromotionalMessageBLL())
            {
                productBal.UpdateContacts(difference);
                MessageBox.Show("Contact updated successfully");
                contacts = new List<Contact>();
                updatedContacts = productBal.GetContacts();
                gridContact.DataSource = updatedContacts;
            }
            this.setContactDetails(updatedContacts);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            itemForm.Enabled = true;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (PromotionalMessageBLL productDal = new PromotionalMessageBLL())
            {
                StringBuilder clipData = new StringBuilder();
                List<Contact> activeContacts = productDal.GetContacts();
                List<string> messageableContacts = new List<string>();
                foreach(Contact contact in activeContacts)
                {
                    if(contact.IsPromotionalMessageEnable)
                    {
                        messageableContacts.Add("94" + contact.PhoneNumber.Substring(1,contact.PhoneNumber.Length - 1));
                        clipData.AppendLine("94" + contact.PhoneNumber.Substring(1, contact.PhoneNumber.Length - 1));
                    }
                }

                Clipboard.Clear();
                Clipboard.SetText(clipData.ToString());

                //MessageBox.Show("Messageable contacts save to clipboard");
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            using (SMSBLL smsBLL = new SMSBLL())
            using (PromotionalMessageBLL productDal = new PromotionalMessageBLL())
            {
                IEnumerable<Contact> activeContacts = productDal.GetContacts();
                List<string> activeNumbers = new List<string>();
                foreach (Contact contact in activeContacts)
                {
                    if (contact.IsPromotionalMessageEnable)
                    {
                        activeNumbers.Add("94" + contact.PhoneNumber.Substring(1, contact.PhoneNumber.Length - 1));
                    }
                }
                List<string> test = new List<string>() {"94718527541"};
                int validationCode = smsBLL.SendSMS(test as IEnumerable<string>, txtMessage.Text);
                
                switch(validationCode)
                {
                    case 200:
                        MessageBox.Show("Message received OK");
                        break;
                    case 151:
                        MessageBox.Show("invalid session");
                        break;
                    case 152:
                        MessageBox.Show("session is still in use for previous request");
                        break;
                    case 155:
                        MessageBox.Show("service halted");
                        break;
                    case 156:
                        MessageBox.Show("other network messaging disabled");
                        break;
                    case 157:
                        MessageBox.Show("IDD messages disabled");
                        break;
                    case 159:
                        MessageBox.Show("failed credit check");
                        break;
                    case 160:
                        MessageBox.Show("no message found");
                        break;
                    case 161:
                        MessageBox.Show("message exceeding 160 characters");
                        break;
                    case 162:
                        MessageBox.Show("invalid message type found");
                        break;
                    case 164:
                        MessageBox.Show("invalid group");
                        break;
                    case 165:
                        MessageBox.Show("no recipients found ");
                        break;
                    case 166:
                        MessageBox.Show("recipient list exceeding allowed limit ");
                        break;
                    case 167:
                        MessageBox.Show("invalid long number ");
                        break;
                    case 168:
                        MessageBox.Show("invalid short code");
                        break;
                    case 169:
                        MessageBox.Show("invalid alias ");
                        break;
                    case 170:
                        MessageBox.Show("black listed numbers in number list");
                        break;
                    case 175:
                        MessageBox.Show("deprecated method");
                        break;
                    default:
                        MessageBox.Show("Error");
                        break;
                }
            }
        }

        private void setContactDetails(List<Contact> contacts)
        {
            int totalContacts = contacts.Count;
            int activeContacts = contacts.Where(x => x.IsPromotionalMessageEnable == true).Count();
            lblTotalContacts.Text = totalContacts.ToString();
            label4.Text = activeContacts.ToString();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            int totalCount = 0;
            char[] fullMessage = txtMessage.Text.ToCharArray();
            foreach(char message in fullMessage)
            {
                if(message == '{' || message == '[' || message == ']' || message == '^' || message == '\\' || message == '/' || message == '|' || message == '~')
                {
                    totalCount += 2;
                } else
                {
                    totalCount += 1;
                }
            }
            lblMessageLenght.Text = totalCount.ToString();
        }
    }
}
