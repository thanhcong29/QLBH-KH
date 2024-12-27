using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{

    public class PhieuNhapBO
    {
        private string strMaPhieuDat;
        private string strMaPhieuNhap;
        private string strNoiDung;
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
		/// MaPhieuNhap
		/// Mã Phiếu Nhập
		/// </summary>
        public string MaPhieuNhap
        {
            get { return strMaPhieuNhap; }
            set { strMaPhieuNhap = value; }
        }

        /// <summary>
		/// NoiDung
		/// Nội Dung
		/// </summary>
        public string NoiDung
        {
            get { return strNoiDung; }
            set { strNoiDung = value; }
        }

        public DateTime NgayLap { get; set; }

        /// <summary>
		/// MaNhanVien
		/// Mã Nhân Viên
		/// </summary>
        public string MaNhanVien
        {
            get { return strMaNhanVien; }
            set { strMaNhanVien = value; }
        }

        public List<ChiTietPhieuNhapBO> lstChiTietPhieuNhapBOs { get; set; }
    }
}
