using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    public class StudentDatabase
    {
        private static List<string> studentData = new List<string>();

        public void AddStudent(string studentName)
        {
            studentData.Add(studentName);
        }

        public List<string> GetStudentList()
        {
            return studentData;
        }
    }
}
