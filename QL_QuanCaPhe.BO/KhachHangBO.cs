using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class KhachHangBO
    {
        public KhachHangBO()
        { }

        /// <summary>
		/// MaKhachHang
		/// Mã Khách Hàng
		/// </summary>
        private string strMaKH = string.Empty;

        public string MaKhachHang
        {
            get { return strMaKH; }
            set { strMaKH = value; }
        }

        /// <summary>
		/// TenKhachHang
		/// Tên Khách Hàng
		/// </summary>
        private string strTenKH = string.Empty;

        public string TenKhachHang
        {
            get { return strTenKH; }
            set { strTenKH = value; }
        }

        /// <summary>
		/// SDT
		/// Số Điện Thoại
		/// </summary>
        private string strSDT = string.Empty;

        public string SDT
        {
            get { return strSDT; }
            set { strSDT = value; }
        }

        public string MatKhau { get; set; }
        /// <summary>
		/// Email
		/// Email
		/// </summary>
        private string strEmail = string.Empty;

        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        /// <summary>
		/// DiemThuong
		/// Điểm thưởng khách hàng
		/// </summary>
        public float DiemThuong { get; set; }

        /// <summary>
		/// TinhTrang
		/// Tình trạng (Đã Xóa)
		/// </summary>
        public int TinhTrang { get; set; }
    }
}
