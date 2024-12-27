using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QL_QuanCaPhe
{
    public partial class RPHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public RPHoaDon()
        {
            InitializeComponent();
        }

        public string KhachDua { get; set; }
        public string HoanLai { get; set; }
        public string KhuyenMai { get; set; }
        private void RPHoaDon_BeforePrint(object sender, CancelEventArgs e)
        {
            //lblKhachDua.Text = KhachDua;
            //lblHoanLai.Text = HoanLai;
            //lblGiamGia.Text = KhuyenMai;
            //this.PageColor = Color.Pink;
            //this.ForeColor = Color.Blue;
            FontFamily f = new FontFamily("Consolas");/*Khởi tạo font mới*/
            this.Font = new Font(f, this.Font.Size);/* Gnas forn mới cho font cần đổi*/
        }
    }
    
}
