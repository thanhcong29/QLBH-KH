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

    public class CongThucBLL
    {
        #region Constructor
        public CongThucBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách nguyên liệu
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(string strMaMon)
        {
            try
            {
                CongThucDAO objCongThucDAO = new CongThucDAO();
                return objCongThucDAO.SearchData(strMaMon);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Thêm công thức
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(CongThucBO objCongThucBO)
        {
            CongThucDAO objCongThucDAO = new CongThucDAO();
            return objCongThucDAO.Insert(objCongThucBO);
        }

        ///<summary>
        /// Sửa công thức
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(CongThucBO objCongThucBO)
        {
            CongThucDAO objCongThucDAO = new CongThucDAO();
            return objCongThucDAO.Update(objCongThucBO);
        }

        ///<summary>
        /// Xóa công thức
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(CongThucBO objCongThucBO)
        {
            CongThucDAO objCongThucDAO = new CongThucDAO();
            return objCongThucDAO.Delete(objCongThucBO);
        }
        #endregion
    }
}
