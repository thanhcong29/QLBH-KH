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
    public partial class frmTKDTTheoTG : Form
    {
        HoaDonBLL objHoaDonBLL = new HoaDonBLL();
        NhanVienBLL objNhanVienBLL = new NhanVienBLL();
        public frmTKDTTheoTG()
        {
            InitializeComponent();
        }

        public DataTable table = null;
        float tongDoanhThu = 0;
        string theo = "";
        bool locNV = false;

        private void loadccbThang()
        {
            DateTime aDateTime = DateTime.Now;
            for (int i = 1; i <= 12; i++)
            {
                cbbThang.Items.Add(i);
            }
            cbbThang.Text = aDateTime.Month.ToString();
        }

        private void loadccbNam()
        {
            DateTime aDateTime = DateTime.Now;
            int nam = aDateTime.Year;
            for (int i = 2018; i <= nam; i++)
            {
                cbbNam.Items.Add(i);
            }
            cbbNam.Text = aDateTime.Year.ToString();
        }

        private void loadData()
        {
            cbbThang.ResetText();
            cbbNam.ResetText();
            cbbThang.ResetText();
            cbbNam.ResetText();

            dtpDTTheoNgay.Enabled = false;
            cbbThang.Enabled = false;
            cbbNam.Enabled = false;
            btnHuy.Enabled = false;
            btnLoc.Enabled = false;
            txtTongDT.Enabled = false;
            cbbNhanVien.Enabled = false;

            btnDTTheoNgay.Enabled = true;
            btnDTTheoThang.Enabled = true;
            btnDTTheoNam.Enabled = true;
            button1.Enabled = true;
            dtgvDT.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
            dtgvDT.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
        }

        private void loadDoanhThuNam()
        {
            tongDoanhThu = 0;
            string nam = cbbNam.Text;
           
            table = objHoaDonBLL.LayDanhSachHoaDon_TKDT_TheoNam(nam);
            dtgvDT.DataSource = table;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                tongDoanhThu += Convert.ToInt32(table.Rows[i].ItemArray[3].ToString());
            }

            txtTongDT.Text = tongDoanhThu.ToString();
        }
        private void loadDoanhThuThang()
        {
            tongDoanhThu = 0;
            string nam = cbbNam.Text;
            int thang = int.Parse(cbbThang.Text);
            
            table = objHoaDonBLL.LayDanhSachHoaDon_TKDT_TheoThang(nam, thang);
            dtgvDT.DataSource = table;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                tongDoanhThu += Convert.ToInt32(table.Rows[i].ItemArray[3].ToString());
            }

            txtTongDT.Text = tongDoanhThu.ToString();
        }
        private void loadDoanhThuNgay()
        {
            tongDoanhThu = 0;
            string ngay = dtpDTTheoNgay.Value.ToString("yyyy-MM-dd");
            table = objHoaDonBLL.LayDanhSachHoaDon_TKDT_TheoNgay(ngay);
            dtgvDT.DataSource = table;

            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tongDoanhThu += Convert.ToInt32(table.Rows[i].ItemArray[3].ToString());
                }
            }
            txtTongDT.Text = tongDoanhThu.ToString();
        }

        private void loadDoanhThuNV_TheoNam()
        {
            tongDoanhThu = 0;
            string nam = cbbNam.Text;
            string manv = cbbNhanVien.EditValue.ToString();
            table = objHoaDonBLL.LayDanhSachHoaDon_TKDT_NV_TheoNam(manv, nam);
            dtgvDT.DataSource = table;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                tongDoanhThu += Convert.ToInt32(table.Rows[i].ItemArray[3].ToString());
            }

            txtTongDT.Text = tongDoanhThu.ToString();
        }
        private void loadDoanhThuNV_TheoThang()
        {
            tongDoanhThu = 0;
            string nam = cbbNam.Text;
            int thang = int.Parse(cbbThang.Text);
            string manv = cbbNhanVien.EditValue.ToString();
            table = objHoaDonBLL.LayDanhSachHoaDon_TKDT_NV_TheoThang(manv, nam, thang);
            dtgvDT.DataSource = table;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                tongDoanhThu += Convert.ToInt32(table.Rows[i].ItemArray[3].ToString());
            }

            txtTongDT.Text = tongDoanhThu.ToString();
        }
        private void loadDoanhThuNV_TheoNgay()
        {
            tongDoanhThu = 0;
            string ngay = dtpDTTheoNgay.Value.ToString("yyyy-MM-dd");
            string manv = cbbNhanVien.EditValue.ToString();
            table = objHoaDonBLL.LayDanhSachHoaDon_TKDT_NV_TheoNgay(manv, ngay);
            dtgvDT.DataSource = table;

            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tongDoanhThu += Convert.ToInt32(table.Rows[i].ItemArray[3].ToString());
                }
            }
            txtTongDT.Text = tongDoanhThu.ToString();
        }

        private void btnDTTheoNgay_Click(object sender, EventArgs e)
        {
            btnLoc.Enabled = true;
            dtpDTTheoNgay.Enabled = true;
            btnHuy.Enabled = true;

            btnDTTheoThang.Enabled = false;
            btnDTTheoNam.Enabled = false;
            button1.Enabled = false;

            theo = "ngay";
            if (!locNV)
            {
                cbbNhanVien.Text = "";
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (locNV)
                {
                    if (theo == "ngay")
                    {
                        loadDoanhThuNV_TheoNgay();
                        loadData();
                    }
                    else if (theo == "thang")
                    {
                        loadDoanhThuNV_TheoThang();
                        loadData();
                    }
                    else
                    {
                        loadDoanhThuNV_TheoNam();
                        loadData();
                    }
                }
                else
                {
                    if (theo == "ngay")
                    {
                        loadDoanhThuNgay();
                        loadData();
                    }
                    else if (theo == "thang")
                    {
                        loadDoanhThuThang();
                        loadData();
                    }
                    else
                    {
                        loadDoanhThuNam();
                        loadData();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void frmTKDTTheoTG_Load(object sender, EventArgs e)
        {
            loadData();

            // Load khách hàng
            cbbNhanVien.Properties.DataSource = objNhanVienBLL.SearchData(-1, "NULL");
            cbbNhanVien.Properties.DisplayMember = "HOTEN";
            cbbNhanVien.Properties.ValueMember = "MANHANVIEN";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnDTTheoThang_Click(object sender, EventArgs e)
        {
            loadccbThang();
            loadccbNam();
            btnLoc.Enabled = true;
            cbbThang.Enabled = true;
            cbbNam.Enabled = true;
            btnHuy.Enabled = true;
            

            btnDTTheoNgay.Enabled = false;
            btnDTTheoNam.Enabled = false;
            button1.Enabled = false;

            theo = "thang";
            if (!locNV)
            {
                cbbNhanVien.Text = "";
            }
        }

        private void btnDTTheoNam_Click(object sender, EventArgs e)
        {
            loadccbNam();
            btnLoc.Enabled = true;
            cbbNam.Enabled = true;
            btnHuy.Enabled = true;

            btnDTTheoThang.Enabled = false;
            btnDTTheoNgay.Enabled = false;
            button1.Enabled = false;

            theo = "nam";
            if (!locNV)
            {
                cbbNhanVien.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
            cbbNhanVien.Text = "";
            cbbNhanVien.Enabled = true;
            locNV = true;
        }
    }
}
