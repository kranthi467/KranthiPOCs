using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServiceInterfaces
{
        [ServiceContract]
        public interface IStudentEnrollmentService
        {
            [OperationContract]
            void EnrollStudent(Student s);

            [OperationContract]
            Student[] GetEnrolledStudents();
        }

        [DataContract]
        public class Student
        {
            private string name;

            [DataMember]
            public string StudentName
            {
                set { this.name = value; }
                get { return this.name; }
            }
        }
    }

