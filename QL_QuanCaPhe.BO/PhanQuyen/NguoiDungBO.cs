using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class NguoiDungBO
    {
        /// <summary>
		/// TenDangNhap
		/// Tên Đăng Nhập
		/// </summary>
        private string strTenDN = string.Empty;
        public string TenDangNhap
        {
            get { return strTenDN; }
            set { strTenDN = value; }
        }

        /// <summary>
		/// MatKhau
		/// Mật Khẩu
		/// </summary>
        private string strMatKhau = string.Empty;
        public string MatKhau
        {
            get { return strMatKhau; }
            set { strMatKhau = value; }
        }

        /// <summary>
		/// TrangThai
		/// Trạng Thái
		/// </summary>
        private string strTrangThai = string.Empty;
        public string TrangThai
        {
            get { return strTrangThai; }
            set { strTrangThai = value; }
        }

        /// <summary>
		/// MaNhanVien
		/// Mã Nhân Viên
		/// </summary>
        private string strMaNV = string.Empty;
        public string MaNhanVien
        {
            get { return strMaNV; }
            set { strMaNV = value; }
        }
    }
}
