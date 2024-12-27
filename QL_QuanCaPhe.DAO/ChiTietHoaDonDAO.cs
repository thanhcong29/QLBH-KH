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

    public class ChiTietHoaDonDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public ChiTietHoaDonDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm chi tiết hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ChiTietHoaDonBO objChiTietHoaDonBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTHOADON_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaHoaDon = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
                paMaHoaDon.Value = objChiTietHoaDonBO.MaHoaDon;
                SqlParameter paMaMon = new SqlParameter("@V_MACTMON", SqlDbType.VarChar);
                paMaMon.Value = objChiTietHoaDonBO.MaCTMon;
                SqlParameter paSoLuong = new SqlParameter("@V_SOLUONG", SqlDbType.Int);
                paSoLuong.Value = objChiTietHoaDonBO.SoLuong;

                cmd.Parameters.Add(paMaHoaDon);
                cmd.Parameters.Add(paMaMon);
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
        /// Xóa chi tiết hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaHoaDon, string strMaMon)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTHOADON_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaHoaDon = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
                paMaHoaDon.Value = strMaHoaDon;
                SqlParameter paMaMon = new SqlParameter("@V_MACTMON", SqlDbType.VarChar);
                paMaMon.Value = strMaMon;

                cmd.Parameters.Add(paMaHoaDon);
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
        /// Cập nhật chi tiết hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(ChiTietHoaDonBO objChiTietHoaDonBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTHOADON_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaHoaDon = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
                paMaHoaDon.Value = objChiTietHoaDonBO.MaHoaDon;
                SqlParameter paMaMon = new SqlParameter("@V_MACTMON", SqlDbType.VarChar);
                paMaMon.Value = objChiTietHoaDonBO.MaCTMon;
                SqlParameter paSoLuong = new SqlParameter("@V_SOLUONG", SqlDbType.Int);
                paSoLuong.Value = objChiTietHoaDonBO.SoLuong;

                cmd.Parameters.Add(paMaHoaDon);
                cmd.Parameters.Add(paMaMon);
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
        /// Lấy danh sách chi tiết hóa đơn theo mã hóa đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachChiTiet(string strMaHoaDon)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTHOADON_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pa = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
                pa.Value = strMaHoaDon;

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
        /// Lấy danh sách mặt hàng bán chạy theo tháng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachMatHangBanChay_TKMHTHEOTHANG(String nam, int thang)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTHOADON_TKMHTHEOTHANG_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Đưa tham số vào cmd
                SqlParameter paramNam = new SqlParameter("@nam", SqlDbType.VarChar);
                paramNam.Value = nam;
                SqlParameter paramThang = new SqlParameter("@thang", SqlDbType.Int);
                paramThang.Value = thang;

                cmd.Parameters.Add(paramNam);
                cmd.Parameters.Add(paramThang);
                cmd.ExecuteNonQuery();

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
        /// Lấy danh sách mặt hàng bán chạy theo tháng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachMatHangBanChay_TKMHTHEONAM(String nam)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTHOADON_TKMHTHEONAM_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Đưa tham số vào cmd
                SqlParameter paramNam = new SqlParameter("@nam", SqlDbType.VarChar);
                paramNam.Value = nam;


                cmd.Parameters.Add(paramNam);

                cmd.ExecuteNonQuery();

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
        /// Lấy danh sách mặt hàng bán chạy theo ngày
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachMatHangBanChay_TKMHTHEONGAY(String ngay)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CTHOADON_TKMHTHEONGAY_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Đưa tham số vào cmd
                SqlParameter paramNgay = new SqlParameter("@ngay", SqlDbType.VarChar);
                paramNgay.Value = ngay;


                cmd.Parameters.Add(paramNgay);

                cmd.ExecuteNonQuery();

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