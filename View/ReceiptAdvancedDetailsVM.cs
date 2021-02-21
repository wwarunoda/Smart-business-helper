using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class ReceiptAdvancedDetailsVM
    {
        public string ReceiptNumber { get; set; }
        public decimal BillAmount { get; set; }
        public decimal CustomerGivenAmount { get; set; }
        public decimal SpecialDiscount { get; set; }
        public string ProductCodes { get; set; }
        public string Products { get; set; }
        public string ProductsUnitPrices { get; set; }
        public string ProductsUnitDiscounts { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTP { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
