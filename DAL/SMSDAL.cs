using PizzaBox_Receipt_Management.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.DAL
{
    public class SMSDAL : IDisposable
    {
        public int SendSMS(IEnumerable<string> contacts, string message)
        {
            int validationCode = 0;
            user user1 = new user();
            user1.username = "esmsusr_uvp";
            user1.password = "1g7bk8f";


            EnterpriseSMSWSClient client = new EnterpriseSMSWSClient();
            Console.WriteLine(client.serviceTest(user1));

            //create the session
            session session1 = new session();
            session1 = client.createSession(user1);

            Console.WriteLine(session1.isActive);

            //multi language message
            smsMessageMultiLang msgMulti = new smsMessageMultiLang();
            msgMulti.message = message;
            msgMulti.sender = "Pizza Box";
            msgMulti.recipients = contacts.ToArray();
            msgMulti.messageType = 1;

            validationCode = client.sendMessagesMultiLang(session1, msgMulti);

            client.closeSession(session1);

            return validationCode;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
