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

    public class ChiTietThucDonDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public ChiTietThucDonDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy thông tin chi tiết thực đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadInfo(string strMaCTMon)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTTHUCDON_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pa = new SqlParameter("@V_MACTMON", SqlDbType.VarChar);
                pa.Value = strMaCTMon;

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

        ///<summary>
        /// Thêm thông tin chi tiết thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ChiTietThucDonBO objChiTietThucDonBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTTHUCDON_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaCTMon = new SqlParameter("@V_MACTMON", SqlDbType.VarChar);
                paMaCTMon.Value = objChiTietThucDonBO.MaCTMon;
                SqlParameter paSize = new SqlParameter("@V_Size", SqlDbType.VarChar);
                paSize.Value = objChiTietThucDonBO.Size;
                SqlParameter paGia = new SqlParameter("@V_GIA", SqlDbType.Float);
                paGia.Value = objChiTietThucDonBO.Gia;
                SqlParameter paMaMon = new SqlParameter("@V_MAMON", SqlDbType.VarChar);
                paMaMon.Value = objChiTietThucDonBO.MaMon;

                cmd.Parameters.Add(paMaCTMon);
                cmd.Parameters.Add(paSize);
                cmd.Parameters.Add(paGia);
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
        /// Sửa thông tin chi tiết thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(ChiTietThucDonBO objChiTietThucDonBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTTHUCDON_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paSize = new SqlParameter("@V_Size", SqlDbType.VarChar);
                paSize.Value = objChiTietThucDonBO.Size;
                SqlParameter paGia = new SqlParameter("@V_GIA", SqlDbType.Float);
                paGia.Value = objChiTietThucDonBO.Gia;
                SqlParameter paMaMon = new SqlParameter("@V_MAMON", SqlDbType.VarChar);
                paMaMon.Value = objChiTietThucDonBO.MaMon;

                cmd.Parameters.Add(paSize);
                cmd.Parameters.Add(paGia);
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
        /// Xóa thông tin chi tiết thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strSize, string strMaMon)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTTHUCDON_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paSize = new SqlParameter("@V_Size", SqlDbType.VarChar);
                paSize.Value = strSize;
                SqlParameter paMaMon = new SqlParameter("@V_MAMON", SqlDbType.VarChar);
                paMaMon.Value = strMaMon;

                cmd.Parameters.Add(paSize);
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
                SqlCommand cmd = new SqlCommand("CF_CTTHUCDON_SRH", con);
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
        /// Lấy danh sách chi tiết theo món
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadDataTheoMon(string strMaMon)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTTHUCDON_MON", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa = new SqlParameter("@V_MAMON", SqlDbType.VarChar);
                pa.Value = strMaMon;
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

        ///<summary>
        /// Lấy chi tiết theo món và size
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayChiTiet(string strMaMon, string strSize)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTTHUCDON_MS", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaMon = new SqlParameter("@V_MAMON", SqlDbType.VarChar);
                paMaMon.Value = strMaMon;
                SqlParameter paSize = new SqlParameter("@V_Size", SqlDbType.VarChar);
                paSize.Value = strSize;

                cmd.Parameters.Add(paMaMon);
                cmd.Parameters.Add(paSize);
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
