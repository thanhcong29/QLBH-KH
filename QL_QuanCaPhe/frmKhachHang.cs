using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmKhachHang : Form
    {
        KhachHangBLL objKhachHangBLL = new KhachHangBLL();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private bool them = false;

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int intSearchType = -1;
            string strKeyWord = txtKeyWord.Text;
            int intTinhTrang = 0;
            if (cbbSearchType.Text == "Tất cả")
                intSearchType = -1;
            if (cbbSearchType.Text == "Mã khách hàng")
                intSearchType = 0;
            if (cbbSearchType.Text == "Tên khách hàng")
                intSearchType = 1;
            if (cbbSearchType.Text == "Số điện thoại")
                intSearchType = 2;
            if (cbbTKTinhTrang.Text == "Hoạt động")
                intTinhTrang = 0;
            if (cbbTKTinhTrang.Text == "Khóa")
                intTinhTrang = 1;
            if (cbbTKTinhTrang.Text == "Đã xóa")
                intTinhTrang = -1;

            dtgvDS.DataSource = objKhachHangBLL.SearchData(intSearchType, strKeyWord, intTinhTrang);
        }

        private void LoadData()
        {
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtSDT.ResetText();
            txtMatKhau.ResetText();
            txtDiemThuong.ResetText();
            txtEmail.ResetText();
            cbbTinhTrang.ResetText();

            txtMaKH.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            txtDiemThuong.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cbbTinhTrang.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;

            grClTimKiem.Enabled = true;
            grClDS.Enabled = true;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dtgvDS.CurrentRow.Cells[4].Value.ToString();
            txtDiemThuong.Text = dtgvDS.CurrentRow.Cells[5].Value.ToString();
            cbbTinhTrang.Text = dtgvDS.CurrentRow.Cells[6].Value.ToString();
            txtMatKhau.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMaKH.Text = objKhachHangBLL.TaoMaKhachHang();
            txtTenKH.ResetText();
            txtSDT.ResetText();
            txtMatKhau.ResetText();
            txtDiemThuong.Text = "0";
            txtEmail.ResetText();
            cbbTinhTrang.Text = "Hoạt động";

            txtMaKH.ReadOnly = true;
            txtTenKH.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtDiemThuong.ReadOnly = true;
            txtEmail.ReadOnly = false;
            cbbTinhTrang.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;

            grClTimKiem.Enabled = false;
            grClDS.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtMaKH.Text == "KH001")
            {
                MessageBox.Show("Bạn không thể sửa thông tin khách hàng này - Khách lẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            them = false;

            txtMaKH.ReadOnly = true;
            txtTenKH.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtDiemThuong.ReadOnly = true;
            txtEmail.ReadOnly = false;
            cbbTinhTrang.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;

            grClTimKiem.Enabled = false;
            grClDS.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMaKH.Text == "KH001")
            {
                MessageBox.Show("Bạn không thể xóa thông tin khách hàng này - Khách lẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa thông tin khách hàng này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(xoa == DialogResult.Yes)
            {
                if(objKhachHangBLL.Delete(txtMaKH.Text))
                {
                    MessageBox.Show("Xóa thành công thông tin khách hàng "+txtMaKH.Text + " - " +txtTenKH.Text, "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                    btnTimKiem_Click(null, null);
                }
                else
                    MessageBox.Show("Xóa thông tin khách hàng thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
        private bool ValiDateUpdate()
        {
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cho khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }
            else
            {
                return true;
            }    
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValiDateUpdate()) return;
                if (them)
                {
                    try
                    {
                        if (!objKhachHangBLL.KT_SDTKhachHang(txtMaKH.Text, txtSDT.Text)) return;
                        KhachHangBO objKhachHangBO = new KhachHangBO();
                        objKhachHangBO.MaKhachHang = txtMaKH.Text;
                        objKhachHangBO.TenKhachHang = txtTenKH.Text;
                        objKhachHangBO.SDT = txtSDT.Text;
                        objKhachHangBO.MatKhau = txtMatKhau.Text;
                        objKhachHangBO.Email = txtEmail.Text;
                        objKhachHangBO.DiemThuong = float.Parse(txtDiemThuong.Text);
                        if (cbbTinhTrang.Text == "Hoạt động")
                            objKhachHangBO.TinhTrang = 0;
                        if (cbbTinhTrang.Text == "Khóa")
                            objKhachHangBO.TinhTrang = 1;
                        if (objKhachHangBLL.Insert(objKhachHangBO))
                        {
                            MessageBox.Show("Thêm thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
                            LoadData();
                            btnTimKiem_Click(null, null);
                        }
                        else
                            MessageBox.Show("Thêm thông tin khách hàng thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi thêm thông tin khách hàng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        if (!objKhachHangBLL.KT_SDTKhachHang(txtMaKH.Text, txtSDT.Text)) return;
                        KhachHangBO objKhachHangBO = new KhachHangBO();
                        objKhachHangBO.MaKhachHang = txtMaKH.Text;
                        objKhachHangBO.TenKhachHang = txtTenKH.Text;
                        objKhachHangBO.SDT = txtSDT.Text;
                        objKhachHangBO.MatKhau = txtMatKhau.Text;
                        objKhachHangBO.Email = txtEmail.Text;
                        objKhachHangBO.DiemThuong = float.Parse(txtDiemThuong.Text);
                        if (cbbTinhTrang.Text == "Hoạt động")
                            objKhachHangBO.TinhTrang = 0;
                        if (cbbTinhTrang.Text == "Khóa")
                            objKhachHangBO.TinhTrang = 1;
                        if (objKhachHangBLL.Update(objKhachHangBO))
                        {
                            MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
                            LoadData();
                            btnTimKiem_Click(null, null);
                        }
                        else
                            MessageBox.Show("Cập nhật thông tin khách hàng thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi cập nhật thông tin khách hàng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                if(them)
                    MessageBox.Show("Lỗi thêm thông tin khách hàng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Lỗi cập nhật thông tin khách hàng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            List<int> lst = new List<int>(new int[] { 09, 03, 07, 08, 05 });
            if (string.IsNullOrEmpty(txtSDT.Text) || txtSDT.Text.Length != 10)
            {
                e.Cancel = true;
                txtSDT.Focus();
                errorProvider.SetError(txtSDT, "Vui lòng nhập số điện thoại gồm 10 số");
            }
            else if(!lst.Contains(Convert.ToInt32(txtSDT.Text.Substring(0, 2))))
            {
                e.Cancel = true;
                txtSDT.Focus();
                errorProvider.SetError(txtSDT, "Số điện thoại không đúng định dạng");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtSDT, null);
            }    
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(txtEmail.Text))
            {
                e.Cancel = true;
                txtSDT.Focus();
                errorProvider.SetError(txtEmail, "Email nhập vào không đúng định dạng");
            }    
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtEmail, null);
            }    
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if(txtSDT.Text.Length == 10 && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
