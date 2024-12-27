using QL_QuanCaPhe.BO;
using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe.BLL
{

    public class KhachHangBLL
    {
        #region Constructor
        public KhachHangBLL()
        {
        }
        #endregion
        #region Methods


        ///<summary>
        /// Tìm kiếm khách hàng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(int intSearchType, string strKeyWord, int intTinhTrang)
        {
            try
            {
                KhachHangDAO objKhachHangDAO = new KhachHangDAO();
                return objKhachHangDAO.SearchData(strKeyWord, intSearchType, intTinhTrang);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// lấy thông tin khách hàng
        ///</summary>
        /// <returns>DataTable</returns>
        public KhachHangBO LoadInfo(string strMaKH)
        {
            KhachHangDAO objKhachHangDAO = new KhachHangDAO();
            return objKhachHangDAO.LoadInfo(strMaKH);
        }

        ///<summary>
        /// Cập nhật điểm thưởng khách hàng
        ///</summary>
        /// <returns></returns>
        public void CapNhatDiemThuong(string strMaKH, float floDiem)
        {
            KhachHangDAO objKhachHangDAO = new KhachHangDAO();
            objKhachHangDAO.CapNhatDiemThuong(strMaKH, floDiem);
        }

        ///<summary>
        /// Lấy danh sách khách hàng
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable Load()
        {
            KhachHangDAO objKhachHangDAO = new KhachHangDAO();
            return objKhachHangDAO.Load();
        }

        ///<summary>
        /// Thêm thông tin khách hàng
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(KhachHangBO objKhachHangBO)
        {
            KhachHangDAO objKhachHangDAO = new KhachHangDAO();
            return objKhachHangDAO.Insert(objKhachHangBO);
        }

        ///<summary>
        /// Cập nhật thông tin khách hàng
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(KhachHangBO objKhachHangBO)
        {
            KhachHangDAO objKhachHangDAO = new KhachHangDAO();
            return objKhachHangDAO.Update(objKhachHangBO);
        }

        ///<summary>
        /// Xóa thông tin khách hàng
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaKH)
        {
            KhachHangDAO objKhachHangDAO = new KhachHangDAO();
            return objKhachHangDAO.Delete(strMaKH);
        }

        ///<summary>
        /// Tạo mã khách hàng tự động tăng
        ///</summary>
        /// <returns>String</returns>
        public string TaoMaKhachHang()
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
                        strMaMoi = "KH00" + matang;
                    else if (matang < 100)
                        strMaMoi = "KH0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "KH" + matang;
                }
                else
                    strMaMoi = "KH001";
                return strMaMoi;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Kiểm tra tồn tại SDT
        ///</summary>
        /// <returns>bool</returns>
        public bool KT_SDTKhachHang(string strMaKH, string strSDT)
        {
            try
            {
                DataTable dt = Load();
                foreach (DataRow dr in dt.Rows)
                {
                    if(dr["SDT"].ToString() == strSDT && dr["MAKHACHHANG"].ToString() != strMaKH)
                    {
                        MessageBox.Show("Số điện thoại này đã được đăng ký bởi khách hàng khác, hãy thay đổi sđt hoặc kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }    
                }
                return true;
            }
            catch (Exception objEx)
            {
                return false;
            }
        }
        #endregion
    }
}
