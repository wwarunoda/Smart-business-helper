using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class ProductReceiptMapVM
    {
        public int ProductId { get; set; }
        public int ReceiptId { get; set; }
        public int Quantity { get; set; }
        public decimal? ItemPrice { get; set; }
        public decimal? ItemDiscountedPrice { get; set; }
        public int? mpt_SizeEnum { get; set; }
        public string Size { get; set; }
        public ProductVM product  { get; set; }
    }
}
