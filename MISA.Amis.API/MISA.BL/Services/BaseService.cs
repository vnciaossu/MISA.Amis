using MISA.BL.Interfaces.Repository;
using MISA.BL.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MISA.BL.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        public int Delete(Guid entityId)
        {
            var res = _repository.Delete(entityId);
            return res;
        }

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created by: TMQuy
        public IEnumerable<T> GetAll()
        {
            var entitys = _repository.GetAll();
            return entitys;
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        public T GetById(Guid entityId)
        {
            var entity = _repository.GetById(entityId);
            return entity;
        }

        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created by: TMQuy

        public int Insert(T entity)
        {
            CustomValidate(entity);
            var res = _repository.Insert(entity);
            return res;
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created by: TMQuy
        public int Update(T entity)
        {
            CustomValidate(entity);
            var res = _repository.Update(entity);
            return res;
        }

        /// <summary>
        /// Kiểm tra
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CustomValidate(T entity)
        {
        }
    }
}