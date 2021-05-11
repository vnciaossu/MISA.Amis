using MISA.BL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        int GetTotalEmployee();
        IEnumerable<Employee> Pagging(Pagging pagging);      
    }
}
