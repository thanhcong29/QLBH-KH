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

    public class HoaDonDAO
    {
        SqlConnection con = ConnectDB.cnn;

        #region Constructor
        public HoaDonDAO()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(HoaDonBO objHoaDonBO)
        {
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_ADD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaHoaDon = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
                paMaHoaDon.Value = objHoaDonBO.MaHoaDon;
                SqlParameter paNgayLap = new SqlParameter("@V_NGAYLAP", SqlDbType.DateTime);
                paNgayLap.Value = objHoaDonBO.NgayLap;
                SqlParameter paTongTien = new SqlParameter("@V_TONGTIEN", SqlDbType.Float);
                paTongTien.Value =objHoaDonBO.TongTien;
                SqlParameter paMaBan = new SqlParameter("@V_MABAN", SqlDbType.Int);
                paMaBan.Value = objHoaDonBO.MaBan;
                SqlParameter paMaNhanVien = new SqlParameter("@V_MANHANVIEN", SqlDbType.VarChar);
                paMaNhanVien.Value = objHoaDonBO.MaNhanVien;
                SqlParameter paMaKH = new SqlParameter("@V_MAKHACHHANG", SqlDbType.VarChar);
                paMaKH.Value = objHoaDonBO.MaKhachHang;

                cmd.Parameters.Add(paMaHoaDon);
                cmd.Parameters.Add(paNgayLap);
                cmd.Parameters.Add(paTongTien);
                cmd.Parameters.Add(paMaBan);
                cmd.Parameters.Add(paMaNhanVien);
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

        ///<summary>
        /// Cập nhật hóa đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatTongTien(string strMaHoaDon, float TongTien)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CAPNHATTONGTIEN_HD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaHoaDon = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
                paMaHoaDon.Value = strMaHoaDon;
                SqlParameter paTongTien = new SqlParameter("@V_TONGTIEN", SqlDbType.Float);
                paTongTien.Value = TongTien;

                cmd.Parameters.Add(paMaHoaDon);
                cmd.Parameters.Add(paTongTien);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Cập nhật hóa đơn khi thanh toán
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatHDThanhToan(HoaDonBO objHoaDonBO)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_PAY", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaHoaDon = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
                paMaHoaDon.Value = objHoaDonBO.MaHoaDon;
                SqlParameter paNgayXuat = new SqlParameter("@V_NGAYXUAT", SqlDbType.DateTime);
                paNgayXuat.Value = objHoaDonBO.NgayXuat;
                SqlParameter paThanhToan = new SqlParameter("@V_THANHTOAN", SqlDbType.Float);
                paThanhToan.Value = objHoaDonBO.ThanhToan;
                SqlParameter paMaGG = new SqlParameter("@V_MAGIAMGIA", SqlDbType.VarChar);
                paMaGG.Value = objHoaDonBO.MaGiamGia;

                cmd.Parameters.Add(paMaHoaDon);
                cmd.Parameters.Add(paNgayXuat);
                cmd.Parameters.Add(paThanhToan);
                cmd.Parameters.Add(paMaGG);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_GET", con);
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
        /// Lấy thông tin hóa đơn theo bàn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayThongTinHoaDonTheoBan(int intMaBan)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_LAYHOADON_BAN", con);
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
        /// Lấy danh sách hóa đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayRPHoaDon(string strHoaDon)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_RPHOADON_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pa = new SqlParameter("@V_MAHOADON", SqlDbType.VarChar);
                pa.Value = strHoaDon;
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
        /// Cập nhật chuyển bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatChuyenBan(int MaBan, int MaBanChuyen, string strMaHoaDon)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CAPNHATCHUYENBAN", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaBan = new SqlParameter("@MABAN", SqlDbType.Int);
                paMaBan.Value = MaBan;
                SqlParameter paMaBanChuyen = new SqlParameter("@MABANCHUYEN", SqlDbType.Int);
                paMaBanChuyen.Value = MaBanChuyen;
                SqlParameter paMaHoaDon = new SqlParameter("@MAHOADON", SqlDbType.VarChar);
                paMaHoaDon.Value = strMaHoaDon;

                cmd.Parameters.Add(paMaBan);
                cmd.Parameters.Add(paMaBanChuyen);
                cmd.Parameters.Add(paMaHoaDon);                
             
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Cập nhật chuyển bàn
        ///</summary>
        /// <returns>bool</returns>
        public bool CapNhatGopBan(int MaBan, int MaBanChuyen, string strMaHoaDon, string strMaHoaDonChuyen)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_CAPNHATGOPBAN", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paMaBan = new SqlParameter("@MABAN", SqlDbType.Int);
                paMaBan.Value = MaBan;
                SqlParameter paMaBanChuyen = new SqlParameter("@MABANCHUYEN", SqlDbType.Int);
                paMaBanChuyen.Value = MaBanChuyen;
                SqlParameter paMaHoaDon = new SqlParameter("@MAHOADON", SqlDbType.VarChar);
                paMaHoaDon.Value = strMaHoaDon;
                SqlParameter paMaHoaDonChuyen = new SqlParameter("@MAHOADONCHUYEN", SqlDbType.VarChar);
                paMaHoaDonChuyen.Value = strMaHoaDonChuyen;

                cmd.Parameters.Add(paMaBan);
                cmd.Parameters.Add(paMaBanChuyen);
                cmd.Parameters.Add(paMaHoaDon);
                cmd.Parameters.Add(paMaHoaDonChuyen);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        ///<summary>
        /// Lấy danh sách hóa đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_TKDT_GET", con);
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
        /// Lấy danh sách hóa đơn theo năm
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_TheoNam(String nam)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_TKDT_THEONAM_GET", con);
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
        /// Lấy danh sách hóa đơn theo tháng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_TheoThang(String nam, int thang)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_TKDT_THEOTHANG_GET", con);
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
        /// Lấy danh sách hóa đơn theo ngày
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_TheoNgay(String ngay)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_TKDT_THEONGAY_GET", con);
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

        ///<summary>
        /// Lấy danh sách hóa đơn theo năm của nhân viên
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_NV_TheoNam(String manv, String nam)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_TKDT_NV_THEONAM_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Đưa tham số vào cmd
                SqlParameter paramMaNV = new SqlParameter("@MANV", SqlDbType.VarChar);
                paramMaNV.Value = manv;
                SqlParameter paramNam = new SqlParameter("@nam", SqlDbType.VarChar);
                paramNam.Value = nam;

                cmd.Parameters.Add(paramMaNV);
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
        /// Lấy danh sách hóa đơn theo tháng của nhân viên
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_NV_TheoThang(String manv, String nam, int thang)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_TKDT_NV_THEOTHANG_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Đưa tham số vào cmd
                SqlParameter paramMaNV = new SqlParameter("@MANV", SqlDbType.VarChar);
                paramMaNV.Value = manv;
                SqlParameter paramNam = new SqlParameter("@nam", SqlDbType.VarChar);
                paramNam.Value = nam;
                SqlParameter paramThang = new SqlParameter("@thang", SqlDbType.Int);
                paramThang.Value = thang;

                cmd.Parameters.Add(paramMaNV);
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
        /// Lấy danh sách hóa đơn theo ngày của nhân viên
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon_TKDT_NV_TheoNgay(String manv, String ngay)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_TKDT_NV_THEONGAY_GET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Đưa tham số vào cmd
                SqlParameter paramMaNV = new SqlParameter("@MANV", SqlDbType.VarChar);
                paramMaNV.Value = manv;
                SqlParameter paramNgay = new SqlParameter("@ngay", SqlDbType.VarChar);
                paramNgay.Value = ngay;

                cmd.Parameters.Add(paramMaNV);
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

        ///<summary>
        /// Lấy danh sách hóa đơn theo điều kiện
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayDanhSachHoaDon(int intSearchType, string strKeyWord, DateTime fromDay, DateTime toDay)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("CF_HOADON_SRH", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paSearchType = new SqlParameter("@V_SEARCHTYPE", SqlDbType.Int);
                paSearchType.Value = intSearchType;

                SqlParameter paKeyWord = new SqlParameter("@V_KEYWORD", SqlDbType.NVarChar);
                paKeyWord.Value = strKeyWord;

                SqlParameter pafromDay = new SqlParameter("@V_STARTDAY", SqlDbType.Date);
                pafromDay.Value = fromDay;

                SqlParameter patoDay = new SqlParameter("@V_ENDDATE", SqlDbType.Date);
                patoDay.Value = toDay;

                cmd.Parameters.Add(paSearchType);
                cmd.Parameters.Add(paKeyWord);
                cmd.Parameters.Add(pafromDay);
                cmd.Parameters.Add(patoDay);

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
