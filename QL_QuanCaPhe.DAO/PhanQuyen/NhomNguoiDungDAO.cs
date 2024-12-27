using QL_QuanCaPhe.BO.PhanQuyen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.DAO.PhanQuyen
{

    public class NhomNguoiDungDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public NhomNguoiDungDAO()
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
                SqlCommand cmd = new SqlCommand("CF_NHOMNGUOIDUNG_GET", con);
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
        /// Thêm thông tin nhóm người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(NhomNguoiDungBO objNhomNguoiDungBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NHOMGUOIDUNG_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNhom = new SqlParameter("@V_MANHOM", SqlDbType.VarChar);
                paMaNhom.Value = objNhomNguoiDungBO.MaNhom;
                SqlParameter paTenNhom = new SqlParameter("@V_TENNHOM", SqlDbType.NVarChar);
                paTenNhom.Value = objNhomNguoiDungBO.TenNhom;
                SqlParameter paGhiChu = new SqlParameter("@V_GHICHU", SqlDbType.NVarChar);
                paGhiChu.Value = objNhomNguoiDungBO.GhiChu;

                cmd.Parameters.Add(paMaNhom);
                cmd.Parameters.Add(paTenNhom);
                cmd.Parameters.Add(paGhiChu);
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
        /// Cập nhật thông tin nhóm người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(NhomNguoiDungBO objNhomNguoiDungBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NHOMGUOIDUNG_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNhom = new SqlParameter("@V_MANHOM", SqlDbType.VarChar);
                paMaNhom.Value = objNhomNguoiDungBO.MaNhom;
                SqlParameter paTenNhom = new SqlParameter("@V_TENNHOM", SqlDbType.NVarChar);
                paTenNhom.Value = objNhomNguoiDungBO.TenNhom;
                SqlParameter paGhiChu = new SqlParameter("@V_GHICHU", SqlDbType.NVarChar);
                paGhiChu.Value = objNhomNguoiDungBO.GhiChu;

                cmd.Parameters.Add(paMaNhom);
                cmd.Parameters.Add(paTenNhom);
                cmd.Parameters.Add(paGhiChu);
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
        /// Xóa thông tin nhóm người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaNhom)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NHOMGUOIDUNG_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNhom = new SqlParameter("@V_MANHOM", SqlDbType.VarChar);
                paMaNhom.Value = strMaNhom;

                cmd.Parameters.Add(paMaNhom);
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
