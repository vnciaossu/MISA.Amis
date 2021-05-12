using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.BL.Entity;
using MISA.BL.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.DL.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Kiểm tra mã nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        public bool CheckEmployeeCodeExits(Guid? employeeId, string employeeCode)
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommad = "Proc_CheckEmployeeCodeExists";
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmployeeId", null);
                param.Add("@EmployeeCode", employeeCode);
                var res = dbConnection.QueryFirstOrDefault<bool>(sqlCommad, param: param, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Lấy tổng số bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created by: TMQuy
        public int GetTotalEmployee()
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommad = "Proc_GetTotalEmployee";
                var total = dbConnection.QueryFirstOrDefault<int>(sqlCommad, commandType: CommandType.StoredProcedure);
                return total;
            }
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pagging"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        public IEnumerable<Employee> Pagging(Pagging pagging)
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommad = "Proc_PaggingEmployee";
                DynamicParameters param = new DynamicParameters();
                param.Add("@m_Page", pagging.pageIndex);
                param.Add("@m_PageSize", pagging.pageSize);
                param.Add("@fillter", pagging.fillter);
                var employees = dbConnection.Query<Employee>(sqlCommad, param: param, commandType: CommandType.StoredProcedure);
                return employees;
            }
        }
    }
}