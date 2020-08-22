using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class BusinessPartnerContactDetails
    {
        public int Id { get; set; }
        public int BusinessPartnerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
