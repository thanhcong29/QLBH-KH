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

    public class NhaCungCapBLL
    {
        #region Constructor
        public NhaCungCapBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách nhà sản xuất
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable SearchData(int intSearchType, string strKeyWord)
        {
            try
            {
                NhaCungCapDAO objNguyenLieuDAO = new NhaCungCapDAO();
                return objNguyenLieuDAO.SearchData(intSearchType, strKeyWord);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public void LoadCCBNhaCungCap(ComboBox cbb)
        {
            for (int i = cbb.Items.Count - 1; i >= 0; i--)
            {
                cbb.Items.RemoveAt(i);
            }
            cbb.Items.Add("-- Chọn nhà cung cấp --");

            List<DataRow> NCCs = new List<DataRow>(SearchData(-1, "NULL").Select());
            var dc = from p in NCCs
                     select new 
                     { MA = p["MANHACUNGCAP"].ToString(),
                       TEN = p["TENNHACUNGCAP"].ToString() };
            foreach (var i in dc)
            {
                cbb.Items.Add(i.MA.Trim() + " - " + i.TEN);
            }
        }
        #endregion
    }
}
