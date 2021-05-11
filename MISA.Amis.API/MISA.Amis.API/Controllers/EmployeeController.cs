using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Entity;
using MISA.BL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Amis.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet("pagging")]
        public IActionResult Pagging([FromQuery] Pagging pagging)
        {
            var employees = _employeeService.Pagging(pagging);
            return Ok(employees);
        }

        [HttpGet("total")]
        public IActionResult GetTotalRecord()
        {
            var total = _employeeService.GetTotalEmployee();
            return Ok(total);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            var employee = _employeeService.GetById(employeeId);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee) 
        {
            var res = _employeeService.Insert(employee);
            if(res > 0)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Employee employee)
        {
            var res = _employeeService.Update(employee);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery]Guid employeeId)
        {
            var res = _employeeService.Delete(employeeId);
            return Ok(res);
        }
    }
}
