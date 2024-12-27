using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.DAO
{

    public class CongThucDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public CongThucDAO()
        {
        }
        #endregion

        #region Methods

        ///<summary>
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(string strMaMon)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CONGTHUC_MON", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaMon = new SqlParameter("@V_MAMON", SqlDbType.VarChar);
                paMaMon.Value = strMaMon;

                cmd.Parameters.Add(paMaMon);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Thêm Công thức
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(CongThucBO objCongThucBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CONGTHUC_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaCTMon = new SqlParameter("@V_MACTMON", SqlDbType.VarChar);
                paMaCTMon.Value = objCongThucBO.MaCTMon;
                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMaNguyenLieu.Value = objCongThucBO.MaNguyenLieu;
                SqlParameter paHamLuong = new SqlParameter("@V_HAMLUONG", SqlDbType.Float);
                paHamLuong.Value = objCongThucBO.HamLuong;

                cmd.Parameters.Add(paMaCTMon);
                cmd.Parameters.Add(paMaNguyenLieu);
                cmd.Parameters.Add(paHamLuong);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Sửa Công thức
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(CongThucBO objCongThucBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CONGTHUC_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaCTMon = new SqlParameter("@V_MACTMON", SqlDbType.VarChar);
                paMaCTMon.Value = objCongThucBO.MaCTMon;
                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMaNguyenLieu.Value = objCongThucBO.MaNguyenLieu;
                SqlParameter paHamLuong = new SqlParameter("@V_HAMLUONG", SqlDbType.Float);
                paHamLuong.Value = objCongThucBO.HamLuong;

                cmd.Parameters.Add(paMaCTMon);
                cmd.Parameters.Add(paMaNguyenLieu);
                cmd.Parameters.Add(paHamLuong);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Sửa Công thức
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(CongThucBO objCongThucBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CONGTHUC_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaCTMon = new SqlParameter("@V_MACTMON", SqlDbType.VarChar);
                paMaCTMon.Value = objCongThucBO.MaCTMon;
                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMaNguyenLieu.Value = objCongThucBO.MaNguyenLieu;

                cmd.Parameters.Add(paMaCTMon);
                cmd.Parameters.Add(paMaNguyenLieu);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
