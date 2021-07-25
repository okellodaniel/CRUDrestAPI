using System.Collections.Generic;
using CrudRestApi.models;

namespace CrudRestApi.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployee();

        Employee GetEmployee(Guid id);

        Employee AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
    }
}