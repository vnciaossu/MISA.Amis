using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Amis.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeDepartmentController : ControllerBase
    {
        IEmployeeDepartmentService _employeeDepartmentService;
        public EmployeeDepartmentController(IEmployeeDepartmentService employeeDepartmentService)
        {
            _employeeDepartmentService = employeeDepartmentService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _employeeDepartmentService.GetAll();
            return Ok(departments);
        }
    }
}
