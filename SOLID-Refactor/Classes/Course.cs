using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Refactor.Classes
{
    public abstract class Course
    {
        public int CourseID { get; set; }
        public string? Name { get; set; }
    }
}
