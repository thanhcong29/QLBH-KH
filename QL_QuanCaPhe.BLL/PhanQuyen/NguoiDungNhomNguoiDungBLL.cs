using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BLL
{

    public class NguoiDungNhomNguoiDungBLL
    {
        #region Constructor
        public NguoiDungNhomNguoiDungBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách người dùng nhóm người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData(string strTenDangNhap)
        {
            try
            {
                NguoiDungNhomNguoiDungDAO objNguoiDungNhomNguoiDungDAO = new NguoiDungNhomNguoiDungDAO();
                return objNguoiDungNhomNguoiDungDAO.LoadData(strTenDangNhap);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách mã nhóm người dùng
        ///</summary>
        /// <returns>List</returns>
        public List<string> GetMaNhomNguoiDung(string tenDN)
        {
            var loaddata = LoadData(tenDN);
            List<DataRow> NguoiDungNhomNguoiDungs = new List<DataRow>(loaddata.Select());
            List<string> kqMNND = new List<string>();
            var quyen = (from p in NguoiDungNhomNguoiDungs
                         select new
                         {
                             TenDangNhap = p["TENDANGNHAP"].ToString().Trim(),
                             MaNhom = p["MANHOM"].ToString().Trim(),
                         }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Đăng Nhập");
            dt.Columns.Add("Mã Nhóm Người Dùng");
            foreach (var TD in quyen)
            {
                dt.Rows.Add(TD.TenDangNhap, TD.MaNhom);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                kqMNND.Add(dt.Rows[i].ItemArray[1].ToString());
            }
            return kqMNND;
        }
        #endregion
    }
}
