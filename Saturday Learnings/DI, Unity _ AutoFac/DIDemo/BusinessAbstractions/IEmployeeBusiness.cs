using Entities;
using RepositoryAbstractions;
using System.Collections.Generic;

namespace BusinessAbstractions
{
    public interface IEmployeeBusiness
    {
        IEmployeeRepository EmployeeRepository { get; set; }

        int CreateEmployee(Employee employee);
        Employee GetEmployee(int id);
        List<Employee> GetEmployees();
    }
}
