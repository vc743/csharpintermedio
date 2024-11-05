using SOLID_Refactor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Refactor.Classes
{
    public class CourseRepository : ICourseRepository
    {
        public void Save(Course course)
        {
            Console.WriteLine($"Saving {course.Name} course to DB...");
            Console.WriteLine($"End save of {course.Name} course to DB");
        }
    }
}
