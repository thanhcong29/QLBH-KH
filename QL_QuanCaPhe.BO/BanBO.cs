using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class BanBO
    {
        public BanBO()
        { }

        /// <summary>
		/// MaBan
		/// Mã Bàn
		/// </summary>
        private string strMaBan = string.Empty;

        public string MaBan
        {
            get { return strMaBan; }
            set { strMaBan = value; }
        }

        /// <summary>
		/// TenBan
		/// Tên Bàn
		/// </summary>
        private string strTenBan = string.Empty;

        public string TenBan
        {
            get { return strTenBan; }
            set { strTenBan = value; }
        }

        /// <summary>
		/// SoChoNgoi
		/// Số Chỗ Ngồi
		/// </summary>
        public int SoChoNgoi { get; set; }

        /// <summary>
		/// TrangThai
		/// Trạng Thái
		/// </summary>
        private string strTrangThai = string.Empty;

        public string TrangThai
        {
            get { return strTrangThai; }
            set { strTrangThai = value; }
        }

        /// <summary>
		/// MaKhuVuc
		/// Mã Khu Vực
		/// </summary>
        private string strMaKhuVuc = string.Empty;

        public string MaKhuVuc
        {
            get { return strMaKhuVuc; }
            set { strMaKhuVuc = value; }
        }
    }
}
