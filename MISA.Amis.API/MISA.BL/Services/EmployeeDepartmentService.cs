using MISA.BL.Entity;
using MISA.BL.Interfaces.Repository;
using MISA.BL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Services
{
    public class EmployeeDepartmentService : BaseService<EmployeeDepartment>, IEmployeeDepartmentService
    {
        IEmployeeDepartmentRepository _employeeDepartmentRepository;
        public EmployeeDepartmentService(IEmployeeDepartmentRepository employeeDepartmentRepository) :base(employeeDepartmentRepository)
        {
            _employeeDepartmentRepository = employeeDepartmentRepository;
        }
    }
}
