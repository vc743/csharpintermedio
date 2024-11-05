using SOLID_Refactor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Refactor.Classes
{
    public class OnsiteCourse : Course, ISubscribe
    {
        public void Subscribe()
        {
            Console.WriteLine("Subscribing to on-site course...");
            Console.WriteLine("End Subscribing");
        }
    }
}
