using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{
    public class CongThucBO
    {
        private int intMaNguyenLieu;
        private string strMaCTMon;
        private float floHamLuong;

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
		/// MaCTMon
		/// Mã Chi Tiết Món
		/// </summary>
        public string MaCTMon
        {
            get { return strMaCTMon; }
            set { strMaCTMon = value; }
        }

        /// <summary>
		/// HamLuong
		/// Hàm Lượng
		/// </summary>
        public float HamLuong
        {
            get { return floHamLuong; }
            set { floHamLuong = value; }
        }
    }
}
