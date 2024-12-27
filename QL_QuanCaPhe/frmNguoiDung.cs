using QL_QuanCaPhe.BLL;
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
    public partial class frmNguoiDung : Form
    {
        NguoiDungBLL objNguoiDungBLL = new NguoiDungBLL();
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        bool them = false;
        private void LoadData()
        {
            dtgvDS.DataSource = objNguoiDungBLL.Search("NULL", -1);

            txtMaNV.Enabled = false;
            cbbHoTen.Enabled = false;
            txtTenDN.Enabled = false;
            txtMatKhau.Enabled = false;
            cbbTrangThai.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;

            dtgvDS.Enabled = true;
        }
        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            cbbHoTen.Properties.NullText = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            txtTenDN.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
            txtMatKhau.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString();
            cbbTrangThai.Text = dtgvDS.CurrentRow.Cells[4].Value.ToString();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMaNV.Enabled = true;
            cbbHoTen.Enabled = true;
            txtTenDN.Enabled = true;
            txtMatKhau.Enabled = true;
            cbbTrangThai.Enabled = true;

            txtMaNV.ResetText();
            cbbHoTen.Properties.NullText = "Chọn Nhân Viên";
            txtTenDN.ResetText();
            txtMatKhau.ResetText();
            cbbTrangThai.Text = "Chọn Trạng Thái";

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;

            dtgvDS.Enabled = false;

            cbbHoTen.Focus();

            cbbHoTen.Properties.DataSource = objNguoiDungBLL.LoadNhanVienChuCoTaiKhoan();
            cbbHoTen.Properties.DisplayMember = "HOTEN";
            cbbHoTen.Properties.ValueMember = "MANHANVIEN";

        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = cbbHoTen.EditValue.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiDungBO objNguoiDungBO = new NguoiDungBO();
                
                objNguoiDungBO.TenDangNhap = txtTenDN.Text.Trim();
                objNguoiDungBO.MatKhau = txtMatKhau.Text.Trim();
                objNguoiDungBO.TrangThai = cbbTrangThai.Text.Trim();
                objNguoiDungBO.MaNhanVien = txtMaNV.Text.Trim();

                if (them)
                {
                    if(objNguoiDungBLL.Insert(objNguoiDungBO))
                    {
                        MessageBox.Show("Bạn đã thêm thành công tài khoản  " + txtTenDN.Text + " từ nhân viên " + txtMaNV.Text, "Thông Báo");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi thêm tài khoản nhân viên !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }
                else
                {
                    if(objNguoiDungBLL.Update(objNguoiDungBO))
                    {
                        MessageBox.Show("Cập nhật tài khoản người dùng thành công", "Thông Báo");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi sửa tài khoản nhân viên !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }    
            }
            catch
            {
                MessageBox.Show("Lỗi rồi bạn ơi !!!", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            cbbHoTen.Enabled = false;
            txtTenDN.Enabled = false;
            txtMatKhau.Enabled = true;
            cbbTrangThai.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;

            dtgvDS.Enabled = false;

            txtMatKhau.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa tài khoản " + txtTenDN.Text + " ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if(xoa == DialogResult.Yes)
            {
                if(objNguoiDungBLL.Delete(txtTenDN.Text))
                {
                    MessageBox.Show("Bạn đã xóa thành công tài khoản " + txtTenDN.Text, "Thông báo");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản người dùng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        
    }
}
