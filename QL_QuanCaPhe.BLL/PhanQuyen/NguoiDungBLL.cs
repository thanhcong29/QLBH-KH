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

    public class NguoiDungBLL
    {
        #region Constructor
        public NguoiDungBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy thông tin người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData(string strTenDangNhap, string strMatKhau)
        {
            try
            {
                NguoiDungDAO objNguoiDungDAO = new NguoiDungDAO();
                return objNguoiDungDAO.LoadData(strTenDangNhap, strMatKhau);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Search(string strKeyWord, int intSearchType)
        {
            try
            {
                NguoiDungDAO objNguoiDungDAO = new NguoiDungDAO();
                return objNguoiDungDAO.Search(strKeyWord, intSearchType);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách nhân viên chưa có tài khoản người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadNhanVienChuCoTaiKhoan()
        {
            try
            {
                NguoiDungDAO objNguoiDungDAO = new NguoiDungDAO();
                return objNguoiDungDAO.LoadNhanVienChuaCoTaiKhoan();
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Thêm tài khoản người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public bool Insert(NguoiDungBO objNguoiDungBO)
        {
            try
            {
                NguoiDungDAO objNguoiDungDAO = new NguoiDungDAO();
                return objNguoiDungDAO.Insert(objNguoiDungBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Cập nhật tài khoản người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(NguoiDungBO objNguoiDungBO)
        {
            try
            {
                NguoiDungDAO objNguoiDungDAO = new NguoiDungDAO();
                return objNguoiDungDAO.Update(objNguoiDungBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Xóa tài khoản người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strTenDangNhap)
        {
            try
            {
                NguoiDungDAO objNguoiDungDAO = new NguoiDungDAO();
                return objNguoiDungDAO.Delete(strTenDangNhap);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }
        #endregion
    }
}
