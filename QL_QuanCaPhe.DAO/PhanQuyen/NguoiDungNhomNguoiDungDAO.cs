using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.DAO
{
    
    public class NguoiDungNhomNguoiDungDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public NguoiDungNhomNguoiDungDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData(string strTenDangNhap)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUOIDUNGNHOMNGUOIDUNG_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa1 = new SqlParameter("@V_TENDANGNHAP", SqlDbType.NVarChar);
                pa1.Value = strTenDangNhap;
                cmd.Parameters.Add(pa1);
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
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        //public DataTable Insert(string strTenDangNhap, string strMaNhom)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("CF_NGUOIDUNGNHOMNGUOIDUNG_GET", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter pa1 = new SqlParameter("@V_TENDANGNHAP", SqlDbType.NVarChar);
        //        pa1.Value = strTenDangNhap;
        //        cmd.Parameters.Add(pa1);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        return dt;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        #endregion
    }
}
