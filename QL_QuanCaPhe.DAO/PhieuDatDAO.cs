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

    public class PhieuDatDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public PhieuDatDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(PhieuDatBO objPhieuDatBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUDAT_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.VarChar);
                paMaPhieuDat.Value = objPhieuDatBO.MaPhieuDat;
                SqlParameter paTenPhieuDat = new SqlParameter("@V_TENPHIEUDAT", SqlDbType.NVarChar);
                paTenPhieuDat.Value = objPhieuDatBO.TenPhieuDat;
                SqlParameter paNgayLap = new SqlParameter("@V_NGAYLAP", SqlDbType.DateTime);
                paNgayLap.Value = objPhieuDatBO.NgayLap;
                SqlParameter paTongTien = new SqlParameter("@V_TONGTIEN", SqlDbType.Float);
                paTongTien.Value = objPhieuDatBO.TongTien;
                SqlParameter paMaNhanVien = new SqlParameter("@V_MANHANVIEN", SqlDbType.VarChar);
                paMaNhanVien.Value = objPhieuDatBO.MaNhanVien;

                cmd.Parameters.Add(paMaPhieuDat);
                cmd.Parameters.Add(paTenPhieuDat);
                cmd.Parameters.Add(paNgayLap);
                cmd.Parameters.Add(paTongTien);
                cmd.Parameters.Add(paMaNhanVien);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Cập nhật phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(PhieuDatBO objPhieuDatBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUDAT_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.VarChar);
                paMaPhieuDat.Value = objPhieuDatBO.MaPhieuDat;
                SqlParameter paTenPhieuDat = new SqlParameter("@V_TENPHIEUDAT", SqlDbType.NVarChar);
                paTenPhieuDat.Value = objPhieuDatBO.TenPhieuDat;
                SqlParameter paTongTien = new SqlParameter("@V_TONGTIEN", SqlDbType.Float);
                paTongTien.Value = objPhieuDatBO.TongTien;

                cmd.Parameters.Add(paMaPhieuDat);
                cmd.Parameters.Add(paTenPhieuDat);
                cmd.Parameters.Add(paTongTien);
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
        /// Xóa phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaPhieu)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUDAT_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.VarChar);
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
        /// Lấy danh sách PHIẾU ĐẶT
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Search(int intSearchType, string strKeyWord, DateTime dtTuNgay, DateTime dtToiNgay, int NCC)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUDAT_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paSearchType = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                paSearchType.Value = intSearchType;
                SqlParameter paKeyWord = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                paKeyWord.Value = strKeyWord;
                SqlParameter paTuNgay = new SqlParameter("@V_STARTDAY", SqlDbType.Date);
                paTuNgay.Value = dtTuNgay;
                SqlParameter paToiNgay = new SqlParameter("@V_ENDDATE", SqlDbType.Date);
                paToiNgay.Value = dtToiNgay;
                SqlParameter paNCC = new SqlParameter("@V_NCC", SqlDbType.Int);
                paNCC.Value = NCC;

                cmd.Parameters.Add(paSearchType);
                cmd.Parameters.Add(paKeyWord);
                cmd.Parameters.Add(paTuNgay);
                cmd.Parameters.Add(paToiNgay);
                cmd.Parameters.Add(paNCC);
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
        /// Lấy danh sách PHIẾU ĐẶT
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Load()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUDAT_LOAD", con);
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
        /// Lấy danh sách PHIẾU ĐẶT
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadPhieuDatTheoNCC(string NCC)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_PHIEUDAT_NCC", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paNCC = new SqlParameter("@V_MANCC", SqlDbType.Int);
                paNCC.Value = NCC;

                cmd.Parameters.Add(paNCC);

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
        /// Lấy danh thông tin in phiếu đặt
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayRPPHIEUDAT(string strMaPD)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_RPPHIEUDAT_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa = new SqlParameter("@MAPHIEUDAT", SqlDbType.VarChar);
                pa.Value = strMaPD;
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
