using QL_QuanCaPhe.BO.PhanQuyen;
using QL_QuanCaPhe.DAO;
using QL_QuanCaPhe.DAO.PhanQuyen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BLL.PhanQuyen
{

    public class NhomNguoiDungBLL
    {
        #region Constructor
        public NhomNguoiDungBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách nhóm người dùng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData()
        {
            try
            {
                NhomNguoiDungDAO objNhomNguoiDungDAO = new NhomNguoiDungDAO();
                return objNhomNguoiDungDAO.LoadData();
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Thêm thông tin nhóm người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(NhomNguoiDungBO objNhomNguoiDungBO)
        {
            try
            {
                NhomNguoiDungDAO objNhomNguoiDungDAO = new NhomNguoiDungDAO();
                return objNhomNguoiDungDAO.Insert(objNhomNguoiDungBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Cập nhật thông tin nhóm người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(NhomNguoiDungBO objNhomNguoiDungBO)
        {
            try
            {
                NhomNguoiDungDAO objNhomNguoiDungDAO = new NhomNguoiDungDAO();
                return objNhomNguoiDungDAO.Update(objNhomNguoiDungBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Xóa thông tin nhóm người dùng
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaNhom)
        {
            try
            {
                NhomNguoiDungDAO objNhomNguoiDungDAO = new NhomNguoiDungDAO();
                return objNhomNguoiDungDAO.Delete(strMaNhom);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Kiểm tra mã nhóm người dùng đã tồn tại ?
        ///</summary>
        /// <returns>bool</returns>
        public bool KiemTraMaNhomNguoiDung(string strMaNhom)
        {
            try
            {
                List<DataRow> NhomNguoiDungs = new List<DataRow>(LoadData().Select());
                var manhom = (from nhom in NhomNguoiDungs
                             where nhom["MANHOM"].ToString() == strMaNhom
                             select nhom).FirstOrDefault();
                if(manhom != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }    
            }
            catch (Exception objEx)
            {
                return false;
            }
        }
        #endregion
    }
}
