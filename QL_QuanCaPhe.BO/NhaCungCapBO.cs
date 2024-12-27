using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class NhaCungCapBO
    {
        private int intMaNhaCungCap;
        private string strTenNhaCungCap;
        private string strSDT;
        private string strDiaChi;
        private int intTinhTrang;

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
		/// TenNhaCungCap
		/// Tên Nhà Cung Cấp
		/// </summary>
        public int TenNhaCungCap
        {
            get { return intMaNhaCungCap; }
            set { intMaNhaCungCap = value; }
        }

        /// <summary>
		/// SDT
		/// Số Điện Thoại
		/// </summary>
        public string SDT
        {
            get { return strSDT; }
            set { strSDT = value; }
        }

        /// <summary>
		/// DiaChi
		/// Địa Chỉ
		/// </summary>
        public string DiaChi
        {
            get { return strDiaChi; }
            set { strDiaChi = value; }
        }

        /// <summary>
		/// TinhTrang
		/// Tình Trạng :  0 chưa xóa, 1 đã xóa
		/// </summary>
        public int TinhTrang
        {
            get { return intTinhTrang; }
            set { intTinhTrang = value; }
        }
    }
}
