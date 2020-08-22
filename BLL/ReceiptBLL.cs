using PizzaBox_Receipt_Management.DML;
using PizzaBox_Receipt_Management.Models;
using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.BLL
{
    public class ReceiptBLL: IDisposable
    {
        public IEnumerable<BusinessPartnerContactDetails> GetContact(string phoneNumber)
        {
            using (ReceiptDAL reciptDal = new ReceiptDAL())
            {
               return reciptDal.GetContact(phoneNumber);
            }
        }

        public BusinessPartnerResponse ManageBusinessPartner(BusinessPartnerVM businessPartner)
        {
            using (ReceiptDAL reciptDal = new ReceiptDAL())
            {
                return reciptDal.ManageBusinessPartner(businessPartner);
            }
        }

        public BusinessPartnerVM GetBusinessPartnerByBSPId(int bspId)
        {
            using (ReceiptDAL reciptDal = new ReceiptDAL())
            {
                return reciptDal.GetBusinessPartnerByBSPId(bspId);
            }
        }

        public int AddReceiptDetails(ReceiptVM receipt)
        {
            using (ReceiptDAL reciptDal = new ReceiptDAL())
            {
                return reciptDal.AddReceiptDetails(receipt);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
