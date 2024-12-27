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

    public class KhuVucBLL
    {
        #region Constructor
        public KhuVucBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách khu vực
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData()
        {
            try
            {
                KhuVucDAO objKhuVucDAO = new KhuVucDAO();
                return objKhuVucDAO.LoadData();
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public string TaoMaKhuVuc()
        {
            try
            {
                string strMaMoi = null;
                DataTable dt = LoadData();
                if (dt.Rows.Count > 0)
                {
                    int ma = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                    int matang = ma + 1;
                    if (matang < 10)
                        strMaMoi = "KV00" + matang;
                    else if (matang < 100)
                        strMaMoi = "KV0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "KV" + matang;
                }
                else
                    strMaMoi = "KV001";
                return strMaMoi;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public bool Insert(KhuVucBO objKhuVucBO)
        {
            try
            {
                KhuVucDAO objKhuVucDAO = new KhuVucDAO();
                return objKhuVucDAO.InsertKhuVUc(objKhuVucBO);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        //Update Bàn

        public bool Update(KhuVucBO objKhuVucBO)
        {
            try
            {
                KhuVucDAO objKhuVucDAO = new KhuVucDAO();
                return objKhuVucDAO.Update(objKhuVucBO);
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
        public bool Delete(string maKhuVuc)
        {
            try
            {
                KhuVucDAO objKhuVucDAO = new KhuVucDAO();
                return objKhuVucDAO.Delete(maKhuVuc);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool KTRAKHOACHINH(string maKV)
        {
            try
            {
                KhuVucDAO objKhuVucDAO = new KhuVucDAO();
                return objKhuVucDAO.KTRAKHOACHINH(maKV);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        #endregion
    }
}
