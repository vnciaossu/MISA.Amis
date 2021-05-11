using MISA.BL.Entity;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces.Repository;
using MISA.BL.Interfaces.Services;
using System;
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

        public int GetTotalEmployee()
        {
            var total = _employeeRepository.GetTotalEmployee();
            return total;
        }

        public IEnumerable<Employee> Pagging(Pagging pagging)
        {
            var employees = _employeeRepository.Pagging(pagging);
            return employees;
        }

        protected override void CustomValidate(Employee entity)
        {
            if (entity is Employee)         {
                var employee = entity as Employee;
                var isExits = _employeeRepository.CheckEmployeeCodeExits(employee.EmployeeId, employee.EmployeeCode);
                if (isExits == true)
                {
                    throw new EmployeeException("Mã khách hàng đã tồn tại trên hệ thống");
                }
            }
        }
    }
}