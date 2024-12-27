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
    public partial class frmQuanLyNguyenLieu : Form
    {
        NguyenLieuBLL objNguyenLieuBLL = new NguyenLieuBLL();
        NhaCungCapBLL objNhaCungCapBLL = new NhaCungCapBLL();
        ThucDonBLL objThucDonBLL = new ThucDonBLL();
        CongThucBLL objCongThucBLL = new CongThucBLL();
        ChiTietThucDonBLL objChiTietThucDonBLL = new ChiTietThucDonBLL();

        public string UserName { get; set; }
        public frmQuanLyNguyenLieu()
        {
            InitializeComponent();
        }

        private bool them = false;
        private bool themCT = false;
        private string MaMon = "";
        private string MaNguyenLieu = "";
        private string MaCTMon = "";
        private void LoadData()
        {
            dtgvDSNL.DataSource = objNguyenLieuBLL.SearchData("0");
            dtgvDSMon.DataSource = objThucDonBLL.SearchData(-1, "NULL");
            cbbNCC.Properties.DataSource = objNhaCungCapBLL.SearchData(-1, "null");
            cbbNCC.Properties.DisplayMember = "TENNHACUNGCAP";
            cbbNCC.Properties.ValueMember = "MANHACUNGCAP";

            txtMa.ReadOnly = true;
            txtTen.ReadOnly = true;
            txtSL.ReadOnly = true;
            txtDVT.ReadOnly = true;
            cbbNCC.ReadOnly = true;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;

            btnDatNL.Enabled = true;
            btnNhapNL.Enabled = true;
            btnTTNCC.Enabled = true;

            txtCTTenMon.ReadOnly = true;
            cbbNL.ReadOnly = true;
            txtCTHL.ReadOnly = true;
            txtSize.Enabled = false;

            btnCTThem.Enabled = false;
            btnCTSua.Enabled = false;
            btnCTXoa.Enabled = false;
            btnCTLuu.Enabled = false;
            btnCTReload.Enabled = true;
            btnCTHuy.Enabled = false;


        }
        private void frmQuanLyNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvDSNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dtgvDSNL.CurrentRow.Cells[0].Value.ToString() ;
            txtTen.Text = dtgvDSNL.CurrentRow.Cells[1].Value.ToString();
            txtSL.Text = dtgvDSNL.CurrentRow.Cells[2].Value.ToString();
            txtDVT.Text = dtgvDSNL.CurrentRow.Cells[3].Value.ToString();
            cbbNCC.Text = dtgvDSNL.CurrentRow.Cells[4].Value.ToString();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;

            btnDatNL.Enabled = true;
            btnNhapNL.Enabled = true;
            btnTTNCC.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMa.ReadOnly = true;
            txtTen.ReadOnly = false;
            txtSL.ReadOnly = false;
            txtDVT.ReadOnly = false;
            cbbNCC.ReadOnly = false;

            txtMa.ResetText();
            txtTen.ResetText();
            txtSL.ResetText();
            txtDVT.ResetText();

            cbbNCC.Properties.NullText = "Chọn Nhà Cung Cấp";
            cbbNCC.Text = "Chọn Nhà Cung Cấp";

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = false;
            btnHuy.Enabled = true;

            btnDatNL.Enabled = true;
            btnNhapNL.Enabled = true;
            btnTTNCC.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;

            txtMa.ReadOnly = true;
            txtTen.ReadOnly = false;
            txtSL.ReadOnly = false;
            txtDVT.ReadOnly = false;
            cbbNCC.ReadOnly = false;

            string ncc = cbbNCC.Properties.NullText;
            cbbNCC.Properties.NullText = ncc;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = false;
            btnHuy.Enabled = true;

            btnDatNL.Enabled = true;
            btnNhapNL.Enabled = true;
            btnTTNCC.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa " + txtTen.Text + " không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(xoa == DialogResult.Yes)
            {
                if(objNguyenLieuBLL.Delete(txtMa.Text))
                {
                    MessageBox.Show("Xóa thông tin nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }   
                else
                {
                    MessageBox.Show("Xóa thông tin nguyên liệu thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }    
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NguyenLieuBO objNguyenLieuBO = new NguyenLieuBO();
            objNguyenLieuBO.TenNguyenLieu = txtTen.Text.Trim();
            objNguyenLieuBO.SoLuong = Convert.ToDecimal(txtSL.Text);
            objNguyenLieuBO.DVT = txtDVT.Text;
            objNguyenLieuBO.MaNhaCungCap = Convert.ToInt32(cbbNCC.EditValue.ToString());

            if(them)
            {
                try
                {
                    if(objNguyenLieuBLL.Insert(objNguyenLieuBO))
                    {
                        MessageBox.Show("Thêm thông tin nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }  
                    else
                    {
                        MessageBox.Show("Thêm thông tin nguyên liệu thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }
                catch
                {
                    MessageBox.Show("Lỗi thêm nguyên liệu !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
            else
            {
                try
                {
                    objNguyenLieuBO.MaNguyenLieu = Convert.ToInt32(txtMa.Text);
                    if(objNguyenLieuBLL.Update(objNguyenLieuBO))
                    {
                        MessageBox.Show("Cập nhật thông tin nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin nguyên liệu thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi sửa nguyên liệu !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvDSMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MaMon = dtgvDSMon.CurrentRow.Cells[0].Value.ToString();
            dtgvCT.DataSource = objCongThucBLL.SearchData(MaMon);

            foreach (DataGridViewRow item in dtgvCT.Rows)
            {
                if(item.Cells[7].Value.ToString() == "1")
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
            txtCTTenMon.Text = dtgvDSMon.CurrentRow.Cells[1].Value.ToString();
            txtSize.ResetText();
            cbbNL.Properties.NullText = "";
            txtCTHL.ResetText();

            btnCTThem.Enabled = true;
            btnCTSua.Enabled = false;
            btnCTXoa.Enabled = false;
            btnCTLuu.Enabled = false;
            btnCTReload.Enabled = true;
            btnCTHuy.Enabled = false;
        }

        private void dtgvCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvCT.CurrentRow.Cells[7].Value.ToString() == "1")
                MessageBox.Show("Nguyên liệu này đã bị xóa, không thể thay đổi công thức !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MaMon = dtgvCT.CurrentRow.Cells[0].Value.ToString();
                txtCTTenMon.Text = dtgvCT.CurrentRow.Cells[1].Value.ToString();
                txtSize.Text = dtgvCT.CurrentRow.Cells[2].Value.ToString();
                MaNguyenLieu = dtgvCT.CurrentRow.Cells[3].Value.ToString();
                MaCTMon = dtgvCT.CurrentRow.Cells[5].Value.ToString();
                cbbNL.Properties.NullText = dtgvCT.CurrentRow.Cells[4].Value.ToString();
                txtCTHL.Text = dtgvCT.CurrentRow.Cells[6].Value.ToString();

                btnCTThem.Enabled = true;
                btnCTSua.Enabled = true;
                btnCTXoa.Enabled = true;
                btnCTLuu.Enabled = false;
                btnCTReload.Enabled = true;
                btnCTHuy.Enabled = false;
            }
        }

        private void btnCTThem_Click(object sender, EventArgs e)
        {
            themCT = true;

            txtCTTenMon.ReadOnly = true;
            cbbNL.ReadOnly = false;
            txtCTHL.ReadOnly = false;
            txtSize.Enabled = true;

            cbbNL.ResetText();
            txtCTHL.ResetText();

            cbbNL.Properties.NullText = "Chọn Nguyên Liệu";
            cbbNL.Properties.DataSource = objNguyenLieuBLL.SearchData("0");
            cbbNL.Properties.DisplayMember = "TENNGUYENLIEU";
            cbbNL.Properties.ValueMember = "MANGUYENLIEU";

            objChiTietThucDonBLL.LoadCbbSize(txtSize, MaMon);
            txtSize.Text = "Chọn Size";


            btnCTThem.Enabled = false;
            btnCTSua.Enabled = false;
            btnCTXoa.Enabled = false;
            btnCTLuu.Enabled = true;
            btnCTReload.Enabled = false;
            btnCTHuy.Enabled = true;
        }

        private void btnCTSua_Click(object sender, EventArgs e)
        {
            themCT = false;

            txtCTHL.ReadOnly = false;

            btnCTThem.Enabled = false;
            btnCTSua.Enabled = false;
            btnCTXoa.Enabled = false;
            btnCTLuu.Enabled = true;
            btnCTReload.Enabled = false;
            btnCTHuy.Enabled = true;
        }
        
        private void btnCTXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có chắc muốn xóa công thức này","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if(xoa == DialogResult.Yes)
                {
                    CongThucBO objCongThucBO = new CongThucBO();
                    objCongThucBO.MaCTMon = MaCTMon;
                    objCongThucBO.MaNguyenLieu = Convert.ToInt32(MaNguyenLieu);
                    if (objCongThucBLL.Delete(objCongThucBO))
                    {
                        MessageBox.Show("Xóa thông tin công thức thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                        dtgvCT.DataSource = objCongThucBLL.SearchData(MaMon);
                        foreach (DataGridViewRow item in dtgvCT.Rows)
                        {
                            if (item.Cells[7].Value.ToString() == "1")
                                item.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }    
                    else
                    {
                        MessageBox.Show("Xóa thông tin công thức thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }    
            }
        }

        private void btnCTLuu_Click(object sender, EventArgs e)
        {
            CongThucBO objCongThucBO = new CongThucBO();
            objCongThucBO.MaCTMon = MaCTMon;
            objCongThucBO.HamLuong = float.Parse(txtCTHL.Text);
            if(themCT)
            {
                try
                {
                    objCongThucBO.MaNguyenLieu = Convert.ToInt32(cbbNL.EditValue.ToString());
                    if (objCongThucBLL.Insert(objCongThucBO))
                    {
                        MessageBox.Show("Thêm thông tin công thức thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                        dtgvCT.DataSource = objCongThucBLL.SearchData(MaMon);
                        foreach (DataGridViewRow item in dtgvCT.Rows)
                        {
                            if (item.Cells[7].Value.ToString() == "1")
                                item.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }    
                    else
                    {
                        MessageBox.Show("Thêm thông tin công thức thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }
                catch
                {
                    MessageBox.Show("Lỗi thêm công thức !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
            else
            {
                try
                {
                    objCongThucBO.MaNguyenLieu = Convert.ToInt32(MaNguyenLieu);
                    if (objCongThucBLL.Update(objCongThucBO))
                    {
                        MessageBox.Show("Cập nhật thông tin công thức thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                        dtgvCT.DataSource = objCongThucBLL.SearchData(MaMon);
                        foreach (DataGridViewRow item in dtgvCT.Rows)
                        {
                            if (item.Cells[7].Value.ToString() == "1")
                                item.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin công thức thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi thêm công thức !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private void btnDatNL_Click(object sender, EventArgs e)
        {
            frmDatNguyenLieu frm = new frmDatNguyenLieu();
            frm.UserName = UserName;
            frm.ShowDialog();
        }

        private void btnNhapNL_Click(object sender, EventArgs e)
        {
            frmNhapNguyenLieu frm = new frmNhapNguyenLieu();
            frm.UserName = UserName;
            frm.ShowDialog();
        }

        private void btnTTNCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap();
            frm.ShowDialog();
        }
    }
}
