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

    public class ChiTietPhieuNhapBLL
    {
        #region Constructor
        public ChiTietPhieuNhapBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm thông tin chi tiết phiếu nhập
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ChiTietPhieuNhapBO objChiTietPhieuNhapBO)
        {
            ChiTietPhieuNhapDAO objChiTietPhieuNhapDAO = new ChiTietPhieuNhapDAO();
            return objChiTietPhieuNhapDAO.Insert(objChiTietPhieuNhapBO);
        }

        ///<summary>
        /// Xóa thông tin chi tiết phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(ChiTietPhieuNhapBO objChiTietPhieuNhapBO)
        {
            ChiTietPhieuNhapDAO objChiTietPhieuNhapDAO = new ChiTietPhieuNhapDAO();
            return objChiTietPhieuNhapDAO.Delete(objChiTietPhieuNhapBO);
        }

        ///<summary>
        /// Lấy danh sách phiếu đặt theo mã phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public DataTable Load(string strMaPhieuNhap)
        {
            ChiTietPhieuNhapDAO objChiTietPhieuNhapDAO = new ChiTietPhieuNhapDAO();
            return objChiTietPhieuNhapDAO.Load(strMaPhieuNhap);
        }
        #endregion
    }
}
