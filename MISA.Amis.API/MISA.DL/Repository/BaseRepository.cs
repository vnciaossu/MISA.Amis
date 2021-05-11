using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.BL.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.DL.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private IConfiguration _configuration;
        protected string connectingDB;
        protected IDbConnection dbConnection;
        private string tagName = typeof(T).Name;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectingDB = configuration.GetConnectionString("connectionDB");
        }

        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommand = $"Proc_Delete{tagName}";
                DynamicParameters param = new DynamicParameters();
                param.Add($"@{tagName}Id", entityId);
                var res = dbConnection.Execute(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommand = $"Proc_Get{tagName}s";
                var entitys = dbConnection.Query<T>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entitys;
            }
        }

        public T GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommand = $"Proc_Get{tagName}ById";
                DynamicParameters param = new DynamicParameters();
                param.Add($"@{tagName}Id", entityId);
                var entity = dbConnection.QueryFirstOrDefault<T>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public int Insert(T entity)
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommand = $"Proc_Insert{tagName}";
                var res = dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public int Update(T entity)
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommand = $"Proc_Update{tagName}";
                var res = dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
    }
}