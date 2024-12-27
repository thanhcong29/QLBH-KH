using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmQuanLyBan_KhuVuc : DevExpress.XtraEditors.XtraForm
    {
        QL_BanBLL objBanBLL = new QL_BanBLL();
        KhuVucBLL objKhuVucBLL = new KhuVucBLL();
        public frmQuanLyBan_KhuVuc()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dtgvBan.DataSource = objBanBLL.SelectData();

            KhuVuc.DataSource = objKhuVucBLL.LoadData();
            KhuVuc.DisplayMember = "TENKHUVUC";
            KhuVuc.ValueMember = "MAKHUVUC";
        }
        private void Load_khuvuc(object sender, EventArgs e)
        {
            dtgvKhuVuc.DataSource = objKhuVucBLL.LoadData();
            txtMaKV.Enabled = false;
            btnLuuKV.Enabled = false;
            btnXoaKV.Enabled = false;
        }

        private void databinding()
        {
            try
            {
                txtMaBan.Text = dtgvBan.CurrentRow.Cells[0].Value.ToString();
                txtTenBan.Text = dtgvBan.CurrentRow.Cells[1].Value.ToString();
                txtSoCho.Text = dtgvBan.CurrentRow.Cells[2].Value.ToString();
                txtTrangThai.Text = dtgvBan.CurrentRow.Cells[3].Value.ToString();
                KhuVuc.Text = dtgvBan.CurrentRow.Cells[4].Value.ToString();
                btnXoa.Enabled = btnThem.Enabled = btnLuu.Enabled = true;
            }
            catch (Exception e)
            {

            }
        }

        private void frmQuanLyBan_KhuVuc_Load(object sender, EventArgs e)
        {
            LoadData();
            Load_khuvuc(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaBan.ResetText();
            txtTenBan.ResetText();
            txtTrangThai.ResetText();
            KhuVuc.ResetText();
            txtSoCho.ResetText();
            txtTenBan.Focus();

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaBan.Text == string.Empty)
                {
                    try
                    {
                        QL_BanBO objBanBO = new QL_BanBO();
                        objBanBO.TenBan = txtTenBan.Text.ToString().Trim();
                        objBanBO.SoChoNgoi = int.Parse(txtSoCho.Text.ToString().Trim());
                        objBanBO.TrangThai = txtTrangThai.Text.ToString().Trim();
                        objBanBO.MaKhuVuc = KhuVuc.SelectedValue.ToString().Trim();


                        if (objBanBLL.Insert(objBanBO))
                        {
                            MessageBox.Show("Thêm bàn thành công", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm bàn thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi thêm nhân viên", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        if (MessageBox.Show("Bạn Có Muốn Sửa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (txtMaBan.Text == string.Empty)
                            {
                                MessageBox.Show("Mời bạn click vào bảng");
                            }
                            else
                            {
                                QL_BanBO objBanBO = new QL_BanBO();
                                objBanBO.MaBan = int.Parse(txtMaBan.Text.ToString().Trim());//cái mã nó tự động vậy lúc thêm nó nhảy số xa quá biết rồi :))) Nhầm bên kia
                                objBanBO.TenBan = txtTenBan.Text.ToString().Trim();
                                objBanBO.SoChoNgoi = int.Parse(txtSoCho.Text.ToString().Trim());
                                objBanBO.TrangThai = txtTrangThai.Text.ToString().Trim();
                                objBanBO.MaKhuVuc = KhuVuc.SelectedValue.ToString().Trim(); /// Trời t kiếm hổm rài

                                if (objBanBLL.Update(objBanBO))
                                {
                                    MessageBox.Show("Sửa thông tin bàn thành công", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                                    LoadData();
                                }
                                else
                                {
                                    MessageBox.Show("Sửa bàn thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                }

                            }
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Sửa thông tin bàn thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        LoadData();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi rồi bạn ơi !!!", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaBan.Text == string.Empty)
                {
                    MessageBox.Show("Mời bạn chọn dữ liệu trong bảng");
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            objBanBLL.Delete(Convert.ToInt32(txtMaBan.Text));
                            MessageBox.Show("Xóa Thành Công");
                            LoadData();
                        }
                        catch
                        {
                            MessageBox.Show("Không thể xóa");
                        }
                    }
                }
            }
            catch { }
        }

        private void btnThemKV_Click(object sender, EventArgs e)
        {
            txtMaKV.Text = objKhuVucBLL.TaoMaKhuVuc();
            txtTenKV.ResetText();
            btnXoaKV.Enabled = false;
            btnThemKV.Enabled = false;
            btnLuuKV.Enabled = true;
        }

        private void btnLuuKV_Click(object sender, EventArgs e)
        {
            try
            {
                if (objKhuVucBLL.KTRAKHOACHINH(txtMaKV.Text))
                {
                    try
                    {
                        KhuVucBO objKhuVucBO = new KhuVucBO();
                        objKhuVucBO.MaKhuVuc = txtMaKV.Text.ToString().Trim();
                        objKhuVucBO.TenKhuVuc = txtTenKV.Text.ToString().Trim();

                        if (objKhuVucBLL.Insert(objKhuVucBO))
                        {
                            MessageBox.Show("Thêm khu vực thành công", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            Load_khuvuc(sender, e);
                            btnThemKV.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("Thêm khu vực thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi thêm khu vực", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {

                        if (MessageBox.Show("Bạn Có Muốn Sửa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (txtMaKV.Text == string.Empty)
                            {
                                MessageBox.Show("Mời bạn click vào bảng");
                            }
                            else
                            {
                                KhuVucBO objKhuVucBO = new KhuVucBO();
                                objKhuVucBO.TenKhuVuc = txtTenKV.Text.ToString().Trim();

                                if (objKhuVucBLL.Update(objKhuVucBO))
                                {
                                    MessageBox.Show("Sửa khu vực thành công", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                                    Load_khuvuc(sender, e);
                                    btnThemKV.Enabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Sửa khu vực thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                }

                            }
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Sửa thông tin bàn thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        LoadData();
                    }

                }
            }
            catch { }
        } 


        private void btnXoaKV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKV.Text == string.Empty)
                {
                    MessageBox.Show("Mời bạn chọn dữ liệu trong bảng");
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            objKhuVucBLL.Delete(txtMaKV.Text);
                            MessageBox.Show("Xóa Thành Công");
                            Load_khuvuc(sender, e);
                            btnThemKV.Enabled = true;
                        }
                        catch
                        {
                            MessageBox.Show("Không thể xóa");
                        }
                    }
                }
            }
            catch { }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void dtgvKhuVuc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaKV.Text = dtgvKhuVuc.CurrentRow.Cells[0].Value.ToString();
                txtTenKV.Text = dtgvKhuVuc.CurrentRow.Cells[1].Value.ToString();
                btnXoaKV.Enabled = true;
            }
            catch { }
        }

        private void dtgvBan_SelectionChanged(object sender, EventArgs e)
        {
        
        }

        private void dtgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            databinding();
        }
    }
}