using Microsoft.AspNetCore.Mvc;
using MISA.BL.Entity;
using MISA.BL.Interfaces.Services;
using System;

namespace MISA.Amis.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created by: TMQuy
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pagging"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        [HttpGet("pagging")]
        public IActionResult Pagging([FromQuery] Pagging pagging)
        {
            var employees = _employeeService.Pagging(pagging);
            return Ok(employees);
        }

        /// <summary>
        /// Lấy số lượng bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created by: TMQuy
        [HttpGet("total")]
        public IActionResult GetTotalRecord()
        {
            var total = _employeeService.GetTotalEmployee();
            return Ok(total);
        }

        /// <summary>
        /// Tìm kiếm theo id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            var employee = _employeeService.GetById(employeeId);
            return Ok(employee);
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var res = _employeeService.Insert(employee);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Created by: TMQuy
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

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid employeeId)
        {
            var res = _employeeService.Delete(employeeId);
            return Ok(res);
        }
    }
}