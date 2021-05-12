using MISA.BL.Entity;
using System.Collections.Generic;

namespace MISA.BL.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// Lấy tổng số bản ghi
        /// </summary>
        /// <returns>tổng số bản ghi</returns>
        /// Created by: TMQuy
        int GetTotalEmployee();

        /// <summary>
        /// Phân trang và lọc
        /// </summary>
        /// <param name="pagging"></param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: TMQuy

        IEnumerable<Employee> Pagging(Pagging pagging);
    }
}