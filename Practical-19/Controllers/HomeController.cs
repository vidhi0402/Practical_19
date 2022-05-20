using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical_19.Models;
using Practical_19.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Iservice iservices;
        private readonly IloggerManager _log;

        public HomeController(Iservice iservicesDA, IloggerManager log)
        {
            this.iservices = iservicesDA;
            _log = log;
        }

        [HttpGet]
        public async Task<List<Employee>> GetAllEmployee()
        {
            
            var employees = await iservices.GetEmployee();
            _log.LogInfo("Fetching all Employees from Database");
            if (employees != null)
            {
                _log.LogInfo($"Returning {employees.Count} Employees.");
                return employees; 
            }
           
            return employees;
        }

        [HttpPost("AddEmployee")]
        public async Task<Employee> AddEmployee([FromBody] Employee employee)
        {
            _log.LogInfo("Adding a new Employee");
            var result = await iservices.PostEmployee(employee);
            
            if (result != null)
            {
                _log.LogInfo("Employee Added Successfully");
                return result;
            }
            
            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            _log.LogInfo("Updating an Existing Employee");
            try
            {
                if (id == employee.Id)
                {
                    _log.LogInfo($"Employee with {id} Exists");
                    await iservices.UpdateEmployee(employee);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                _log.LogError("Error While Updating an Employee");
                throw;
            }
            _log.LogInfo("Employee Updated Successfully");
            return Ok("Updated Successfull");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _log.LogInfo("Deleting an Existing Employee");
            var employee = await iservices.GetEmployeeByID(id);

            if (employee == null)
            {
                _log.LogError($"Employee with {id} Doesn't Exists");
                return NotFound();
            }
            await iservices.DeleteEmployee(id);
            _log.LogInfo("Employee Deleted Successfully");
            return Ok("Deleted Successfull");
        }
    }
}
