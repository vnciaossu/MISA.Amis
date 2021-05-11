using Microsoft.Extensions.Configuration;
using MISA.BL.Entity;
using MISA.BL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Repository
{
    public class EmployeeDepartmentRepository : BaseRepository<EmployeeDepartment>, IEmployeeDepartmentRepository
    {
        public EmployeeDepartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
