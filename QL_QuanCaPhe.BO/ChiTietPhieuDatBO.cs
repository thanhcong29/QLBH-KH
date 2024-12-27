using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class ChiTietPhieuDatBO
    {
        private int intMaNguyenLieu;
        private string strMaPhieuDat;
        private float floSoLuong;
        private int intGiaDat;

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
		/// MaPhieuDat
		/// Mã Phiếu Đặt
		/// </summary>
        public string MaPhieuDat
        {
            get { return strMaPhieuDat; }
            set { strMaPhieuDat = value; }
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

        /// <summary>
		/// GiaDat
		/// Giá Đặt
		/// </summary>
        public int GiaDat
        {
            get { return intGiaDat; }
            set { intGiaDat = value; }
        }
    }
}
