using MISA.BL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        int GetTotalEmployee();

        IEnumerable<Employee> Pagging(Pagging pagging);

        bool CheckEmployeeCodeExits(Guid? employeeId, string employeeCode);
    }
}
