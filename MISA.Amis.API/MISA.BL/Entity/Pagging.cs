namespace MISA.BL.Entity
{
    public class Pagging
    {
        /// <summary>
        /// Bảng ghi
        /// </summary>
        public int pageIndex { get; set; } = 1;

        /// <summary>
        /// Số lượng bản ghi
        /// </summary>
        public int pageSize { get; set; } = 10;

        /// <summary>
        /// Tên hoặc mã nhân viên nhập vào
        /// </summary>
        public string fillter { get; set; } = null;
    }
}