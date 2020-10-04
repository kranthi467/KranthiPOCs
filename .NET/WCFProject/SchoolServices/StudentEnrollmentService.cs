using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolDatabase;
using SchoolServiceInterfaces;

namespace SchoolServices
{
    public class StudentEnrollmentService: IStudentEnrollmentService
    {
        public void EnrollStudent(Student s)
        {
            StudentDatabase sd = new StudentDatabase();
            sd.AddStudent(s.StudentName);
        }

        public Student[] GetEnrolledStudents()
        {
            StudentDatabase sd = new StudentDatabase();
            List<string> studentList = sd.GetStudentList();
            Student[] studentArray = new Student[studentList.Count];
            for (int i = 0; i < studentList.Count; i++)
            {
                Student s = new Student();
                s.StudentName = studentList[i];
                studentArray[i] = s;
            }
            return studentArray;
        }
    }
}
