using DevExpress.XtraEditors;
using QL_QuanCaPhe.BO;
using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;

namespace QL_QuanCaPhe.BLL
{

    public class LoaiMonBLL
    {
        #region Constructor
        public LoaiMonBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách loại món
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData()
        {
            try
            {
                LoaiMonDAO objLoaiMonDAO = new LoaiMonDAO();
                return objLoaiMonDAO.LoadData();
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Thêm thông tin loại món
        ///</summary>
        /// <returns>bool</returns>
        public bool Insert(LoaiMonBO objLoaiMonBO)
        {
            try
            {
                LoaiMonDAO objLoaiMonDAO = new LoaiMonDAO();
                return objLoaiMonDAO.Insert(objLoaiMonBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Sửa thông tin loại món
        ///</summary>
        /// <returns>bool</returns>
        public bool Update(LoaiMonBO objLoaiMonBO)
        {
            try
            {
                LoaiMonDAO objLoaiMonDAO = new LoaiMonDAO();
                return objLoaiMonDAO.Update(objLoaiMonBO);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Xóa thông tin loại món
        ///</summary>
        /// <returns>bool</returns>
        public bool Delete(string strMaLoai)
        {
            try
            {
                LoaiMonDAO objLoaiMonDAO = new LoaiMonDAO();
                return objLoaiMonDAO.Delete(strMaLoai);
            }
            catch (Exception objEx)
            {
                return false;
            }
        }

        ///<summary>
        /// Lấy danh sách loại món
        ///</summary>
        /// <returns>DataTable</returns>
        public void LoadCBBLoaiMon(ComboBox cbb)
        {
            try
            {
                for (int i = cbb.Items.Count - 1; i >= 0; i--)
                {
                    cbb.Items.RemoveAt(i);
                }
                cbb.Items.Add("Chọn loại món");

                List<DataRow> Loais = new List<DataRow>(LoadData().Select());
                var dc = (from p in Loais
                          select new
                          {
                              MaLoai = p["MALOAI"].ToString(),
                              TenLoai = p["TENLOAI"].ToString()
                          }).ToList();
                         
                foreach (var i in dc)
                {
                    cbb.Items.Add(i.MaLoai.Trim() + " - " + i.TenLoai.Trim());
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show("Lỗi load danh sách loại món", "Thông báo");
            }
        }

        ///<summary>
        /// Tạo mã loại món tự động tăng
        ///</summary>
        /// <returns>String</returns>
        public string TaoMaLoaiMon()
        {
            try
            {
                string strMaMoi = null;
                DataTable dt = LoadData();
                if (dt.Rows.Count > 0)
                {
                    int ma = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(1, 3));
                    int matang = ma + 1;
                    if (matang < 10)
                        strMaMoi = "L00" + matang;
                    else if (matang < 100)
                        strMaMoi = "L0" + matang;
                    else if (matang < 1000)
                        strMaMoi = "L" + matang;
                }
                else
                    strMaMoi = "L001";
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
