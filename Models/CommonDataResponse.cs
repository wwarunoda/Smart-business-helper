using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.Models
{
    public class CommonDataResponse
    {
        public IEnumerable<MultiPurposeTagVM> Sizes { get; set; }
        public IEnumerable<MultiPurposeTagVM> Categories { get; set; }
        public IEnumerable<MultiPurposeTagVM> Status { get; set; }
        public IEnumerable<MultiPurposeTagVM> Portions { get; set; }
    }
}
