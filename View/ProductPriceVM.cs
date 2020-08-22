using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class ProductPriceVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int mpt_SizeEnum { get; set; }
        public string SizeName { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
