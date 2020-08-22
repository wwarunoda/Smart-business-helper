using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int mpt_CategoryEnum { get; set; }
        public string CategoryName { get; set; }
        public int mpt_StatusEnum { get; set; }
        public string Status { get; set; }
        public IEnumerable<ProductPriceVM> PriceList { get; set; }
    }
}
