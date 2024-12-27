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

    public class GiamGiaBLL
    {
        #region Constructor
        public GiamGiaBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách mã giảm giá
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(string strMaKM)
        {
            try
            {
                GiamGiaDAO objGiamGiaDAO = new GiamGiaDAO();
                return objGiamGiaDAO.SearchData(strMaKM);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Thêm mã giảm giá
        ///</summary>
        /// <returns>DataTable</returns>
        public bool Insert(GiamGiaBO objGiamGiaBO)
        {
            GiamGiaDAO objGiamGiaDAO = new GiamGiaDAO();
            return objGiamGiaDAO.Insert(objGiamGiaBO);
        }

        ///<summary>
        /// Sửa mã giảm giá
        ///</summary>
        /// <returns>DataTable</returns>
        public bool Update(GiamGiaBO objGiamGiaBO)
        {
            GiamGiaDAO objGiamGiaDAO = new GiamGiaDAO();
            return objGiamGiaDAO.Update(objGiamGiaBO);
        }

        ///<summary>
        /// Xóa mã giảm giá
        ///</summary>
        /// <returns>DataTable</returns>
        public bool Delete(string strMaGiamGia)
        {
            GiamGiaDAO objGiamGiaDAO = new GiamGiaDAO();
            return objGiamGiaDAO.Delete(strMaGiamGia);
        }
        #endregion
    }
}
