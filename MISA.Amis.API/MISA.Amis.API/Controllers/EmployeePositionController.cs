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
    public class EmployeePositionController : ControllerBase
    {
        IEmployeePositionService _employeePositionService;
        public EmployeePositionController(IEmployeePositionService employeePositionService)
        {
            _employeePositionService = employeePositionService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var positions = _employeePositionService.GetAll();
            return Ok(positions);
        }
    }
}
