using QL_QuanCaPhe.BLL.PhanQuyen;
using QL_QuanCaPhe.BO;
using QL_QuanCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BLL
{


    public class PhanQuyenBLL
    {
        public static SqlConnection con = ConnectDB.cnn;

        ManHinhBLL objManHinhBLL = new ManHinhBLL();

        #region Constructor
        public PhanQuyenBLL()
        {
        }
        #endregion
        #region Methods

        ///<summary>
        /// Lấy danh sách phân quyền
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable LoadData()
        {
            try
            {
                PhanQuyenDAO objPhanQuyenDAO = new PhanQuyenDAO();
                return objPhanQuyenDAO.LoadData();
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        ///<summary>
        /// Lấy danh sách màn hình
        ///</summary>
        /// <returns>DataTable</returns>
        public DataTable GetMaManHinh(string pMaNhom)
        {
            List<DataRow> PhanQuyens = new List<DataRow>(LoadData().Select());
            var quen = (from a in PhanQuyens
                        where (a["MANHOM"].ToString().Trim() == pMaNhom)
                        select new
                        {
                            MaNhom = a["MANHOM"].ToString().Trim(),
                            MaManHinh = a["MAMANHINH"].ToString().Trim(),
                            CoQuyen = Convert.ToBoolean(a["COQUYEN"].ToString().Trim())
                        }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhóm");
            dt.Columns.Add("Mã Màn Hình");
            dt.Columns.Add("CoQuyen");
            foreach (var TD in quen)
            {
                dt.Rows.Add(TD.MaNhom.Trim(), TD.MaManHinh.Trim(), TD.CoQuyen);
            }
            return dt;
        }

        ///<summary>
        /// Lấy danh sách phân quyền theo nhóm
        ///</summary>
        /// <returns>DataTable</returns>

        public DataTable LayDanhSachPhanQuyen(string pMaNhom)
        {
            List<DataRow> ManHinhs = new List<DataRow>(objManHinhBLL.LoadData().Select());
            List<DataRow> PhanQuyens = new List<DataRow>(LoadData().Select());
            var quyen = (from p in ManHinhs
                         join q in PhanQuyens on p["MAMANHINH"].ToString().Trim() equals q["MAMANHINH"].ToString().Trim()
                         where (q["MANHOM"].ToString().Trim() == pMaNhom)
                         select new
                         {
                             MaManHinh = p["MAMANHINH"].ToString().Trim(),
                             TenManHinh = p["TENMANHINH"].ToString().Trim(),
                             CoQuyen = Convert.ToBoolean(q["COQUYEN"].ToString().Trim())
                         }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaManHinh");
            dt.Columns.Add("TenManHinh");
            dt.Columns.Add("CoQuyen");
            foreach (var TD in quyen)
            {
                dt.Rows.Add(TD.MaManHinh.Trim(), TD.TenManHinh.Trim(), TD.CoQuyen);
            }
            return dt;
        }

        ///<summary>
        /// Lưu phân quyền
        ///</summary>
        /// <returns>DataTable</returns>
        public bool LuuPhanQuyen(PhanQuyenBO objPhanQuyenBO)
        {
            try
            {

                PhanQuyenDAO objPhanQuyenDAO = new PhanQuyenDAO();
                if (objPhanQuyenDAO.Update(objPhanQuyenBO))
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        #endregion
    }
}
