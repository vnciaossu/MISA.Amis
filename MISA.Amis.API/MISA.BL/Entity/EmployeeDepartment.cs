using System;

namespace MISA.BL.Entity
{
    public class EmployeeDepartment
    {
        /// <summary>
        /// ID phòng ban
        /// </summary>
        public Guid EmployeeDepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string EmployeeDepartmentName { get; set; }
    }
}