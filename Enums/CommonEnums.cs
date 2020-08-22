using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.Enums
{
    public class CommonEnums
    {
        public enum CategoryEnum
        {
            Pizza,    // 0
            Submarine,   // 1
            Hotdog,      // 2
            Bite      // 3
        }

        public enum BusinessPartnerStatusEnum
        {
            Active = 1,
            Blocked = 2
        }
    }
}
