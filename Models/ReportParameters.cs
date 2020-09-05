using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.Models
{
    public class ReportParameters
    {
        public IEnumerable<ReportParameterVM> parameters { get; set; }
    }
}
