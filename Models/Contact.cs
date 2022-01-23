using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.Models
{
    public class Contact
    {
        public Contact() { }
        public Contact(Contact contact)
        {
            this.BusinessPartnerId = contact.BusinessPartnerId;
            this.Name = contact.Name;
            this.PhoneNumber = contact.PhoneNumber;
            this.Email = contact.Email;
            this.ID = contact.ID;
            this.IsPromotionalMessageEnable = contact.IsPromotionalMessageEnable;
        }
        public int BusinessPartnerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }
        public bool IsPromotionalMessageEnable { get; set; }
        
    }
}
