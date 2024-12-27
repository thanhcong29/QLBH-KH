using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class ChiTietThucDonBO
    {
        public ChiTietThucDonBO()
        { }

        /// <summary>
		/// MaCTMon
		/// Mã Chi Tiết Món
		/// </summary>
        private string strMaCTMon = string.Empty;
        public string MaCTMon
        {
            get { return strMaCTMon; }
            set { strMaCTMon = value; }
        }

        /// <summary>
		/// Size
		/// Size
		/// </summary>
        private string strSize = string.Empty;
        public string Size
        {
            get { return strSize; }
            set { strSize = value; }
        }

        /// <summary>
		/// Size
		/// Size
		/// </summary>
        public float Gia { get; set; }

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
    }
}
