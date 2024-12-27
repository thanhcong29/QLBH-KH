using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_QuanCaPhe.BO;
using QL_QuanCaPhe.DAO;

namespace QL_QuanCaPhe.BLL
{
    public class DatBanBLL
    {
        #region Constructor
        public DatBanBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm đặt bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(DatBanBO objDatBanBO)
        {

            try
            {
                DatBanDAO objDatBanDAO = new DatBanDAO();
                ChiTietHoaDonDAO objChiTietHoaDonDAO = new ChiTietHoaDonDAO();
                if (objDatBanDAO.Insert(objDatBanBO))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

            }
        }


        ///<summary>
        /// Tạo mã hóa đơn tự động tăng
        ///</summary>
        /// <returns>String</returns>
        public string TaoMaDatBan()
        {
            try
            {
                string strMaMoi = null;
                DatBanDAO objDatBanDAO = new DatBanDAO();
                DataTable dt = objDatBanDAO.LayDanhSachDatBan();
                if (dt.Rows.Count > 0)
                {
                    int ma = Convert.ToInt32(dt.Rows[0][0].ToString().Substring(2, 3));
                    int matang = ma + 1;
                    if (matang < 10)
                        strMaMoi = "DB00" + matang;
                    else if (matang < 100)
                        strMaMoi = "DB0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "DB" + matang;
                }
                else
                    strMaMoi = "DB001";
                return strMaMoi;
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách đặt bàn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachDatBan()
        {
            try
            {
                DatBanDAO objDatBanDAO = new DatBanDAO();
                return objDatBanDAO.LayDanhSachDatBan();
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy thông tin khách hàng đặt bàn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayThongTinKHDatBan(int intMaBan)
        {
            try
            {
                DatBanDAO objDatBanDAO = new DatBanDAO();
                return objDatBanDAO.LayThongTinKHDatBan(intMaBan);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Cập nhật trạng thái đặt bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatTrangThaiDatBan(int MaBan, string TrangThai)
        {           
            try
            {
                DatBanDAO objDatBanDAO = new DatBanDAO();
                return objDatBanDAO.CapNhatTrangThaiDatBan(MaBan, TrangThai);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Xóa thông tin đặt bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaDB)
        {
            DatBanDAO objDatBanDAO = new DatBanDAO();
            return objDatBanDAO.Delete(strMaDB);
        }

        #endregion
    }
}
