using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class HoaDonBO
    {

        public HoaDonBO()
        { }

        /// <summary>
		/// MaHoaDon
		/// Mã Hóa Đơn
		/// </summary>
        public string MaHoaDon { get; set; }
        /// <summary>
		/// NgayLap
		/// Ngày Lập
		/// </summary>
        public DateTime NgayLap { get; set; }

        /// <summary>
		/// NgayXuat
		/// Ngày Xuất
		/// </summary>
        public DateTime NgayXuat { get; set; }

        /// <summary>
		/// TongTien
		/// Tổng Tiền
		/// </summary>
        public float TongTien { get; set; }

        /// <summary>
		/// ThanhToan
		/// Thanh Toán
		/// </summary>
        public float ThanhToan { get; set; }

        /// <summary>
		/// MaBan
		/// Mã Bàn
		/// </summary>
        public int MaBan { get; set; }

        /// <summary>
		/// MaNhanVien
		/// Mã Nhân Viên
		/// </summary>
        private string strMaNhanVien = string.Empty;
        public string MaNhanVien
        {
            get { return strMaNhanVien; }
            set { strMaNhanVien = value; }
        }

        /// <summary>
		/// MaKhachHang
		/// Mã Khách Hàng
		/// </summary>
        private string strMaKhachHang = string.Empty;
        public string MaKhachHang
        {
            get { return strMaKhachHang; }
            set { strMaKhachHang = value; }
        }

        /// <summary>
		/// MaGiamGia
		/// Mã Giảm Giá
		/// </summary>
        private string strMaGiamGia = string.Empty;
        public string MaGiamGia
        {
            get { return strMaGiamGia; }
            set { strMaGiamGia = value; }
        }

        public List<ChiTietHoaDonBO> lstChiTietHoaDonBOs { get; set; }
    }
}
