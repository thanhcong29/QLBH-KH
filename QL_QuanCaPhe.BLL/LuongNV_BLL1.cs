using QL_QuanCaPhe.BO;
using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QL_QuanCaPhe.BLL
{
    public class LuongNV_BLL1
    {
        public DataTable LoadBangLuong()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadBangLuong();
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return null;
            }
        }

        public DataTable LoadCalam()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadCalam();
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return null;
            }
        }

        public DataTable LoadChamCong()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadChamCong();
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return null;
            }
        }

        public DataTable LoadNhanVien()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadNhanVien();
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return null;
            }
        }

        public DataTable LoadQL()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadQL();
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return null;
            }
        }
        //------------------------------------------------------------
        public bool luuBangLuong()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.LuuBangNV();
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool KTRAKHOACHINHLUONGNV(string maBl, string manv)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.kiemTraKhoaChinhluongnv(maBl, manv);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool LUULUONGNV(string mabl, string manv, string ngaylam, float tienluong)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.luuluongnv(mabl, manv, ngaylam, tienluong);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        public bool SUALUONGNV(string mabl, string manv, string ngaypl)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.sualuongnv(mabl, manv, ngaypl);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool XOABANGLUONG(string mabl, string manv)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.xoaluongnv(mabl, manv);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        //----------------------------------------------------------
        public bool KTRAKHOACHINH(string maBl, string manv, string maca, string ngaylam)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.ktKhoaCtBangLuong(maBl, manv, maca, ngaylam);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        public bool Them_CTBANGLUONG(string mabl, string manv, string maca, string ngaylam, float sotien, float sotieng, string ghichu)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.themctLuongnv(mabl, manv, maca, ngaylam, sotien, sotieng, ghichu);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool XoaCTBangLuong(string maBl, string manv, string maca, string ngaylam)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.xoactLuongnv(maBl, manv, maca, ngaylam);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }



        //--------------------------------------------------------------
        public DataTable LoadCTLUONG_TheoMa(string mabl, string manv)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadctLuongTheoMa(mabl, manv);
            }
            catch (Exception objEx)
            {

                return null;
            }
        }

        public DataTable LoadCTBangLuong_Luong()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadctLuongnv();
            }
            catch (Exception objEx)
            {

                return null;
            }
        }


        public DataTable LoadLuongNV()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadLuongnv();
            }
            catch (Exception objEx)
            {

                return null;
            }
        }
        //----------------------------------------------------------Tính lương Quản lý-------------------------------------------------------------

        public DataTable LoadBangLuongQL()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadLuongQL();
            }
            catch (Exception objEx)
            {

                return null;
            }
        }

        public DataTable LoadCTBangLuongQL()
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadctLuongql();
            }
            catch (Exception objEx)
            {

                return null;
            }
        }

        public DataTable LoadCTLUONG_TheoMaQL(string mabl, string manv)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadctLuongTheoMaQL(mabl, manv);
            }
            catch (Exception objEx)
            {

                return null;
            }
        }

        //--------------------------------------------Lương Quản lý--------------------------------------------------------
        public bool KTRAKHOACHINHLUONGQL(string maBl, string manv)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.kiemTraKhoaChinhluongql(maBl, manv);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool LUULUONGQL(string mabl, string manv, string ngaylam, float tienluong)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.luuluongql(mabl, manv, ngaylam, tienluong);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        public bool SUALUONGQL(string mabl, string manv, string ngaypl)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.sualuongql(mabl, manv, ngaypl);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool XOABANGLUONGQL(string mabl, string manv)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.xoaluongql(mabl, manv);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool KTRAKHOACHINHCTLUONGQL(string maBl, string manv, string maca)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.ktKhoaCtBangLuongQL(maBl, manv, maca);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool Them_CTBANGLUONGQL(string mabl, string manv, string maca, float luongcb, float socongthang, float heso, float phucap, string ghichu)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.themctLuongql(mabl, manv, maca, luongcb, socongthang, heso, phucap, ghichu);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        public bool XoaCTBangLuongQL(string maBl, string manv, string maca)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.xoactLuongql(maBl, manv, maca);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool SuaCTBangLuongQL(string maBl, string manv, string maca, string ngaycong)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.sualuongctql(maBl, manv, maca, ngaycong);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
        public bool KTRAKHOACHINHChamCongLUONGQL(string macc, string maBl, string manv, string maca, string ngaylam)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.ktKhoaCtBangLuongChamCongQL(macc, maBl, manv, maca, ngaylam);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public bool Them_CHAMCONGBANGLUONGQL(string macc, string mabl, string manv, string maca, string ngaylam, string ghichu)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.themChamCongLuongql(macc, mabl, manv, maca, ngaylam, ghichu);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }

        public DataTable LoadChamCongLUONG_TheoMaQL(string mabl, string manv)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.loadChamCongLuongTheoMaQL(mabl, manv);
            }
            catch (Exception objEx)
            {

                return null;
            }
        }

        public bool XoaChamCongBangLuongQL(string macc, string maBl, string manv, string maca, string ngaylam)
        {
            try
            {
                LuongNV_DAO1 objLuongNVDAO = new LuongNV_DAO1();
                return objLuongNVDAO.xoaChamCongql(macc, maBl, manv, maca, ngaylam);
            }
            catch (Exception objEx)
            {

                return false;
            }
        }
    }
}
