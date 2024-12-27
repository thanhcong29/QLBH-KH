using QL_QuanCaPhe.BO;
using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe.BLL
{

    public class ChiTietThucDonBLL
    {
        #region Constructor
        public ChiTietThucDonBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy thông tin thực đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadInfo(string strMaCTMon)
        {
            try
            {
                ChiTietThucDonDAO objThucDonDAO = new ChiTietThucDonDAO();
                return objThucDonDAO.LoadInfo(strMaCTMon);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Thêm thông tin chi tiết thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(ChiTietThucDonBO objChiTietThucDonBO)
        {
            try
            {
                ChiTietThucDonDAO objChiTietThucDonDAO = new ChiTietThucDonDAO();
                return objChiTietThucDonDAO.Insert(objChiTietThucDonBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Sửa thông tin chi tiết thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(ChiTietThucDonBO objChiTietThucDonBO)
        {
            try
            {
                ChiTietThucDonDAO objChiTietThucDonDAO = new ChiTietThucDonDAO();
                return objChiTietThucDonDAO.Update(objChiTietThucDonBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Xóa thông tin chi tiết thực đơn
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strSize, string strMaMon)
        {
            try
            {
                ChiTietThucDonDAO objChiTietThucDonDAO = new ChiTietThucDonDAO();
                return objChiTietThucDonDAO.Delete(strSize, strMaMon);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Lấy danh sách thực đơn
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(int intSearchType, string strKeyWord)
        {
            try
            {
                ChiTietThucDonDAO objThucDonDAO = new ChiTietThucDonDAO();
                return objThucDonDAO.SearchData(intSearchType, strKeyWord);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách thực đơn theo  món
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadDataTheoMon(string strMaMon)
        {
            try
            {
                ChiTietThucDonDAO objThucDonDAO = new ChiTietThucDonDAO();
                return objThucDonDAO.LoadDataTheoMon(strMaMon);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy chi tiết thực đơn theo  món và size
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LayChiTiet(string strMaMon, string strSize)
        {
            try
            {
                ChiTietThucDonDAO objThucDonDAO = new ChiTietThucDonDAO();
                return objThucDonDAO.LayChiTiet(strMaMon, strSize);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Gắn size vào combobox
        ///</summary>
        /// <returns></returns>
        public void LoadCbbSize(ComboBox cbb, string strMaMon)
        {
            try
            {
                for (int i = cbb.Items.Count - 1; i >= 0; i--)
                {
                    cbb.Items.RemoveAt(i);
                }
                cbb.Items.Add("Chọn Size");

                List<DataRow> Sizes = new List<DataRow>(LoadDataTheoMon(strMaMon).Select());
                var dc = (from p in Sizes
                          select new
                          {
                              Size = p["Size"].ToString()
                          }).ToList();

                foreach (var i in dc)
                {
                    cbb.Items.Add(i.Size.Trim());
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show("Lỗi load danh sách size", "Thông báo");
            }
        }

        ///<summary>
        /// Gộp Size
        ///</summary>
        /// <returns>DataTable</returns>
        public string GopSize(string strMaMon)
        {
            try
            {
                string strSize = "";
                DataTable dt = LoadDataTheoMon(strMaMon);

                foreach (DataRow dr in dt.Rows)
                {
                    strSize += dr["Size"].ToString() + ", ";
                }
                return strSize;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }
        ///<summary>
        /// Gộp Giá
        ///</summary>
        /// <returns>DataTable</returns>
        public string GopGia(string strMaMon)
        {
            try
            {
                string strGia = "";
                int Gia = 0;
                DataTable dt = LoadDataTheoMon(strMaMon);

                foreach (DataRow dr in dt.Rows)
                {
                    strGia += string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", Convert.ToInt32(dr["GIA"].ToString())) + ", ";
                }
                return strGia;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Tạo mã chi tiết thực đơn tự động tăng
        ///</summary>
        /// <returns>String</returns>
        public string TaoMaChiTietThucDon(string strMaMon)
        {
            try
            {
                string strMaMoi = null;
                DataTable dt = LoadDataTheoMon(strMaMon);
                if (dt.Rows.Count > 0)
                {
                    int ma = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(4, 2));
                    int matang = ma + 1;
                    if (matang < 10)
                        strMaMoi = strMaMon + "0" + matang;
                    else if (matang < 100)
                        strMaMoi = strMaMon + "1" + matang;                   
                }
                else
                    strMaMoi = strMaMon +"01";
                return strMaMoi;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }
        #endregion
    }
}
