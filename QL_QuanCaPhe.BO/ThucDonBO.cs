using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class ThucDonBO
    {
        public ThucDonBO()
        { }

        /// <summary>
		/// MaMon
		/// Mã Món
		/// </summary>
        private string strMaMon = string.Empty;
        public string MaMon
        {
            get { return strMaMon; }
            set { strMaMon = value; }
        }

        /// <summary>
		/// TenMon
		/// Tên Món
		/// </summary>
        private string strTenMon = string.Empty;
        public string TenMon
        {
            get { return strTenMon; }
            set { strTenMon = value; }
        }

        /// <summary>
		/// MaLoai
		/// Mã Loại
		/// </summary>
        private string strMaLoai = string.Empty;
        public string MaLoai
        {
            get { return strMaLoai; }
            set { strMaLoai = value; }
        }

        /// <summary>
		/// DVT
		/// Đơn Vị Tính
		/// </summary>
        private string strDVT = string.Empty;
        public string DVT
        {
            get { return strDVT; }
            set { strDVT = value; }
        }

        /// <summary>
		/// DVT
		/// Đơn Vị Tính
		/// </summary>
        private string strHinhAnh = string.Empty;
        public string HinhAnh
        {
            get { return strHinhAnh; }
            set { strHinhAnh = value; }
        }

        /// <summary>
		/// GIA
		/// Giá
		/// </summary>
        public float Gia { get; set; }
    }
}
