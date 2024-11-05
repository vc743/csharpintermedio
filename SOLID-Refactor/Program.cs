using SOLID_Refactor.Classes;
using SOLID_Refactor.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        // Configuración de dependencias
        IPaymentProcessor paymentProcessor = new PaymentProcessor();
        ICourseRepository courseRepository = new CourseRepository();
        IEmailService emailService = new EmailService();
        IStudentRepository studentRepository = new StudentRepository();

        CourseSubscription courseSubscription = new CourseSubscription(paymentProcessor, courseRepository, emailService);

        // Crear estudiante
        Student student = new Student
        {
            StudentId = 1,
            FirstName = "Juan",
            LastName = "Perez",
            DoB = new DateTime(2000, 1, 1),
            email = "juan.perez@example.com",
            Address1 = "123 Main St",
            Address2 = "",
            City = "Santo Domingo",
            State = "Distrito Nacional",
            Zipcode = "10101"
        };

        //Guarda el estudiante
        studentRepository.Save(student);

        // Crear curso
        ISubscribe course = new OnsiteCourse
        {
            CourseID = 101,
            Name = "Curso de Programación en C#"
        };

        // Suscribir estudiante al curso
        courseSubscription.Subscribe(course);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
