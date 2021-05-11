using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.BL.Entity;
using MISA.BL.Interfaces.Repository;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System;

namespace MISA.DL.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool CheckEmployeeCodeExits(Guid? employeeId ,string employeeCode)
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommad = "Proc_CheckEmployeeCodeExists";
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmployeeId", null);
                param.Add("@EmployeeCode", employeeCode);
                var res = dbConnection.QueryFirstOrDefault<bool>(sqlCommad,param: param ,commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public int GetTotalEmployee()
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommad = "Proc_GetTotalEmployee";
                var total = dbConnection.QueryFirstOrDefault<int>(sqlCommad, commandType: CommandType.StoredProcedure);
                return total;
            }
        }

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
