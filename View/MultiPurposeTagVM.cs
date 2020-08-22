using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.View
{
    public class MultiPurposeTagVM
    {
        public int Id { get; set; }
        public int TypeEnum { get; set; }
        public int Data { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
