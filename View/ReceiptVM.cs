using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class ReceiptVM
    {
        public int Id { get; set; }
        public int BSPId { get; set; }
        public decimal TotalAmount { get; set; }        
        public decimal? GivenAmount { get; set; }
        public decimal? SpecialDiscount { get; set; }
        public decimal? CustomerBalance { get; set; }
        public string Remark { get; set; }
        public string ReceiptReference { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public IEnumerable<ProductReceiptMapVM> Products { get; set; }
    }
}
