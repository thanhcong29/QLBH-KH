using QL_QuanCaPhe.BO;
using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe.BLL
{

    public class HoaDonBLL
    {
        #region Constructor
        public HoaDonBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(HoaDonBO objHoaDonBO)
        {
            
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                if(objHoaDonDAO.Insert(objHoaDonBO))
                {
                    foreach(ChiTietHoaDonBO objChiTietHoaDonBO in objHoaDonBO.lstChiTietHoaDonBOs)
                    {
                        if (objChiTietHoaDonDAO.Insert(objChiTietHoaDonBO))
                            continue;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {
                
            }
        }

        ///<summary>
        /// Cập nhật hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatTongTien(string strMaHoaDon, float TongTien)
        {

            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                if (objHoaDonDAO.CapNhatTongTien(strMaHoaDon, TongTien))
                {                  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {

            }
        }

        ///<summary>
        /// Cập nhật hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatHDThanhToan(HoaDonBO objHoaDonBO)
        {

            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                if (objHoaDonDAO.CapNhatHDThanhToan(objHoaDonBO))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {

            }
        }

        ///<summary>
        /// Lấy thông tin hóa đơn theo bàn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayThongTinHoaDonTheoBan(int intMaBan)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayThongTinHoaDonTheoBan(intMaBan);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon()
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon();
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy hóa đơn theo bàn
        ///</summary>
        /// <returns>string</returns>
        public string LayHoaDon(string strMaBan)
        {
            try
            {
                string Ma = "";
                DataTable dt = LayDanhSachHoaDon();
                List<DataRow> HoaDons = new List<DataRow>(dt.Select());
                var mp = (from p in HoaDons
                          where p["MABAN"].ToString().Trim() == strMaBan
                          orderby p["MAHOADON"] descending
                          select p).FirstOrDefault();
                if(mp != null)
                {
                    Ma = mp["MAHOADON"].ToString().Trim();
                }    
                

                return Ma;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Tạo mã hóa đơn tự động tăng
        ///</summary>
        /// <returns>String</returns>
        public string TaoMaHoaDon()
        {
            try
            {
                string strMaMoi = null;
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                DataTable dt = objHoaDonDAO.LayDanhSachHoaDon();
                if (dt.Rows.Count > 0 )
                {
                    int ma = Convert.ToInt32(dt.Rows[0][0].ToString().Substring(2, 3));
                    int matang = ma + 1;
                    if (matang < 10)
                        strMaMoi = "HD00" + matang;
                    else if (matang < 100)
                        strMaMoi = "HD0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "HD" + matang;
                }
                else
                    strMaMoi = "HD001";
                return strMaMoi;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy thông tin khi xuất report
        ///</summary>
        /// <returns>Datatable</returns>
        
        public DataTable LayRPHoaDon (string strMaHD)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayRPHoaDon(strMaHD);
            }
            catch
            {
                return null;
            }
        }

        ///<summary>
        /// Cập nhật chuyển bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatChuyenBan(int MaBan, int MaBanChuyen, string strMaHoaDon)
        {

            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                if (objHoaDonDAO.CapNhatChuyenBan(MaBan, MaBanChuyen, strMaHoaDon))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {

            }
        }

        ///<summary>
        /// Cập nhật gộp bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatGopBan(int MaBan, int MaBanChuyen, string strMaHoaDon, string strMaHoaDonChuyen)
        {

            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                if (objHoaDonDAO.CapNhatGopBan(MaBan, MaBanChuyen, strMaHoaDon, strMaHoaDonChuyen))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {

            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn TKDT
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT()
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon_TKDT();
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn TKDT theo năm
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_TheoNam(String nam)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon_TKDT_TheoNam(nam);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn TKDT theo tháng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_TheoThang(String nam, int thang)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon_TKDT_TheoThang(nam, thang);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn TKDT theo ngày
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_TheoNgay(String ngay)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon_TKDT_TheoNgay(ngay);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn TKDT theo năm
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_NV_TheoNam(String manv, String nam)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon_TKDT_NV_TheoNam(manv, nam);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn TKDT theo tháng của nhân viên
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_NV_TheoThang(String manv, String nam, int thang)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon_TKDT_NV_TheoThang(manv, nam, thang);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn TKDT theo ngày của nhân viên
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_NV_TheoNgay(String manv, String ngay)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon_TKDT_NV_TheoNgay(manv, ngay);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn theo điều kiện
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon(int intSearchType, string strKeyWord, DateTime fromDay, DateTime toDay)
        {
            try
            {
                HoaDonDAO objHoaDonDAO = new HoaDonDAO();
                return objHoaDonDAO.LayDanhSachHoaDon(intSearchType, strKeyWord, fromDay, toDay);
            }
            catch (Exception objEx)
            {               
                return null;
            }
        }
        #endregion
    }
}
