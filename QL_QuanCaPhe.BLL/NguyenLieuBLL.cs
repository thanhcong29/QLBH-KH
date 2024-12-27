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

    public class NguyenLieuBLL
    {
        #region Constructor
        public NguyenLieuBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách nguyên liệu
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(string strTen)
        {
            try
            {
                NguyenLieuDAO objNguyenLieuDAO = new NguyenLieuDAO();
                return objNguyenLieuDAO.SearchData(strTen);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Thêm mã giảm giá
        ///</summary>
        /// <returns>DataTable</returns>
        public bool Insert(NguyenLieuBO objNguyenLieuBO)
        {
            NguyenLieuDAO objNguyenLieuDAO = new NguyenLieuDAO();
            return objNguyenLieuDAO.Insert(objNguyenLieuBO);
        }

        ///<summary>
        /// Sửa nguyên liệu
        ///</summary>
        /// <returns>DataTable</returns>
        public bool Update(NguyenLieuBO objNguyenLieuBO)
        {
            NguyenLieuDAO objNguyenLieuDAO = new NguyenLieuDAO();
            return objNguyenLieuDAO.Update(objNguyenLieuBO);
        }

        ///<summary>
        /// Sửa nguyên liệu
        ///</summary>
        /// <returns>DataTable</returns>
        public bool CapNhatSoLuong(int intMaNguyenLieu, float floSoLuong)
        {
            NguyenLieuDAO objNguyenLieuDAO = new NguyenLieuDAO();
            return objNguyenLieuDAO.CapNhatSoLuong(intMaNguyenLieu, floSoLuong);
        }

        ///<summary>
        /// Xóa nguyên liệu
        ///</summary>
        /// <returns>DataTable</returns>
        public bool Delete(string strMa)
        {
            NguyenLieuDAO objNguyenLieuDAO = new NguyenLieuDAO();
            return objNguyenLieuDAO.Delete(strMa);
        }

        public DataTable LoadNguyenLieuTheoNCC(int intMaNCC)
        {
            
            List<DataRow> NLs = new List<DataRow>(SearchData("0").Select());

            var NL = (from nl in NLs
                      where Convert.ToInt32(nl["MANHACUNGCAP"].ToString()) == intMaNCC
                      select new 
                      {
                            MaNL = nl["MANGUYENLIEU"].ToString(),
                            Ten = nl["TENNGUYENLIEU"].ToString(),
                            SL = nl["SOLUONG"].ToString(),
                            DVT = nl["DVT"].ToString()
                      }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Ma");
            dt.Columns.Add("Ten");
            dt.Columns.Add("SL");
            dt.Columns.Add("DVT");
            foreach (var item in NL)
            {
                dt.Rows.Add(item.MaNL, item.Ten, item.SL, item.DVT);
            }
            return dt;
        }


        #endregion
    }
}
