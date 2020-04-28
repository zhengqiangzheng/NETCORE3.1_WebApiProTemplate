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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> GetAll()
        {
            var departments = await departmentRepository.GetAll();
            if (!departments.Any())
            {
                return NoContent();
            }
            return Ok(departments);
        }
        [HttpPost]
        public async Task<ActionResult<Department>> Add([FromBody]Department department)
        {
            var added = await departmentRepository.Add(department);
            return Ok(added);
        }
    }
}