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

    public class ChiTietPhieuDatDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public ChiTietPhieuDatDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm chi tiết phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ChiTietPhieuDatBO objChiTietPhieuDatBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTPHIEUDAT_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMaNguyenLieu.Value = objChiTietPhieuDatBO.MaNguyenLieu;
                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.NVarChar);
                paMaPhieuDat.Value = objChiTietPhieuDatBO.MaPhieuDat;
                SqlParameter paSoLuong = new SqlParameter("@V_SOLUONG", SqlDbType.Float);
                paSoLuong.Value = objChiTietPhieuDatBO.SoLuong;
                SqlParameter paGiaDat = new SqlParameter("@V_GIADAT", SqlDbType.Int);
                paGiaDat.Value = objChiTietPhieuDatBO.GiaDat;

                cmd.Parameters.Add(paMaNguyenLieu);
                cmd.Parameters.Add(paMaPhieuDat);
                cmd.Parameters.Add(paSoLuong);
                cmd.Parameters.Add(paGiaDat);
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
        /// Xóa chi tiết phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(ChiTietPhieuDatBO objChiTietPhieuDatBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTPHIEUDAT_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMaNguyenLieu.Value = objChiTietPhieuDatBO.MaNguyenLieu;
                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.NVarChar);
                paMaPhieuDat.Value = objChiTietPhieuDatBO.MaPhieuDat;

                cmd.Parameters.Add(paMaNguyenLieu);
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
        /// lấy thông tin chi tiết phiếu đăth theo mã phiếu đặt
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Load(string strMaPhieuDat)
        {

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("CF_CTPHIEUDAT_LOAD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.NVarChar);
                paMaNguyenLieu.Value = strMaPhieuDat;

                cmd.Parameters.Add(paMaNguyenLieu);
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
        /// lấy thông tin chi tiết phiếu đăt khi nhập
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadNguyenLieuNhap(string strMaPhieuDat)
        {

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("CF_CTPHIEUDAT_NHAP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.VarChar);
                paMaNguyenLieu.Value = strMaPhieuDat;

                cmd.Parameters.Add(paMaNguyenLieu);
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
        /// lấy thông tin chi tiết phiếu đăt khi nhập
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadNguyenLieuChuaNhap(string strMaPhieuDat)
        {

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("CF_CTPHIEUDAT_CNHAP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MAPHIEUDAT", SqlDbType.VarChar);
                paMaNguyenLieu.Value = strMaPhieuDat;

                cmd.Parameters.Add(paMaNguyenLieu);
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
