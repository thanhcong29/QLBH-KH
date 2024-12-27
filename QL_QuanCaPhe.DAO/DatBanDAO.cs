using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QL_QuanCaPhe.BO;

namespace QL_QuanCaPhe.DAO
{
    public class DatBanDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public DatBanDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm đặt bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(DatBanBO objDatBanBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_DATBAN_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaDatBan = new SqlParameter("@V_MADATBAN", SqlDbType.VarChar);
                paMaDatBan.Value = objDatBanBO.MaDatBan;
                SqlParameter paThoiGianNhanBan = new SqlParameter("@V_THOIGIANNHANBAN", SqlDbType.DateTime);
                paThoiGianNhanBan.Value = objDatBanBO.ThoiGianNhanBan;
                SqlParameter paGhiChu = new SqlParameter("@V_GHICHU", SqlDbType.NVarChar);
                paGhiChu.Value = objDatBanBO.GhiChu;
                SqlParameter paMaKhachHang = new SqlParameter("@V_MAKHACHHANG", SqlDbType.VarChar);
                paMaKhachHang.Value = objDatBanBO.MaKhachHang;
                SqlParameter paMaBan = new SqlParameter("@V_MABAN", SqlDbType.Int);
                paMaBan.Value = objDatBanBO.MaBan;
                SqlParameter paMaNV = new SqlParameter("@V_MANV", SqlDbType.VarChar);
                paMaNV.Value = objDatBanBO.MaNhanVien;

                cmd.Parameters.Add(paMaDatBan);
                cmd.Parameters.Add(paThoiGianNhanBan);
                cmd.Parameters.Add(paGhiChu);
                cmd.Parameters.Add(paMaKhachHang);
                cmd.Parameters.Add(paMaBan);
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

        ///<summary>
        /// Cập nhật hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        //public bool CapNhatTongTien(string strMaHoaDon, float TongTien)
        //{

        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("CF_CAPNHATTONGTIEN_HD", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter paMaHoaDon = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
        //        paMaHoaDon.Value = strMaHoaDon;
        //        SqlParameter paTongTien = new SqlParameter("@V_TONGTIEN", SqlDbType.Float);
        //        paTongTien.Value = TongTien;

        //        cmd.Parameters.Add(paMaHoaDon);
        //        cmd.Parameters.Add(paTongTien);
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception objEx)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        ///<summary>
        /// Lấy danh sách hóa đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachDatBan()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_DATBAN_GET", con);
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
        /// Lấy thông khách hàng đặt bàn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayThongTinKHDatBan(int intMaBan)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_LAYTTKHACHHANG_DATBAN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa = new SqlParameter("@V_MABAN", SqlDbType.Int);
                pa.Value = intMaBan;
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
        /// Câp nhật tình trạng đặt bàn
        ///</summary>
        /// <returns></returns>
        public bool CapNhatTrangThaiDatBan(int MaBan, string TrangThai)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CAPNHATTINHTRANGDATBAN", con);
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
        /// Xóa thông tin đặt bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaDB)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_DATBAN_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaDB = new SqlParameter("@MADATBAN", SqlDbType.VarChar);
                paMaDB.Value = strMaDB;
                cmd.Parameters.Add(paMaDB);
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
