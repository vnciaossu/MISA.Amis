using System;
using System.Collections.Generic;

namespace MISA.BL.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu bản ghi
        /// </summary>
        /// <returns>Trả về dữ liệu bản ghi</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy toàn bộ bản ghi có id là entityId
        /// </summary>
        /// <param name="entityId">id đối tượng</param>
        /// <returns>Trả về bản ghi có id là entityId</returns>
        T GetById(Guid entityId);

        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns>Thêm thành công bản ghi mới hay không</returns>
        int Insert(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns>Cập nhật bản ghi thành công hay không</returns>
        int Update(T entity);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">id đối tượng</param>
        /// <returns>Xóa bản ghi thành công hay không</returns>
        int Delete(Guid entityId);
    }
}