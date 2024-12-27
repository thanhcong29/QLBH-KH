using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BLL.PhanQuyen
{

    public class ManHinhBLL
    {
        #region Constructor
        public ManHinhBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách nhóm người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData()
        {
            try
            {
                ManHinhDAO objManHinhDAO = new ManHinhDAO();
                return objManHinhDAO.LoadData();
            }
            catch (Exception objEx)
            {
                return null;
            }
        }
        #endregion
    }
}
