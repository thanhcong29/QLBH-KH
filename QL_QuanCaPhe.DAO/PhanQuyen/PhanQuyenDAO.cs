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
 
    public class PhanQuyenDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public PhanQuyenDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHANQUYEN_GET", con);
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
        /// Sửa thông tin phân quyền
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(PhanQuyenBO objPhanQuyenBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHANQUYEN_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNhom = new SqlParameter("@V_MANHOM", SqlDbType.VarChar);
                paMaNhom.Value = objPhanQuyenBO.MaNhom;
                SqlParameter paMaManHinh = new SqlParameter("@V_MAMANHINH", SqlDbType.VarChar);
                paMaManHinh.Value = objPhanQuyenBO.MaManHinh;
                SqlParameter paCoQuyen = new SqlParameter("@V_COQUYEN", SqlDbType.Bit);
                paCoQuyen.Value = objPhanQuyenBO.CoQuyen;

                cmd.Parameters.Add(paMaNhom);
                cmd.Parameters.Add(paMaManHinh);
                cmd.Parameters.Add(paCoQuyen);
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
