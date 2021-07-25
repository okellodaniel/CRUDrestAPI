using System;
using CrudRestApi.EmployeeData;
using CrudRestApi.models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace CrudRestApi.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeData;
        // GET
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }
        
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"The employee with Id:{id} not found");
        }
        
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,employee);
        }
        
        [HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee with the Id:{id} could not be found");

        }
        
        [HttpPatch]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);

            if (existingEmployee != null)
            {
                employee.Id = existingEmployee.Id;
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee with the Id:{id} could not be found");

        }
        
    }
}