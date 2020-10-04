using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  
    public class EmployeeController : ApiController
    {
        private static List<Employee> Employees;
        static EmployeeController()
        {
            Employees = new List<Employee>()
            {
                new Employee {ID=0, Name="KKR", Age=21 },
                new Employee {ID=1, Name="Abhinay", Age=21 },
                new Employee {ID=2, Name="Anvesh", Age=21 },
                new Employee {ID=3, Name="Rohit", Age=20 },
                new Employee {ID=4, Name="Sridhar", Age=22 },
                new Employee {ID=5, Name="Yuva", Age=21 },
                new Employee {ID=6, Name="Gopal", Age=21 }
            };
        }

        public IEnumerable<Employee> Get()
        {
            return Employees;
        }


        public Employee Get(int id)
        {
            return Employees.Where(c => c.ID == id).SingleOrDefault();
            //  return Employees[id];
        }


        public void Post([FromBody]Employee value)
        {
            Employees.Add(value);
        }


        public void Put(int id, [FromBody]Employee value)
        {
            Employees.Remove(Employees.Where(c => c.ID == id).Single());
            // Employees.RemoveAt(id);
            Employees.Add(value);
        }


        public void Delete(int id)
        {
            Employees.Remove(Employees.Where(c => c.ID == id).Single());
        }
    }
}
