using DevExpress.XtraReports.UI;
using QL_QuanCaPhe.BLL;
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
    public partial class frmXemHoaDon : Form
    {
        HoaDonBLL objHoaDonBLL = new HoaDonBLL();
        public frmXemHoaDon()
        {
            InitializeComponent();
        }

        private bool daxuat = false;
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!ValiDateSearch()) return;
            int intSearchType = -1;
            string strKeyWord = txtKeyWord.Text.Trim();
            DateTime TuNgay = dtTuNgay.DateTime.Date;
            DateTime ToiNgay = dtToiNgay.DateTime;
            if (cbbSearchType.Text == "-- Tìm theo --")
                intSearchType = -1;
            if (cbbSearchType.Text == "Mã hóa đơn")
                intSearchType = 0;
            if (cbbSearchType.Text == "Mã  khách hàng")
                intSearchType = 1;
            if (cbbSearchType.Text == "Mã nhân viên")
                intSearchType = 2;
            dtgvDS.DataSource = objHoaDonBLL.LayDanhSachHoaDon(intSearchType, strKeyWord, TuNgay, ToiNgay);
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(!daxuat)
            {
                inHóaĐơnToolStripMenuItem.Enabled = false;
            }
            else
            {
                inHóaĐơnToolStripMenuItem.Enabled = true;
            }
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string thanhtoan = dtgvDS.CurrentRow.Cells[5].Value.ToString();
            if (dtgvDS.CurrentRow.Cells[5].Value.ToString() == "")
            {
                daxuat = false;
            }
            else
            {
                daxuat = true;
            }
        }

        private void inHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPHoaDonNew rp = new RPHoaDonNew();
            string maHD = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            rp.DataSource = objHoaDonBLL.LayRPHoaDon(maHD);            
            rp.ShowPreview();
        }

        private void frmXemHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
