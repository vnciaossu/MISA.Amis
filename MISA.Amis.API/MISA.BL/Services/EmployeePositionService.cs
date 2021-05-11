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
    public class EmployeePositionService : BaseService<EmployeePosition>, IEmployeePositionService
    {
        IEmployeePositionRepository _employeePositionRepository;

        public EmployeePositionService(IEmployeePositionRepository employeePositionRepository) :base(employeePositionRepository)
        {
            _employeePositionRepository = employeePositionRepository;
        }
    }
}
