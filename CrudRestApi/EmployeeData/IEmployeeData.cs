using System;
using System.Collections.Generic;
using CrudRestApi.models;

namespace CrudRestApi.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        void AddEmployee(Employee employee);
        
        void DeleteEmployee(Employee employee);
        
        Employee EditEmployee(Employee employee);
    }
}