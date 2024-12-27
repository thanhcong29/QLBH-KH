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

    public class BanDAO
    {
        SqlConnection con = ConnectDB.cnn;
        #region Constructor
        public BanDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách bàn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_BAN_GET", con);
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
        /// Tìm kiếm bàn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Search(int intSearchType, string strKeyWord)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_BAN_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paSearchType = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                paSearchType.Value = intSearchType;
                SqlParameter pastrKeyWord = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                pastrKeyWord.Value = strKeyWord;

                cmd.Parameters.Add(paSearchType);
                cmd.Parameters.Add(paSearchType);

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
        /// Câp nhật tình trạng bàn
        ///</summary>
        /// <returns></returns>
        public bool CapNhatTrangThaiBan(int MaBan, string TrangThai)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CAPNHATTINHTRANGBAN", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaBan = new SqlParameter("@V_MABAN", SqlDbType.Int);
                paMaBan.Value = MaBan;
                SqlParameter paTrangThai = new SqlParameter("@V_TRANGTHAI", SqlDbType.NVarChar);
                paTrangThai.Value = TrangThai;

                cmd.Parameters.Add(paMaBan);
                cmd.Parameters.Add(paTrangThai);
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
        /// Câp nhật tình trạng bàn
        ///</summary>
        /// <returns></returns>
        public BanBO LayThongTinBan(int MaBan)
        {
            try
            {
                BanBO banBO = new BanBO();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CAPNHATTINHTRANGBAN", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaBan = new SqlParameter("@V_MABAN", SqlDbType.Int);
                paMaBan.Value = MaBan;

                cmd.Parameters.Add(paMaBan);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    banBO.MaBan = reader[0].ToString();
                    banBO.TenBan = reader[2].ToString();
                }
                reader.Close();
                return banBO;
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
        /// Lấy thông tin tình trạng bàn
        ///</summary>
        /// <returns></returns>
        public DataTable LayThongTinTinhTrangBan(int MaBan)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KIEMTRATINHTRANGBAN", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaBan = new SqlParameter("@MABAN", SqlDbType.Int);
                paMaBan.Value = MaBan;

                cmd.Parameters.Add(paMaBan);

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
