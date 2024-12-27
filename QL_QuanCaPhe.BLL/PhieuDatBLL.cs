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

    public class PhieuDatBLL
    {

        ///<summary>
        /// Lấy danh sách phiếu đặt
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Search(int intSearchType, string strKeyWord, DateTime dtTuNgay, DateTime dtToiNgay, int NCC)
        {
            PhieuDatDAO objHoaDonDAO = new PhieuDatDAO();
            return objHoaDonDAO.Search(intSearchType, strKeyWord, dtTuNgay, dtToiNgay, NCC);
        }

        ///<summary>
        /// xóa thông tin phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaPhieu)
        {
            PhieuDatDAO objHoaDonDAO = new PhieuDatDAO();
            return objHoaDonDAO.Delete(strMaPhieu);
        }

        ///<summary>
        /// Lấy danh sách phiếu đặt
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Load()
        {
            PhieuDatDAO objHoaDonDAO = new PhieuDatDAO();
            return objHoaDonDAO.Load();
        }

        ///<summary>
        /// Lấy danh sách phiếu đặt theo nhà cung cấp
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadPhieuDatTheoNCC(string NCC, DateTime FromDay, DateTime ToDay, int SearchType, string KeyWord)
        {
            string fromDay = FromDay.ToString();
            string toDay = ToDay.ToString();
            DataTable dt = new DataTable();
            PhieuDatDAO objHoaDonDAO = new PhieuDatDAO();
            List<DataRow> NCCs = new List<DataRow>(objHoaDonDAO.LoadPhieuDatTheoNCC(NCC).Select());
            if(FromDay != null && ToDay != null && SearchType == 0)
            {
                var pd = from p in NCCs
                         where DateTime.Parse(p["NGAYLAP"].ToString()) >= DateTime.Parse(FromDay.Date.ToShortDateString()) && Convert.ToDateTime(p["NGAYLAP"].ToString()) <= DateTime.Parse(ToDay.Date.ToShortDateString()) && p["MAPHIEUDAT"].ToString() == KeyWord
                         select new
                         {
                             MAPHIEUDAT = p["MAPHIEUDAT"].ToString(),
                             TENPHIEUDAT = p["TENPHIEUDAT"].ToString(),
                             NGAYLAP = p["NGAYLAP"].ToString(),
                             TONGTIEN = p["TONGTIEN"].ToString(),
                             TINHTRANG = p["TINHTRANG"].ToString(),
                             MANHANVIEN = p["MANHANVIEN"].ToString(),
                             HOTEN = p["HOTEN"].ToString()
                         };
                if (pd != null)
                {
                    dt.Rows.Add(pd);
                }
            }
            if (FromDay != null && ToDay != null && SearchType == 1)
            {
                var pd = from p in NCCs
                         where Convert.ToDateTime(p["NGAYLAP"].ToString()) >= FromDay && Convert.ToDateTime(p["NGAYLAP"].ToString()) <= ToDay && p["TENPHIEUDAT"].ToString().Contains(KeyWord)
                         select new
                         {
                             MAPHIEUDAT = p["MAPHIEUDAT"].ToString(),
                             TENPHIEUDAT = p["TENPHIEUDAT"].ToString(),
                             NGAYLAP = p["NGAYLAP"].ToString(),
                             TONGTIEN = p["TONGTIEN"].ToString(),
                             TINHTRANG = p["TINHTRANG"].ToString(),
                             MANHANVIEN = p["MANHANVIEN"].ToString(),
                             HOTEN = p["HOTEN"].ToString()
                         };
                if (pd != null)
                {
                    dt.Rows.Add(pd);
                }
                
            }
            if (FromDay != null && ToDay != null && SearchType == -1)
            {
                var pd = from p in NCCs
                         where DateTime.Parse(p["NGAYLAP"].ToString()) >= DateTime.Parse(FromDay.Date.ToShortDateString()) && Convert.ToDateTime(p["NGAYLAP"].ToString()) <= DateTime.Parse(ToDay.Date.ToShortDateString())
                         select new
                         {
                             MAPHIEUDAT = p["MAPHIEUDAT"].ToString(),
                             TENPHIEUDAT = p["TENPHIEUDAT"].ToString(),
                             NGAYLAP = p["NGAYLAP"].ToString(),
                             TONGTIEN = p["TONGTIEN"].ToString(),
                             TINHTRANG = p["TINHTRANG"].ToString(),
                             MANHANVIEN = p["MANHANVIEN"].ToString(),
                             HOTEN = p["HOTEN"].ToString()
                         };
                if (pd != null)
                {
                    foreach (var item in pd)
                    {
                        dt.Rows.Add(pd);
                    }
                }
            }
            return dt;
        }

        ///<summary>
        /// Thêm phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(PhieuDatBO objPhieuDatBO)
        {
            PhieuDatDAO objPhieuDatDAO = new PhieuDatDAO();
            if(objPhieuDatDAO.Insert(objPhieuDatBO))
            {
                foreach (ChiTietPhieuDatBO ct in objPhieuDatBO.lstChiTietPhieuDatBOs)
                {
                    ChiTietPhieuDatDAO objChiTietPhieuDatDAO = new ChiTietPhieuDatDAO();
                    if(objChiTietPhieuDatDAO.Insert(ct))
                    {
                        continue;
                    }    
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }    
        }
        ///<summary>
        /// Cập nhật phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(PhieuDatBO objPhieuDatBO)
        {
            PhieuDatDAO objPhieuDatDAO = new PhieuDatDAO();
            if (objPhieuDatDAO.Update(objPhieuDatBO))
            {
                foreach (ChiTietPhieuDatBO ct in objPhieuDatBO.lstChiTietPhieuDatBOs)
                {
                    ChiTietPhieuDatDAO objChiTietPhieuDatDAO = new ChiTietPhieuDatDAO();
                    if (objChiTietPhieuDatDAO.Insert(ct))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public string TaoMaTuTang()
        {
            try
            {
                string strMaMoi = null;
                DataTable dt = Load();
                if (dt.Rows.Count > 0)
                {
                    int ma = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                    int matang = ma + 1;
                    if (matang < 10)
                        strMaMoi = "PD00" + matang;
                    else if (matang < 100)
                        strMaMoi = "PD0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "PD" + matang;
                }
                else
                    strMaMoi = "PD001";
                return strMaMoi;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách phiếu đặt khi nhập
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadPhieuDatKhiNhap()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MAPHIEUDAT");
            dt.Columns.Add("TENPHIEUDAT");
            dt.Columns.Add("NGAYLAP");
            dt.Columns.Add("TONGTIEN");

            List<DataRow> PDs = new List<DataRow>(Load().Select());

            var pd = (from p in PDs
                      where Convert.ToInt32(p["TINHTRANG"].ToString()) > -1
                      select new
                      {
                          MAPHIEUDAT = p["MAPHIEUDAT"].ToString(),
                          TENPHIEUDAT = p["TENPHIEUDAT"].ToString(),
                          NGAYLAP = p["NGAYLAP"].ToString(),
                          TONGTIEN = p["TONGTIEN"].ToString()
                      }).ToList();
            if(pd != null)
            {
                foreach (var item in pd)
                {
                    DateTime fromDay = Convert.ToDateTime(item.NGAYLAP);
                    DateTime toDay = Convert.ToDateTime(DateTime.Now);
                    TimeSpan Time = toDay - fromDay;
                    int TongSoNgay = Time.Days;
                    if(TongSoNgay <= 30)
                    {
                        dt.Rows.Add(item.MAPHIEUDAT, item.TENPHIEUDAT, item.NGAYLAP, item.TONGTIEN);
                    }    
                }
            }    

            return dt;
        }

        ///<summary>
        /// Lấy thông tin khi xuất report
        ///</summary>
        /// <returns>Datatable</returns>

        public DataTable LayRPPHIEUDAT(string strMaPD)
        {
            try
            {
                PhieuDatDAO objPhieuDatDAO = new PhieuDatDAO();
                return objPhieuDatDAO.LayRPPHIEUDAT(strMaPD);
            }
            catch
            {
                return null;
            }
        }

    }
}
