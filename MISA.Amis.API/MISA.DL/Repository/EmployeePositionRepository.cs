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
    public class EmployeePositionRepository : BaseRepository<EmployeePosition>, IEmployeePositionRepository
    {
        public EmployeePositionRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
