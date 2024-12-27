using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class PhanQuyenBO
    {
        public PhanQuyenBO()
        { }

        /// <summary>
		/// MaMon
		/// Mã Món
		/// </summary>
        private string strMaMon = string.Empty;
        public string MaNhom
        {
            get { return strMaMon; }
            set { strMaMon = value; }
        }

        /// <summary>
		/// MaMon
		/// Mã Món
		/// </summary>
        private string strMaManHinh = string.Empty;
        public string MaManHinh
        {
            get { return strMaManHinh; }
            set { strMaManHinh = value; }
        }

        public bool CoQuyen { get; set; }
    }
}
