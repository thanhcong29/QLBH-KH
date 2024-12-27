using DevExpress.XtraReports.UI;
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
    public partial class frmNhapNguyenLieu : Form
    {
        PhieuNhapBLL objPhieuNhapBLL = new PhieuNhapBLL();     
        PhieuDatBLL objPhieuDatBLL = new PhieuDatBLL();
        ChiTietPhieuNhapBLL objChiTietPhieuNhapBLL = new ChiTietPhieuNhapBLL();
        ChiTietPhieuDatBLL objChiTietPhieuDatBLL = new ChiTietPhieuDatBLL();

        public frmNhapNguyenLieu()
        {
            InitializeComponent();
        }
        public string MaNV { get; set; }
        public string UserName { get; set; }

        private bool load = true;
        private bool them = false;
        private bool sua = false;
        private string MaPhieuNhap;
        private int Gia;
        private int MaNL;
        private int MaNCC;
        private DataTable table = null;

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!ValiDateSearch()) return;
            int intSearchType = -1;
            string strKeyWord = txtKeyWord.Text.Trim();
            DateTime TuNgay = dtTuNgay.DateTime.Date;
            DateTime ToiNgay = dtToiNgay.DateTime;
            if (cbbSearchType.Text == "-- Tìm theo --") //-- Tìm theo -- Mã phiếu đặt Nội dung nhập
                intSearchType = -1;
            if (cbbSearchType.Text == "Mã phiếu nhập") //-- Tìm theo -- Mã phiếu đặt Nội dung nhập
                intSearchType = 0;
            if (cbbSearchType.Text == "Nội dung nhập") //-- Tìm theo -- Mã phiếu đặt Nội dung nhập
                intSearchType = 1;          
            dtgvDS.DataSource = objPhieuNhapBLL.Search(intSearchType, strKeyWord, TuNgay, ToiNgay);
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        private bool ValiDateSearch()
        {
            if (!string.IsNullOrEmpty(dtTuNgay.Text) && !string.IsNullOrEmpty(dtToiNgay.Text))
            {
                DateTime fromDay = Convert.ToDateTime(dtTuNgay.Text);
                DateTime toDay = Convert.ToDateTime(dtToiNgay.Text);
                TimeSpan Time = toDay - fromDay;
                int TongSoNgay = Time.Days;
                if (TongSoNgay < 0)
                {
                    MessageBox.Show("Ngày đến phải lớn hơn ngày bắt đầu tìm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
                }
                else if (TongSoNgay > 30)
                {
                    MessageBox.Show("Thời gian cần tìm phải trong khoảng 30 ngày !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        private void frmNhapNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            load = true;
            them = false;
            sua = false;
            tabControl1.SelectedTab = tabPage1;
            pannelNL.Visible = false;

            dtTuNgay.Text = DateTime.Now.ToString("d");
            dtToiNgay.Text = DateTime.Now.ToString("d");

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            dtgvDSNhap.Enabled = true;
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPage2 && load)
                e.Cancel = true;
            if (e.TabPage == tabPage1 && !load)
                e.Cancel = true;
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MaPhieuNhap = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void dtgvDS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            load = false;
            them = false;
            tabControl1.SelectedTab = tabPage2;
            txtMaPhieuNhap.Text = MaPhieuNhap;
            cbbPhieuDat.Properties.NullText = dtgvDS.CurrentRow.Cells[4].Value.ToString();
            txtNgayLap.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
            txtNoiDung.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            txtNguoiLap.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString();

            cbbPhieuDat.Enabled = false;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnThemNL.Enabled = false;
            btnSuaNL.Enabled = false;
            btnXoaNL.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            dtgvDSNhap.DataSource = objChiTietPhieuNhapBLL.Load(txtMaPhieuNhap.Text);
            table = objChiTietPhieuNhapBLL.Load(txtMaPhieuNhap.Text);
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if(them)
            {
                if (cbbPhieuDat.Text != "-- Chọn Phiếu Đặt --")
                {
                    cbbNguyenLieu.Properties.DataSource = objChiTietPhieuDatBLL.LoadCBBNguyenLieuNhap(cbbPhieuDat.EditValue.ToString());
                    pannelNL.Visible = true;
                    btnThemNL.Enabled = false;
                    btnSuaNhap.Enabled = false;
                }
                else
                    MessageBox.Show("Bạn chưa chọn phiếu đặt !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            
            
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (dtgvDSNhap.Rows.Count > 0)
            {
                MessageBox.Show("Xóa thành công nguyên liệu " + dtgvDSNhap.CurrentRow.Cells[1].Value.ToString(), "Thông báo", MessageBoxButtons.OK);
                dtgvDSNhap.Rows.RemoveAt(dtgvDSNhap.CurrentRow.Index);
            }    
                
            CheckData();
        }
        private void CheckData()
        {
            btnXoaNL.Enabled = false;
            btnSuaNL.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValiDateInsert()) return;
            if(!KTTrungNL())
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    if (them)
                        dataTable = table;
                    else
                        dataTable = (DataTable)dtgvDSNhap.DataSource;
                    DataRow newRow = dataTable.NewRow();
                    newRow[0] = cbbNguyenLieu.EditValue;
                    newRow[1] = cbbNguyenLieu.Text;
                    newRow[2] = txtSoLuong.Text;
                    newRow[3] = txtMaPhieuNhap.Text;
                    dataTable.Rows.Add(newRow);

                    dtgvDSNhap.DataSource = dataTable;
                    MessageBox.Show("Đã thêm thành công nguyên liệu vào phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cbbPhieuDat.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm nguyên liệu vào phiếu đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
            else
            {
                MessageBox.Show("Nguyên liệu này đã có trong phiếu nhập, hãy kiểm tra lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
            cbbPhieuDat.Properties.DataSource = null;
            cbbPhieuDat.Enabled = true;
            XoaChiTietPhieuKhiHuy();
        }
        private void XoaChiTietPhieuKhiHuy()
        {
            try
            {
                for (int i = dtgvDSNhap.RowCount -1 ; i >= 0; i--)
                {
                    dtgvDSNhap.Rows.Remove(dtgvDSNhap.Rows[i]);
                }
                txtNoiDung.ResetText();
            }
            catch(Exception ex)
            {
                return;
            }
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            load = false;
            them = true;
            tabControl1.SelectedTab = tabPage2;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnIn.Enabled = false;

            btnThemNL.Enabled = true;
            btnXoaNL.Enabled = false;
            btnSuaNL.Enabled = false;
            cbbPhieuDat.Focus();

            cbbPhieuDat.Properties.DataSource = objPhieuDatBLL.LoadPhieuDatKhiNhap();
            cbbPhieuDat.Properties.DisplayMember = "MAPHIEUDAT";
            cbbPhieuDat.Properties.ValueMember = "MAPHIEUDAT";
            cbbPhieuDat.Properties.NullText = "-- Chọn Phiếu Đặt --";
            txtMaPhieuNhap.Text = objPhieuNhapBLL.TaoMaTuTang();
            txtNgayLap.Text = DateTime.Now.ToString("G");
            txtNguoiLap.Text = UserName;

            table = objChiTietPhieuNhapBLL.Load(txtMaPhieuNhap.Text);
        }
        private bool ValiDateUpdate()
        {
            DateTime ngayLap = Convert.ToDateTime(txtNgayLap.Text);
            DateTime datenow = Convert.ToDateTime(DateTime.Now);
            TimeSpan Time = datenow - ngayLap;
            int TongSoNgay = Time.Hours;
            if (TongSoNgay > 1)
            {
                MessageBox.Show("Đã qua thời gian chỉnh sửa đơn nhập hàng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }           
            else
            {
                return true;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            load = false;
            them = false;
            tabControl1.SelectedTab = tabPage2;
            txtMaPhieuNhap.Text = MaPhieuNhap;
            cbbPhieuDat.Properties.NullText = dtgvDS.CurrentRow.Cells[4].Value.ToString();
            txtNgayLap.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
            txtNoiDung.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            txtNguoiLap.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString();

            cbbPhieuDat.Enabled = false;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnThemNL.Enabled = false;
            btnSuaNL.Enabled = false;
            btnXoaNL.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            dtgvDSNhap.DataSource = objChiTietPhieuNhapBLL.Load(txtMaPhieuNhap.Text);
            table = objChiTietPhieuNhapBLL.Load(txtMaPhieuNhap.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(them)
            {
                try
                {
                    PhieuNhapBO objPhieuNhapBO = new PhieuNhapBO();
                    objPhieuNhapBO.MaPhieuDat = cbbPhieuDat.Text;
                    objPhieuNhapBO.MaPhieuNhap = txtMaPhieuNhap.Text;
                    objPhieuNhapBO.NoiDung = txtNoiDung.Text;
                    objPhieuNhapBO.NgayLap = DateTime.Now;
                    string[] arrListStr = txtNguoiLap.Text.Split('-');
                    objPhieuNhapBO.MaNhanVien = "NV001" /*arrListStr[0].Trim()*/;
                    List<ChiTietPhieuNhapBO> chiTietPhieuNhapBOs = new List<ChiTietPhieuNhapBO>();

                    foreach (DataGridViewRow dtgvRow in dtgvDSNhap.Rows)
                    {
                        ChiTietPhieuNhapBO objChiTietPhieuNhapBO = new ChiTietPhieuNhapBO();
                        objChiTietPhieuNhapBO.MaNguyenLieu = Convert.ToInt32(dtgvRow.Cells[0].Value.ToString());
                        objChiTietPhieuNhapBO.MaPhieuNhap = objPhieuNhapBO.MaPhieuNhap;
                        objChiTietPhieuNhapBO.SoLuong = float.Parse(dtgvRow.Cells[2].Value.ToString());

                        chiTietPhieuNhapBOs.Add(objChiTietPhieuNhapBO);
                    }
                    objPhieuNhapBO.lstChiTietPhieuNhapBOs = chiTietPhieuNhapBOs;
                    if (objPhieuNhapBO.lstChiTietPhieuNhapBOs.Count == 0)
                    {
                        MessageBox.Show("Không thể lưu phiếu nhập không có nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (objPhieuNhapBLL.Insert(objPhieuNhapBO))
                    {
                        MessageBox.Show("Lưu thông tin phiếu nhập nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                        btnTimKiem_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Lưu thông tin phiếu nhập nguyên liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu thông tin phiếu nhập nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
            else
            {
                try
                {
                    if (!ValiDateUpdate())
                        return;
                    PhieuNhapBO objPhieuNhapBO = new PhieuNhapBO();
                    objPhieuNhapBO.MaPhieuDat = cbbPhieuDat.Text;
                    objPhieuNhapBO.MaPhieuNhap = txtMaPhieuNhap.Text;
                    objPhieuNhapBO.NoiDung = txtNoiDung.Text;
                    objPhieuNhapBO.NgayLap = Convert.ToDateTime(txtNgayLap.Text);
                    string[] arrListStr = txtNguoiLap.Text.Split('-');
                    objPhieuNhapBO.MaNhanVien = arrListStr[0].Trim();

                    if (objPhieuNhapBLL.Update(objPhieuNhapBO))
                    {
                        MessageBox.Show("Lưu thông tin phiếu nhập nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                        btnTimKiem_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Lưu thông tin phiếu nhập nguyên liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu thông tin phiếu nhập nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void cbbPhieuDat_TextChanged(object sender, EventArgs e)
        {
            if (cbbPhieuDat.Text != "-- Chọn Phiếu Đặt --")
            {
                cbbNguyenLieu.Properties.DataSource = objChiTietPhieuDatBLL.LoadCBBNguyenLieuNhap(cbbPhieuDat.EditValue.ToString());
                cbbNguyenLieu.Properties.DisplayMember = "TENNGUYENLIEU";
                cbbNguyenLieu.Properties.ValueMember = "MANGUYENLIEU"/* + " - " + "SOLUONG" + " - "+ "SLNHAP"*/;
                
            }
            else
                cbbNguyenLieu.Properties.DataSource = null;
        }

        private decimal SoLuongNhapToiDa()
        {
            try
            {
                if (them)
                {
                    DataTable dt = objChiTietPhieuDatBLL.LoadCBBNguyenLieuNhap(cbbPhieuDat.EditValue.ToString());
                    // Tìm kiếm nguyên liệu trong dt
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["MANGUYENLIEU"] };
                    DataRow dr = dt.Rows.Find(cbbNguyenLieu.EditValue.ToString());
                    // tính số lượng nguyên liệu
                    decimal soluongdat = Convert.ToDecimal(dr["SOLUONG"].ToString());
                    decimal soluongnhap = Convert.ToDecimal(dr["SLNHAP"].ToString());
                    return (soluongdat - soluongnhap);
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
            
        }

        private void cbbNguyenLieu_EditValueChanged(object sender, EventArgs e)
        {
             MaNL = Convert.ToInt32(cbbNguyenLieu.EditValue.ToString());
            txtSoLuong.Text = SoLuongNhapToiDa().ToString();
        }
        private bool ValiDateInsert()
        {
            if(SoLuongNhapToiDa() < Convert.ToDecimal(txtSoLuong.Text))
            {
                MessageBox.Show("Số lượng nhập không được lớn hơn số lượng đặt còn lại của nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool KTTrungNL()
        {
            foreach (DataGridViewRow dr in dtgvDSNhap.Rows)
            {
                if (Convert.ToInt32(dr.Cells[0].Value.ToString()) == MaNL)
                {
                    return true;
                }
            }
            return false;
        }

        private void dtgvDSNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbNguyenLieu.Text = dtgvDSNhap.CurrentRow.Cells[0].Value.ToString();
            txtSoLuong.Text = dtgvDSNhap.CurrentRow.Cells[2].Value.ToString();
            if(pannelNL.Visible == true)
            {
                btnSuaNL.Enabled = false;
                btnSuaNhap.Enabled = true;
            }    
            else
            {
                btnSuaNL.Enabled = true;
            }    
                
            btnXoaNL.Enabled = true;
            
        }

        private void btnSuaNhap_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dtgvDSNhap.Rows)
            {
                if (Convert.ToInt32(dgr.Cells[0].Value.ToString().Trim()) == MaNL)
                {
                    dgr.Cells[2].Value = Convert.ToInt32(txtSoLuong.Text);
                }
            }
            MessageBox.Show("Đã cập nhật số lượng nguyên liệu " + cbbNguyenLieu.Text + " thành " + txtSoLuong.Text, "Thông báo");
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            RPPhieuNhap rp = new RPPhieuNhap();
            rp.DataSource = objPhieuNhapBLL.LayRPPHIEUNHAP(txtMaPhieuNhap.Text);
            rp.ShowPreview();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
