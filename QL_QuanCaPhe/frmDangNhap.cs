using DevExpress.XtraEditors;
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
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        NguoiDungBLL objNguoiDungBLL = new NguoiDungBLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateLogin()) return;
            try
            {
                string strTenDangNhap = txtTaiKhoan.Text.Trim();
                string strMatKhau = txtMatKhau.Text.Trim();
                DataTable dt = objNguoiDungBLL.LoadData(strTenDangNhap, strMatKhau);
                if(dt.Rows.Count > 0 && dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if(dr["TRANGTHAI"].ToString().Trim() == "Hoạt động")
                        {
                            frmHome frmHome = new frmHome();
                            frmHome.TenDangNhap = dr["TENDANGNHAP"].ToString().Trim();
                            frmHome.MaNhanVien = dr["MANHANVIEN"].ToString().Trim();
                            frmHome.TenNhanVien = dr["HOTEN"].ToString().Trim();
                            frmHome.Quyen = dr["CHUCVU"].ToString().Trim();
                            frmHome.ShowDialog();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản đã bị khóa. Vui lòng liên hệ quản lý để hỗ trợ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }    
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                }                        
            }
            catch
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult huy = MessageBox.Show("Bạn có chắc muốn hủy đăng nhập", "Thông báo", MessageBoxButtons.YesNo);
            if(huy == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Focus();
                MessageBox.Show("Vui lòng nhập tài khoản người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                txtMatKhau.Focus();
                MessageBox.Show("Vui lòng nhập mật khẩu người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }    
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
        public void SetTaiKhoan(string taiKhoan)
        {
            txtTaiKhoan.Text = taiKhoan;
        }

        public void SetMatKhau(string matKhau)
        {
            txtMatKhau.Text = matKhau;
        }
    }
}