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

    public class PhieuNhapDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public PhieuNhapDAO()
        {
        }
        #endregion
        #region Methods
        ///<summary>
        /// Thêm phiếu nhập
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(PhieuNhapBO objPhieuNhapBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUNHAP_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaPhieuNhap = new SqlParameter("@V_MAPHIEUNHAP", SqlDbType.VarChar);
                paMaPhieuNhap.Value = objPhieuNhapBO.MaPhieuNhap;
                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.VarChar);
                paMaPhieuDat.Value = objPhieuNhapBO.MaPhieuDat;
                SqlParameter paNoiDung = new SqlParameter("@V_NOIDUNG", SqlDbType.NVarChar);
                paNoiDung.Value = objPhieuNhapBO.NoiDung;
                SqlParameter paNgayLap = new SqlParameter("@V_NGAYLAP", SqlDbType.DateTime);
                paNgayLap.Value = objPhieuNhapBO.NgayLap;
                SqlParameter paMaNhanVien = new SqlParameter("@V_MANHANVIEN", SqlDbType.VarChar);
                paMaNhanVien.Value = objPhieuNhapBO.MaNhanVien;

                cmd.Parameters.Add(paMaPhieuNhap);
                cmd.Parameters.Add(paMaPhieuDat);
                cmd.Parameters.Add(paNoiDung);
                cmd.Parameters.Add(paNgayLap);
                cmd.Parameters.Add(paMaNhanVien);
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
        /// Cập nhật phiếu nhập
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(PhieuNhapBO objPhieuNhapBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUNHAP_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaPhieuNhap = new SqlParameter("@V_MAPHIEUNHAP", SqlDbType.VarChar);
                paMaPhieuNhap.Value = objPhieuNhapBO.MaPhieuNhap;
                SqlParameter paNoiDung = new SqlParameter("@V_NOIDUNG", SqlDbType.NVarChar);
                paNoiDung.Value = objPhieuNhapBO.NoiDung;

                cmd.Parameters.Add(paMaPhieuNhap);
                cmd.Parameters.Add(paNoiDung);
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
        /// Xóa phiếu nhập
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaPhieu)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUNHAP_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUNHAP", SqlDbType.VarChar);
                paMaPhieuDat.Value = strMaPhieu;

                cmd.Parameters.Add(paMaPhieuDat);
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
        /// Tìm kiếm phiếu nhập
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Search(int intSearchType, string strKeyWord, DateTime fromDay, DateTime toDay)
        {

            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUNHAP_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paSearchType = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                paSearchType.Value = intSearchType;
                SqlParameter paKeyWord = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                paKeyWord.Value = strKeyWord;
                SqlParameter pafromDay = new SqlParameter("@V_STARTDAY", SqlDbType.Date);
                pafromDay.Value = fromDay;
                SqlParameter patoDay = new SqlParameter("@V_ENDDATE", SqlDbType.Date);
                patoDay.Value = toDay;

                cmd.Parameters.Add(paSearchType);
                cmd.Parameters.Add(paKeyWord);
                cmd.Parameters.Add(pafromDay);
                cmd.Parameters.Add(patoDay);
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
        /// lấy danh sách phiếu nhập
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Load()
        {

            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUNHAP_LOAD", con);
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
        /// Lấy danh thông tin in phiếu nhập
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayRPPHIEUNHAP(string strMaPN)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_RPPHIEUNHAP_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa = new SqlParameter("@MAPHIEUNHAP", SqlDbType.VarChar);
                pa.Value = strMaPN;
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
