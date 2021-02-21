using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class DialyReportVM
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SpecialDiscount { get; set; }
        public decimal CustomerGivenAmount { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
