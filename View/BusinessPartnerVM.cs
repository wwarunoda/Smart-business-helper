using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class BusinessPartnerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? mpt_StatusEnum { get; set; }
        public IEnumerable<BusinessPartnerContactDetails> contacts { get; set; }
        public IEnumerable<BusinessPartnerAddressDetails> addresses { get; set; }
    }
}
