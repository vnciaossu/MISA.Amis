using MISA.BL.Entity;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces.Repository;
using MISA.BL.Interfaces.Services;
using System.Collections.Generic;

namespace MISA.BL.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Lấy tổng số bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created by: TMQuy
        public int GetTotalEmployee()
        {
            var total = _employeeRepository.GetTotalEmployee();
            return total;
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pagging"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        public IEnumerable<Employee> Pagging(Pagging pagging)
        {
            var employees = _employeeRepository.Pagging(pagging);
            return employees;
        }

        /// <summary>
        /// Kiểm tra
        /// </summary>
        /// <param name="entity"></param>
        /// Created by: TMQuy
        protected override void CustomValidate(Employee entity)
        {
            if (entity is Employee)
            {
                var employee = entity as Employee;
                var isExits = _employeeRepository.CheckEmployeeCodeExits(employee.EmployeeId, employee.EmployeeCode);
                if (isExits == true)
                {
                    var msgError = Properties.Resources.ErrorEmployeeCodeExits;
                    throw new EmployeeException(msgError);
                }
            }
        }
    }
}