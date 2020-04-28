using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace ThreeApi.Controllers
{
    [Route("V1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetByDepartmentId(int departmentId)
        {
            var employees = await employeeRepository.GeByDepartmentId(departmentId);
            if (!employees.Any())
            {
                return NoContent();
            }
            return Ok(employees);
        }
        [HttpGet("One/{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult>Add([FromBody]Employee employee)
        {
            var added = await employeeRepository.Add(employee);
            return CreatedAtRoute("GetById", new { id = added.Id }, value: added);
 
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Fire(int id)
        {
            var res = await employeeRepository.Fire(id);
            if (res != null)
            {
                return NoContent();
            }
            return NotFound(res);
        }

    }
}