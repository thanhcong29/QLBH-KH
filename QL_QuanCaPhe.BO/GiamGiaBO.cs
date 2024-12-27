using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class GiamGiaBO
    {
        public GiamGiaBO()
        { }

        /// <summary>
		/// MaGiamGia
		/// Mã Giảm Giá
		/// </summary>
        public string MaGiamGia { get; set; }

        /// <summary>
		/// Giam
		/// Giá Trị Của Mã Giảm Giá
		/// </summary>
        public int Giam { get; set; }

        /// <summary>
		/// GiamToiDa
		/// Giảm Tối Đa
		/// </summary>
        public int GiamToiDa { get; set; }

        /// <summary>
		/// NgayBatDau
		/// Ngày Bắt Đầu
		/// </summary>
        public DateTime NgayBatDau { get; set; }

        /// <summary>
		/// NgayKetThuc
		/// Ngày Kết Thúc
		/// </summary>
        public DateTime NgayKetThuc { get; set; }

        /// <summary>
		/// SoLuot
		/// Số Lượt Được Sử Dụng
		/// </summary>
        public int SoLuot { get; set; }

        /// <summary>
		/// TinhTrang
		/// Tình Trạng
		/// </summary>
        public int TinhTrang { get; set; }
    }
}
