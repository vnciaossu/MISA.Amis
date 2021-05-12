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

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by: TMQuy
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

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created by: TMQuy
        public IEnumerable<T> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommand = $"Proc_Get{tagName}s";
                var entitys = dbConnection.Query<T>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entitys;
            }
        }

        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by: TMQuy
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

        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            using (dbConnection = new MySqlConnection(connectingDB))
            {
                var sqlCommand = $"Proc_Insert{tagName}";
                var res = dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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