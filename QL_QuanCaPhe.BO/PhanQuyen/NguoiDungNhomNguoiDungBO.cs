using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class NguoiDungNhomNguoiDungBO
    {
        public NguoiDungNhomNguoiDungBO()
        { }

        /// <summary>
		/// TENDANGNHAP
		/// Tên Đăng Nhập
		/// </summary>
        private string strTenDN = string.Empty;
        public string TenDangNhap
        {
            get { return strTenDN; }
            set { strTenDN = value; }
        }

        /// <summary>
		/// MaNhom
		/// Mã Nhóm
		/// </summary>
        private string strMaNhom = string.Empty;
        public string MaNhom
        {
            get { return strMaNhom; }
            set { strMaNhom = value; }
        }

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
    }
}
