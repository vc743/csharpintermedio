using SOLID_Refactor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Refactor.Classes
{
    public class EmailService : IEmailService
    {
        public void SendConfirmation()
        {
            Console.WriteLine("Sending confirmation email...");
            Console.WriteLine("End Sending email");
        }
    }
}
