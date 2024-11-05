using SOLID_Refactor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Refactor.Classes
{
    public class CourseSubscription
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ICourseRepository _courseRepository;
        private readonly IEmailService _emailService;
        public CourseSubscription(IPaymentProcessor paymentProcessor, ICourseRepository courseRepository, IEmailService emailService)
        {
            _paymentProcessor = paymentProcessor;
            _courseRepository = courseRepository;
            _emailService = emailService;
        }

        public void Subscribe(ISubscribe course) { 
            course.Subscribe(); 
            _paymentProcessor.ProcessPayment(); 
            _courseRepository.Save((Course)course); 
            _emailService.SendConfirmation(); 
            Console.WriteLine("Subscription complete");
        }
    }
}
