using QL_QuanCaPhe.BLL;
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
    public partial class frmNguoiDungNhomNguoiDung : Form
    {
        NguoiDungBLL objNguoiDungBLL = new NguoiDungBLL();
        public frmNguoiDungNhomNguoiDung(string maNhom)
        {
            InitializeComponent();
        }

        private void frmNguoiDungNhomNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dtgvDS.DataSource = objNguoiDungBLL.Search("NULL", -1);

            txtMaNhom.Enabled = false;
            txtTenNhom.Enabled = false;
            txtMaNV.Enabled = false;
            cbbHoTen.Enabled = false;
            txtTenDN.Enabled = false;
            cbbTrangThai.Enabled = false;
            txtGhiChu.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;

            dtgvDS.Enabled = true;
        }
    }
}
