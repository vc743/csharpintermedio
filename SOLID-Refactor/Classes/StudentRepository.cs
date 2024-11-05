
using SOLID_Refactor.Interfaces;

namespace SOLID_Refactor.Classes
{
    public class StudentRepository : IStudentRepository
    {
        public void Delete(Student student)
        {
            Console.WriteLine($"Deleting {student.FirstName} {student.LastName} from DB...");
            Console.WriteLine("End Delete()");
        }

        public void Save(Student student)
        {
            Console.WriteLine($"Saving {student.FirstName} {student.LastName} to DB...");
            Console.WriteLine("End Save()");
        }
    }
}
