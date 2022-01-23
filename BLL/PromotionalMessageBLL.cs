using PizzaBox_Receipt_Management.DML;
using PizzaBox_Receipt_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.BLL
{
    public class PromotionalMessageBLL : IDisposable
    {
        public List<Contact> GetContacts()
        {
            using (PromotionalMessageDAL productDal = new PromotionalMessageDAL())
            {
                return productDal.GetContacts();
            }
        }

        public void UpdateContacts(IEnumerable<Contact> contacts)
        {
            using (PromotionalMessageDAL productDal = new PromotionalMessageDAL())
            {
                foreach(Contact contact in contacts)
                {
                    productDal.UpdateContacts(contact);
                }                
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
