using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{
    public class DatBanBO
    {
        public DatBanBO()
        { }

        /// <summary>
		/// MaDatBan
		/// Mã Đặt Bàn
		/// </summary>
        private string strMaDatBan = string.Empty;

        public string MaDatBan
        {
            get { return strMaDatBan; }
            set { strMaDatBan = value; }
        }

        /// <summary>
		/// ThoiGianNhanBan
		/// Thời Gian Nhận Bàn
		/// </summary>
        public DateTime ThoiGianNhanBan { get; set; }

        /// <summary>
		/// GhiChu
		/// Ghi Chú
		/// </summary>
        private string strGhiChu = string.Empty;

        public string GhiChu
        {
            get { return strGhiChu; }
            set { strGhiChu = value; }
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
    }
}
