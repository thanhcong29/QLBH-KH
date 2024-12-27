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
    public partial class frmDatNguyenLieu : Form
    {
        PhieuDatBLL objPhieuDatBLL = new PhieuDatBLL();
        NhaCungCapBLL objNhaCungCapBLL = new NhaCungCapBLL();
        NguyenLieuBLL objNguyenLieuBLL = new NguyenLieuBLL();
        ChiTietPhieuDatBLL objChiTietPhieuDatBLL = new ChiTietPhieuDatBLL();
        public string MaNV { get; set; }
        public string UserName { get; set; }
        public frmDatNguyenLieu()
        {
            InitializeComponent();
        }

        private bool load = true;
        private bool them = false;
        private bool sua = false;
        private string MaPhieuDat;
        private int Gia;
        private int MaNL;
        private int MaNCC;
        private DataTable table = null;
        private void LoadData()
        {
            load = true;
            them = false;
            sua = false;
            tabControl1.SelectedTab = tabPage1;
            pannelNL.Visible = false;

            dtTuNgay.Text = DateTime.Now.ToString("d");
            dtToiNgay.Text = DateTime.Now.ToString("d");
            cbbNCC.Properties.DataSource = objNhaCungCapBLL.SearchData(-1, "NULL");
            cbbNCC.Properties.DisplayMember = "TENNHACUNGCAP";
            cbbNCC.Properties.ValueMember = "MANHACUNGCAP";
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            dtgvDSNhap.Enabled = true;
        }
        private void frmDatNguyenLieu_Load(object sender, EventArgs e)
        {
            //tabControl1.Controls.Remove(tabPage2);
            LoadData();

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPage2 && load)
                e.Cancel = true;
            if (e.TabPage == tabPage1 && !load)
                e.Cancel = true;
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
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pannelNL.Visible = true;
            btnThemNL.Enabled = false;
            btnXoaNL.Enabled = false;
            btnSuaNL.Enabled = false;

            btnThemNhap.Enabled = true;
            btnSuaNhap.Enabled = false;
            btnXoaNhap.Enabled = false;
            btnHuyNhap.Enabled = true;
            cbbNguyenLieu.EditValue = null;
            cbbNguyenLieu.Properties.NullText = "";
            txtSoLuong.ResetText();
            txtGiaDat.ResetText();
            dtgvDSNhap.Enabled = false;
            cbbNguyenLieu.Enabled = true;
            if (dtgvDSNhap.Rows.Count < 1)
                objNhaCungCapBLL.LoadCCBNhaCungCap(cbbNCCNhap);
            else
            {
                cbbNCCNhap.Text = dtgvDSNhap.Rows[0].Cells[5].Value.ToString();
            }
        }
        private bool ValiDateSearch()
        {
            if(!string.IsNullOrEmpty(dtTuNgay.Text) && !string.IsNullOrEmpty(dtToiNgay.Text))
            {
                DateTime fromDay = Convert.ToDateTime(dtTuNgay.Text);
                DateTime toDay = Convert.ToDateTime(dtToiNgay.Text);
                TimeSpan Time = toDay - fromDay;
                int TongSoNgay = Time.Days;
                if (TongSoNgay < 0)
                {
                    MessageBox.Show("Ngày đến phải lớn hơn ngày bắt đầu tìm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
                }    
                else if(TongSoNgay > 30)
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValiDateSearch()) return;
            int intSearchType = -1;
            string strKeyWord = txtKeyWord.Text.Trim();
            DateTime TuNgay = dtTuNgay.DateTime.Date;
            DateTime ToiNgay = dtToiNgay.DateTime;
            if (cbbSearchType.Text == "-- Tìm theo --") //-- Tìm theo -- Mã phiếu đặt Nội dung đặt
                intSearchType = -1;
            if (cbbSearchType.Text == "Mã phiếu đặt") //-- Tìm theo -- Mã phiếu đặt Nội dung đặt
                intSearchType = 0;
            if (cbbSearchType.Text == "Nội dung đặt") //-- Tìm theo -- Mã phiếu đặt Nội dung đặt
                intSearchType = 1;
            int NCC = cbbNCC.EditValue == null ? 0 : Convert.ToInt32(cbbNCC.EditValue);
            dtgvDS.DataSource = objPhieuDatBLL.Search(intSearchType, strKeyWord, TuNgay, ToiNgay, NCC);
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void dtgvDS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            load = false;
            them = false;
            tabControl1.SelectedTab = tabPage2;
            dtgvDSNhap.DataSource = objChiTietPhieuDatBLL.Load(txtMaPhieuDat.Text);
            table = objChiTietPhieuDatBLL.Load(txtMaPhieuDat.Text);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;

                btnSuaNL.Enabled = false;
                btnXoaNL.Enabled = false;
                btnThemNL.Enabled = true;
                cbbNCCNhap.Items.Clear();
                cbbNCCNhap.Text = "-- Chọn nhà cung cấp --";
                //cbbNguyenLieu.ResetText();
                txtSoLuong.ResetText();
                txtGiaDat.ResetText();

                if (txtMaPhieuDat.Text == "") // texbox Mã Phiếu không có giá trị hiểu là thêm mới => không thể xóa hoặc In
                {
                    btnXoa.Enabled = true;
                    btnIn.Enabled = false;
                }
                else
                {
                    btnXoa.Enabled = true;
                    btnIn.Enabled = true;
                }
                if (!them)
                {
                    MaPhieuDat = dtgvDS.CurrentRow.Cells[0].Value.ToString();
                    txtMaPhieuDat.Text = dtgvDS.CurrentRow.Cells[0].Value.ToString();
                    txtNgayLap.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
                    txtNguoiLap.Text = dtgvDS.CurrentRow.Cells[5].Value.ToString() + " - " + dtgvDS.CurrentRow.Cells[6].Value.ToString();
                    txtNoiDung.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
                    txtTongTien.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString();
                    MaNV = dtgvDS.CurrentRow.Cells[5].Value.ToString();
                    table = objChiTietPhieuDatBLL.Load(MaPhieuDat);
                    btnIn.Enabled = true;
                }
                else
                {
                    txtNgayLap.Text = DateTime.Now.ToString("G");
                    MaPhieuDat = objPhieuDatBLL.TaoMaTuTang();
                    txtMaPhieuDat.Text = MaPhieuDat;
                    table = objChiTietPhieuDatBLL.Load(MaPhieuDat);
                    txtNguoiLap.Text = UserName;
                }
            }
            else
            {
                txtMaPhieuDat.ResetText();
                txtNgayLap.ResetText();
                txtNguoiLap.ResetText();
                txtNoiDung.ResetText();
                txtTongTien.ResetText();
                cbbNCCNhap.Enabled = true;
            }
        }

        private void cbbNCCNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbbNCCNhap.Text == "-- Chọn nhà cung cấp --")
            //    cbbNCCNhap.Enabled = true;
            //else
            //    cbbNCCNhap.Enabled = false;
            if (cbbNCCNhap.Text != "-- Chọn nhà cung cấp")
            {
                string[] arrListStr = cbbNCCNhap.Text.Split('-');
                MaNCC = Convert.ToInt32(arrListStr[0].Trim());
                cbbNguyenLieu.Properties.DataSource = objNguyenLieuBLL.LoadNguyenLieuTheoNCC(MaNCC);
                cbbNguyenLieu.Properties.DisplayMember = "Ten";
                cbbNguyenLieu.Properties.ValueMember = "Ma";
            }
        }
        private void ToExcel(DataGridView dataGridView1, string fileName, string resultMessage)
        {
            ////khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Sheets oSheets;
            //Microsoft.Office.Interop.Excel.Workbook workbook;
            //Microsoft.Office.Interop.Excel.Worksheet worksheet;
            ////Tạo đối tượng COM.
            //excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Visible = false;
            //excel.DisplayAlerts = false;
            //excel.Application.SheetsInNewWorkbook = 1;
            //workbook = (Microsoft.Office.Interop.Excel.Workbook)(excel.Workbooks.Add(Type.Missing));
            //try
            //{
            //    //tạo mới một Workbooks bằng phương thức add()

            //    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
            //    //đặt tên cho sheet
            //    worksheet.Name = "Danh sách nguyên liệu nhập";
            //    Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("A1", "H1");

            //    head.Font.Bold = true;

            //    head.Font.Name = "Times New Roman";

            //    head.Font.Size = "13";
            //    // export header trong DataGridView
            //    for (int i = 0; i < dataGridView1.ColumnCount; i++)
            //    {
            //        worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            //    }
            //    // export nội dung trong DataGridView
            //    for (int i = 0; i < dataGridView1.RowCount; i++)
            //    {
            //        for (int j = 0; j < dataGridView1.ColumnCount; j++)
            //        {
            //            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //    // sử dụng phương thức SaveAs() để lưu workbook với filename
            //    workbook.SaveAs(fileName);

            //    MessageBox.Show(resultMessage);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    //đóng workbook
            //    workbook.Close();
            //    excel.Quit();
            //    workbook = null;
            //    worksheet = null;
            //}
        }

        private void btnExcelMau_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "MauDanhSachNguyenLieuNhap" + DateTime.Now.ToString("ddMMyyyyhms");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dtgvDSNhap, saveFileDialog.FileName, "Xuất file Excel mẫu thành công");
            }
        }

        private void btnThemNhap_Click(object sender, EventArgs e)
        {
            MaNL = Convert.ToInt32(cbbNguyenLieu.EditValue);
            //if (them)
            //{
            if (!KTTrungNL())
            {
                Gia = Convert.ToInt32(txtGiaDat.Text);
                int ThanhTien = Gia * Convert.ToInt32(txtSoLuong.Text);
                try
                {
                    DataTable dataTable = new DataTable();
                    if(them)
                        dataTable = table;
                    else
                        dataTable = (DataTable)dtgvDSNhap.DataSource;
                    DataRow newRow = dataTable.NewRow();
                    newRow[0] = cbbNguyenLieu.EditValue;
                    newRow[1] = cbbNguyenLieu.Text;
                    newRow[2] = txtSoLuong.Text;
                    newRow[3] = Gia;
                    newRow[4] = ThanhTien;
                    newRow[5] = cbbNCCNhap.Text;

                    dataTable.Rows.Add(newRow);

                    dtgvDSNhap.DataSource = dataTable;

                    TinhTongTien();
                    MessageBox.Show("Đã thêm thành công nguyên liệu vào phiếu đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    cbbNguyenLieu.ResetText();
                    cbbNguyenLieu.Properties.NullText = "-- Chọn nguyên liệu --";
                    txtSoLuong.ResetText();
                    txtGiaDat.ResetText();
                    cbbNCCNhap.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm nguyên liệu vào phiếu đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nguyên liệu này đãn có trong phiếu đặt, hãy kiểm tra lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //}
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
        private void TinhTongTien()
        {
            int TongTien = 0;
            foreach (DataGridViewRow dr in dtgvDSNhap.Rows)
            {
                TongTien += Convert.ToInt32(dr.Cells[4].Value.ToString());
            }
            txtTongTien.Text = TongTien.ToString();
        }

        private void dtgvDSNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbNCCNhap.Text = dtgvDSNhap.CurrentRow.Cells[5].Value.ToString();
            MaNL = Convert.ToInt32(dtgvDSNhap.CurrentRow.Cells[0].Value.ToString());
            //cbbNguyenLieu.Text = dtgvDSNhap.CurrentRow.Cells[1].Value.ToString();
            cbbNguyenLieu.Properties.NullText = dtgvDSNhap.CurrentRow.Cells[1].Value.ToString();
            txtSoLuong.Text = dtgvDSNhap.CurrentRow.Cells[2].Value.ToString();
            txtGiaDat.Text = dtgvDSNhap.CurrentRow.Cells[3].Value.ToString();

            cbbNCCNhap.Enabled = false;
            cbbNguyenLieu.Enabled = false;

            btnThemNhap.Enabled = false;
            btnSuaNhap.Enabled = true;
            btnXoaNhap.Enabled = true;
            btnSuaNL.Enabled = true;
            btnXoaNL.Enabled = true;
            if (sua)
            {
                btnXoaNL.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    PhieuDatBO objPhieuDatBO = new PhieuDatBO();
                    objPhieuDatBO.MaPhieuDat = txtMaPhieuDat.Text;
                    objPhieuDatBO.TenPhieuDat = txtNoiDung.Text;
                    objPhieuDatBO.NgayLap = DateTime.Now;
                    objPhieuDatBO.TongTien = Convert.ToInt32(txtTongTien.Text);
                    string[] arrListStr = txtNguoiLap.Text.Split('-');
                    objPhieuDatBO.MaNhanVien = arrListStr[0].Trim();
                    List<ChiTietPhieuDatBO> chiTietPhieuDatBOs = new List<ChiTietPhieuDatBO>();

                    foreach (DataGridViewRow dtgvRow in dtgvDSNhap.Rows)
                    {
                        ChiTietPhieuDatBO objChiTietPhieuDatBO = new ChiTietPhieuDatBO();
                        objChiTietPhieuDatBO.MaNguyenLieu = Convert.ToInt32(dtgvRow.Cells[0].Value.ToString());
                        objChiTietPhieuDatBO.MaPhieuDat = objPhieuDatBO.MaPhieuDat;
                        objChiTietPhieuDatBO.SoLuong = float.Parse(dtgvRow.Cells[2].Value.ToString());
                        objChiTietPhieuDatBO.GiaDat = Convert.ToInt32(dtgvRow.Cells[3].Value.ToString());

                        chiTietPhieuDatBOs.Add(objChiTietPhieuDatBO);
                    }
                    objPhieuDatBO.lstChiTietPhieuDatBOs = chiTietPhieuDatBOs;
                    if(objPhieuDatBO.lstChiTietPhieuDatBOs.Count == 0)
                    {
                        MessageBox.Show("Không thể lưu phiếu đặt không có nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }    
                    if (objPhieuDatBLL.Insert(objPhieuDatBO))
                    {
                        MessageBox.Show("Lưu thông tin phiếu đặt nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                        button1_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Lưu thông tin phiếu đặt nguyên liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi lưu thông tin phiếu đặt nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    PhieuDatBO objPhieuDatBO = new PhieuDatBO();
                    objPhieuDatBO.MaPhieuDat = txtMaPhieuDat.Text;
                    objPhieuDatBO.TenPhieuDat = txtNoiDung.Text;
                    objPhieuDatBO.NgayLap = DateTime.Now;
                    objPhieuDatBO.TongTien = Convert.ToInt32(txtTongTien.Text);
                    objPhieuDatBO.MaNhanVien = txtNguoiLap.Text;
                    List<ChiTietPhieuDatBO> chiTietPhieuDatBOs = new List<ChiTietPhieuDatBO>();
                    foreach (DataGridViewRow dtgvRow in dtgvDSNhap.Rows)
                    {
                        ChiTietPhieuDatBO objChiTietPhieuDatBO = new ChiTietPhieuDatBO();
                        objChiTietPhieuDatBO.MaNguyenLieu = Convert.ToInt32(dtgvRow.Cells[0].Value.ToString());
                        objChiTietPhieuDatBO.MaPhieuDat = objPhieuDatBO.MaPhieuDat;
                        objChiTietPhieuDatBO.SoLuong = float.Parse(dtgvRow.Cells[2].Value.ToString());
                        objChiTietPhieuDatBO.GiaDat = Convert.ToInt32(dtgvRow.Cells[3].Value.ToString());

                        chiTietPhieuDatBOs.Add(objChiTietPhieuDatBO);
                    }
                    objPhieuDatBO.lstChiTietPhieuDatBOs = chiTietPhieuDatBOs;
                    if (objPhieuDatBO.lstChiTietPhieuDatBOs.Count == 0)
                    {
                        MessageBox.Show("Không thể lưu phiếu đặt không có nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    foreach (DataRow dr in table.Rows)
                    {
                        ChiTietPhieuDatBO objChiTietPhieuDatBO = new ChiTietPhieuDatBO();
                        objChiTietPhieuDatBO.MaNguyenLieu = Convert.ToInt32(dr[0].ToString());
                        objChiTietPhieuDatBO.MaPhieuDat = objPhieuDatBO.MaPhieuDat;
                        objChiTietPhieuDatBLL.Delete(objChiTietPhieuDatBO);
                    }

                    if (objPhieuDatBLL.Update(objPhieuDatBO))
                    {
                        MessageBox.Show("Lưu thông tin phiếu đặt nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                        button1_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Lưu thông tin phiếu đặt nguyên liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi lưu thông tin phiếu đặt nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSuaNL.Enabled = true;
            btnXoaNL.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            sua = true;
            pannelNL.Visible = true;
            btnThemNL.Enabled = false;
            btnXoaNL.Enabled = false;
            btnXoaNhap.Enabled = false;
        }

        private void CheckData()
        {
            btnXoaNL.Enabled = false;
            btnSuaNL.Enabled = false;
        }
        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (dtgvDSNhap.Rows.Count > 0)
                dtgvDSNhap.Rows.RemoveAt(dtgvDSNhap.CurrentRow.Index);
            CheckData();
        }

        private void btnXoaNhap_Click(object sender, EventArgs e)
        {
            if (dtgvDSNhap.Rows.Count > 0)
                dtgvDSNhap.Rows.RemoveAt(dtgvDSNhap.CurrentRow.Index);
            CheckData();
        }

        private void btnSuaNhap_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dtgvDSNhap.Rows)
            {
                if (Convert.ToInt32(dgr.Cells[0].Value.ToString().Trim()) == MaNL)
                {
                    dgr.Cells[2].Value = Convert.ToInt32(txtSoLuong.Text);
                    dgr.Cells[3].Value = Convert.ToInt32(txtGiaDat.Text);
                    dgr.Cells[4].Value = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32(txtGiaDat.Text);
                }
            }
            TinhTongTien();
            MessageBox.Show("Đã cập nhật số lượng nguyên liệu " + cbbNguyenLieu.Text + " thành " + txtSoLuong.Text + " giá đặt " + txtGiaDat.Text, "Thông báo");
        }

        private void cbbNCCNhap_TextChanged(object sender, EventArgs e)
        {
            if (cbbNCCNhap.Text != "-- Chọn nhà cung cấp --")
            {
                string[] arrListStr = cbbNCCNhap.Text.Split('-');
                MaNCC = Convert.ToInt32(arrListStr[0].Trim());
                cbbNguyenLieu.Properties.DataSource = objNguyenLieuBLL.LoadNguyenLieuTheoNCC(MaNCC);
                cbbNguyenLieu.Properties.DisplayMember = "Ten";
                cbbNguyenLieu.Properties.ValueMember = "Ma";
            }
        }

        private void btnHuyNhap_Click(object sender, EventArgs e)
        {
            sua = false;
            pannelNL.Visible = false;
            btnThemNL.Enabled = true;
            dtgvDSNhap.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string strMaPhieu = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa phiếu đặt " + strMaPhieu + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(xoa == DialogResult.Yes)
            {
                if (objPhieuDatBLL.Delete(strMaPhieu))
                {
                    MessageBox.Show("Xóa thông tin phiếu đặt nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                    button1_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Xóa thông tin phiếu đặt nguyên liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            XtraReport1 rp = new XtraReport1();
            rp.DataSource = objPhieuDatBLL.LayRPPHIEUDAT(txtMaPhieuDat.Text);
            rp.ShowPreview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
