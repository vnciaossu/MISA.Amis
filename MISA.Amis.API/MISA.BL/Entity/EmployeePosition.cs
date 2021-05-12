using System;

namespace MISA.BL.Entity
{
    public class EmployeePosition
    {
        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }
    }
}