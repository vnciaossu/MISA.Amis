using System;

namespace MISA.BL.Entity
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int Gender { get; set; } = 0;

        public string GenderName
        {
            get
            {
                if (Gender == 1)
                {
                    return "Nam";
                }
                else if (Gender == 2)
                {
                    return "Nữ";
                }
                return null;
            }
        }

        public DateTime? DateOfBirth { get; set; } = null;
        public string? IdentificationId { get; set; } = null;
        public DateTime IdentificationDate { get; set; }
        public string? IdentificationPlace { get; set; } = null;
        public Guid EmployeeDepartmentId { get; set; }

        public string EmployeeDepartmentName 
        {
            get
            {
                if (EmployeeDepartmentId == Guid.Parse("7e02e90a-b0b8-11eb-8a1f-00163e047e89"))
                {
                    return "Phòng Sản Xuất";
                }
                else if (EmployeeDepartmentId == Guid.Parse("7e111447-b0b8-11eb-8a1f-00163e047e89"))
                {
                    return "Phòng Nhân sự";
                }
                else if (EmployeeDepartmentId == Guid.Parse("7e2664dd-b0b8-11eb-8a1f-00163e047e89"))
                {
                    return "Phòng Kế toán";
                }
                else if (EmployeeDepartmentId == Guid.Parse("835dbf81-b0b8-11eb-8a1f-00163e047e89"))
                {
                    return "Phòng Hành chính";
                }
                return null;
            }
        }

        public Guid? EmployeePositionId { get; set; } = null;

        public string EmployeePositionName
        {
            get
            {
                if (EmployeePositionId == Guid.Parse("966f3957-b0b8-11eb-8a1f-00163e047e89"))
                {
                    return "Giám đốc";
                }
                else if (EmployeePositionId == Guid.Parse("9bffb538-b0b8-11eb-8a1f-00163e047e89"))
                {
                    return "Nhân viên thử việc";
                }
                else if (EmployeePositionId == Guid.Parse("a1790de2-b0b8-11eb-8a1f-00163e047e89"))
                {
                    return "Nhân viên chính thức";
                }

                return null;
            }
        }

        public string? Address { get; set; } = null;
        public string? TelephoneNumber { get; set; } = null;
        public string? TablephoneNmber { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? BankNumber { get; set; } = null;
        public string? BankName { get; set; } = null;
        public string? BankBranch { get; set; } = null;
        public string? Note { get; set; } = null;

        /// <summary>
        /// Ngày tạo
        /// Created By : TMQuy
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// Created By : TMQuy
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa lần cuối
        /// Created By : TMQuy
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa lần cuối
        /// Created By : TMQuy
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}