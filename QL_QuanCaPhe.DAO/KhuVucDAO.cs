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

    public class KhuVucDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public KhuVucDAO()
        {
        }
        #endregion
        #region Methods
        ///<summary>
        /// Lấy danh sách khu vực
        ///</summary>
        /// <returns>list khu vực</returns>
        public DataTable LoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHUVUC_GET", con);
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

        public bool InsertKhuVUc(KhuVucBO objKhuVucBO) //QL_BanBO vừa nãy thiếu BO . m lên đặt sau là QL_BanBO, QL_BanDAO, QL_BanBLL để dẽ biết
        {
            try // Oke rồi đó. Ok haha 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHUVUC_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paMaKhuVuc = new SqlParameter("@V_MAKHUVUC", SqlDbType.VarChar);
                paMaKhuVuc.Value = objKhuVucBO.MaKhuVuc;
                SqlParameter paTenKhuVuc = new SqlParameter("@V_TENKHUVUC", SqlDbType.NVarChar);
                paTenKhuVuc.Value = objKhuVucBO.TenKhuVuc;

                cmd.Parameters.Add(paMaKhuVuc);
                cmd.Parameters.Add(paTenKhuVuc);


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

        public bool Update(KhuVucBO objKhuVucBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHUVUC_UPDATE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaKhuVuc = new SqlParameter("@V_MAKHUVUC", SqlDbType.VarChar);
                paMaKhuVuc.Value = objKhuVucBO.MaKhuVuc;
                SqlParameter paTenKhuVuc = new SqlParameter("@V_TENKHUVUC", SqlDbType.NVarChar);
                paTenKhuVuc.Value = objKhuVucBO.TenKhuVuc;

                cmd.Parameters.Add(paMaKhuVuc);
                cmd.Parameters.Add(paTenKhuVuc);

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

        public bool Delete(string MaKhuVuc)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHUVUC_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNV = new SqlParameter("@V_MAKHUVUC", SqlDbType.VarChar);
                paMaNV.Value = MaKhuVuc.Trim();

                cmd.Parameters.Add(paMaNV);
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

        public bool KTRAKHOACHINH(string maKhuVuc)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHUVUC_KHOACHINH", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaKV = new SqlParameter("@V_MAKHUVUC", SqlDbType.VarChar);
                paMaKV.Value = maKhuVuc.ToString();

                cmd.Parameters.Add(paMaKV);
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
