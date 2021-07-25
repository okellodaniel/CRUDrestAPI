using System;
using CrudRestApi.EmployeeData;
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
    }
}