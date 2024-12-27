using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class NguyenLieuBO
    {
        private int intMaNguyenLieu;
        private string strTenNguyenLieu;
        private decimal floSoLuong;
        private string strDVT;
        private int intMaNhaCungCap;
        private int intTinhTrang;

        /// <summary>
		/// MaNguyenLieu
		/// Mã Nguyên Liệu
		/// </summary>
        public int MaNguyenLieu 
        {
            get {return intMaNguyenLieu; }
            set {intMaNguyenLieu = value; } 
        }

        /// <summary>
		/// TenNguyenLieu
		/// Tên Nguyên Liệu
		/// </summary>
        public string TenNguyenLieu
        {
            get { return strTenNguyenLieu; }
            set { strTenNguyenLieu = value; }
        }

        /// <summary>
		/// SoLuong
		/// Số Lượng
		/// </summary>
        public decimal SoLuong
        {
            get { return floSoLuong; }
            set { floSoLuong = value; }
        }

        /// <summary>
		/// DVT
		/// Đơn Vị Tính
		/// </summary>
        public string DVT
        {
            get { return strDVT; }
            set { strDVT = value; }
        }

        /// <summary>
		/// MaNhaCungCap
		/// Mã Nhà Cung Cấp
		/// </summary>
        public int MaNhaCungCap
        {
            get { return intMaNhaCungCap; }
            set { intMaNhaCungCap = value; }
        }

        /// <summary>
		/// MaNhaCungCap
		/// Mã Nhà Cung Cấp
		/// </summary>
        public int TinhTrang
        {
            get { return intTinhTrang; }
            set { intTinhTrang = value; }
        }
    }
}
