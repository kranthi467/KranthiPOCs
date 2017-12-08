using BusinessAbstractions;
using Entities;
using RepositoryAbstractions;
using System;
using System.Collections.Generic;

namespace Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        IEmployeeRepository _employeeRepository = null;

        //Constructor Injection
        public EmployeeBusiness(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //Property Injection
        public IEmployeeRepository EmployeeRepository { get; set; }

        public int CreateEmployee(Employee employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }
    }
}
