using DevExpress.XtraReports.UI;
using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmXemThongTinBan : Form
    {
        HoaDonBLL objHoaDonBLL = new HoaDonBLL();
        BanBLL objBanBLL = new BanBLL();
        DatBanBLL objDatBanBLL = new DatBanBLL();
        DataTable tbCBBBan = new DataTable();

        public frmXemThongTinBan()
        {
            InitializeComponent();
        }

        public string MaNhanVien { get; set; }
        public string TenBan { get; set; }
        public int MaBan { get; set; }
        public string TienBan { get; set; }
        public double TongTienBan { get; set; }
        public string TrangThaiBan { get; set; }
        public string MaKhachHang { get; set; }
        public int MaBanChuyen { get; set; }
        public class Ban
        {
            public Button btn;
            public Label lblTenBan;
            public ToolTip tTip;
        }

        public class KhuVuc
        {
            public List<Ban> LBan;
        }

        public List<Ban> ListBan = new List<Ban>();
        public List<TabPage> ListTapPage = new List<TabPage>();
        public int index = 0;
        int temp = 0;

        private void CapNhatTrangThaiDatBan()
        {
            DataTable tbDatBan = objDatBanBLL.LayDanhSachDatBan();
            DateTime dtNow = DateTime.Now;
            DateTime tgNhanBan;
            int result;
            int maBan;
            TimeSpan aInterval = new System.TimeSpan(0, 1, 30, 0);

            foreach (DataRow row in tbDatBan.Rows)
            {
                if (row["TINHTRANG"].ToString() == "Đã đặt")
                {
                    tgNhanBan = DateTime.Parse(row["THOIGIANNHANBAN"].ToString());
                    result = DateTime.Compare(dtNow, tgNhanBan);
                    maBan = int.Parse(row["MABAN"].ToString());
                    if (result > 0)
                    {
                        objDatBanBLL.CapNhatTrangThaiDatBan(maBan, "Đã hủy");
                        //cap nhat tinh trang ban
                        objBanBLL.CapNhatTrangThaiBan(maBan, "Trống");
                    }
                    else
                    {
                        tgNhanBan = tgNhanBan.Subtract(aInterval);
                        if (DateTime.Compare(dtNow, tgNhanBan) >= 0)
                        {
                            objBanBLL.CapNhatTrangThaiBan(maBan, "Đã đặt");
                        }
                    }
                }
            }
        }
        private void LoadBan()
        {
            tabctrlDSBan.Controls.Clear();

            KhuVucBLL objKhuVucBLL = new KhuVucBLL();
            BanBLL objBanBLL = new BanBLL();
            
            var LayKV = objKhuVucBLL.LoadData();
            foreach (DataRow item in LayKV.Rows)
            {
                string tenKhuVuc = item["TENKHUVUC"].ToString().Trim();
                TabPage tb = new TabPage(tenKhuVuc);
                ListTapPage.Add(tb);
                tb.Width = grctrlDSBan.Width - 10;
                tb.Text = tenKhuVuc;
                tb.BackColor = Color.WhiteSmoke;

                var LayBan = objBanBLL.LoadData();
                // đổi DataTable thành list
                List<DataRow> Bans = new List<DataRow>(LayBan.Select());
                List<DataRow> KhuVucs = new List<DataRow>(LayKV.Select());

                var table = from x in Bans
                            join i in KhuVucs on x["MAKHUVUC"] equals i["MAKHUVUC"]
                            where i["TENKHUVUC"].ToString().Trim() == tb.Text
                            select new
                            {
                                maBan = x["MABAN"].ToString().Trim(),
                                tenBan = x["TENBAN"].ToString().Trim(),
                                trangThai = x["TRANGTHAI"].ToString().Trim()
                            };
                foreach (var a in table)
                {
                    Ban b = new Ban();
                    ListBan.Add(b);
                    ListBan[index].btn = new Button();
                    ListBan[index].btn.Size = new Size(100, 100);
                    //ListBan[index].btn.BackColor = Color.Blue;
                    ListBan[index].btn.Name = a.maBan.ToString();
                    ListBan[index].btn.Text = a.tenBan.ToString();
                    //ListBan[index].btn.BackColor = Color.Gold;

                    if (a.trangThai.ToString() == "Trống")
                        this.ListBan[index].btn.BackColor = Color.Aqua;
                    else if (a.trangThai.ToString() == "Đã đặt")
                        this.ListBan[index].btn.BackColor = Color.Gray;
                    else
                        this.ListBan[index].btn.BackColor = Color.Red;

                    ListBan[index].btn.Click += btn_Click;
                    tb.Controls.Add(ListBan[index].btn);
                    if (index == temp)
                    {
                        ListBan[index].btn.Location = new Point(50, 10);
                    }
                    else
                    {
                        if (ListBan[index - 1].btn.Location.X + 180 > tb.Width)
                        {
                            ListBan[index].btn.Location = new Point(50, ListBan[index - 1].btn.Location.Y + 100);
                        }
                        else
                        {
                            ListBan[index].btn.Location = new Point(ListBan[index - 1].btn.Location.X + 105, ListBan[index - 1].btn.Location.Y);
                        }
                    }
                    index++;
                }
                temp += table.Count();
                tb.Refresh();
                tabctrlDSBan.Controls.Add(tb);
            }
        }

        private void loadCBBBan()
        {
            tbCBBBan = objBanBLL.LoadData();

            cbbChuyenBan.DataSource = tbCBBBan;
            cbbChuyenBan.DisplayMember = "TENBAN";
            cbbChuyenBan.ValueMember = "MABAN";

            cbbGopBan.DataSource = tbCBBBan;
            cbbGopBan.DisplayMember = "TENBAN";
            cbbGopBan.ValueMember = "MABAN";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button bt = sender as Button;
                TenBan = bt.Text;
                MaBan = int.Parse(bt.Name);
                if (bt.BackColor == Color.Aqua)
                    TrangThaiBan = "Trống";
                if (bt.BackColor == Color.Gray)
                    TrangThaiBan = "Đã đặt";
                if (bt.BackColor == Color.Red)
                    TrangThaiBan = "Có Khách";
                lblBan.Text = "Bạn Đang Chọn Bàn " + TenBan;

                // lấy thông tin bàn
                dtgvTT.DataSource = objHoaDonBLL.LayThongTinHoaDonTheoBan(MaBan);
                DataTable table = objDatBanBLL.LayThongTinKHDatBan(MaBan);

                if (TrangThaiBan == "Đã đặt")
                {
                    lblTenKH.Text = table.Rows[0]["TENKHACHHANG"].ToString();
                    lbl2.Text = "";
                    lblThanhTien.Text = "";
                    lbl3.Text = "";
                    lblChu.Text = "";
                    btnInPhieu.Enabled = false;
                    btnThanhToan.Enabled = false;
                    MaKhachHang = table.Rows[0]["MAKHACHHANG"].ToString();

                }
                else
                {
                    MaKhachHang = null;
                    lbl2.Text = "Tổng Tiền:";
                    lbl3.Text = "Bằng Chữ:";
                    TienBan = TongTien(dtgvTT).ToString(); // tính tổng tiền bàn
                    TongTienBan = Double.Parse(TienBan); // gắn tiền bàn cho tổng tiền
                    lblThanhTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTienBan); // gắn tổng tiền bàn cho label tổng tiền
                    lblChu.Text = objBanBLL.So_chu(TongTienBan);
                    if (dtgvTT.Rows.Count < 1)
                    {
                        lblTenKH.Text = "Chưa có khách";
                        btnInPhieu.Enabled = false;
                        btnThanhToan.Enabled = false;
                    }
                    else
                    {
                        lblTenKH.Text = dtgvTT.Rows[0].Cells[6].Value.ToString();
                        btnInPhieu.Enabled = true;
                        btnThanhToan.Enabled = true;
                    }
                }

                btnGoiMon.Enabled = true;
                btnDatBan.Enabled = true;
                btnChuyenBan.Enabled = true;
                btnTaiLai.Enabled = true;
                btnGopBan.Enabled = true;

                cbbChuyenBan.Enabled = true;
                cbbGopBan.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Reload lại chương trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ReLoad();
            }
        }
        private int TongTien(DataGridView dgvi)
        {
            int T = 0;
            for (int i = 0; i <= dgvi.Rows.Count - 1; i++)
            {
                if(dgvi.Rows[i].Cells[4].Value != null)
                {
                    T += int.Parse(dgvi.Rows[i].Cells[4].Value.ToString());
                }    
            }
            return T;
        }
        private void ReLoad()
        {
            CapNhatTrangThaiDatBan();
            lblBan.Text = "Bạn Chưa Chọn Bàn";
            MaBan = 0;
            TenBan = "";
            TongTienBan = 0;
            lblThanhTien.Text = "Chưa Chọn Bàn";
            lblChu.Text = "";
            LoadBan();
            ClearDS();

            btnGoiMon.Enabled = false;
            btnDatBan.Enabled = false;
            btnChuyenBan.Enabled = false;
            btnTaiLai.Enabled = true;
            btnInPhieu.Enabled = false;
            btnThanhToan.Enabled = false;
            btnGopBan.Enabled = false;

            cbbChuyenBan.Enabled = false;
            cbbGopBan.Enabled = false;
        }
        private void ClearDS()
        {
            //dtgvTT.DataSource = null;
            //dtgvTT.Refresh();
            do
            {
                foreach (DataGridViewRow row in dtgvTT.Rows)
                {
                    try
                    {
                        dtgvTT.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (dtgvTT.Rows.Count > 0);
        }
        private void frmXemThongTinBan_Load(object sender, EventArgs e)
        {
            loadCBBBan();
            ReLoad();
        }
        private void btnGoiMon_Click_1(object sender, EventArgs e)
        {
            if(MaBan == 0)
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(TrangThaiBan == "Đã đặt")
            {
                frmGoiMon frm = new frmGoiMon();
                frm.MaBan = MaBan;
                frm.TenBan = TenBan;
                frm.MaBan = MaBan;
                frm.MaNhanVien = MaNhanVien;
                frm.TrangThaiBan = TrangThaiBan;
                frm.MaKhachHang = MaKhachHang;
                frm.ShowDialog();
            }    
            else
            {
                frmGoiMon frm = new frmGoiMon();
                frm.MaBan = MaBan;
                frm.TenBan = TenBan;
                frm.MaBan = MaBan;
                frm.MaNhanVien = MaNhanVien;
                frm.TrangThaiBan = TrangThaiBan;
                frm.ShowDialog();
            }
            ReLoad();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmThanhToan frm = new frmThanhToan();
            frm.MaBan = MaBan.ToString();
            frm.TenBan = TenBan;
            frm.MaKH = dtgvTT.Rows[0].Cells[5].Value.ToString();
            frm.KhachHang = dtgvTT.Rows[0].Cells[6].Value.ToString();
            frm.TienBan = lblThanhTien.Text;
            frm.TongTien = TongTienBan;
            frm.ShowDialog();
            ReLoad();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            string strMaHD = objHoaDonBLL.LayHoaDon(MaBan.ToString());
            RPPhieuOrder rp = new RPPhieuOrder();

            rp.DataSource = objHoaDonBLL.LayRPHoaDon(strMaHD);
            rp.ShowPreview();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            ReLoad();
        }

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            if (MaBan == 0)
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(String.Compare(TrangThaiBan, "Trống", true) != 0)
            {
                MessageBox.Show("Bàn đã có khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
                frmDatBan frm = new frmDatBan();
                frm.MaBan = MaBan;
                frm.TenBan = TenBan;
                frm.MaBan = MaBan;
                frm.MaNhanVien = MaNhanVien;
                frm.TrangThaiBan = TrangThaiBan;
                frm.LoadDataFormDatBan = new frmDatBan.LoadDaTa(ReLoad);
                frm.ktrBtn = true;
                frm.ShowDialog();
            }
            ReLoad();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if(MaBan == null) 
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strMaHD = null;
            if(objHoaDonBLL.LayHoaDon(MaBan.ToString()) != null)
            {
                strMaHD = objHoaDonBLL.LayHoaDon(MaBan.ToString());
            }
            
            MaBanChuyen = int.Parse(cbbChuyenBan.SelectedValue.ToString());

            if(MaBan == MaBanChuyen) 
            {
                MessageBox.Show("Bàn chuyển bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tbBan = objBanBLL.LayThongTinTinhTrangBan(MaBanChuyen);
            string TrangThaiBanChuyen = tbBan.Rows[0]["TRANGTHAI"].ToString();



            if (TrangThaiBan == "Trống" && TrangThaiBanChuyen == "Trống")
            {
                MessageBox.Show("Cả 2 bàn đều không có khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (TrangThaiBan == "Có Khách" && TrangThaiBanChuyen == "Có Khách")
            {
                MessageBox.Show("Cả 2 bàn đã có  khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (TrangThaiBan == "Đã đặt" || TrangThaiBanChuyen == "Đã đặt")
            {
                MessageBox.Show("1 trong 2 bàn đã có khách đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (objHoaDonBLL.CapNhatChuyenBan(MaBan, MaBanChuyen, strMaHD))
                {
                    MessageBox.Show("Chuyển bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ReLoad();
                    return;
                }
                else 
                {
                    MessageBox.Show("Lỗi chuyển bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }   

        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            if (MaBan == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strMaHD = null;
            if (objHoaDonBLL.LayHoaDon(MaBan.ToString()) != null)
            {
                strMaHD = objHoaDonBLL.LayHoaDon(MaBan.ToString());
            }

            MaBanChuyen = int.Parse(cbbChuyenBan.SelectedValue.ToString());

            string strMaHDChuyen = null;
            if (objHoaDonBLL.LayHoaDon(MaBanChuyen.ToString()) != null)
            {
                strMaHDChuyen = objHoaDonBLL.LayHoaDon(MaBanChuyen.ToString());
            }

            if (MaBan == MaBanChuyen)
            {
                MessageBox.Show("Bàn chuyển bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tbBan = objBanBLL.LayThongTinTinhTrangBan(MaBanChuyen);
            string TrangThaiBanChuyen = tbBan.Rows[0]["TRANGTHAI"].ToString();

            if (TrangThaiBan == "Trống" && TrangThaiBanChuyen == "Trống")
            {
                MessageBox.Show("Cả 2 bàn đều không có khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (TrangThaiBan == "Trống" && TrangThaiBanChuyen == "Có Khách" || TrangThaiBan == "Có Khách" && TrangThaiBanChuyen == "Trống")
            {
                MessageBox.Show("Có một bàn chưa có khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (TrangThaiBan == "Đã đặt" || TrangThaiBanChuyen == "Đã đặt")
            {
                MessageBox.Show("1 trong 2 bàn đã có khách đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (objHoaDonBLL.CapNhatGopBan(MaBan, MaBanChuyen, strMaHD, strMaHDChuyen))
                {
                    MessageBox.Show("Gộp bà thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ReLoad();
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi gộp bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void tabctrlDSBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
