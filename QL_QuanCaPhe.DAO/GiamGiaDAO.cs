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

    public class GiamGiaDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public GiamGiaDAO()
        {
        }
        #endregion

        #region Methods

        ///<summary>
        /// Nạp thông tin từ CSDL
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(string strMaKM)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_GIAMGIA_LOAD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paMaKM = new SqlParameter("@V_MAGIAMGIA", SqlDbType.VarChar);
                paMaKM.Value = strMaKM;

                cmd.Parameters.Add(paMaKM);

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
        /// Thêm thông tin giảm giá
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(GiamGiaBO objGiamGiaBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_GIAMGIA_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaGiamGia = new SqlParameter("@V_MAGIAMGIA", SqlDbType.VarChar);
                paMaGiamGia.Value = objGiamGiaBO.MaGiamGia;
                SqlParameter paGiam = new SqlParameter("@V_GIAM", SqlDbType.Int);
                paGiam.Value = objGiamGiaBO.Giam;
                SqlParameter paGiamToiDai = new SqlParameter("@V_GIAMTOIDA", SqlDbType.Int);
                paGiamToiDai.Value = objGiamGiaBO.GiamToiDa;
                SqlParameter paNgayBatDau = new SqlParameter("@V_NGAYBATDAU", SqlDbType.Date);
                paNgayBatDau.Value = objGiamGiaBO.NgayBatDau;
                SqlParameter paNgayKetThuc = new SqlParameter("@V_NGAYKETTHUC", SqlDbType.Date);
                paNgayKetThuc.Value = objGiamGiaBO.NgayKetThuc;
                SqlParameter paSoLuot = new SqlParameter("@V_SOLUOT", SqlDbType.Int);
                paSoLuot.Value = objGiamGiaBO.SoLuot;

                cmd.Parameters.Add(paMaGiamGia);
                cmd.Parameters.Add(paGiam);
                cmd.Parameters.Add(paGiamToiDai);
                cmd.Parameters.Add(paNgayBatDau);
                cmd.Parameters.Add(paNgayKetThuc);
                cmd.Parameters.Add(paSoLuot);
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
        /// Cập nhật thông tin giảm giá
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(GiamGiaBO objGiamGiaBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_GIAMGIA_UPD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaGiamGia = new SqlParameter("@V_MAGIAMGIA", SqlDbType.VarChar);
                paMaGiamGia.Value = objGiamGiaBO.MaGiamGia;
                SqlParameter paGiam = new SqlParameter("@V_GIAM", SqlDbType.Int);
                paGiam.Value = objGiamGiaBO.Giam;
                SqlParameter paGiamToiDai = new SqlParameter("@V_GIAMTOIDA", SqlDbType.Int);
                paGiamToiDai.Value = objGiamGiaBO.GiamToiDa;
                SqlParameter paNgayBatDau = new SqlParameter("@V_NGAYBATDAU", SqlDbType.Date);
                paNgayBatDau.Value = objGiamGiaBO.NgayBatDau;
                SqlParameter paNgayKetThuc = new SqlParameter("@V_NGAYKETTHUC", SqlDbType.Date);
                paNgayKetThuc.Value = objGiamGiaBO.NgayKetThuc;
                SqlParameter paSoLuot = new SqlParameter("@V_SOLUOT", SqlDbType.Int);
                paSoLuot.Value = objGiamGiaBO.SoLuot;

                cmd.Parameters.Add(paMaGiamGia);
                cmd.Parameters.Add(paGiam);
                cmd.Parameters.Add(paGiamToiDai);
                cmd.Parameters.Add(paNgayBatDau);
                cmd.Parameters.Add(paNgayKetThuc);
                cmd.Parameters.Add(paSoLuot);
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
        /// Cập nhật thông tin giảm giá
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaGiamGia)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_GIAMGIA_DEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaGiamGia = new SqlParameter("@V_MAGIAMGIA", SqlDbType.VarChar);
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
