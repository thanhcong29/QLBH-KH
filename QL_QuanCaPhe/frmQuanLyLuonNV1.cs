using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace QL_QuanCaPhe
{
    public partial class frmQuanLyLuonNV1 : Form
    {
        LuongNV_BLL1 luongBLL = new LuongNV_BLL1();
        public frmQuanLyLuonNV1()
        {
            InitializeComponent();
        }
        public string TenNhanVien { get; set; }


        private void frmQuanLyLuonNV1_Load(object sender, EventArgs e)
        {
            Load_LuongNV();
            Load_LuongQL();
            // panel3.Visible = false;
            txtNgayCongThucTe.Enabled = false;


            btnLuuBLNV.Enabled = btnXoaBLNV.Enabled = false;
            btnLuuCTBLNV.Enabled = btnXoaCTBLNV.Enabled = false;
            btnThemCTBLNV.Enabled = false;
            btnLuuLuongQL.Enabled = btnXoaLuongQL.Enabled = false;
            btnThemCTLuongQL.Enabled = btnLuuCTLuongQL.Enabled = btnXoaCTLuongQL.Enabled = false;
        }
        public string UserName { get; set; }

        public void ExportFile(DataTable dataTable, string sheetName, string title)
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

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("A2", "C2");

            cl6.Value2 = "COFFEE ACE";

            cl6.MergeCells = true;

            cl6.ColumnWidth = 18;

            cl6.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("A3", "C3");

            cl7.Value2 = "Địa chỉ: ";

            cl7.MergeCells = true;

            cl7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("A4", "B4");

            cl8.Value2 = "Điện thoại liên hệ: ";

            cl8.MergeCells = true;

            cl8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("A5", "B5");

            cl9.Value2 = "Ngày xuất bảng lương: "+DateTime.Now.ToString("dd/MM/yyyy HH:mm")+"";

            cl9.MergeCells = true;

            cl9.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("A6", "B6");
            string[] arrListStr = TenNhanVien.Split('-');
            cl10.Value2 = "Người xuất: "+ arrListStr[1] + "";

            cl10.MergeCells = true;

            cl10.ColumnWidth = 20;
            // ký
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("F16", "G16");

            cl13.Value2 = "Hà Nội ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + " ";

            cl13.MergeCells = true;

            cl13.Font.Italic = true;

            cl13.ColumnWidth = 15;

            cl13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("F17", "G17");

            cl14.Value2 = "Người lập ";

            cl14.MergeCells = true;

            cl14.Font.Bold = true;

            cl14.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            cl14.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("F19", "G19");

            cl15.Value2 = ""+ arrListStr[1] +"";

            cl15.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            cl15.MergeCells = true;

            cl15.Font.Bold = true;

            cl15.ColumnWidth = 15;
            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A8", "A8");

            cl1.Value2 = "Mã bảng lương";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B8", "B8");

            cl2.Value2 = "Họ tên nhân viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C8", "C8");

            cl3.Value2 = "Ca làm";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D8", "D8");

            cl4.Value2 = "Ngày làm";

            cl4.ColumnWidth = 13;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E8", "E8");

            cl5.Value2 = "Số tiền";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("F8", "F8");

            cl18.Value2 = "Giờ công";

            cl18.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("G8", "G8");

            cl11.Value2 = "Thành tiền";

            cl11.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("H8", "H8");

            cl12.Value2 = "Ghi chú";

            cl12.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A8", "H8");

            rowHead.Font.Bold = true;

            //Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("G12", "G12");


            //TongCTLUONGNV(cl14);

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

            int rowStart = 9;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        //public void TongCTLUONGNV(string cl)
        //{
        //    int tien = data_gvCTBangLuong.Rows.Count;
        //    float thanhtien = 0;
        //    for (int i = 0; i < tien - 1; i++)
        //    {
        //        thanhtien += float.Parse(data_gvCTBangLuong.Rows[i].Cells["THANHTIEN"].Value.ToString());
        //    }

        //}
        public void ExportFileBLNV(DataTable dataTable, string sheetName, string title)
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

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("A2", "C2");

            cl6.Value2 = "COFFEE ACE";

            cl6.MergeCells = true;

            cl6.ColumnWidth = 18;

            cl6.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("A3", "C3");

            cl7.Value2 = "Địa chỉ: 140 Lê trọng Tấn, Phường Tây Thạnh, Q.Tân Phú, Tp.HCM";

            cl7.MergeCells = true;

            cl7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("A4", "B4");

            cl8.Value2 = "Điện thoại liên hệ: 0832110611";

            cl8.MergeCells = true;

            cl8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("A5", "B5");

            cl9.Value2 = "Ngày xuất bảng lương: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "";

            cl9.MergeCells = true;

            cl9.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("A6", "B6");

            string[] arrListStr = TenNhanVien.Split('-');

            cl10.Value2 = "Người xuất: " + arrListStr[1] + "";

            cl10.MergeCells = true;

            cl10.ColumnWidth = 20;
            // ký
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("E15", "F15");

            cl13.Value2 = "Tp.HCM ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + " ";

            cl13.MergeCells = true;

            cl13.Font.Italic = true;

            cl13.ColumnWidth = 15;

            cl13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("E16", "F16");

            cl14.Value2 = "Người lập ";

            cl14.MergeCells = true;

            cl14.Font.Bold = true;

            cl14.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            cl14.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("E18", "F18");

            cl15.Value2 = "" + arrListStr[1] + "";

            cl15.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            cl15.MergeCells = true;

            cl15.Font.Bold = true;

            cl15.ColumnWidth = 15;
            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A8", "A8");

            cl1.Value2 = "Mã bảng lương";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B8", "B8");

            cl2.Value2 = "Họ tên nhân viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C8", "C8");

            cl3.Value2 = "Ngày phát lương";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D8", "D8");

            cl4.Value2 = "Lương cơ bản";

            cl4.ColumnWidth = 13;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E8", "E8");

            cl5.Value2 = "Tổng lương";

            cl5.ColumnWidth = 20.5;



            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A8", "E8");

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

            int rowStart = 9;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        public void ExportFileBLQL(DataTable dataTable, string sheetName, string title)
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

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("A2", "C2");

            cl6.Value2 = "COFFEE ACE";

            cl6.MergeCells = true;

            cl6.ColumnWidth = 18;

            cl6.Font.Size = "15";

            cl6.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("A3", "C3");

            cl7.Value2 = "Địa chỉ: 140 Lê trọng Tấn, Phường Tây Thạnh, Q.Tân Phú, Tp.HCM";

            cl7.MergeCells = true;

            cl7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("A4", "B4");

            cl8.Value2 = "Điện thoại liên hệ: 0832110611";

            cl8.MergeCells = true;

            cl8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("A5", "B5");

            cl9.Value2 = "Ngày xuất bảng lương:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "";

            cl9.MergeCells = true;

            cl9.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("A6", "B6");

            string[] arrListStr = TenNhanVien.Split('-');

            cl10.Value2 = "Người xuất: " + arrListStr[1] + "";

            cl10.MergeCells = true;

            cl10.ColumnWidth = 20;

            // ký
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("D15", "E15");

            cl13.Value2 = "Tp.HCM ngày 12 tháng 01 năm 2022 ";

            cl13.MergeCells = true;

            cl13.Font.Italic = true;

            cl13.ColumnWidth = 15;

            cl13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("D16", "E16");

            cl14.Value2 = "Người lập ";

            cl14.MergeCells = true;

            cl14.Font.Bold = true;

            cl14.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            cl14.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("D18", "E18");

            cl15.Value2 = "" + arrListStr[1] + "";

            cl15.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            cl15.MergeCells = true;

            cl15.Font.Bold = true;

            cl15.ColumnWidth = 15;
            // Tạo tiêu đề cột 


            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A8", "A8");

            cl1.Value2 = "Mã bảng lương";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B8", "B8");

            cl2.Value2 = "Họ tên nhân viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C8", "C8");

            cl3.Value2 = "Ngày vào làm";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D8", "D8");

            cl4.Value2 = "Chức vụ";

            cl4.ColumnWidth = 13;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E8", "E8");

            cl5.Value2 = "Ngày phát lương";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("F8", "F8");

            cl11.Value2 = "Lương cơ bản";

            cl11.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("G8", "G8");

            cl12.Value2 = "Tổng lương";

            cl12.ColumnWidth = 20.5;



            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A8", "G8");

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

            int rowStart = 9;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        public void ExportFileCTLUONGQL(DataTable dataTable, string sheetName, string title)
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

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "J1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("A2", "C2");

            cl6.Value2 = "COFFEE ACE";

            cl6.MergeCells = true;

            cl6.ColumnWidth = 18;

            cl6.Font.Size = "15";
                
            cl6.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("A3", "C3");

            cl7.Value2 = "Địa chỉ: 140 Lê trọng Tấn, Phường Tây Thạnh, Q.Tân Phú, Tp.HCM";

            cl7.MergeCells = true;

            cl7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("A4", "B4");

            cl8.Value2 = "Điện thoại liên hệ: 0832110611";

            cl8.MergeCells = true;

            cl8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("A5", "B5");

            cl9.Value2 = "Ngày xuất bảng lương: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " ";

            cl9.MergeCells = true;

            cl9.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("A6", "B6");

            string[] arrListStr = TenNhanVien.Split('-');

            cl10.Value2 = "Người xuất: " + arrListStr[1] + "";

            cl10.MergeCells = true;

            cl10.ColumnWidth = 20;
            // ký
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("G15", "I15");

            cl13.Value2 = "Tp.HCM ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + " ";

            cl13.MergeCells = true;

            cl13.Font.Italic = true;

            cl13.ColumnWidth = 15;

            cl13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("G16", "I16");

            cl14.Value2 = "Người lập ";

            cl14.MergeCells = true;

            cl14.Font.Bold = true;

            cl14.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            cl14.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("G18", "I18");

            cl15.Value2 = "" + arrListStr[1] + "";

            cl15.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            cl15.MergeCells = true;

            cl15.Font.Bold = true;

            cl15.ColumnWidth = 15;
            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A8", "A8");

            cl1.Value2 = "Mã bảng lương";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B8", "B8");

            cl2.Value2 = "Họ tên nhân viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C8", "C8");

            cl3.Value2 = "Ca làm";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D8", "D8");

            cl4.Value2 = "Lương cơ bản";

            cl4.ColumnWidth = 13;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E8", "E8");

            cl5.Value2 = "Số ngày công tháng";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("F8", "F8");

            cl11.Value2 = "Số ngày công thực tế";

            cl11.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("G8", "G8");

            cl12.Value2 = "Hệ số lương";

            cl12.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("H8", "H8");

            cl16.Value2 = "Phụ cấp";

            cl16.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("I8", "I8");

            cl17.Value2 = "Thành tiền";

            cl17.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("J8", "J8");

            cl18.Value2 = "Ghi chú";

            cl18.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A8", "J8");

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

            int rowStart = 9;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        public void Load_LuongNV()
        {
            data_gvBangLuong.DataSource = luongBLL.LoadLuongNV();

            data_gvCTBangLuong.DataSource = luongBLL.LoadCTBangLuong_Luong();

            cbb_MaBL.DataSource = luongBLL.LoadBangLuong();
            cbb_MaBL.DisplayMember = "MABANGLUONG";
            cbb_MaBL.ValueMember = "MABANGLUONG";

            cbb_MaBLct.DataSource = luongBLL.LoadBangLuong();
            cbb_MaBLct.DisplayMember = "MABANGLUONG";
            cbb_MaBLct.ValueMember = "MABANGLUONG";

            cbb_TenNV.DataSource = luongBLL.LoadNhanVien();
            cbb_TenNV.DisplayMember = "HOTEN";
            cbb_TenNV.ValueMember = "MANHANVIEN";

            cboxNhanVien.DataSource = luongBLL.LoadNhanVien();
            cboxNhanVien.DisplayMember = "HOTEN";
            cboxNhanVien.ValueMember = "MANHANVIEN";

            txtCaLam.DataSource = luongBLL.LoadCalam();
            txtCaLam.DisplayMember = "CHITIETCA";
            txtCaLam.ValueMember = "MACA";
        }

        public void Load_LuongQL()
        {
            data_gvLuongQL.DataSource = luongBLL.LoadBangLuongQL();

            data_gvCTLuongQL.DataSource = luongBLL.LoadCTBangLuongQL();

            cbox_BLQL.DataSource = luongBLL.LoadBangLuong();
            cbox_BLQL.DisplayMember = "MABANGLUONG";
            cbox_BLQL.ValueMember = "MABANGLUONG";

            cbox_CTBLQL.DataSource = luongBLL.LoadBangLuong();
            cbox_CTBLQL.DisplayMember = "MABANGLUONG";
            cbox_CTBLQL.ValueMember = "MABANGLUONG";

            cbox_TenQL.DataSource = luongBLL.LoadQL();
            cbox_TenQL.DisplayMember = "HOTEN";
            cbox_TenQL.ValueMember = "MANHANVIEN";

            cbox_CTTenQL.DataSource = luongBLL.LoadQL();
            cbox_CTTenQL.DisplayMember = "HOTEN";
            cbox_CTTenQL.ValueMember = "MANHANVIEN";

            cbox_CTCaLam.DataSource = luongBLL.LoadCalam();
            cbox_CTCaLam.DisplayMember = "CHITIETCA";
            cbox_CTCaLam.ValueMember = "MACA";

            //cbox_MaCC.DataSource = luongBLL.LoadChamCong();
            //cbox_MaCC.DisplayMember = "TENBANGCHAMCONG";
            //cbox_MaCC.ValueMember = "MACHAMCONG";
        }

        public void hesoluong()
        {
            DateTime ngayvaolam = DateTime.Parse(txtNgayVaoLamQL.Text);
            DateTime ngayhientai = DateTime.Now;
            int kq = int.Parse(ngayhientai.Year.ToString()) - int.Parse(ngayvaolam.Year.ToString());
            if (kq >= 4)
            {
                txtHeSoLuong.Text = "3";
                txtPhuCap.Text = "300000";
            }
            else if (kq >= 2)
            {
                txtHeSoLuong.Text = "2";
                txtPhuCap.Text = "200000";


            }
            else
            {
                txtHeSoLuong.Text = "1";
                txtPhuCap.Text = "100000";
            }
        }
       



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbb_MaBL.SelectedIndex < 0 && cbb_TenNV.SelectedIndex < 0)
                {
                    MessageBox.Show("Mời bạn chọn dữ liệu");
                }
                else
                {
                    DateTime ngayPLNV = DateTime.Parse(txt_NgayPL.Text);

                    if (ngayPLNV > DateTime.Now)
                    {
                        MessageBox.Show("Ngày phát lương phải nhỏ hơn ngày hiện tại!");
                    }
                    else
                    {
                        string mabl = cbb_MaBL.SelectedValue.ToString();
                        string manv = cbb_TenNV.SelectedValue.ToString();
                        string ngaypl = txt_NgayPL.Text;
                        float luong = float.Parse(txt_Luognnv.Text);

                        if (luongBLL.KTRAKHOACHINHLUONGNV(mabl, manv))
                        {

                            if (luongBLL.LUULUONGNV(mabl, manv, ngaypl, luong))
                            {
                                MessageBox.Show("Thêm Thành Công");
                                data_gvBangLuong.DataSource = luongBLL.LoadLuongNV();


                                txt_Luognnv.Clear();
                                txt_NgayPL.ResetText();
                                btnThemBLNV.Enabled = true;
                                btnThemCTBLNV.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }

                        }
                        else
                        {
                            if (MessageBox.Show("Bảng lương nhân viên đã tồn tại! Bạn có muốn sửa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                            {
                                luongBLL.SUALUONGNV(mabl, manv, ngaypl);
                                data_gvBangLuong.DataSource = luongBLL.LoadLuongNV();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtCaLam.Enabled = true;
            txtNgaylam.ResetText();
            txtSoTieng.Text = "0";
            label12.Text = "Thành tiền";
            btnThemCTBLNV.Enabled = false;
            btnLuuCTBLNV.Enabled = true;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtNgaylam.Text == string.Empty && cbb_MaBLct.SelectedIndex < 0 && cboxNhanVien.SelectedIndex < 0 && txtCaLam.SelectedIndex < 0)
            {
                MessageBox.Show("Mời bạn chọn dữ liệu");
            }
            else
            {
                if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (luongBLL.XoaCTBangLuong(cbb_MaBLct.SelectedValue.ToString(), cboxNhanVien.SelectedValue.ToString(), txtCaLam.SelectedValue.ToString(), txtNgaylam.Text))
                    {
                        MessageBox.Show("Xóa Thành Công");
                        data_gvCTBangLuong.DataSource = luongBLL.LoadCTLUONG_TheoMa(cbb_MaBLct.SelectedValue.ToString(), cboxNhanVien.SelectedValue.ToString());
                        data_gvBangLuong.DataSource = luongBLL.LoadLuongNV();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thất Bại");
                    }
                }
            }
        }

        private void btnThemLuongQL_Click(object sender, EventArgs e)
        {
            cbox_BLQL.Enabled = true;
            cbox_TenQL.Enabled = true;
            txtTongLuongQL.Text = "0";
            txtNgayPLQL.ResetText();
            btnLuuLuongQL.Enabled = true;
        }

        private void btnXoaLuongQL_Click(object sender, EventArgs e)
        {
            if (cbox_BLQL.SelectedIndex < 0 && cbox_TenQL.SelectedIndex < 0)
            {
                MessageBox.Show("Mời Click vào bảng");
            }
            else
            {
                if (luongBLL.XOABANGLUONGQL(cbox_BLQL.SelectedValue.ToString(), cbox_TenQL.SelectedValue.ToString()))
                {
                    MessageBox.Show("Xóa Thành Công");
                    data_gvLuongQL.DataSource = luongBLL.LoadBangLuongQL();

                    txtTongLuongQL.Clear();
                    txtNgayPLQL.ResetText();
                }
                else
                {
                    MessageBox.Show("Không thể xóa được");

                }
            }
        }

        private void btnLuuLuongQL_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbox_BLQL.SelectedIndex < 0 && cbox_TenQL.SelectedIndex < 0)
                {
                    MessageBox.Show("Mời bạn chọn dữ liệu");
                }
                else
                {
                    DateTime ngayplQL = DateTime.Parse(txtNgayPLQL.Text);

                    if (ngayplQL > DateTime.Now)
                    {
                        MessageBox.Show("Ngày phát lương phải nhỏ hơn ngày hiện tại!", "Thông báo");
                    }
                    else

                    {
                        string mabl = cbox_BLQL.SelectedValue.ToString();
                        string manv = cbox_TenQL.SelectedValue.ToString();
                        string ngaypl = txtNgayPLQL.Text;
                        float luong = float.Parse(txtTongLuongQL.Text);

                        if (luongBLL.KTRAKHOACHINHLUONGQL(mabl, manv))
                        {

                            if (luongBLL.LUULUONGQL(mabl, manv, ngaypl, luong))
                            {
                                MessageBox.Show("Thêm Thành Công");
                                data_gvLuongQL.DataSource = luongBLL.LoadBangLuongQL();


                                txtTongLuongQL.Clear();
                                txtNgayPLQL.ResetText();
                                btnThemCTLuongQL.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }

                        }
                        else
                        {
                            if (MessageBox.Show("Bảng lương nhân viên đã tồn tại! Bạn có muốn sửa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                            {
                                luongBLL.SUALUONGQL(mabl, manv, ngaypl);
                                MessageBox.Show("Sửa thành công!", "Thông báo");
                                data_gvLuongQL.DataSource = luongBLL.LoadBangLuongQL();
                                btnThemCTLuongQL.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void btnThemCTLuongQL_Click(object sender, EventArgs e)
        {
            cbox_CTCaLam.DataSource = luongBLL.LoadCalam();
            cbox_CTCaLam.DisplayMember = "CHITIETCA";
            cbox_CTCaLam.ValueMember = "MACA";

            cbox_CTCaLam.Enabled = true;
            txtNgayCongThang.Text = "0";
            txtNgayCongThucTe.Text = "0";
            label23.Text = "Thành tiền";
            btnLuuCTLuongQL.Enabled = btnXuatCTLuongQL.Enabled = true;
            btnThemCTLuongQL.Enabled = false;
        }

        private void btnLuuCTLuongQL_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbox_CTCaLam.SelectedIndex < 0 || cbox_CTBLQL.SelectedIndex < 0 || cbox_CTTenQL.SelectedIndex < 0 || txtNgayCongThang.Text == string.Empty || txtNgayCongThucTe.Text == string.Empty)
                {
                    MessageBox.Show("Mời bạn chọn dữ liệu");
                }
                else
                {
                    string mabl = cbox_CTBLQL.SelectedValue.ToString();
                    string manv = cbox_CTTenQL.SelectedValue.ToString();
                    string maca = cbox_CTCaLam.SelectedValue.ToString();
                    float luongcb = float.Parse(txtLuongCoBan.Text);
                    float ngaycongthanng = float.Parse(txtNgayCongThang.Text);
                    float heso = float.Parse(txtHeSoLuong.Text);
                    float phucap = float.Parse(txtPhuCap.Text);
                    string ghichu = txtGhiChu.Text;

                    if (luongBLL.KTRAKHOACHINHCTLUONGQL(mabl, manv, maca))
                    {
                        if (txtNgayCongThang.Text == string.Empty || txtNgayCongThang.Text == "0")
                        {
                            MessageBox.Show("Ngày công tháng không hợp lệ!", "Thông báo");
                        }
                        else
                        {
                            if (luongBLL.Them_CTBANGLUONGQL(mabl, manv, maca, luongcb, ngaycongthanng, heso, phucap, ghichu))
                            {
                                MessageBox.Show("Thêm Thành Công");
                                data_gvCTLuongQL.DataSource = luongBLL.LoadCTLUONG_TheoMaQL(mabl, manv);
                                data_gvLuongQL.DataSource = luongBLL.LoadBangLuongQL();
                                btnXoaCTLuongQL.Enabled = false;
                                //btnLuuChamCong.Enabled = true;
                            }
                        }

                    }
                    else
                    {
                        if (MessageBox.Show("Bảng lương nhân viên đã tồn tại! Bạn có muốn sửa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        {
                            luongBLL.SuaCTBangLuongQL(mabl, manv, maca, txtNgayCongThang.Text);
                            MessageBox.Show("Sửa thành công!", "Thông báo");
                            data_gvCTLuongQL.DataSource = luongBLL.LoadCTLUONG_TheoMaQL(mabl, manv);
                            data_gvLuongQL.DataSource = luongBLL.LoadBangLuongQL();
                        }
                    }
                }
            }
            catch { }
        }

        private void btnXoaCTLuongQL_Click(object sender, EventArgs e)
        {
            if (cbox_CTBLQL.SelectedIndex < 0 && cbox_CTCaLam.SelectedIndex < 0 && cbox_CTTenQL.SelectedIndex < 0)
            {
                MessageBox.Show("Mời bạn chọn dữ liệu");
            }
            else
            {
                if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (luongBLL.XoaCTBangLuongQL(cbox_CTBLQL.SelectedValue.ToString(), cbox_CTTenQL.SelectedValue.ToString(), cbox_CTCaLam.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Xóa Thành Công");
                        data_gvCTLuongQL.DataSource = luongBLL.LoadCTLUONG_TheoMaQL(cbox_CTBLQL.SelectedValue.ToString(), cbox_CTTenQL.SelectedValue.ToString());
                        data_gvLuongQL.DataSource = luongBLL.LoadBangLuongQL();

                        cbox_CTCaLam.Enabled = false;
                        txtNgayCongThang.Text = "0";
                        txtNgayCongThucTe.Text = "0";
                        label23.Text = "Thành tiền";
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thất Bại");
                    }
                }
            }
        }



        private void data_gvBangLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbb_MaBL.Text = data_gvBangLuong.CurrentRow.Cells[0].Value.ToString();
                cbb_TenNV.Text = data_gvBangLuong.CurrentRow.Cells[1].Value.ToString();
                txt_NgayPL.Text = DateTime.Parse(data_gvBangLuong.CurrentRow.Cells[2].Value.ToString()).ToString("MM/dd/yyyy");

                txtTienLuong.Text = data_gvBangLuong.CurrentRow.Cells[3].Value.ToString();
                txt_Luognnv.Text = data_gvBangLuong.CurrentRow.Cells[4].Value.ToString();


                cbb_MaBLct.Text = data_gvBangLuong.CurrentRow.Cells[0].Value.ToString();
                cboxNhanVien.Text = data_gvBangLuong.CurrentRow.Cells[1].Value.ToString();
                if (cbb_MaBL.Text != null)
                {
                    string mabl = cbb_MaBL.SelectedValue.ToString();
                    string manv = cboxNhanVien.SelectedValue.ToString();
                    data_gvCTBangLuong.DataSource = luongBLL.LoadCTLUONG_TheoMa(mabl, manv);
                }
                cbb_MaBL.Enabled = false;
                cbb_TenNV.Enabled = false;


                btnXoaBLNV.Enabled = true;
                btnThemCTBLNV.Enabled = true;
            }
            catch
            {
            }
        }

        private void data_gvCTBangLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbb_MaBLct.Text = data_gvCTBangLuong.CurrentRow.Cells[0].Value.ToString();
                cboxNhanVien.Text = data_gvCTBangLuong.CurrentRow.Cells[1].Value.ToString();
                txtCaLam.Text = data_gvCTBangLuong.CurrentRow.Cells[2].Value.ToString();
                txtNgaylam.Text = DateTime.Parse(data_gvCTBangLuong.CurrentRow.Cells[3].Value.ToString()).ToShortDateString();
                txtTienLuong.Text = data_gvCTBangLuong.CurrentRow.Cells[4].Value.ToString();
                txtSoTieng.Text = data_gvCTBangLuong.CurrentRow.Cells[5].Value.ToString();
                label12.Text = data_gvCTBangLuong.CurrentRow.Cells[6].Value.ToString();
                txtGhiChu.Text = data_gvCTBangLuong.CurrentRow.Cells[7].Value.ToString();

                btnXoaCTBLNV.Enabled = true;
            }
            catch
            {
            }
        }

        private void data_gvLuongQL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbox_BLQL.Text = data_gvLuongQL.CurrentRow.Cells[0].Value.ToString();
                cbox_TenQL.Text = data_gvLuongQL.CurrentRow.Cells[1].Value.ToString();
                txtNgayVaoLamQL.Text = data_gvLuongQL.CurrentRow.Cells[2].Value.ToString();
                txtChucVu.Text = data_gvLuongQL.CurrentRow.Cells[3].Value.ToString();
                txtNgayPLQL.Text = DateTime.Parse(data_gvLuongQL.CurrentRow.Cells[4].Value.ToString()).ToString("MM/dd/yyyy");
                txtLuongCoBan.Text = data_gvLuongQL.CurrentRow.Cells[5].Value.ToString();
                txtTongLuongQL.Text = data_gvLuongQL.CurrentRow.Cells[6].Value.ToString();


                cbox_CTBLQL.Text = data_gvLuongQL.CurrentRow.Cells[0].Value.ToString();
                cbox_CTTenQL.Text = data_gvLuongQL.CurrentRow.Cells[1].Value.ToString();

                string mabl = cbox_CTBLQL.SelectedValue.ToString();
                string manv = cbox_CTTenQL.SelectedValue.ToString();
                data_gvCTLuongQL.DataSource = luongBLL.LoadCTLUONG_TheoMaQL(mabl, manv);

                hesoluong();
                // txtTienLuong.Text = "25000";
                btnXoaLuongQL.Enabled = true;
                btnThemCTLuongQL.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void data_gvCTLuongQL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //cbox_CTBLQL.Text = data_gvCTLuongQL.CurrentRow.Cells[0].Value.ToString();
                //cbox_CTTenQL.Text = data_gvCTLuongQL.CurrentRow.Cells[1].Value.ToString();
                cbox_CTCaLam.Text = data_gvCTLuongQL.CurrentRow.Cells[2].Value.ToString();
                txtLuongCoBan.Text = data_gvCTLuongQL.CurrentRow.Cells[3].Value.ToString();
                txtNgayCongThang.Text = data_gvCTLuongQL.CurrentRow.Cells[4].Value.ToString();
                txtNgayCongThucTe.Text = data_gvCTLuongQL.CurrentRow.Cells[5].Value.ToString();
                txtHeSoLuong.Text = data_gvCTLuongQL.CurrentRow.Cells[6].Value.ToString();
                txtPhuCap.Text = data_gvCTLuongQL.CurrentRow.Cells[7].Value.ToString();
                label23.Text = data_gvCTLuongQL.CurrentRow.Cells[8].Value.ToString();


                string mabl = cbox_CTBLQL.SelectedValue.ToString();
                string manv = cbox_CTTenQL.SelectedValue.ToString();

                //data_gv_ChamCong.DataSource = luongBLL.LoadChamCongLUONG_TheoMaQL(mabl, manv);


                //cbox_MaCC.Enabled = true;
                btnXoaCTLuongQL.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }





        private void txtSoTieng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXuatLuongQL_Click(object sender, EventArgs e)
        {


        }

        private void btnXuatCTLuongQL_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable datatable = new DataTable();
                DataColumn cl1 = new DataColumn("MABANGLUONG");
                DataColumn cl2 = new DataColumn("HOTEN");
                DataColumn cl3 = new DataColumn("CHITIETCA");
                DataColumn cl4 = new DataColumn("LUONGCOBAN");
                DataColumn cl5 = new DataColumn("NGAYCONGTHANG");
                DataColumn cl6 = new DataColumn("NGAYCONGTHUCTE");
                DataColumn cl7 = new DataColumn("HESOLUONG");
                DataColumn cl8 = new DataColumn("PHUCAP");
                DataColumn cl9 = new DataColumn("THANHTIEN");
                DataColumn cl10 = new DataColumn("GHICHU");


                datatable.Columns.Add(cl1);
                datatable.Columns.Add(cl2);
                datatable.Columns.Add(cl3);
                datatable.Columns.Add(cl4);
                datatable.Columns.Add(cl5);
                datatable.Columns.Add(cl6);
                datatable.Columns.Add(cl7);
                datatable.Columns.Add(cl8);
                datatable.Columns.Add(cl9);
                datatable.Columns.Add(cl10);

                foreach (DataGridViewRow dtvR in data_gvCTLuongQL.Rows)
                {
                    DataRow dtr = datatable.NewRow();
                    dtr[0] = dtvR.Cells[0].Value;
                    dtr[1] = dtvR.Cells[1].Value;
                    dtr[2] = dtvR.Cells[2].Value;
                    dtr[3] = dtvR.Cells[3].Value;
                    dtr[4] = dtvR.Cells[4].Value;
                    dtr[5] = dtvR.Cells[5].Value;
                    dtr[6] = dtvR.Cells[6].Value;
                    dtr[7] = dtvR.Cells[7].Value;
                    dtr[8] = dtvR.Cells[8].Value;
                    dtr[9] = dtvR.Cells[9].Value;


                    datatable.Rows.Add(dtr);
                }

                ExportFileCTLUONGQL(datatable, "Danh sach nhan vien", "CHI TIẾT LƯƠNG NHÂN VIÊN TOÀN THỜI GIAN");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất excel !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatBLNV_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable datatable = new DataTable();
                DataColumn cl1 = new DataColumn("MABANGLUONG");
                DataColumn cl2 = new DataColumn("HOTEN");
                DataColumn cl3 = new DataColumn("NGAYPHATLUONG");
                DataColumn cl4 = new DataColumn("LUONGCOBAN");
                DataColumn cl5 = new DataColumn("TONGLUONG");


                datatable.Columns.Add(cl1);
                datatable.Columns.Add(cl2);
                datatable.Columns.Add(cl3);
                datatable.Columns.Add(cl4);
                datatable.Columns.Add(cl5);


                foreach (DataGridViewRow dtvR in data_gvBangLuong.Rows)
                {
                    DataRow dtr = datatable.NewRow();
                    dtr[0] = dtvR.Cells[0].Value;
                    dtr[1] = dtvR.Cells[1].Value;
                    dtr[2] = dtvR.Cells[2].Value;
                    dtr[3] = dtvR.Cells[3].Value;
                    dtr[4] = dtvR.Cells[4].Value;


                    datatable.Rows.Add(dtr);
                }

                ExportFileBLNV(datatable, "Danh sach nhan vien", "LƯƠNG NHÂN VIÊN THỜI VỤ");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất excel !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void btnXuatCTBLNV_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable datatable = new DataTable();
                DataColumn cl1 = new DataColumn("MABANGLUONG");
                DataColumn cl2 = new DataColumn("HOTEN");
                DataColumn cl3 = new DataColumn("CHITIETCA");
                DataColumn cl4 = new DataColumn("NGAYLAM");
                DataColumn cl5 = new DataColumn("SOTIEN");
                DataColumn cl10 = new DataColumn("SOTIENG");
                DataColumn cl11 = new DataColumn("THANHTIEN");
                DataColumn cl12 = new DataColumn("GHICHU");

                datatable.Columns.Add(cl1);
                datatable.Columns.Add(cl2);
                datatable.Columns.Add(cl3);
                datatable.Columns.Add(cl4);
                datatable.Columns.Add(cl5);
                datatable.Columns.Add(cl10);
                datatable.Columns.Add(cl11);
                datatable.Columns.Add(cl12);

                foreach (DataGridViewRow dtvR in data_gvCTBangLuong.Rows)
                {
                    DataRow dtr = datatable.NewRow();
                    dtr[0] = dtvR.Cells[0].Value;
                    dtr[1] = dtvR.Cells[1].Value;
                    dtr[2] = dtvR.Cells[2].Value;
                    dtr[3] = dtvR.Cells[3].Value;
                    dtr[4] = dtvR.Cells[4].Value;
                    dtr[5] = dtvR.Cells[5].Value;
                    dtr[6] = dtvR.Cells[6].Value;
                    dtr[7] = dtvR.Cells[7].Value;

                    datatable.Rows.Add(dtr);
                }

                ExportFile(datatable, "Danh sach nhan vien", "LƯƠNG NHÂN VIÊN THỜI VỤ");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất excel !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnThemBLNV_Click(object sender, EventArgs e)
        {
            cbb_MaBL.Enabled = true;
            cbb_TenNV.Enabled = true;
            txt_Luognnv.Text = "0";
            txt_NgayPL.ResetText();
            btnThemBLNV.Enabled = false;
            btnLuuBLNV.Enabled = true;
        }

        private void btnLuuBLNV_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbb_MaBL.SelectedIndex < 0 && cbb_TenNV.SelectedIndex < 0)
                {
                    MessageBox.Show("Mời bạn chọn dữ liệu");
                }
                else
                {
                    DateTime ngayPLNV = DateTime.Parse(txt_NgayPL.Text);

                    if (ngayPLNV > DateTime.Now)
                    {
                        MessageBox.Show("Ngày phát lương phải nhỏ hơn ngày hiện tại!");
                    }
                    else
                    {
                        string mabl = cbb_MaBL.SelectedValue.ToString();
                        string manv = cbb_TenNV.SelectedValue.ToString();
                        string ngaypl = txt_NgayPL.Text;
                        float luong = float.Parse(txt_Luognnv.Text);

                        if (luongBLL.KTRAKHOACHINHLUONGNV(mabl, manv))
                        {

                            if (luongBLL.LUULUONGNV(mabl, manv, ngaypl, luong))
                            {
                                MessageBox.Show("Thêm Thành Công");
                                data_gvBangLuong.DataSource = luongBLL.LoadLuongNV();


                                txt_Luognnv.Clear();
                                txt_NgayPL.ResetText();
                                btnThemBLNV.Enabled = true;
                                btnThemCTBLNV.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }

                        }
                        else
                        {
                            if (MessageBox.Show("Bảng lương nhân viên đã tồn tại! Bạn có muốn sửa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                            {
                                luongBLL.SUALUONGNV(mabl, manv, ngaypl);
                                data_gvBangLuong.DataSource = luongBLL.LoadLuongNV();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void btnLuuCTBLNV_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtNgaylam.Text == string.Empty || cbb_MaBLct.SelectedIndex < 0 || cboxNhanVien.SelectedIndex < 0 || txtTienLuong.Text == string.Empty || txtSoTieng.Text == string.Empty)
                {
                    MessageBox.Show("Mời bạn chọn dữ liệu");
                }
                else
                {
                    DateTime ngaylamNV = DateTime.Parse(txtNgaylam.Text);
                    DateTime ngayPLNV = DateTime.Parse(txt_NgayPL.Text);

                    if (ngaylamNV > ngayPLNV)
                    {
                        MessageBox.Show("Ngày làm phải nhỏ hơn ngày phát lương!", "Thông báo");
                    }
                    else
                    {
                        string mabl = cbb_MaBLct.SelectedValue.ToString();
                        string manv = cboxNhanVien.SelectedValue.ToString();
                        string maca = txtCaLam.SelectedValue.ToString();
                        string ngaylam = txtNgaylam.Text;
                        float tienluong = float.Parse(txtTienLuong.Text);
                        float sotieng = float.Parse(txtSoTieng.Text);
                        string ghichu = txtGhiChu.Text;


                        if (luongBLL.KTRAKHOACHINH(mabl, manv, maca, ngaylam))
                        {
                            if (txtSoTieng.Text == string.Empty || txtSoTieng.Text == "0")
                            {
                                MessageBox.Show("Giờ công phải lớn hơn 0", "Thông báo");
                            }
                            else
                            {

                                if (luongBLL.Them_CTBANGLUONG(mabl, manv, maca, ngaylam, tienluong, sotieng, ghichu))
                                {
                                    MessageBox.Show("Thêm Thành Công");
                                    data_gvCTBangLuong.DataSource = luongBLL.LoadCTLUONG_TheoMa(mabl, manv);
                                    data_gvBangLuong.DataSource = luongBLL.LoadLuongNV();
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Trùng Khóa Chính");

                        }
                    }
                }
            }
            catch { }
        }

        private void btnThemCTLuongQL_Click_1(object sender, EventArgs e)
        {
            cbox_CTCaLam.DataSource = luongBLL.LoadCalam();
            cbox_CTCaLam.DisplayMember = "CHITIETCA";
            cbox_CTCaLam.ValueMember = "MACA";

            cbox_CTCaLam.Enabled = true;
            txtNgayCongThang.Text = "0";
            txtNgayCongThucTe.Text = "0";
            label23.Text = "Thành tiền";
            btnLuuCTLuongQL.Enabled = btnXuatCTLuongQL.Enabled = true;
            btnThemCTLuongQL.Enabled = false;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                frmLuongQL_ChamCong frm = new frmLuongQL_ChamCong();
                frm.MaBL = cbox_CTBLQL.SelectedValue.ToString(); //lay du lieu tu cbb nay dung k. d.e v ay thoi
                frm.MaCa = cbox_CTCaLam.SelectedValue.ToString();
                frm.MaNV = cbox_CTTenQL.SelectedValue.ToString();
                frm.NgayPL = DateTime.Parse(txtNgayPLQL.Text);
                frm.ShowDialog();
                //viet ham load lai o day la duoc.
                data_gvCTLuongQL.DataSource = luongBLL.LoadCTLUONG_TheoMaQL(cbb_MaBL.Text, cbb_TenNV.Text);
                data_gvLuongQL.DataSource = luongBLL.LoadBangLuongQL();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnXuatLuongQL_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable datatable = new DataTable();
                DataColumn cl1 = new DataColumn("MABANGLUONG");
                DataColumn cl2 = new DataColumn("HOTEN");
                DataColumn cl3 = new DataColumn("NGAYVAOLAM");
                DataColumn cl4 = new DataColumn("CHUCVU");
                DataColumn cl5 = new DataColumn("NGAYPHATLUONG");
                DataColumn cl6 = new DataColumn("LUONGCOBAN");
                DataColumn cl7 = new DataColumn("TONGLUONG");


                datatable.Columns.Add(cl1);
                datatable.Columns.Add(cl2);
                datatable.Columns.Add(cl3);
                datatable.Columns.Add(cl4);
                datatable.Columns.Add(cl5);
                datatable.Columns.Add(cl6);
                datatable.Columns.Add(cl7);


                foreach (DataGridViewRow dtvR in data_gvLuongQL.Rows)
                {
                    DataRow dtr = datatable.NewRow();
                    dtr[0] = dtvR.Cells[0].Value;
                    dtr[1] = dtvR.Cells[1].Value;
                    dtr[2] = dtvR.Cells[2].Value;
                    dtr[3] = dtvR.Cells[3].Value;
                    dtr[4] = dtvR.Cells[4].Value;
                    dtr[5] = dtvR.Cells[5].Value;
                    dtr[6] = dtvR.Cells[6].Value;


                    datatable.Rows.Add(dtr);
                }

                ExportFileBLQL(datatable, "Danh sach nhan vien", "LƯƠNG NHÂN VIÊN TOÀN THỜI GIAN");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất excel !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXuatCTLuongQL_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void data_gvLuongQL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTongLuongQL_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txtTongLuongQL.Text, System.Globalization.NumberStyles.AllowThousands);
            txtTongLuongQL.Text = String.Format(culture, "{#,##0.##}", value);
            txtTongLuongQL.Select(txtTongLuongQL.Text.Length, 0);
        }

        private void txt_Luognnv_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txt_Luognnv.Text, System.Globalization.NumberStyles.AllowThousands);
            txt_Luognnv.Text = String.Format(culture, "{0:N0}", value);
            txt_Luognnv.Select(txt_Luognnv.Text.Length, 0);
        }

        private void txtTienLuong_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txtTienLuong.Text, System.Globalization.NumberStyles.AllowThousands);
            txtTienLuong.Text = String.Format(culture, "{0:N0}", value);
            txtTienLuong.Select(txtTienLuong.Text.Length, 0);
        }

        private void txtPhuCap_EditValueChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txtPhuCap.Text, System.Globalization.NumberStyles.AllowThousands);
            txtPhuCap.Text = String.Format(culture, "{0:N0}", value);
            txtPhuCap.Select(txtPhuCap.Text.Length, 0);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
