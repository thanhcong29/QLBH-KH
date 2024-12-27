using DevExpress.XtraEditors;
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

    public class NhanVienBLL
    {
        #region Constructor
        public NhanVienBLL()
        {
        }
        #endregion
        #region Methods
        ///<summary>
        /// Thêm nhân viên
        ///</summary>
        /// <returns>Int</returns>
        public bool Insert(NhanVienBO objNhanVienBO)
        {
            try
            {
                NhanVienDAO objNhanVienDAO = new NhanVienDAO();
                return objNhanVienDAO.Insert(objNhanVienBO);
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return false;
            }
        }

        ///<summary>
        /// Sửa nhân viên
        ///</summary>
        /// <returns>Int</returns>
        public bool Update(NhanVienBO objNhanVienBO)
        {
            try
            {
                NhanVienDAO objNhanVienDAO = new NhanVienDAO();
                return objNhanVienDAO.Update(objNhanVienBO);
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return false;
            }
        }

        ///<summary>
        /// Xóa nhân viên
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaNhanVien)
        {
            try
            {
                NhanVienDAO objNhanVienDAO = new NhanVienDAO();
                return objNhanVienDAO.Delete(strMaNhanVien);
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return false;
            }
        }

        ///<summary>
        /// Tìm kiếm nhân viên
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(int intSearchType, string strKeyWord)
        {
            try
            {
                NhanVienDAO objNhanVienDAO = new NhanVienDAO();
                return objNhanVienDAO.SearchData(strKeyWord, intSearchType);
            }
            catch (Exception objEx)
            {
                //objResultMessageBO = ResultMessageDAO.InitResultMessage(true, SystemErrorBO.ErrorTypes.SearchData
                //    , "Lỗi nạp danh sách Nhân Viên", objEx, "NhanVien -> SearchData", "Tên Mudule ");
                return null;
            }
        }

        ///<summary>
        /// Tạo mã nhân viên tự động tăng
        ///</summary>
        /// <returns>String</returns>
        public string TaoMaNhanVien()
        {
            try
            {
                string strMaMoi = null;               
                DataTable dt = SearchData(-1,"NULL");
                if (dt.Rows.Count > 0)
                {
                    int ma = Convert.ToInt32(dt.Rows[dt.Rows.Count -1][0].ToString().Substring(2, 3));
                    int matang = ma + 1;
                    if (matang < 10)
                        strMaMoi = "NV00" + matang;
                    else if (matang < 100)
                        strMaMoi = "NV0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "NV" + matang;
                }
                else
                    strMaMoi = "NV001";
                return strMaMoi;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public void LoadDiaChi(ComboBoxEdit cbbDC)
        {
            for (int i = cbbDC.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbbDC.Properties.Items.RemoveAt(i);
            }
            cbbDC.Properties.Items.Add("Tất Cả");

            List<DataRow> NhanViens = new List<DataRow>(SearchData(-1, "NULL").Select());
            var dc = from p in NhanViens group p by p["DIACHI"].ToString().Trim() into g select new { dc = g.Key };
            foreach (var i in dc)
            {
                cbbDC.Properties.Items.Add(i.dc.Trim());
            }
        }

        ///<summary>
        /// Lọc Nhân viên
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LocNhanVien(string strGioiTinh, string strDiaChi)
        {
            try
            {
                DataTable dt = new DataTable();
                if(strGioiTinh == "Tất Cả" && strDiaChi == "Tất Cả")
                {
                    dt = SearchData(-1, "NULL");
                }
                if(strGioiTinh != "Tất Cả" && strDiaChi == "Tất Cả")
                {
                    List<DataRow> NhanViens = new List<DataRow>(SearchData(-1, "NULL").Select());
                    var nv = (from a in NhanViens
                              where a["GIOITINH"].ToString().Trim() == strGioiTinh
                              select new
                              { 
                                  MaNhanVien = a["MANHANVIEN"].ToString().Trim(),
                                  HoTen = a["HOTEN"].ToString().Trim(),
                                  GioiTinh = a["GIOITINH"].ToString().Trim(),
                                  NgaySinh = Convert.ToDateTime(a["NGAYSINH"]).ToString("MM/dd/yyyy"),
                                  DiaChi = a["DIACHI"].ToString().Trim(),
                                  SDT = a["SDT"].ToString().Trim(),
                                  NgayVaoLam = Convert.ToDateTime(a["NGAYVAOLAM"]).ToString("MM/dd/yyyy"),
                                  LuongCoBan = a["LUONGCOBAN"].ToString().Trim(),
                                  ChucVu = a["CHUCVU"].ToString().Trim(),
                                  HinhAnh = a["HINHANH"].ToString().Trim()
                              }).ToList();
                    dt.Columns.Add("MANHANVIEN");
                    dt.Columns.Add("HOTEN");
                    dt.Columns.Add("GIOITINH");
                    dt.Columns.Add("NGAYSINH");
                    dt.Columns.Add("DIACHI");
                    dt.Columns.Add("SDT");
                    dt.Columns.Add("NGAYVAOLAM");
                    dt.Columns.Add("LUONGCOBAN");
                    dt.Columns.Add("CHUCVU");
                    dt.Columns.Add("HINHANH");
                    foreach (var item in nv)
                    {
                        dt.Rows.Add(item.MaNhanVien, item.HoTen, item.GioiTinh, item.NgaySinh, item.DiaChi, item.SDT, item.NgayVaoLam, item.LuongCoBan, item.ChucVu, item.HinhAnh);
                    }    

                }
                if(strGioiTinh == "Tất Cả" && strDiaChi != "Tất Cả")
                {
                    List<DataRow> NhanViens = new List<DataRow>(SearchData(-1, "NULL").Select());
                    var nv = (from a in NhanViens
                              where a["DIACHI"].ToString().Contains(strDiaChi)
                              select new
                              {
                                  MaNhanVien = a["MANHANVIEN"].ToString().Trim(),
                                  HoTen = a["HOTEN"].ToString().Trim(),
                                  GioiTinh = a["GIOITINH"].ToString().Trim(),
                                  NgaySinh = Convert.ToDateTime(a["NGAYSINH"]).ToString("MM/dd/yyyy"),
                                  DiaChi = a["DIACHI"].ToString().Trim(),
                                  SDT = a["SDT"].ToString().Trim(),
                                  NgayVaoLam = Convert.ToDateTime(a["NGAYVAOLAM"]).ToString("MM/dd/yyyy"),
                                  LuongCoBan = a["LUONGCOBAN"].ToString().Trim(),
                                  ChucVu = a["CHUCVU"].ToString().Trim(),
                                  HinhAnh = a["HINHANH"].ToString().Trim()
                              }).ToList();
                    dt.Columns.Add("MANHANVIEN");
                    dt.Columns.Add("HOTEN");
                    dt.Columns.Add("GIOITINH");
                    dt.Columns.Add("NGAYSINH");
                    dt.Columns.Add("DIACHI");
                    dt.Columns.Add("SDT");
                    dt.Columns.Add("NGAYVAOLAM");
                    dt.Columns.Add("LUONGCOBAN");
                    dt.Columns.Add("CHUCVU");
                    dt.Columns.Add("HINHANH");
                    foreach (var item in nv)
                    {
                        dt.Rows.Add(item.MaNhanVien, item.HoTen, item.GioiTinh, item.NgaySinh, item.DiaChi, item.SDT, item.NgayVaoLam, item.LuongCoBan, item.ChucVu, item.HinhAnh);
                    }
                }
                if (strGioiTinh != "Tất Cả" && strDiaChi != "Tất Cả")
                {
                    List<DataRow> NhanViens = new List<DataRow>(SearchData(-1, "NULL").Select());
                    var nv = (from a in NhanViens
                              where a["DIACHI"].ToString().Contains(strDiaChi) && a["GIOITINH"].ToString().Trim() == strGioiTinh
                              select new
                              {
                                  MaNhanVien = a["MANHANVIEN"].ToString().Trim(),
                                  HoTen = a["HOTEN"].ToString().Trim(),
                                  GioiTinh = a["GIOITINH"].ToString().Trim(),
                                  NgaySinh = Convert.ToDateTime(a["NGAYSINH"]).ToString("MM/dd/yyyy"),
                                  DiaChi = a["DIACHI"].ToString().Trim(),
                                  SDT = a["SDT"].ToString().Trim(),
                                  NgayVaoLam = Convert.ToDateTime(a["NGAYVAOLAM"]).ToString("MM/dd/yyyy"),
                                  LuongCoBan = a["LUONGCOBAN"].ToString().Trim(),
                                  ChucVu = a["CHUCVU"].ToString().Trim(),
                                  HinhAnh = a["HINHANH"].ToString().Trim()
                              }).ToList();
                    dt.Columns.Add("MANHANVIEN");
                    dt.Columns.Add("HOTEN");
                    dt.Columns.Add("GIOITINH");
                    dt.Columns.Add("NGAYSINH");
                    dt.Columns.Add("DIACHI");
                    dt.Columns.Add("SDT");
                    dt.Columns.Add("NGAYVAOLAM");
                    dt.Columns.Add("LUONGCOBAN");
                    dt.Columns.Add("CHUCVU");
                    dt.Columns.Add("HINHANH");
                    foreach (var item in nv)
                    {
                        dt.Rows.Add(item.MaNhanVien, item.HoTen, item.GioiTinh, item.NgaySinh, item.DiaChi, item.SDT, item.NgayVaoLam, item.LuongCoBan, item.ChucVu, item.HinhAnh);
                    }
                }
                return dt;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        #endregion
    }
}
