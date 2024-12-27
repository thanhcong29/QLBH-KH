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

    public class PhieuNhapBLL
    {
        ///<summary>
        /// Thêm phiếu nhập
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(PhieuNhapBO objPhieuNhapBO)
        {
            PhieuNhapDAO objPhieuDatDAO = new PhieuNhapDAO();
            if (objPhieuDatDAO.Insert(objPhieuNhapBO))
            {
                foreach (ChiTietPhieuNhapBO ct in objPhieuNhapBO.lstChiTietPhieuNhapBOs)
                {
                    ChiTietPhieuNhapDAO objChiTietPhieuNhapDAO = new ChiTietPhieuNhapDAO();
                    if (objChiTietPhieuNhapDAO.Insert(ct))
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
        /// Cập nhật phiếu nhập
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(PhieuNhapBO objPhieuNhapBO)
        {
            PhieuNhapDAO objPhieuNhapDAO = new PhieuNhapDAO();
            if (objPhieuNhapDAO.Update(objPhieuNhapBO))
            {               
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        /// Xóa phiếu nhập
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaPhieu)
        {
            PhieuNhapDAO objPhieuNhapDAO = new PhieuNhapDAO();
            return objPhieuNhapDAO.Delete(strMaPhieu);
        }

        ///<summary>
        /// tìm kiếm phiếu nhập
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Search(int intSearchType, string strKeyWord, DateTime fromDay, DateTime toDay)
        {
            PhieuNhapDAO objPhieuNhapDAO = new PhieuNhapDAO();
            return objPhieuNhapDAO.Search(intSearchType, strKeyWord, fromDay, toDay);
        }

        ///<summary>
        /// lấy danh sách phiếu nhập
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Load()
        {
            PhieuNhapDAO objPhieuNhapDAO = new PhieuNhapDAO();
            return objPhieuNhapDAO.Load();
        }

        ///<summary>
        /// tạo mã phiếu nhập tự tăng
        ///</summary>
        /// <returns>string</returns>
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
                        strMaMoi = "PN00" + matang;
                    else if (matang < 100)
                        strMaMoi = "PN0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "PN" + matang;
                }
                else
                    strMaMoi = "PN001";
                return strMaMoi;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy thông tin khi xuất report
        ///</summary>
        /// <returns>Datatable</returns>

        public DataTable LayRPPHIEUNHAP(string strMaPN)
        {
            try
            {
                PhieuNhapDAO objPhieuNhapDAO = new PhieuNhapDAO();
                return objPhieuNhapDAO.LayRPPHIEUNHAP(strMaPN);
            }
            catch
            {
                return null;
            }
        }
    }
}
