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
    public class ThucDonDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public ThucDonDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm thông tin thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ThucDonBO objThucDonBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_THUCDON_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaMon = new SqlParameter("@V_MAMMON", SqlDbType.VarChar);
                paMaMon.Value = objThucDonBO.MaMon;
                SqlParameter paTenMon = new SqlParameter("@V_TENMON", SqlDbType.NVarChar);
                paTenMon.Value = objThucDonBO.TenMon;
                SqlParameter paMaLoai = new SqlParameter("@V_MALOAI", SqlDbType.VarChar);
                paMaLoai.Value = objThucDonBO.MaLoai;
                SqlParameter paDVT = new SqlParameter("@V_DVT", SqlDbType.NVarChar);
                paDVT.Value = objThucDonBO.DVT;
                SqlParameter paHinhAnh = new SqlParameter("@V_HINHANH", SqlDbType.NVarChar);
                paHinhAnh.Value = objThucDonBO.HinhAnh;                

                cmd.Parameters.Add(paMaMon);
                cmd.Parameters.Add(paTenMon);
                cmd.Parameters.Add(paMaLoai);
                cmd.Parameters.Add(paDVT);
                cmd.Parameters.Add(paHinhAnh);               
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
        /// Sửa thông tin thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(ThucDonBO objThucDonBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_THUCDON_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaMon = new SqlParameter("@V_MAMMON", SqlDbType.VarChar);
                paMaMon.Value = objThucDonBO.MaMon;
                SqlParameter paTenMon = new SqlParameter("@V_TENMON", SqlDbType.NVarChar);
                paTenMon.Value = objThucDonBO.TenMon;
                SqlParameter paMaLoai = new SqlParameter("@V_MALOAI", SqlDbType.VarChar);
                paMaLoai.Value = objThucDonBO.MaLoai;
                SqlParameter paDVT = new SqlParameter("@V_DVT", SqlDbType.NVarChar);
                paDVT.Value = objThucDonBO.DVT;
                SqlParameter paHinhAnh = new SqlParameter("@V_HINHANH", SqlDbType.NVarChar);
                paHinhAnh.Value = objThucDonBO.HinhAnh;

                cmd.Parameters.Add(paMaMon);
                cmd.Parameters.Add(paTenMon);
                cmd.Parameters.Add(paMaLoai);
                cmd.Parameters.Add(paDVT);
                cmd.Parameters.Add(paHinhAnh);
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
        /// Xóa thông tin thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaMon)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_THUCDON_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaMon = new SqlParameter("@V_MAMMON", SqlDbType.VarChar);
                paMaMon.Value = strMaMon;               

                cmd.Parameters.Add(paMaMon);              
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
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(int intSearchType, string strKeyWord)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_THUCDON_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa2 = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                pa2.Value = intSearchType;
                SqlParameter pa1 = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                pa1.Value = strKeyWord;
                cmd.Parameters.Add(pa1);
                cmd.Parameters.Add(pa2);
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
        public DataTable SearchThucDon(int intSearchType, string strKeyWord)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_THUCDON_GM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa2 = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                pa2.Value = intSearchType;
                SqlParameter pa1 = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                pa1.Value = strKeyWord;
                cmd.Parameters.Add(pa1);
                cmd.Parameters.Add(pa2);
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
        /// Tìm kiếm thực đơn theo loại
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchTheoLoai(string strMaLoai)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_THUCDON_LOAI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa = new SqlParameter("@V_MALOAI", SqlDbType.VarChar);
                pa.Value = strMaLoai;
                cmd.Parameters.Add(pa);
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
        #endregion
    }
}
