using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_QuanCaPhe.BLL;

namespace QL_QuanCaPhe
{
    public partial class frmTKMatHangBanChay : Form
    {
        ChiTietHoaDonBLL objChiTietHoaDonBLL = new ChiTietHoaDonBLL();
        public frmTKMatHangBanChay()
        {
            InitializeComponent();
        }
        public DataTable table = null;
        string theo = "";

        private void loadccbThang()
        {
            DateTime aDateTime = DateTime.Now;
            for (int i = 1; i <= 12; i++)
            {
                cbbThang.Items.Add(i);
            }
            //cbbThang.Text = aDateTime.Month.ToString();
        }

        private void loadccbNam()
        {
            DateTime aDateTime = DateTime.Now;
            int nam = aDateTime.Year;
            for (int i = 2018; i <= nam; i++)
            {
                cbbNam.Items.Add(i);
            }
            //cbbNam.Text = aDateTime.Year.ToString();
        }

        private void loadData()
        {
            dtpDTTheoNgay.Enabled = false;
            cbbThang.Enabled = false;
            cbbNam.Enabled = false;
            btnHuy.Enabled = false;
            btnLoc.Enabled = false;

            btnDTTheoNgay.Enabled = true;
            btnDTTheoThang.Enabled = true;
            btnDTTheoNam.Enabled = true;
        }

        private void frmTKMatHangBanChay_Load(object sender, EventArgs e)
        {
            loadData();
            loadccbThang();
            loadccbNam();
        }

        private void tkMatHangBanChayTheoNam()
        {
            chartMatHangBanChay.Series["Thực Đơn"].Points.Clear();
            string nam = cbbNam.Text;
            dtgvMatHangBanChay.DataSource = objChiTietHoaDonBLL.LayDanhSachMatHangBanChay_TKMHTHEONAM(nam);

            table = objChiTietHoaDonBLL.LayDanhSachMatHangBanChay_TKMHTHEONAM(nam);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chartMatHangBanChay.Series["Thực Đơn"].Points.AddXY(table.Rows[i].ItemArray[1].ToString(), int.Parse(table.Rows[i].ItemArray[4].ToString()));
            }
        }
        private void tkMatHangBanChayTheoThang()
        {
            chartMatHangBanChay.Series["Thực Đơn"].Points.Clear();
            string nam = cbbNam.Text;
            int thang = int.Parse(cbbThang.Text);
            dtgvMatHangBanChay.DataSource = objChiTietHoaDonBLL.LayDanhSachMatHangBanChay_TKMHTHEOTHANG(nam, thang);

            table = objChiTietHoaDonBLL.LayDanhSachMatHangBanChay_TKMHTHEOTHANG(nam, thang);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chartMatHangBanChay.Series["Thực Đơn"].Points.AddXY(table.Rows[i].ItemArray[1].ToString(), int.Parse(table.Rows[i].ItemArray[4].ToString()));
            }
        }
        private void tkMatHangBanChayTheoNgay()
        {
            chartMatHangBanChay.Series["Thực Đơn"].Points.Clear();
            string ngay = dtpDTTheoNgay.Value.ToString("yyyy-MM-dd");
            dtgvMatHangBanChay.DataSource = objChiTietHoaDonBLL.LayDanhSachMatHangBanChay_TKMHTHEONGAY(ngay);

            table = objChiTietHoaDonBLL.LayDanhSachMatHangBanChay_TKMHTHEONGAY(ngay);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chartMatHangBanChay.Series["Thực Đơn"].Points.AddXY(table.Rows[i].ItemArray[1].ToString(), int.Parse(table.Rows[i].ItemArray[4].ToString()));
            }
        }

        private void dtgvDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (theo == "ngay")
            {
                tkMatHangBanChayTheoNgay();
                loadData();
            }
            else if (theo == "thang")
            {
                tkMatHangBanChayTheoThang();
                loadData();
            }
            else
            {
                tkMatHangBanChayTheoNam();
                loadData();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnDTTheoNgay_Click(object sender, EventArgs e)
        {
            btnLoc.Enabled = true;
            dtpDTTheoNgay.Enabled = true;
            btnHuy.Enabled = true;

            btnDTTheoThang.Enabled = false;
            btnDTTheoNam.Enabled = false;

            theo = "ngay";
        }

        private void btnDTTheoThang_Click(object sender, EventArgs e)
        {
            DateTime aDateTime = DateTime.Now;
            cbbThang.Text = aDateTime.Month.ToString();
            cbbNam.Text = aDateTime.Year.ToString();

            btnLoc.Enabled = true;
            cbbThang.Enabled = true;
            cbbNam.Enabled = true;
            btnHuy.Enabled = true;


            btnDTTheoNgay.Enabled = false;
            btnDTTheoNam.Enabled = false;

            theo = "thang";
        }

        private void btnDTTheoNam_Click(object sender, EventArgs e)
        {
            DateTime aDateTime = DateTime.Now;
            cbbNam.Text = aDateTime.Year.ToString();

            btnLoc.Enabled = true;
            cbbNam.Enabled = true;
            btnHuy.Enabled = true;

            btnDTTheoThang.Enabled = false;
            btnDTTheoNgay.Enabled = false;

            theo = "nam";
        }
    }
}
