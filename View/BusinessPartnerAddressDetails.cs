using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class BusinessPartnerAddressDetails
    {
        public int Id { get; set; }
        public int BusinessPartnerId { get; set; }
        public string Address { get; set; }
    }
}
