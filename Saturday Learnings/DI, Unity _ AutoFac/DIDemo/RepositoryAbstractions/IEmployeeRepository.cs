using Entities;
using System.Collections.Generic;

namespace RepositoryAbstractions
{
    public interface IEmployeeRepository
    {
        int CreateEmployee(Employee employee);
        Employee GetEmployee(int id);
        List<Employee> GetEmployees();
    }
}
