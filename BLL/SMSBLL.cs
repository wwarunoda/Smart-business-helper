using PizzaBox_Receipt_Management.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.BLL
{
    public class SMSBLL : IDisposable
    {
        public int SendSMS(IEnumerable<string> contacts, string message)
        {
            using (SMSDAL smsDal = new SMSDAL())
            {
                return smsDal.SendSMS(contacts, message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
