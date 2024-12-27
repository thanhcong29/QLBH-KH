using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class NhanVienBO
    {
        public NhanVienBO()
        { }

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

        /// <summary>
		/// HoTen
		/// Họ Tên Nhân Viên
		/// </summary>
        private string strHoTen = string.Empty;

        public string HoTen
        {
            get { return strHoTen; }
            set { strHoTen = value; }
        }

        /// <summary>
		/// GioiTinh
		/// Giới Tính
		/// </summary>
        private string strGioiTinh = string.Empty;
        public string GioiTinh
        {
            get { return strGioiTinh; }
            set { strGioiTinh = value; }
        }


        /// <summary>
        /// DiaChi
        /// Địa Chỉ
        /// </summary>
        private string strDiaChi = string.Empty;
        public string DiaChi
        {
            get { return strDiaChi; }
            set { strDiaChi = value; }
        }

        /// <summary>
		/// NgaySinh
		/// Ngày Sinh
		/// </summary>
        public DateTime? NgaySinh { get; set; }

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

        /// <summary>
		/// NgayVaoLam
		/// Ngày Vào Làm
		/// </summary>
        public DateTime? NgayVaoLam { get; set; }

        /// <summary>
        /// LuongCoBan
        /// Lương Cơ Bản
        /// </summary>
        public int LuongCoBan { get; set; }

        /// <summary>
        /// ChucVu
        /// Chức Vụ
        /// </summary>
        private string strChucVu = string.Empty;
        public string ChucVu
        {
            get { return strChucVu; }
            set { strChucVu = value; }
        }

        /// <summary>
		/// HinhAnh
		/// Hình Ảnh
		/// </summary>
        private string strHinhAnh = string.Empty;

        public string HinhAnh
        {
            get { return strHinhAnh; }
            set { strHinhAnh = value; }
        }
    }
}
