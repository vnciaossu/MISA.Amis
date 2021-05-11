using MISA.BL.Interfaces.Repository;
using MISA.BL.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MISA.BL.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public int Delete(Guid entityId)
        {
            var res = _repository.Delete(entityId);
            return res;
        }

        public IEnumerable<T> GetAll()
        {
            var entitys = _repository.GetAll();
            return entitys;
        }

        public T GetById(Guid entityId)
        {
            var entity = _repository.GetById(entityId);
            return entity;
        }

        public int Insert(T entity)
        {
            CustomValidate(entity);
            var res = _repository.Insert(entity);
            return res;
        }

        public int Update(T entity)
        {
            var res = _repository.Update(entity);
            return res;
        }

        protected virtual void CustomValidate(T entity)
        {

        }
    }
}