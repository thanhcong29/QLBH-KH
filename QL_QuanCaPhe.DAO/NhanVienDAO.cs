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

    public class NhanVienDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public NhanVienDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>OjbectBO</returns>
        //public NhanVienBO LoadInfo(string strMaNV)
        //{
        //    try
        //    {

        //    }
        //    catch
        //    {

        //    }
        //}

        ///<summary>
        /// Thêm nhân viên
        ///</summary>
        /// <returns>kết quả thêm</returns>
        public bool Insert(NhanVienBO objNhanVienBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NHANVIEN_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNV = new SqlParameter("@V_MANHANVIEN", SqlDbType.VarChar);
                paMaNV.Value = objNhanVienBO.MaNhanVien;
                SqlParameter paHoTen = new SqlParameter("@V_HOTEN", SqlDbType.NVarChar);
                paHoTen.Value = objNhanVienBO.HoTen;
                SqlParameter paGT = new SqlParameter("@V_GIOITINH", SqlDbType.NVarChar);
                paGT.Value = objNhanVienBO.GioiTinh;
                SqlParameter paNS = new SqlParameter("@V_NGAYSINH", SqlDbType.Date);
                paNS.Value = objNhanVienBO.NgaySinh;
                SqlParameter paDC = new SqlParameter("@V_DIACHI", SqlDbType.NVarChar);
                paDC.Value = objNhanVienBO.DiaChi;
                SqlParameter paSDT = new SqlParameter("@V_SDT", SqlDbType.VarChar);
                paSDT.Value = objNhanVienBO.SDT;
                SqlParameter paNVL = new SqlParameter("@V_NGAYVAOLAM", SqlDbType.Date);
                paNVL.Value = objNhanVienBO.NgayVaoLam;
                SqlParameter paLCB = new SqlParameter("@V_LUONGCOBAN", SqlDbType.Int);
                paLCB.Value = objNhanVienBO.LuongCoBan;
                SqlParameter paCV = new SqlParameter("@V_CHUCVU", SqlDbType.NVarChar);
                paCV.Value = objNhanVienBO.ChucVu;
                SqlParameter paHA = new SqlParameter("@V_HINHANH", SqlDbType.NVarChar);
                paHA.Value = objNhanVienBO.HinhAnh;

                cmd.Parameters.Add(paMaNV);
                cmd.Parameters.Add(paHoTen);
                cmd.Parameters.Add(paGT);
                cmd.Parameters.Add(paNS);
                cmd.Parameters.Add(paDC);
                cmd.Parameters.Add(paSDT);
                cmd.Parameters.Add(paNVL);
                cmd.Parameters.Add(paLCB);
                cmd.Parameters.Add(paCV);
                cmd.Parameters.Add(paHA);
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
        /// Sửa thông tin nhân viên
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(NhanVienBO objNhanVienBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NHANVIEN_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNV = new SqlParameter("@V_MANHANVIEN", SqlDbType.VarChar);
                paMaNV.Value = objNhanVienBO.MaNhanVien;
                SqlParameter paHoTen = new SqlParameter("@V_HOTEN", SqlDbType.NVarChar);
                paHoTen.Value = objNhanVienBO.HoTen;
                SqlParameter paGT = new SqlParameter("@V_GIOITINH", SqlDbType.NVarChar);
                paGT.Value = objNhanVienBO.GioiTinh;
                SqlParameter paNS = new SqlParameter("@V_NGAYSINH", SqlDbType.Date);
                paNS.Value = objNhanVienBO.NgaySinh;
                SqlParameter paDC = new SqlParameter("@V_DIACHI", SqlDbType.NVarChar);
                paDC.Value = objNhanVienBO.DiaChi;
                SqlParameter paSDT = new SqlParameter("@V_SDT", SqlDbType.VarChar);
                paSDT.Value = objNhanVienBO.SDT;
                SqlParameter paNVL = new SqlParameter("@V_NGAYVAOLAM", SqlDbType.Date);
                paNVL.Value = objNhanVienBO.NgayVaoLam;
                SqlParameter paLCB = new SqlParameter("@V_LUONGCOBAN", SqlDbType.Int);
                paLCB.Value = objNhanVienBO.LuongCoBan;
                SqlParameter paCV = new SqlParameter("@V_CHUCVU", SqlDbType.NVarChar);
                paCV.Value = objNhanVienBO.ChucVu;
                SqlParameter paHA = new SqlParameter("@V_HINHANH", SqlDbType.NVarChar);
                paHA.Value = objNhanVienBO.HinhAnh;

                cmd.Parameters.Add(paMaNV);
                cmd.Parameters.Add(paHoTen);
                cmd.Parameters.Add(paGT);
                cmd.Parameters.Add(paNS);
                cmd.Parameters.Add(paDC);
                cmd.Parameters.Add(paSDT);
                cmd.Parameters.Add(paNVL);
                cmd.Parameters.Add(paLCB);
                cmd.Parameters.Add(paCV);
                cmd.Parameters.Add(paHA);
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
        
        public bool Delete (string strMaNhanVien)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NHANVIEN_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaNV = new SqlParameter("@V_MANHANVIEN", SqlDbType.VarChar);
                paMaNV.Value = strMaNhanVien.Trim();

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
        /// Tìm kiếm nhân viên
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(string strKeyWord, int intSearchType)
        {
            try 
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NHANVIEN_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa2 = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                pa2.Value = intSearchType;
                SqlParameter pa1 = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                pa1.Value = strKeyWord;
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

        #endregion

    }
}