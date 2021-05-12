using MISA.BL.Entity;
using System;
using System.Collections.Generic;

namespace MISA.BL.Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
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

        /// <summary>
        /// Kiểm tra mã nhân viên đã có chưa
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employeeCode"></param>
        /// <returns>true: đã có, false: chưa có</returns>
        /// Created by: TMQuy

        bool CheckEmployeeCodeExits(Guid? employeeId, string employeeCode);
    }
}