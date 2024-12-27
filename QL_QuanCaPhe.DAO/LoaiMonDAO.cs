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

    public class LoaiMonDAO
    {
        SqlConnection con = ConnectDB.cnn;
        #region Constructor
        public LoaiMonDAO()
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
                SqlCommand cmd = new SqlCommand("CF_LOAIMON_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;             
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
        /// Thêm thông tin loại món
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(LoaiMonBO objLoaiMonBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_LOAIMON_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMA = new SqlParameter("@V_MALOAI", SqlDbType.VarChar);
                paMA.Value = objLoaiMonBO.MaLoai;

                SqlParameter paTEN = new SqlParameter("@V_TENLOAI", SqlDbType.NVarChar);
                paTEN.Value = objLoaiMonBO.TenLoai;

                cmd.Parameters.Add(paMA);
                cmd.Parameters.Add(paTEN);
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
        /// Sửa thông tin loại món
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(LoaiMonBO objLoaiMonBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_LOAIMON_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMA = new SqlParameter("@V_MALOAI", SqlDbType.VarChar);
                paMA.Value = objLoaiMonBO.MaLoai;

                SqlParameter paTEN = new SqlParameter("@V_TENLOAI", SqlDbType.NVarChar);
                paTEN.Value = objLoaiMonBO.TenLoai;

                cmd.Parameters.Add(paMA);
                cmd.Parameters.Add(paTEN);
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
        /// Thêm thông tin loại món
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaLoai)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_LOAIMON_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMA = new SqlParameter("@V_MALOAI", SqlDbType.VarChar);
                paMA.Value = strMaLoai;

                cmd.Parameters.Add(paMA);
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
