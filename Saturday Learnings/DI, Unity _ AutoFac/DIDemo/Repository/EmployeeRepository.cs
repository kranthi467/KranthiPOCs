using RepositoryAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public int CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            return new Employee()
            {
                EmployeeID = 1,
                Name = "xyz",
                Email = "xyz@ggktech.com"
            };
        }

        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
