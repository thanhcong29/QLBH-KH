using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class ChiTietHoaDonBO
    {
        public ChiTietHoaDonBO()
        { }

        /// <summary>
		/// MaHoaDon
		/// Mã Hóa Đơn
		/// </summary>
        private string strMaHoaDon = string.Empty;
        public string MaHoaDon
        {
            get { return strMaHoaDon; }
            set { strMaHoaDon = value; }
        }

        /// <summary>
		/// MaMon
		/// Mã Món
		/// </summary>
        private string strMaCTMon = string.Empty;
        public string MaCTMon
        {
            get { return strMaCTMon; }
            set { strMaCTMon = value; }
        }

        /// <summary>
		/// SoLuong
		/// Số Lượng
		/// </summary>
        public int SoLuong { get; set; }
    }
}
