using SchoolServiceInterfaces;
using SchoolServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServiceHost
{
    class Program
    {
        static ServiceHost host = null;

        static void StartService()
        {
            host = new ServiceHost(typeof(StudentEnrollmentService));

            //host.AddServiceEndpoint(new ServiceEndpoint(
            //ContractDescription.GetContract(typeof(IStudentEnrollmentService)),
            //new WSHttpBinding(), 
            //new EndpointAddress("http://localhost/WCF/schoolservices"))); 
            host.Open();
        }

        static void CloseService()
        {
            if (host.State != CommunicationState.Closed)
            {
                host.Close();
            }
        }

        static void Main(string[] args)
        {
            StartService();

            Console.WriteLine("Student Enrollment Service is running....");
            Console.ReadKey();

            CloseService();
        }
    }
}
