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
    public class LuongNV_DAO1
    {
        SqlConnection con = ConnectDB.cnn;
        public DataTable loadLuongnv()
        {

            DataSet ds = new DataSet();
            string load = "select MABANGLUONG,HoTen,NgayPhatLuong,LuongCoBan,Luong  from LuongNV bl,nhanvien nv where bl.MANHANVIEN=nv.MANHANVIEN ";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "Luongnv");
            return ds.Tables["Luongnv"];
        }
        public DataTable loadctLuongnv()
        {
            DataSet ds = new DataSet();
            string load = "select MABANGLUONG,hoten,CHITIETCA,ngaylam,sotien,sotieng,thanhtien,ghichu  from nhanvien nv,CTBANGLUONGNV ct, CALAM cl where  nv.MANHANVIEN=ct.MANHANVIEN and ct.MACA = cl.MACA";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "Luongnv");
            return ds.Tables["Luongnv"];
        }




        public DataTable loadctLuongTheoMa(string mabl, string manv)
        {
            DataSet ds = new DataSet();
            string load = "select MABANGLUONG,HOTEN,CHITIETCA,NGAYLAM,SOTIEN,SOTIENG,THANHTIEN, GHICHU  from nhanvien nv,CTBANGLUONGNV ct,CALAM cl where ct.MACA = cl.MACA and  nv.MANHANVIEN=ct.MANHANVIEN and ct.MABANGLUONG='" + mabl + "' and ct.MANHANVIEN='" + manv + "'";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "Luongnv");
            return ds.Tables["Luongnv"];
        }

        public DataTable loadBangLuong()
        {
            DataSet ds = new DataSet();
            string load = "select * from BangLuong";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "BangLuong");
            return ds.Tables["BangLuong"];
        }

        public DataTable loadCalam()
        {
            DataSet ds = new DataSet();
            string load = "select * from Calam";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "Calam");
            return ds.Tables["Calam"];
        }

        public DataTable loadChamCong()
        {
            DataSet ds = new DataSet();
            string load = "select * from CHAMCONG_LUONGQL";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "CHAMCONG_LUONGQL");
            return ds.Tables["CHAMCONG_LUONGQL"];
        }

        public DataTable loadNhanVien()
        {
            DataSet ds = new DataSet();
            string load = "select * from NhanVien where CHUCVU = N'Nhân viên'";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "NhanVien");
            return ds.Tables["NhanVien"];
        }

        public DataTable loadQL()
        {
            DataSet ds = new DataSet();
            string load = "select * from NhanVien where CHUCVU not in (N'Nhân viên')";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "NhanVien");
            return ds.Tables["NhanVien"];
        }

        /////----------------------------------------------
        //-------------------------------------------------------------------------------------
        public bool kiemTraKhoaChinhluongnv(string mabl, string manv)
        {
            try
            {
                con.Open();
                string kt = "select count(*) from luongnv where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' ";
                SqlCommand cmd = new SqlCommand(kt, ConnectDB.cnn);
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                if (kq >= 1)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool luuluongnv(string mabl, string manv, string ngaypl, float luong)
        {
            try
            {
                DataSet ds = new DataSet();
                string luu = "select * from luongnv ";
                SqlDataAdapter da = new SqlDataAdapter(luu, ConnectDB.cnn);
                da.Fill(ds, "Luongnv");
                DataRow dr = ds.Tables["Luongnv"].NewRow();
                dr["MABANGLUONG"] = mabl;
                dr["MANHANVIEN"] = manv;
                dr["NgayPhatLuong"] = ngaypl;
                dr["Luong"] = luong;
                ds.Tables["Luongnv"].Rows.Add(dr);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                da.Update(ds, "Luongnv");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sualuongnv(string mabl, string manv, string ngaypl)
        {
            try
            {
                con.Open();
                string sua = "update luongnv set ngayphatluong='" + ngaypl + "' where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' ";
                SqlCommand cmd = new SqlCommand(sua, ConnectDB.cnn);
                int kq = cmd.ExecuteNonQuery();
                con.Close();
                if (kq > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaluongnv(string mabl, string manv)
        {
            try
            {
                con.Open();
                string xoa = "delete from luongnv where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' ";
                SqlCommand cmd = new SqlCommand(xoa, ConnectDB.cnn);
                int kq = cmd.ExecuteNonQuery();
                con.Close();
                if (kq > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //----------------------------------------------------CTLUONGNV------------------------------------------------------------------

        public bool ktKhoaCtBangLuong(string mabl, string manv, string maca, string ngaylam)
        {
            try
            {
                con.Open();
                string kt = "select count(*) from ctbangluongnv where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' and MACA='" + maca + "' and ngaylam='" + ngaylam + "'";
                SqlCommand cmd = new SqlCommand(kt, ConnectDB.cnn);
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                if (kq >= 1)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool themctLuongnv(string mabl, string manv, string maca, string ngaylam, float sotien, float sotieng, string ghichu)
        {
            DataSet ds = new DataSet();
            string themct = "select * from ctbangluongNV ";
            SqlDataAdapter da = new SqlDataAdapter(themct, ConnectDB.cnn);
            da.Fill(ds, "ctbangluongNV");
            DataRow dr = ds.Tables["ctbangluongNV"].NewRow();
            dr["MABANGLUONG"] = mabl;
            dr["MANHANVIEN"] = manv;
            dr["MACA"] = maca;
            string ngayS = DateTime.Parse(ngaylam.ToString()).ToString("MM/dd/yyyy");
            dr["NgayLam"] = ngayS;
            dr["sotien"] = sotien;
            dr["sotieng"] = sotieng;
            dr["GhiChu"] = ghichu;
            ds.Tables["ctbangluongNV"].Rows.Add(dr);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "ctbangluongNV");
            return true;
        }

        public bool xoactLuongnv(string mabl, string manv, string maca, string ngaylam)
        {
            try
            {
                con.Open();
                string delete = "delete from ctbangluongnv where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' and MACA='" + maca + "' and NgayLam='" + ngaylam + "'  ";
                SqlCommand cmd = new SqlCommand(delete, ConnectDB.cnn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool suactluongnv(string mabl, string manv, string ngaylam, float sotien, float sotieng, string ghichu)
        {
            try
            {

                string sua = "update CTBANGLUONGNV set ngaylam='" + ngaylam + "',sotien = '" + sotien + "',sotieng='" + sotieng + "', ghichu ='N" + ghichu + "' where mabangluong='" + mabl + "' and manhanvien='" + manv + "' ";
                SqlCommand cmd = new SqlCommand(sua, ConnectDB.cnn);
                int kq = cmd.ExecuteNonQuery();

                if (kq > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public int LayMaBL()
        {

            string dem = "select Max(convert(int,SUBSTRING(MABANGLUONG,3,3))) from BANGLUONG";
            SqlCommand cmd = new SqlCommand(dem, ConnectDB.cnn);
            int kq = (int)cmd.ExecuteScalar();

            return kq;
        }
        public bool LuuBangNV()
        {
            string maBL, TenBL;
            DataSet ds = new DataSet();
            int kq = LayMaBL();
            kq++;
            maBL = "BL0" + kq.ToString();
            TenBL = kq.ToString();
            string load = "select * from BANGLUONG";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "BANGLUONG");
            DataRow dr = ds.Tables["BANGLUONG"].NewRow();
            dr["MABANGLUONG"] = maBL;
            dr["TENBANGLUONG"] = "Bảng Lương " + TenBL + "";
            ds.Tables["BANGLUONG"].Rows.Add(dr);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "BANGLUONG");
            return true;

        }
        //-----------------------------------------------------------------------------Tính Lương Quả Lý ---------------------------------------------------------------------------

        public DataTable loadLuongQL()
        {

            DataSet ds = new DataSet();
            string load = "select MABANGLUONG,HOTEN,NGAYVAOLAM,CHUCVU,NGAYPHATLUONG,LUONGCOBAN,LUONG from LUONGQL ql,NHANVIEN nv where ql.MANHANVIEN = nv.MANHANVIEN";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "Luongql");
            return ds.Tables["Luongql"];
        }

        public DataTable loadctLuongql()
        {
            DataSet ds = new DataSet();
            string load = "select MABANGLUONG,hoten,CHITIETCA,ct.LUONGCOBAN,NGAYCONGTHANG,NGAYCONGTHUCTE,PHUCAP,thanhtien,ghichu  from nhanvien nv,CTBANGLUONGQL ct, CALAM cl where  nv.MANHANVIEN=ct.MANHANVIEN and ct.MACA = cl.MACA";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "Luongql");
            return ds.Tables["Luongql"];
        }

        public DataTable loadctLuongTheoMaQL(string mabl, string manv)
        {
            DataSet ds = new DataSet();
            string load = "select MABANGLUONG,hoten,CHITIETCA,ct.LUONGCOBAN,NGAYCONGTHANG,NGAYCONGTHUCTE,HESOLUONG,PHUCAP,thanhtien,ghichu  from nhanvien nv,CTBANGLUONGQL ct, CALAM cl where ct.MACA = cl.MACA and  nv.MANHANVIEN=ct.MANHANVIEN and ct.MABANGLUONG='" + mabl + "' and ct.MANHANVIEN='" + manv + "'";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "Luongql");
            return ds.Tables["Luongql"];
        }

        //------------------------------------------------------------Bảng lương Quản Lý--------------------------------------------------
        public bool kiemTraKhoaChinhluongql(string mabl, string manv)
        {
            try
            {
                con.Open();
                string kt = "select count(*) from luongql where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' ";
                SqlCommand cmd = new SqlCommand(kt, ConnectDB.cnn);
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                if (kq >= 1)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool luuluongql(string mabl, string manv, string ngaypl, float luong)
        {
            try
            {
                DataSet ds = new DataSet();
                string luu = "select * from luongql ";
                SqlDataAdapter da = new SqlDataAdapter(luu, ConnectDB.cnn);
                da.Fill(ds, "Luongnv");
                DataRow dr = ds.Tables["Luongnv"].NewRow();
                dr["MABANGLUONG"] = mabl;
                dr["MANHANVIEN"] = manv;
                dr["NgayPhatLuong"] = ngaypl;
                dr["Luong"] = luong;
                ds.Tables["Luongnv"].Rows.Add(dr);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                da.Update(ds, "Luongnv");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sualuongql(string mabl, string manv, string ngaypl)
        {
            try
            {
                con.Open();
                string sua = "update luongql set ngayphatluong='" + ngaypl + "' where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' ";
                SqlCommand cmd = new SqlCommand(sua, ConnectDB.cnn);
                int kq = cmd.ExecuteNonQuery();
                con.Close();
                if (kq > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaluongql(string mabl, string manv)
        {
            try
            {
                con.Open();
                string xoa = "delete from luongql where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' ";
                SqlCommand cmd = new SqlCommand(xoa, ConnectDB.cnn);
                int kq = cmd.ExecuteNonQuery();
                con.Close();
                if (kq > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //----------------------CT Lương quản lý--------------------------------------
        public bool ktKhoaCtBangLuongQL(string mabl, string manv, string maca)
        {
            try
            {
                con.Open();
                string kt = "select count(*) from ctbangluongql where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' and MACA='" + maca + "'";
                SqlCommand cmd = new SqlCommand(kt, ConnectDB.cnn);
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                if (kq >= 1)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool themctLuongql(string mabl, string manv, string maca, float luongcb, float socongthang, float heso, float phucap, string ghichu)
        {
            DataSet ds = new DataSet();
            string themct = "select * from ctbangluongQL ";
            SqlDataAdapter da = new SqlDataAdapter(themct, ConnectDB.cnn);
            da.Fill(ds, "ctbangluongQL");
            DataRow dr = ds.Tables["ctbangluongQL"].NewRow();
            dr["MABANGLUONG"] = mabl;
            dr["MANHANVIEN"] = manv;
            dr["MACA"] = maca;
            dr["LUONGCOBAN"] = luongcb;
            dr["NGAYCONGTHANG"] = socongthang;
            dr["HESOLUONG"] = heso;
            dr["PHUCAP"] = phucap;
            dr["GhiChu"] = ghichu;
            ds.Tables["ctbangluongQL"].Rows.Add(dr);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "ctbangluongQL");
            return true;
        }

        public bool xoactLuongql(string mabl, string manv, string maca)
        {
            try
            {
                con.Open();
                string delete = "delete from ctbangluongql where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' and MACA='" + maca + "' ";
                SqlCommand cmd = new SqlCommand(delete, ConnectDB.cnn);
                int kq = cmd.ExecuteNonQuery();

                if (kq > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool sualuongctql(string mabl, string manv, string maca, string ngaycong)
        {
            try
            {
                con.Open();
                string sua = "update ctbangluongql set NGAYCONGTHANG='" + ngaycong + "' where MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' and MACA='" + maca + "' ";
                SqlCommand cmd = new SqlCommand(sua, ConnectDB.cnn);
                int kq = cmd.ExecuteNonQuery();
                con.Close();
                if (kq > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ktKhoaCtBangLuongChamCongQL(string macc, string mabl, string manv, string maca, string ngaylam)
        {
            try
            {
                con.Open();
                string kt = "select count(*) from CTCHAMCONG_QUANLY where MACHAMCONG = '" + macc + "' and MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' and MACA='" + maca + "' and NGAYLAM = '" + ngaylam + "'";
                SqlCommand cmd = new SqlCommand(kt, ConnectDB.cnn);
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                if (kq >= 1)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool themChamCongLuongql(string macc, string mabl, string manv, string maca, string ngaylam, string ghichu) //may dang lay ten nv ne
        {
            DataSet ds = new DataSet();
            string themct = "select * from CTCHAMCONG_QUANLY ";
            SqlDataAdapter da = new SqlDataAdapter(themct, ConnectDB.cnn);
            da.Fill(ds, "CTCHAMCONG_QUANLY");
            DataRow dr = ds.Tables["CTCHAMCONG_QUANLY"].NewRow();
            dr["MACHAMCONG"] = macc;
            dr["MABANGLUONG"] = mabl;
            dr["MANHANVIEN"] = manv;
            dr["MACA"] = maca;
            string ngayS = DateTime.Parse(ngaylam.ToString()).ToString("MM/dd/yyyy");
            dr["NgayLam"] = ngayS;
            dr["GhiChu"] = ghichu;
            ds.Tables["CTCHAMCONG_QUANLY"].Rows.Add(dr);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "CTCHAMCONG_QUANLY");
            return true;
        }

        public DataTable loadChamCongLuongTheoMaQL(string mabl, string manv)
        {
            DataSet ds = new DataSet();
            string load = "select MACHAMCONG,ct.MABANGLUONG,HoTen,ct.MACA,NGAYLAM,cc.GHICHU from CTBANGLUONGQL ct, CTCHAMCONG_QUANLY cc,NHANVIEN nv where nv.MANHANVIEN = ct.MANHANVIEN and ct.MABANGLUONG = cc.MABANGLUONG and ct.MANHANVIEN = cc.MANHANVIEN and ct.MACA = cc.MACA and  ct.MABANGLUONG='" + mabl + "' and ct.MANHANVIEN='" + manv + "'";
            SqlDataAdapter da = new SqlDataAdapter(load, ConnectDB.cnn);
            da.Fill(ds, "Luongql");
            return ds.Tables["Luongql"];
        }

        public bool xoaChamCongql(string macc, string mabl, string manv, string maca, string ngaylam)
        {
            try
            {
                con.Open();
                string delete = "delete from CTCHAMCONG_QUANLY where MACHAMCONG = '" + macc + "' and MABANGLUONG='" + mabl + "' and MANHANVIEN='" + manv + "' and MACA='" + maca + "' and NGAYLAM = '" + ngaylam + "' ";
                SqlCommand cmd = new SqlCommand(delete, ConnectDB.cnn);
                int kq = cmd.ExecuteNonQuery();

                if (kq > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
