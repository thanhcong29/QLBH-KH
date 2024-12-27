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
    public class QL_BanDAO // QL_BanDAO
    {
        SqlConnection con = ConnectDB.cnn;
        public bool InsertBan(QL_BanBO objBanBO) //QL_BanBO vừa nãy thiếu BO . m lên đặt sau là QL_BanBO, QL_BanDAO, QL_BanBLL để dẽ biết
        {
            try // Oke rồi đó. Ok haha 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_BAN_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paTenBan = new SqlParameter("@V_TENBAN", SqlDbType.NVarChar);
                paTenBan.Value = objBanBO.TenBan;
                SqlParameter paSoChoNgoi = new SqlParameter("@V_SOCHONGOI", SqlDbType.Int);
                paSoChoNgoi.Value = objBanBO.SoChoNgoi;
                SqlParameter paTrangThai = new SqlParameter("@V_TRANGTHAI", SqlDbType.NVarChar);
                paTrangThai.Value = objBanBO.TrangThai;
                SqlParameter paMaKhuVuc = new SqlParameter("@V_MAKHUVUC", SqlDbType.VarChar);
                paMaKhuVuc.Value = objBanBO.MaKhuVuc;

                cmd.Parameters.Add(paTenBan);
                cmd.Parameters.Add(paSoChoNgoi);
                cmd.Parameters.Add(paTrangThai);
                cmd.Parameters.Add(paMaKhuVuc);

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
        public bool Update(QL_BanBO objBanBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_BAN_UPDATE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaBan = new SqlParameter("@V_MABAN", SqlDbType.Int);
                paMaBan.Value = objBanBO.MaBan;
                SqlParameter paTenBan = new SqlParameter("@V_TENBAN", SqlDbType.NVarChar);
                paTenBan.Value = objBanBO.TenBan;
                SqlParameter paSoChoNgoi = new SqlParameter("@V_SOCHONGOI", SqlDbType.Int);
                paSoChoNgoi.Value = objBanBO.SoChoNgoi;
                SqlParameter paTrangThai = new SqlParameter("@V_TRANGTHAI", SqlDbType.NVarChar);
                paTrangThai.Value = objBanBO.TrangThai;
                SqlParameter paMaKhuVuc = new SqlParameter("@V_MAKHUVUC", SqlDbType.VarChar);
                paMaKhuVuc.Value = objBanBO.MaKhuVuc; // trống nè

                cmd.Parameters.Add(paMaBan);
                cmd.Parameters.Add(paTenBan);
                cmd.Parameters.Add(paSoChoNgoi);
                cmd.Parameters.Add(paTrangThai);
                cmd.Parameters.Add(paMaKhuVuc);

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
        /// Xóa thông tin nhân viên
        ///</summary>
        /// <returns>bool</returns>

        public bool Delete(int maBan)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_BAN_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaBan = new SqlParameter("@V_MABAN", SqlDbType.Int);
                paMaBan.Value = maBan.ToString();

                cmd.Parameters.Add(paMaBan);
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
        public bool KTRAKHOACHINH(int maBan)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_BAN_KHOACHINH", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaBan = new SqlParameter("@V_MABAN", SqlDbType.Int);
                paMaBan.Value = maBan.ToString();

                cmd.Parameters.Add(paMaBan);
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

        public DataTable SelectData()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_BAN_SELECT", con);
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
    }
}
