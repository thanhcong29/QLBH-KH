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

    public class NguyenLieuDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public NguyenLieuDAO()
        {
        }
        #endregion

        #region Methods
        ///<summary>
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(string strTenNguyenLieu)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUYENLIEU_LOAD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paTENNGUYENLIEU = new SqlParameter("@V_TENNGUYENLIEU", SqlDbType.NVarChar);
                paTENNGUYENLIEU.Value = strTenNguyenLieu;

                cmd.Parameters.Add(paTENNGUYENLIEU);

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
        /// Thêm thông tin nguyên liệu
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(NguyenLieuBO objNguyenLieuBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUYENLIEU_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paTen = new SqlParameter("@V_TENNGUYENLIEU", SqlDbType.NVarChar);
                paTen.Value = objNguyenLieuBO.TenNguyenLieu;
                SqlParameter paSoLuong = new SqlParameter("@V_SOLUONG", SqlDbType.Float);
                paSoLuong.Value = objNguyenLieuBO.SoLuong;
                SqlParameter paDVT = new SqlParameter("@V_DVT", SqlDbType.NVarChar);
                paDVT.Value = objNguyenLieuBO.DVT;
                SqlParameter paNCC = new SqlParameter("@V_MANHACUNGCAP", SqlDbType.Int);
                paNCC.Value = objNguyenLieuBO.MaNhaCungCap;

                cmd.Parameters.Add(paTen);
                cmd.Parameters.Add(paSoLuong);
                cmd.Parameters.Add(paDVT);
                cmd.Parameters.Add(paNCC);
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
        /// Sửa thông tin nguyên liệu
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(NguyenLieuBO objNguyenLieuBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUYENLIEU_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMa = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMa.Value = objNguyenLieuBO.MaNguyenLieu;
                SqlParameter paTen = new SqlParameter("@V_TENNGUYENLIEU", SqlDbType.NVarChar);
                paTen.Value = objNguyenLieuBO.TenNguyenLieu;
                SqlParameter paSoLuong = new SqlParameter("@V_SOLUONG", SqlDbType.Float);
                paSoLuong.Value = objNguyenLieuBO.SoLuong;
                SqlParameter paDVT = new SqlParameter("@V_DVT", SqlDbType.NVarChar);
                paDVT.Value = objNguyenLieuBO.DVT;
                SqlParameter paNCC = new SqlParameter("@V_MANHACUNGCAP", SqlDbType.Int);
                paNCC.Value = objNguyenLieuBO.MaNhaCungCap;

                cmd.Parameters.Add(paMa);
                cmd.Parameters.Add(paTen);
                cmd.Parameters.Add(paSoLuong);
                cmd.Parameters.Add(paDVT);
                cmd.Parameters.Add(paNCC);
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
        /// Cập nhật số lượng nguyên liệu
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatSoLuong(int intMaNguyenLieu, float floSoLuong)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUYENLIEU_SL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMa = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMa.Value = intMaNguyenLieu;
                SqlParameter paSoLuong = new SqlParameter("@V_SOLUONG", SqlDbType.Float);
                paSoLuong.Value = floSoLuong;

                cmd.Parameters.Add(paMa);
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
        /// Xóa thông tin nguyên liệu
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaGiamGia)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_NGUYENLIEU_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaGiamGia = new SqlParameter("@V_MANGUYENLIEU", SqlDbType.Int);
                paMaGiamGia.Value = strMaGiamGia;

                cmd.Parameters.Add(paMaGiamGia);
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
