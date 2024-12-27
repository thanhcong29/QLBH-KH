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

    public class ChiTietPhieuNhapDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public ChiTietPhieuNhapDAO()
        {
        }
        #endregion
        #region Methods
        ///<summary>
        /// Thêm chi tiết phiếu NHẬP
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ChiTietPhieuNhapBO objChiTietPhieuNhapBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTPHIEUNHAP_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMaNguyenLieu.Value = objChiTietPhieuNhapBO.MaNguyenLieu;
                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUNHAP", SqlDbType.VarChar);
                paMaPhieuDat.Value = objChiTietPhieuNhapBO.MaPhieuNhap;
                SqlParameter paSoLuong = new SqlParameter("@V_SOLUONG", SqlDbType.Float);
                paSoLuong.Value = objChiTietPhieuNhapBO.SoLuong;

                cmd.Parameters.Add(paMaNguyenLieu);
                cmd.Parameters.Add(paMaPhieuDat);
                cmd.Parameters.Add(paSoLuong);
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
        /// Xóa chi tiết phiếu nhập
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(ChiTietPhieuNhapBO objChiTietPhieuNhapBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTPHIEUNHAP_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNguyenLieu = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMaNguyenLieu.Value = objChiTietPhieuNhapBO.MaNguyenLieu;
                SqlParameter paMaPhieuDat = new SqlParameter("@V_MAPHIEUNHAP", SqlDbType.VarChar);
                paMaPhieuDat.Value = objChiTietPhieuNhapBO.MaPhieuNhap;

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
        public DataTable Load(string strMaPhieu)
        {

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("CF_CTPHIEUNHAP_LOAD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaPhieu = new SqlParameter("@V_MAPHIEUNHAP", SqlDbType.VarChar);
                paMaPhieu.Value = strMaPhieu;

                cmd.Parameters.Add(paMaPhieu);
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
