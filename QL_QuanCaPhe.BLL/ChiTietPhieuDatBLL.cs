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

    public class ChiTietPhieuDatBLL
    {
        #region Constructor
        public ChiTietPhieuDatBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Thêm thông tin chi tiết phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ChiTietPhieuDatBO objChitietPhieuDatBO)
        {
            ChiTietPhieuDatDAO objChiTietPhieuDatDAO = new ChiTietPhieuDatDAO();
            return objChiTietPhieuDatDAO.Insert(objChitietPhieuDatBO);
        }

        ///<summary>
        /// Xóa thông tin chi tiết phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(ChiTietPhieuDatBO objChitietPhieuDatBO)
        {
            ChiTietPhieuDatDAO objChiTietPhieuDatDAO = new ChiTietPhieuDatDAO();
            return objChiTietPhieuDatDAO.Delete(objChitietPhieuDatBO);
        }

        ///<summary>
        /// Lấy danh sách phiếu đặt theo mã phiếu đặt
        ///</summary>
        /// <returns>bool</returns>
        public DataTable Load(string strMaPhieuDat)
        {
            ChiTietPhieuDatDAO objChiTietPhieuDatDAO = new ChiTietPhieuDatDAO();
            return objChiTietPhieuDatDAO.Load(strMaPhieuDat);
        }

        ///<summary>
        /// Lấy danh sách phiếu đặt theo mã phiếu đặt khi nhập
        ///</summary>
        /// <returns>bool</returns>
        public DataTable LoadNguyenLieuNhap(string strMaPhieuDat)
        {
            ChiTietPhieuDatDAO objChiTietPhieuDatDAO = new ChiTietPhieuDatDAO();
            return objChiTietPhieuDatDAO.LoadNguyenLieuNhap(strMaPhieuDat);
        }
        ///<summary>
        /// Lấy danh sách phiếu đặt theo mã phiếu đặt khi nhập
        ///</summary>
        /// <returns>bool</returns>
        public DataTable LoadNguyenLieuChuaNhap(string strMaPhieuDat)
        {
            ChiTietPhieuDatDAO objChiTietPhieuDatDAO = new ChiTietPhieuDatDAO();
            return objChiTietPhieuDatDAO.LoadNguyenLieuChuaNhap(strMaPhieuDat);
        }

        ///<summary>
        /// Lấy danh sách phiếu đặt theo mã phiếu đặt khi nhập
        ///</summary>
        /// <returns>bool</returns>
        public DataTable LoadCBBNguyenLieuNhap(string strMaPhieuDat)
        {
            try
            {
                DataTable dtbNLNhap = LoadNguyenLieuNhap(strMaPhieuDat);
                dtbNLNhap.PrimaryKey = new DataColumn[] { dtbNLNhap.Columns["MANGUYENLIEU"] };

                DataTable dtbChuaNhap = LoadNguyenLieuChuaNhap(strMaPhieuDat);
                dtbChuaNhap.PrimaryKey = new DataColumn[] { dtbChuaNhap.Columns["MANGUYENLIEU"] };

                DataTable dt = new DataTable();
                dt.Columns.Add("MANGUYENLIEU");
                dt.Columns.Add("TENNGUYENLIEU");
                dt.Columns.Add("SOLUONG");
                dt.Columns.Add("SLNHAP");

                foreach (DataRow dra in dtbChuaNhap.Rows)
                {
                    DataRow dr = dtbNLNhap.Rows.Find(dra["MANGUYENLIEU"]);
                    if (dr == null)
                    {
                        dt.Rows.Add(dra["MANGUYENLIEU"].ToString(), dra["TENNGUYENLIEU"].ToString(), dra["SOLUONG"].ToString(), dra["SLNHAP"].ToString());
                    }
                    else
                    {
                        decimal soluongdat = Convert.ToDecimal(dra["SOLUONG"]);
                        decimal soluongnhap = Convert.ToDecimal(dr["SLNHAP"]);
                        decimal soluong = soluongdat - soluongnhap;
                        if(soluong != 0)
                            dt.Rows.Add(dra["MANGUYENLIEU"].ToString(), dra["TENNGUYENLIEU"].ToString(), dra["SOLUONG"].ToString(), soluong.ToString());
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
