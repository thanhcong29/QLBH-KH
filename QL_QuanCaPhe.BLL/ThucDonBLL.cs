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

    public class ThucDonBLL
    {
        #region Constructor
        public ThucDonBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ThucDonBO objThucDonBO)
        {
            try
            {
                ThucDonDAO objThucDonDAO = new ThucDonDAO();
                return objThucDonDAO.Insert(objThucDonBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Sửa thông tin thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(ThucDonBO objThucDonBO)
        {
            try
            {
                ThucDonDAO objThucDonDAO = new ThucDonDAO();
                return objThucDonDAO.Update(objThucDonBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Xóa thông tin thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaMon)
        {
            try
            {
                ThucDonDAO objThucDonDAO = new ThucDonDAO();
                return objThucDonDAO.Delete(strMaMon);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Lấy danh sách thực đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(int intSearchType, string strKeyWord)
        {
            try
            {
                ThucDonDAO objThucDonDAO = new ThucDonDAO();
                return objThucDonDAO.SearchData(intSearchType, strKeyWord);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách thực đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchThucDon(int intSearchType, string strKeyWord)
        {
            try
            {
                ThucDonDAO objThucDonDAO = new ThucDonDAO();
                return objThucDonDAO.SearchThucDon(intSearchType, strKeyWord);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Tìm kiếm thực đơn theo loại
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchTheoLoai(string strMaLoai)
        {
            try
            {
                ThucDonDAO objThucDonDAO = new ThucDonDAO();
                return objThucDonDAO.SearchTheoLoai(strMaLoai);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Tạo mã tự tăng
        ///</summary>
        /// <returns>string</returns>
        public string TaoMaTuTang()
        {
            try
            {
                string strMaMoi = "";
                DataTable dt = SearchData(-1, "NULL");
                if (dt.Rows.Count > 0)
                {
                    int ma = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(1, 3)); // m = 14
                    int matang = ma + 1; // ma tang = 15
                    if (matang < 10)
                        strMaMoi = "M00" + matang; // M011
                    else if (matang < 100)
                        strMaMoi = "M0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "M" + matang; // M999
                }
                else
                    strMaMoi = "M001";
                return strMaMoi;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        
        #endregion
    }
}
