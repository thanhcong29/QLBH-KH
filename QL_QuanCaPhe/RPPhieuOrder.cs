using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QL_QuanCaPhe
{
    public partial class RPPhieuOrder : DevExpress.XtraReports.UI.XtraReport
    {
        public RPPhieuOrder()
        {
            InitializeComponent();
        }

        private void RPPhieuOrder_BeforePrint(object sender, CancelEventArgs e)
        {
            this.PageColor = Color.Pink;
            this.ForeColor = Color.Blue;
            FontFamily f = new FontFamily("Consolas");/*Khởi tạo font mới*/
            this.Font = new Font(f, this.Font.Size);/* Gnas forn mới cho font cần đổi*/
        }
    }
}
