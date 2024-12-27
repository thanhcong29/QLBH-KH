using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QL_QuanCaPhe
{
    public partial class frmQuanLyNhanVien : Form
    {
        NhanVienBLL objNhanVienBLL = new NhanVienBLL();

        bool them = false;
        string HinhAnh = null;
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dtgvDS.DataSource = objNhanVienBLL.SearchData(-1, "null");
            objNhanVienBLL.LoadDiaChi(cbbDiaChi);

            txtMaNV.Enabled = false;
            txtHoTen.Enabled = false;
            cbbGioiTinh.Enabled = false;
            cbbNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            cbbNgayVL.Enabled = false;
            txtLuongCB.Enabled = false;
            cbbChucVu.Enabled = false;

            // set display button
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXuatExcel.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;
            btnThemFile.Visible = false;

            dtgvDS.Enabled = true;
            groupControl_TK.Enabled = true;
            groupControl_Loc.Enabled = true;
        }
        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void cbbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbSearchType.SelectedItem.ToString() == "-- Tìm kiếm theo --")
            {
                dtgvDS.DataSource = objNhanVienBLL.SearchData(-1, "null");
            }
            if(cbbSearchType.SelectedItem.ToString() == "Mã nhân viên")
            {
                dtgvDS.DataSource = objNhanVienBLL.SearchData(0, txtKeyWord.Text);
            }
            if (cbbSearchType.SelectedItem.ToString() == "Tên nhân viên")
            {
                dtgvDS.DataSource = objNhanVienBLL.SearchData(1, txtKeyWord.Text);
            }
        }

        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            if (cbbSearchType.SelectedItem.ToString() == "-- Tìm kiếm theo --")
            {
                dtgvDS.DataSource = objNhanVienBLL.SearchData(-1, "null");
            }
            if (cbbSearchType.SelectedItem.ToString() == "Mã nhân viên")
            {
                dtgvDS.DataSource = objNhanVienBLL.SearchData(0, txtKeyWord.Text);
            }
            if (cbbSearchType.SelectedItem.ToString() == "Tên nhân viên")
            {
                dtgvDS.DataSource = objNhanVienBLL.SearchData(1, txtKeyWord.Text);
            }
        }

        private void dtgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            cbbGioiTinh.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
            cbbNgaySinh.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dtgvDS.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = dtgvDS.CurrentRow.Cells[5].Value.ToString();
            cbbNgayVL.Text = dtgvDS.CurrentRow.Cells[6].Value.ToString();
            txtLuongCB.Text = dtgvDS.CurrentRow.Cells[7].Value.ToString();
            cbbChucVu.Text = dtgvDS.CurrentRow.Cells[8].Value.ToString();
            string img = dtgvDS.CurrentRow.Cells[9].Value.ToString();
            try
            {
                string strHinhAnh = img;
                if (strHinhAnh != "")
                {
                    var request = WebRequest.Create(strHinhAnh);
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    imgHinhAnh.Image = Bitmap.FromStream(stream);
                }
                else
                {
                    imgHinhAnh.Image = global::QL_QuanCaPhe.Properties.Resources.pre_account;
                }
            }
            catch (Exception ex)
            {
                imgHinhAnh.Image = global::QL_QuanCaPhe.Properties.Resources.error_Image1;
            }

            // set display button
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnXuatExcel.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;
            btnThemFile.Enabled = true;
        }       
        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMaNV.Enabled = true;
            txtHoTen.Enabled = true;
            cbbGioiTinh.Enabled = true;
            cbbNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            cbbNgayVL.Enabled = true;
            txtLuongCB.Enabled = true;
            cbbChucVu.Enabled = true;

            txtMaNV.Text = objNhanVienBLL.TaoMaNhanVien();
            txtHoTen.Text = "";
            cbbGioiTinh.Text = "Chọn giới tính";
            cbbNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            cbbNgayVL.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtLuongCB.Text = "";
            cbbChucVu.Text = "Chọn chức vụ";

            // set display button
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnXuatExcel.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            btnThemFile.Visible = true;

            imgHinhAnh.Image = null;
            dtgvDS.Enabled = false;
            groupControl_TK.Enabled = false;
            groupControl_Loc.Enabled = false;
            
        }

        private void btnThemFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                HinhAnh = "http://kltnqlquancaphe.somee.com/HinhAnh/" + Path.GetFileName(open.FileName);
                upLoadFile(open.FileName);
            }
        }
        private void upLoadFile(string filename)
        {
            try
            {
                var client = new WebClient();
                var uri = new Uri("http://kltnqlquancaphe.somee.com/Home.aspx");
                {
                    client.Headers.Add("fileName", System.IO.Path.GetFileName(filename));
                    client.UploadFileAsync(uri, filename);
                    MessageBox.Show("Tải hình ảnh thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hình ảnh" + ex.Message);
            }
        }
        private bool ValiDate()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            if (cbbGioiTinh.Text == "Chọn giới tính")
            {
                MessageBox.Show("Vui lòng chọn giới tính nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbGioiTinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng nhập ngày sinh nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbNgaySinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLuongCB.Text))
            {
                MessageBox.Show("Vui lòng nhập lương cơ bản của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuongCB.Focus();
                return false;
            }
            if (cbbChucVu.Text == "Chọn chức vụ")
            {
                MessageBox.Show("Vui lòng chọn chức vụ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbChucVu.Focus();
                return false;
            }
            else
                return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = DateTime.Now;
                DateTime dateNS = DateTime.Parse(cbbNgaySinh.Text.ToString().Trim());
                if (date.Year - dateNS.Year < 18)
                {
                    MessageBox.Show("Nhân viên chưa đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbNgaySinh.Focus();
                    return;
                }
                if (!ValiDate()) return;
                if(them)
                {
                    try
                    {
                        NhanVienBO objNhanVienBO = new NhanVienBO();
                        objNhanVienBO.MaNhanVien = txtMaNV.Text.ToString().Trim();
                        objNhanVienBO.HoTen = txtHoTen.Text.ToString().Trim();
                        objNhanVienBO.GioiTinh = cbbGioiTinh.Text.ToString().Trim();
                        objNhanVienBO.NgaySinh = DateTime.Parse(cbbNgaySinh.Text.ToString().Trim());
                        objNhanVienBO.DiaChi = txtDiaChi.Text.ToString().Trim();
                        objNhanVienBO.SDT = txtSDT.Text.ToString().Trim();
                        objNhanVienBO.NgayVaoLam = DateTime.Parse(cbbNgayVL.Text.ToString().Trim());
                        objNhanVienBO.LuongCoBan = int.Parse(txtLuongCB.Text.ToString().Trim());
                        objNhanVienBO.ChucVu = cbbChucVu.Text.ToString().Trim();                     
                        objNhanVienBO.HinhAnh = HinhAnh != null ? HinhAnh : "NULL";
                        if (objNhanVienBLL.Insert(objNhanVienBO))
                        {
                            MessageBox.Show("Thêm thông tin nhân viên thành công", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm nhân viên thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
                        NhanVienBO objNhanVienBO = new NhanVienBO();
                        objNhanVienBO.MaNhanVien = txtMaNV.Text.ToString().Trim();
                        objNhanVienBO.HoTen = txtHoTen.Text.ToString().Trim();
                        objNhanVienBO.GioiTinh = cbbGioiTinh.Text.ToString().Trim();
                        objNhanVienBO.NgaySinh = DateTime.Parse(cbbNgaySinh.Text.ToString().Trim());
                        objNhanVienBO.DiaChi = txtDiaChi.Text.ToString().Trim();
                        objNhanVienBO.SDT = txtSDT.Text.ToString().Trim();
                        objNhanVienBO.NgayVaoLam = DateTime.Parse(cbbNgayVL.Text.ToString().Trim());
                        objNhanVienBO.LuongCoBan = int.Parse(txtLuongCB.Text.ToString().Trim());
                        objNhanVienBO.ChucVu = cbbChucVu.Text.ToString().Trim();
                        objNhanVienBO.HinhAnh = HinhAnh != null ? HinhAnh : "NULL";
                        if (objNhanVienBLL.Update(objNhanVienBO))
                        {
                            MessageBox.Show("Sửa thông tin nhân viên thành công", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            LoadData();
                        }    
                    }
                    catch
                    {
                        MessageBox.Show("Sửa thông tin nhân viên thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        LoadData();
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
            them = false;

            txtMaNV.Enabled = false;
            txtHoTen.Enabled = true;
            cbbGioiTinh.Enabled = true;
            cbbNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            cbbNgayVL.Enabled = true;
            txtLuongCB.Enabled = true;
            cbbChucVu.Enabled = true;

            btnLuu.Enabled = true;
            btnThemFile.Visible = true;

            dtgvDS.Enabled = false;
            groupControl_TK.Enabled = false;
            groupControl_Loc.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa nhân viên " + txtMaNV.Text + " - " + txtHoTen.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(xoa == DialogResult.Yes)
            {
                if(objNhanVienBLL.Delete(txtMaNV.Text))
                {
                    MessageBox.Show("Bạn xóa thành công nhân viên  " + txtMaNV.Text + " - " + txtHoTen.Text, "Thông Báo");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            else
            {
                MessageBox.Show("Bạn đã hủy thao tác xóa nhân viên", "Thông Báo");
            }    
        }

        private void cbbLocGT_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvDS.DataSource = objNhanVienBLL.LocNhanVien(cbbLocGT.Text, cbbDiaChi.Text);
        }

        private void cbbDiaChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvDS.DataSource = objNhanVienBLL.LocNhanVien(cbbLocGT.Text, cbbDiaChi.Text);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
            cbbLocGT.Text = "Tất Cả";
            cbbDiaChi.Text = "Tất Cả";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
            cbbLocGT.Text = "Tất Cả";
            cbbDiaChi.Text = "Tất Cả";
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
            else if (!lst.Contains(Convert.ToInt32(txtSDT.Text.Substring(0, 2))))
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

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (txtSDT.Text.Length == 10 && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtLuongCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtLuongCB_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("MANHANVIEN");
                dataTable.Columns.Add("HOTEN");
                dataTable.Columns.Add("GIOITINH");
                dataTable.Columns.Add("NGAYSINH");
                dataTable.Columns.Add("SDT");
                dataTable.Columns.Add("DIACHI");
                dataTable.Columns.Add("NGAYVAOLAM");
                dataTable.Columns.Add("LUONGCOBAN");
                dataTable.Columns.Add("CHUCVU");

                foreach (DataGridViewRow item in dtgvDS.Rows)
                {
                    DataRow dr = dataTable.NewRow();
                    dr["MANHANVIEN"] = item.Cells[0].Value;
                    dr["HOTEN"] = item.Cells[1].Value;
                    dr["GIOITINH"] = item.Cells[2].Value;
                    dr["NGAYSINH"] = item.Cells[3].Value.ToString().Substring(0,10);
                    dr["SDT"] = item.Cells[5].Value;
                    dr["DIACHI"] = item.Cells[4].Value;
                    dr["NGAYVAOLAM"] = item.Cells[6].Value.ToString().Substring(0, 10);
                    dr["LUONGCOBAN"] = item.Cells[7].Value;
                    dr["CHUCVU"] = item.Cells[8].Value;
                    dataTable.Rows.Add(dr);
                }

                ExportFile(dataTable, "", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất excel !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            

            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = "DS Nhan Vien";

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "I1");

            head.MergeCells = true;

            head.Value2 = "Danh Sách Nhân Viên";

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range name = oSheet.get_Range("A2", "I2");

            name.MergeCells = true;

            name.Value2 = "Quán cà phê THE COFFEE";

            name.Font.Bold = true;

            name.Font.Name = "Times New Roman";

            name.Font.Size = "13";

            name.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range dc = oSheet.get_Range("A3", "I3");

            dc.MergeCells = true;

            dc.Value2 = "ĐC: 140 Lê Trọng Tấn, Tây Thạnh Tân Phú, TP.HCM";

            dc.Font.Bold = true;

            dc.Font.Name = "Times New Roman";

            dc.Font.Size = "13";

            dc.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range dt = oSheet.get_Range("A4", "I4");

            dt.MergeCells = true;

            dt.Value2 = "ĐT: 0392419643";

            dt.Font.Bold = true;

            dt.Font.Name = "Times New Roman";

            dt.Font.Size = "13";

            dt.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A5", "A5");

            cl1.Value2 = "Mã Nhân Viên";

            cl1.ColumnWidth = 13;

            cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B5", "B5");

            cl2.Value2 = "Họ Tên";

            cl2.ColumnWidth = 25.0;            

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("C5", "C5");

            cl4.Value2 = "Ngày Sinh";
            cl4.ColumnWidth = 12.0;
            cl4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("D5", "D5");

            cl3.Value2 = "Giới Tính";

            cl3.ColumnWidth = 10.5;

            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E5", "E5");

            cl5.Value2 = "SĐT";

            cl5.ColumnWidth = 15;
            cl5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F5", "F5");

            cl6.Value2 = "Địa Chỉ";

            cl6.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G5", "G5");

            cl7.Value2 = "Ngày VL";

            cl7.ColumnWidth = 15;
            cl7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H5", "H5");

            cl8.Value2 = "Lương CB";

            cl8.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I5", "I5");

            cl9.Value2 = "Chức Vụ";

            cl9.ColumnWidth = 13.5;
            cl9.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A5", "I5");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 6;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // cột dầu tiên

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            //Căn giữa cột mã nhân viên

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            //oSheet.get_Range(c1, col1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
    }
}
