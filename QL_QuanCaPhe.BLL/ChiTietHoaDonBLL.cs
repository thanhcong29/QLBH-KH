using QL_QuanCaPhe.BO;
using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BLL
{

    public class ChiTietHoaDonBLL
    {
        #region Constructor
        public ChiTietHoaDonBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm Chi Tiết hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ChiTietHoaDonBO objChiTietHoaDonBO)
        {
            try
            {
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                return objChiTietHoaDonDAO.Insert(objChiTietHoaDonBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Xóa Chi Tiết hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaHoaDon, string strMaMon)
        {
            try
            {
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                return objChiTietHoaDonDAO.Delete(strMaHoaDon, strMaMon);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Lấy danh sách chi tiết hóa đơn theo mã hóa đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachChiTiet(string strMaHoaDon)
        {
            try
            {
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                return objChiTietHoaDonDAO.LayDanhSachChiTiet(strMaHoaDon);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Kiểm tra món tồn tại
        ///</summary>
        /// <returns>bool</returns>
        public bool KiemTraMonTonTai(string strMaHoaDon, string strMaMon)
        {
            try
            {
                int Mon = 0;
                DataTable dt = LayDanhSachChiTiet(strMaHoaDon);

                foreach(DataRow dr in dt.Rows)
                {
                    if(dr["MAMON"].ToString().Trim() == strMaMon)
                    {
                        Mon++;
                    }
                    else
                    {
                        continue;
                    }    
                }
                if (Mon > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Lấy danh sách mặt hàng bán chạy theo tháng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachMatHangBanChay_TKMHTHEOTHANG(String nam, int thang)
        {
            try
            {
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                return objChiTietHoaDonDAO.LayDanhSachMatHangBanChay_TKMHTHEOTHANG(nam, thang);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách mặt hàng bán chạy theo năm
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachMatHangBanChay_TKMHTHEONAM(String nam)
        {
            try
            {
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                return objChiTietHoaDonDAO.LayDanhSachMatHangBanChay_TKMHTHEONAM(nam);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách mặt hàng bán chạy theo ngày
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachMatHangBanChay_TKMHTHEONGAY(String ngay)
        {
            try
            {
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                return objChiTietHoaDonDAO.LayDanhSachMatHangBanChay_TKMHTHEONGAY(ngay);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
