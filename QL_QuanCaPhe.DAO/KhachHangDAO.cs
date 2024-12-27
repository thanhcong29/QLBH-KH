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

    public class KhachHangDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public KhachHangDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Tìm kiếm khách hàng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(string strKeyWord, int intSearchType, int intTinhTrang)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHACHHANG_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa2 = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                pa2.Value = intSearchType;
                SqlParameter pa1 = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                pa1.Value = strKeyWord;
                SqlParameter pa3 = new SqlParameter("@V_TINHTRANG", SqlDbType.Int);
                pa3.Value = intTinhTrang;

                cmd.Parameters.Add(pa1);
                cmd.Parameters.Add(pa2);
                cmd.Parameters.Add(pa3);
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
        /// Lấy thông tin khách hàng
        ///</summary>
        /// <returns>KhachHangBO</returns>
        public KhachHangBO LoadInfo(string strMaKH)
        {
            try
            {
                KhachHangBO objKhachHangBO = new KhachHangBO();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHACHHANG_GET", con);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaKH = new SqlParameter("@V_MAKHACHHANG", SqlDbType.VarChar);
                paMaKH.Value = strMaKH;

                cmd.Parameters.Add(paMaKH);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    objKhachHangBO.MaKhachHang = reader[0].ToString();
                    objKhachHangBO.TenKhachHang = reader[1].ToString();
                    objKhachHangBO.SDT = reader[2].ToString();
                    objKhachHangBO.Email = reader[4].ToString();
                    objKhachHangBO.DiemThuong = float.Parse(reader[5].ToString());
                }
                reader.Close();
                return objKhachHangBO;
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
        /// Cập nhật điểm thưởng khách hàng
        ///</summary>
        /// <returns></returns>
        public void CapNhatDiemThuong (string strMaKH, float floDiem)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHACHHANG_UPDDIEM", con);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaKH = new SqlParameter("@V_MAKHACHHANG", SqlDbType.VarChar);
                paMaKH.Value = strMaKH;
                SqlParameter paDiem = new SqlParameter("@V_DIEMTHUONG", SqlDbType.Float);
                paDiem.Value = floDiem;

                cmd.Parameters.Add(paMaKH);
                cmd.Parameters.Add(paDiem);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Lỗi cập nhật điểm cho khách hàng !!!", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Lấy danh sách khách hàng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Load()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHACHHANG_LOAD", con);
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
        /// Thêm thông tin khách hàng
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(KhachHangBO objKhachHang)
         {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHACHHANG_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaKH = new SqlParameter("@V_MAKHACHHANG", SqlDbType.VarChar);
                paMaKH.Value = objKhachHang.MaKhachHang;
                SqlParameter paTenKH = new SqlParameter("@V_TENKHACHHANG", SqlDbType.NVarChar);
                paTenKH.Value = objKhachHang.TenKhachHang;
                SqlParameter paSDT = new SqlParameter("@V_SDT", SqlDbType.VarChar);
                paSDT.Value = objKhachHang.SDT;
                SqlParameter paMatKhau = new SqlParameter("@V_MATKHAU", SqlDbType.VarChar);
                paMatKhau.Value = objKhachHang.MatKhau;
                SqlParameter paEmail = new SqlParameter("@V_EMAIL", SqlDbType.NVarChar);
                paEmail.Value = objKhachHang.Email;
                SqlParameter paDiem = new SqlParameter("@V_DIEMTHUONG", SqlDbType.Float);
                paDiem.Value = objKhachHang.DiemThuong;

                cmd.Parameters.Add(paMaKH);
                cmd.Parameters.Add(paTenKH);
                cmd.Parameters.Add(paSDT);
                cmd.Parameters.Add(paMatKhau);
                cmd.Parameters.Add(paEmail);
                cmd.Parameters.Add(paDiem);

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
        /// Cập nhật thông tin khách hàng
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(KhachHangBO objKhachHang)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHACHHANG_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaKH = new SqlParameter("@V_MAKHACHHANG", SqlDbType.VarChar);
                paMaKH.Value = objKhachHang.MaKhachHang;
                SqlParameter paTenKH = new SqlParameter("@V_TENKHACHHANG", SqlDbType.NVarChar);
                paTenKH.Value = objKhachHang.TenKhachHang;
                SqlParameter paSDT = new SqlParameter("@V_SDT", SqlDbType.VarChar);
                paSDT.Value = objKhachHang.SDT;
                SqlParameter paMatKhau = new SqlParameter("@V_MATKHAU", SqlDbType.VarChar);
                paMatKhau.Value = objKhachHang.MatKhau;
                SqlParameter paEmail = new SqlParameter("@V_EMAIL", SqlDbType.NVarChar);
                paEmail.Value = objKhachHang.Email;
                SqlParameter paDiem = new SqlParameter("@V_DIEMTHUONG", SqlDbType.Float);
                paDiem.Value = objKhachHang.DiemThuong;
                SqlParameter paTinhTrang = new SqlParameter("@V_TINHTRANG", SqlDbType.Int);
                paTinhTrang.Value = objKhachHang.TinhTrang;

                cmd.Parameters.Add(paMaKH);
                cmd.Parameters.Add(paTenKH);
                cmd.Parameters.Add(paSDT);
                cmd.Parameters.Add(paMatKhau);  
                cmd.Parameters.Add(paEmail);
                cmd.Parameters.Add(paDiem);
                cmd.Parameters.Add(paTinhTrang);

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
        /// Xóa thông tin khách hàng
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaKH)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_KHACHHANG_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaKH = new SqlParameter("@V_MAKHACHHANG", SqlDbType.VarChar);
                paMaKH.Value = strMaKH;
                cmd.Parameters.Add(paMaKH);              
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
