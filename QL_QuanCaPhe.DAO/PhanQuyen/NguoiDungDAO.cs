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

    public class NguoiDungDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public NguoiDungDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData(string strTenDangNhap, string strMatKhau)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUOIDUNG_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa1 = new SqlParameter("@V_TENDANGNHAP", SqlDbType.VarChar);
                pa1.Value = strTenDangNhap;
                SqlParameter pa2 = new SqlParameter("@V_MATKHAU", SqlDbType.VarChar);
                pa2.Value = strMatKhau;
                cmd.Parameters.Add(pa1);
                cmd.Parameters.Add(pa2);
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
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Search(string strKeyWord, int intSearchType)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUOIDUNG_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa1 = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                pa1.Value = strKeyWord;
                SqlParameter pa2 = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                pa2.Value = intSearchType;
                cmd.Parameters.Add(pa1);
                cmd.Parameters.Add(pa2);
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
        /// Lấy sanh sách nhân viên chưa có tài khoản người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadNhanVienChuaCoTaiKhoan()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUOIDUNG_NO", con);
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
        /// Thêm tài khoản người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public bool Insert(NguoiDungBO objNguoiDungBO)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUOIDUNG_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paTenDN = new SqlParameter("@V_TENDANGNHAP", SqlDbType.VarChar);
                paTenDN.Value = objNguoiDungBO.TenDangNhap;
                SqlParameter paMATKHAU = new SqlParameter("@V_MATKHAU", SqlDbType.VarChar);
                paMATKHAU.Value = objNguoiDungBO.MatKhau;
                SqlParameter paTRANGTHAI = new SqlParameter("@V_TRANGTHAI", SqlDbType.NVarChar);
                paTRANGTHAI.Value = objNguoiDungBO.TrangThai;
                SqlParameter paMANHANVIEN = new SqlParameter("@V_MANHANVIEN", SqlDbType.VarChar);
                paMANHANVIEN.Value = objNguoiDungBO.MaNhanVien;

                cmd.Parameters.Add(paTenDN);
                cmd.Parameters.Add(paMATKHAU);
                cmd.Parameters.Add(paTRANGTHAI);
                cmd.Parameters.Add(paMANHANVIEN);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
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
        /// Cập nhật tài khoản người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(NguoiDungBO objNguoiDungBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUOIDUNG_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paTenDN = new SqlParameter("@V_TENDANGNHAP", SqlDbType.VarChar);
                paTenDN.Value = objNguoiDungBO.TenDangNhap;
                SqlParameter paMATKHAU = new SqlParameter("@V_MATKHAU", SqlDbType.VarChar);
                paMATKHAU.Value = objNguoiDungBO.MatKhau;
                SqlParameter paTRANGTHAI = new SqlParameter("@V_TRANGTHAI", SqlDbType.NVarChar);
                paTRANGTHAI.Value = objNguoiDungBO.TrangThai;

                cmd.Parameters.Add(paTenDN);
                cmd.Parameters.Add(paMATKHAU);
                cmd.Parameters.Add(paTRANGTHAI);
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
        /// Xóa tài khoản người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strTenDangNhap)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUOIDUNG_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paTenDN = new SqlParameter("@V_TENDANGNHAP", SqlDbType.VarChar);
                paTenDN.Value = strTenDangNhap;

                cmd.Parameters.Add(paTenDN);
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
