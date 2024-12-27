using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class ChiTietPhieuNhapBO
    {
        private int intMaNguyenLieu;
        private string strMaPhieuNhap;
        private float floSoLuong;

        /// <summary>
		/// MaNguyenLieu
		/// Mã Nguyên Liệu
		/// </summary>
        public int MaNguyenLieu
        {
            get { return intMaNguyenLieu; }
            set { intMaNguyenLieu = value; }
        }

        /// <summary>
		/// MaPhieuNhap
		/// Mã Phiếu Nhập
		/// </summary>
        public string MaPhieuNhap
        {
            get { return strMaPhieuNhap; }
            set { strMaPhieuNhap = value; }
        }

        /// <summary>
		/// SoLuong
		/// Số Lượng
		/// </summary>
        public float SoLuong
        {
            get { return floSoLuong; }
            set { floSoLuong = value; }
        }
    }
}
