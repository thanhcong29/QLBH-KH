using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class PhieuDatBO
    {
        private string strMaPhieuDat;
        private string strTenPhieuDat;
        private float floTongTien;
        private int intTinhTrang;
        private string strMaNhanVien;

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
		/// TenPhieuDat
		/// Tên Phiếu Đặt
		/// </summary>
        public string TenPhieuDat
        {
            get { return strTenPhieuDat; }
            set { strTenPhieuDat = value; }
        }

        public DateTime NgayLap { get; set; }

        /// <summary>
		/// TongTien
		/// Tổng Tiền
		/// </summary>
        public float TongTien
        {
            get { return floTongTien; }
            set { floTongTien = value; }
        }

        /// <summary>
		/// TinhTrang
		/// Tổng Tiền
		/// </summary>
        public int TinhTrang
        {
            get { return intTinhTrang; }
            set { intTinhTrang = value; }
        }

        /// <summary>
		/// MaNhanVien
		/// Mã Nhân Viên
		/// </summary>
        public string MaNhanVien
        {
            get { return strMaNhanVien; }
            set { strMaNhanVien = value; }
        }

        public List<ChiTietPhieuDatBO> lstChiTietPhieuDatBOs { get; set; }
    }
}
