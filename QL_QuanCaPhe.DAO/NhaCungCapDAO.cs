using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.DAO
{

    public class NhaCungCapDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public NhaCungCapDAO()
        {
        }
        #endregion

        #region Methods

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
                SqlCommand cmd = new SqlCommand("CF_NHACUNGCAP_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paSearchType = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                paSearchType.Value = intSearchType;
                SqlParameter paKeyWord = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                paKeyWord.Value = strKeyWord;

                cmd.Parameters.Add(paSearchType);
                cmd.Parameters.Add(paKeyWord);

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
