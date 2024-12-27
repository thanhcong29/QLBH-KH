using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BLL.PhanQuyen;
using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmPhanQuyen : Form
    {
        NhomNguoiDungBLL objNhomNguoiDungBLL = new NhomNguoiDungBLL();
        PhanQuyenBLL objPhanQuyenBLL = new PhanQuyenBLL();

        public string MaNhom { get; set; }
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTable dt = objNhomNguoiDungBLL.LoadData();
            dtgvDS.DataSource = dt;
        }
        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MaNhom = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            dtgvQuyen.DataSource = objPhanQuyenBLL.LayDanhSachPhanQuyen(MaNhom);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                PhanQuyenBO objPhanQuyenBO = new PhanQuyenBO();
                objPhanQuyenBO.MaNhom = MaNhom;
                objPhanQuyenBO.MaManHinh = dtgvQuyen.CurrentRow.Cells[0].Value.ToString();
                objPhanQuyenBO.CoQuyen = Convert.ToBoolean(dtgvQuyen.CurrentRow.Cells[2].Value.ToString());
                foreach (DataGridViewRow item in dtgvQuyen.Rows)
                {
                    try
                    {
                        if (objPhanQuyenBLL.LuuPhanQuyen(objPhanQuyenBO))
                        {
                            //MessageBox.Show("Lưu thành công", "Thông báo");
                            objPhanQuyenBLL.LayDanhSachPhanQuyen(MaNhom);
                        }
                        else
                            //MessageBox.Show("Lưu thất bại", "Thông báo");
                            objPhanQuyenBLL.LayDanhSachPhanQuyen(MaNhom); 
                    }
                    catch
                    {
                        //MessageBox.Show("Lưu thất bại", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Lưu thất bại", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }
    }
}
