using BusinessAbstractions;
using Entities;
using RepositoryAbstractions;
using System;
using System.Collections.Generic;

namespace Business
{
    public class ManagerBusiness: IEmployeeBusiness
    {
        IEmployeeRepository _employeeRepository = null;

        public ManagerBusiness(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEmployeeRepository EmployeeRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public void InitializeRepository(IEmployeeRepository employeeRepository)
        {
            throw new NotImplementedException();
        }
    }
}
