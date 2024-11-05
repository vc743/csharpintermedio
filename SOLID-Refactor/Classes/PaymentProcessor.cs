using SOLID_Refactor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Refactor.Classes
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing payment...");
            Console.WriteLine("End Processing payment");
        }
    }
}
