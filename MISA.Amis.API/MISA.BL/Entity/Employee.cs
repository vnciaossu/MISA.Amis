using System;

namespace MISA.BL.Entity
{
    public class Employee
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Giới tính int
        /// </summary>
        public int Gender { get; set; } = 0;

        /// <summary>
        /// Giới tính string
        /// </summary>

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

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; } = null;

        /// <summary>
        /// CMND
        /// </summary>
        public string? IdentificationId { get; set; } = null;

        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        public DateTime IdentificationDate { get; set; }

        /// <summary>
        /// Nơi cấp CMND
        /// </summary>
        public string? IdentificationPlace { get; set; } = null;

        /// <summary>
        /// ID phòng ban
        /// </summary>
        public Guid EmployeeDepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>

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

        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid? EmployeePositionId { get; set; } = null;

        /// <summary>
        /// Tên vị trí
        /// </summary>

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

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; } = null;

        /// <summary>
        /// Điện thoại di động
        /// </summary>
        public string? TelephoneNumber { get; set; } = null;

        /// <summary>
        /// Điện thoại bàn
        /// </summary>
        public string? TablephoneNmber { get; set; } = null;

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; } = null;

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string? BankNumber { get; set; } = null;

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; } = null;

        /// <summary>
        /// CHi nhánh ngân hàng
        /// </summary>
        public string? BankBranch { get; set; } = null;

        /// <summary>
        /// Ghi chú
        /// </summary>
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