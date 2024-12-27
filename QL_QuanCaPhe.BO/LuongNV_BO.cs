using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO
{
    public class LuongNV_BO
    {
        public LuongNV_BO()
        { }

        /// <summary>
		/// MaNhanVien
		/// Mã Nhân Viên
		/// </summary>
        private string MaBangLuong = string.Empty;

        public string maBangLuong
        {
            get { return MaBangLuong; }
            set { MaBangLuong = value; }
        }

        private string MaNhanVien = string.Empty;

        public string maNhanVien
        {
            get { return MaNhanVien; }
            set { MaNhanVien = value; }
        }

        private string MaCa = string.Empty;

        public string maCa
        {
            get { return MaCa; }
            set { MaCa = value; }
        }


        public DateTime? NgayLam { get; set; }


        public double SoTien { get; set; }

        public double SoTieng { get; set; }

        public double ThanhTien { get; set; }

        private string GhiChu = string.Empty;
        public string ghiChu
        {
            get { return GhiChu; }
            set { GhiChu = value; }
        }


    }
}
