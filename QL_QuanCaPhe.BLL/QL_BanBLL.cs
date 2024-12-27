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
    public class QL_BanBLL
    {
        //Thêm bàn
        public bool Insert(QL_BanBO objBanBO)
        {
            try
            {
                QL_BanDAO objBanDAO = new QL_BanDAO();
                return objBanDAO.InsertBan(objBanBO);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        //Update Bàn
        public bool Update(QL_BanBO objBanBO)
        {
            try
            {
                QL_BanDAO objBanDAO = new QL_BanDAO();
                return objBanDAO.Update(objBanBO);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        ///<summary>
        /// Xóa bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(int maBan)
        {
            try
            {
                QL_BanDAO objBanDAO = new QL_BanDAO();
                return objBanDAO.Delete(maBan);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool KTRAKHOACHINH(int maBan)
        {
            try
            {
                QL_BanDAO objBanDAO = new QL_BanDAO();
                return objBanDAO.KTRAKHOACHINH(maBan);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        ///<summary>
        /// Select Bàn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SelectData()
        {
            try
            {
                QL_BanDAO objBanDAO = new QL_BanDAO();
                return objBanDAO.SelectData();
            }
            catch (Exception objEx)
            {

                return null;
            }
        }


    }
}
