using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentsController : ApiController
    {
        private static List<Student> Students;
        static StudentsController()
        {
            Students = new List<Student>()
            {
                new Student {RollNumber=0, Name="KKR", Age=21 },
                new Student {RollNumber=1, Name="Abhinay", Age=21 },
                new Student {RollNumber=2, Name="Anvesh", Age=21 },
                new Student {RollNumber=3, Name="Rohit", Age=20 },
                new Student {RollNumber=4, Name="Sridhar", Age=22 },
                new Student {RollNumber=5, Name="Yuva", Age=21 },
                new Student {RollNumber=6, Name="Gopal", Age=21 }
            };
        }

        public IEnumerable<Student> Get()
        {
            //return Request.CreateResponse(HttpStatusCode.OK, Employees);
            return Students;
        }


        public Student Get(int id)
        {
            return Students.Where(c => c.RollNumber == id).SingleOrDefault();
            //  return Employees[id];
        }


        public Student Post([FromBody]Student value)
        {
            Students.Add(value);
            return value;
        }


        public void Put(int id, [FromBody]Student value)
        {
            Students.Remove(Students.Where(c => c.RollNumber == id).Single());
            // Employees.RemoveAt(id);
            Students.Add(value);
        }


        public void Delete(int id)
        {
            Students.Remove(Students.Where(c => c.RollNumber == id).Single());
        }
    }
}
