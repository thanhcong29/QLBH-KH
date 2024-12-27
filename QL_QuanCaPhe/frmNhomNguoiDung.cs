using QL_QuanCaPhe.BLL.PhanQuyen;
using QL_QuanCaPhe.BO.PhanQuyen;
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
    public partial class frmNhomNguoiDung : Form
    {
        NhomNguoiDungBLL objNhomNguoiDungBLL = new NhomNguoiDungBLL();
        public frmNhomNguoiDung()
        {
            InitializeComponent();
        }
        private bool them = false;
        private void frmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dtgvDS.DataSource = objNhomNguoiDungBLL.LoadData();

            txtMaNhom.ReadOnly = true;
            txtTenNhom.ReadOnly = true;
            txtGhiChu.ReadOnly = true;

            txtMaNhom.ResetText();
            txtTenNhom.ResetText();
            txtGhiChu.ResetText();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;
            btnThemNguoiDungVaoNhom.Enabled = false;
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhom.Text = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            txtTenNhom.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;
            btnThemNguoiDungVaoNhom.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMaNhom.ReadOnly = false;
            txtTenNhom.ReadOnly = false;
            txtGhiChu.ReadOnly = false;

            txtMaNhom.ResetText();
            txtTenNhom.ResetText();
            txtGhiChu.ResetText();
            txtMaNhom.Focus();

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            btnThemNguoiDungVaoNhom.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;

            txtMaNhom.ReadOnly = true;
            txtTenNhom.ReadOnly = false;
            txtGhiChu.ReadOnly = false;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            btnThemNguoiDungVaoNhom.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNhom.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhóm người dùng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhom.Focus();
            }
            else if (txtTenNhom.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhóm người dùng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhom.Focus();
            }
            else
            {
                NhomNguoiDungBO objNhomNguoiDungBO = new NhomNguoiDungBO();
                objNhomNguoiDungBO.MaNhom = txtMaNhom.Text.Trim();
                objNhomNguoiDungBO.TenNhom = txtTenNhom.Text.Trim();
                objNhomNguoiDungBO.GhiChu = txtGhiChu.Text.Trim();
                if (them)
                {
                    try
                    {
                        if (objNhomNguoiDungBLL.KiemTraMaNhomNguoiDung(txtMaNhom.Text))
                        {
                            MessageBox.Show("Mã nhóm người dùng đã tồn tại, hãy tạo mã mới !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (objNhomNguoiDungBLL.Insert(objNhomNguoiDungBO))
                            {
                                MessageBox.Show("Thêm mới nhóm người dùng thành công", "Thông báo", MessageBoxButtons.OK);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Thêm mới nhóm người dùng thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi thêm mới nhóm người dùng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        if (objNhomNguoiDungBLL.Update(objNhomNguoiDungBO))
                        {
                            MessageBox.Show("Cập nhật thông tin nhóm người dùng thành công", "Thông báo", MessageBoxButtons.OK);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi cập nhật thông tin nhóm người dùng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }    
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi cập nhật thông tin nhóm người dùng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }    
                
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult xoa = MessageBox.Show("Bạn có chắc muốn xóa nhóm người dùng này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xoa == DialogResult.Yes)
                {
                    if (objNhomNguoiDungBLL.Delete(txtMaNhom.Text))
                    {
                        MessageBox.Show("Xóa thông tin nhóm người dùng thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhóm người dùng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xóa nhóm người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemNguoiDungVaoNhom_Click(object sender, EventArgs e)
        {
            // Lấy mã nhóm người dùng hiện tại
            string maNhom = txtMaNhom.Text;

            // Mở form frmNguoiDungNhomNguoiDung và truyền mã nhóm qua
            frmNguoiDungNhomNguoiDung frm = new frmNguoiDungNhomNguoiDung(maNhom);
            frm.ShowDialog();
        }


    }
}
