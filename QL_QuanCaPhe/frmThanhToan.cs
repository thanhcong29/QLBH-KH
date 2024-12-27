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
    public partial class frmThanhToan : Form
    {
        HoaDonBLL objHoaDonBLL = new HoaDonBLL();
        BanBLL objBanBLL = new BanBLL();
        KhachHangBLL objKhachHangBLL = new KhachHangBLL();
        GiamGiaBLL objGiamGiaBLL = new GiamGiaBLL();
        public frmThanhToan()
        {
            InitializeComponent();
        }

        public string MaBan { get; set; }
        public string TenBan { get; set; }
        public string MaKH { get; set; }
        public string KhachHang { get; set; }
        public string TienBan { get; set; }
        public double TongTien { get; set; }
        private double GiamGia = 0;
        private double ThanhToan = 0;
        private string MaGiamGia = null;
        private float Diem = 0;
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblBan.Text = TenBan;
            lblKH.Text = KhachHang;
            lblTienBan.Text = TienBan;
            lblGiamGia.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", GiamGia);
            ThanhToan = TongTien - GiamGia;
            lblThanhToan.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", ThanhToan);

            KhachHangBO objKhachHangBO = objKhachHangBLL.LoadInfo(MaKH);

            Diem = objKhachHangBO.DiemThuong;
            lblDiem.Text = Diem + " điểm";

            if (Diem < 1000)
            {
                ckbSDDiem.Enabled = false;
            }
        }

        private void btnGiamGia_Click(object sender, EventArgs e)
        {
            DataTable giam = objGiamGiaBLL.SearchData(txtMaGiam.Text);

            if (giam != null && giam.Rows.Count > 0)
            {
                DateTime ngaykt = Convert.ToDateTime(giam.Rows[0][4].ToString());
                if (ngaykt < DateTime.Now)
                {
                    MessageBox.Show("Mã giảm giá đã hết hạn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MaGiamGia = txtMaGiam.Text.Trim();
                    double km = Convert.ToDouble(giam.Rows[0][1].ToString());
                    double toida = Convert.ToDouble(giam.Rows[0][2].ToString());
                    if (km < 100)
                    {
                        GiamGia = GiamGia + (TongTien - (TongTien * km / 100)) > toida ? toida : (TongTien - (TongTien * km / 100));
                        if (GiamGia > ThanhToan)
                            GiamGia = ThanhToan;
                    }

                    else
                    {
                        GiamGia = GiamGia + km;
                        if (GiamGia > TongTien)
                            GiamGia = TongTien;
                    }

                    MessageBox.Show("Đã áp dụng mã giảm giá", "Thông báo", MessageBoxButtons.OK);
                    ThanhToan = TongTien - GiamGia;
                    lblGiamGia.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", GiamGia);
                    lblThanhToan.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", ThanhToan);
                    txtMaGiam.Enabled = false;
                    btnGiamGia.Enabled = false;
                    btnHuyGG.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool ValiDatePay()
        {
            if (txtMaGiam.Enabled == true)
            {
                DialogResult pay = MessageBox.Show("Mã giảm giá đang được nhập nhưng chưa xác nhận, bạn có muốn thanh toán mà không cần mã giảm giá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (pay == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            else
            {
                return true;
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValiDatePay()) return;
                if (txtKhachDua.Text == "Nhập số tiền")
                {
                    MessageBox.Show("Bạn chưa nhập số tiền khách gửi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDouble(txtKhachDua.Text) - ThanhToan < 0)
                {
                    MessageBox.Show("Số tiền khách gửi nhỏ hơn số tiền cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    HoaDonBO objHoaDonBO = new HoaDonBO();
                    objHoaDonBO.MaHoaDon = objHoaDonBLL.LayHoaDon(MaBan.ToString());
                    objHoaDonBO.NgayXuat = DateTime.Now;
                    objHoaDonBO.ThanhToan = (float)ThanhToan;
                    objHoaDonBO.MaGiamGia = MaGiamGia == null ? "NULL" : MaGiamGia;
                    if (objHoaDonBLL.CapNhatHDThanhToan(objHoaDonBO))
                    {
                        objBanBLL.CapNhatTrangThaiBan(Convert.ToInt32(MaBan), "Trống");
                        if (MaKH != "KH001")
                        {
                            objKhachHangBLL.CapNhatDiemThuong(MaKH, TinhDiemThuong());
                        }
                        MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK);
                        RPHoaDon rp = new RPHoaDon();
                        rp.DataSource = objHoaDonBLL.LayRPHoaDon(objHoaDonBO.MaHoaDon);
                        rp.KhachDua = txtKhachDua.Text;
                        rp.KhuyenMai = lblGiamGia.Text;
                        rp.HoanLai = (Convert.ToDouble(txtKhachDua.Text) - ThanhToan).ToString();
                        rp.ShowPreview();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xử lý thanh tóan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private float TinhDiemThuong()
        {
            if (ckbSDDiem.Checked)
            {
                float DiemSauSD = Diem % 1000;
                float DiemThem = (float)ThanhToan / 1000;
                return DiemSauSD + DiemThem;
            }                    
            else
                return Diem + (float)ThanhToan / 1000;
        }

        private void btnGiamGia_Click_1(object sender, EventArgs e)
        {
            DataTable giam = objGiamGiaBLL.SearchData(txtMaGiam.Text);

            if (giam != null && giam.Rows.Count > 0)
            {
                DateTime ngaykt = Convert.ToDateTime(giam.Rows[0][4].ToString());
                int soluot = Convert.ToInt32(giam.Rows[0][5].ToString());
                if (ngaykt < DateTime.Now)
                {
                    MessageBox.Show("Mã giảm giá đã hết hạn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (soluot < 1)
                {
                    MessageBox.Show("Mã giảm giá đã hết số lượt sử dụng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MaGiamGia = txtMaGiam.Text.Trim();
                    double km = Convert.ToDouble(giam.Rows[0][1].ToString());
                    double toida = Convert.ToDouble(giam.Rows[0][2].ToString());
                    if (km <= 100)
                    {
                        double A = TongTien * km / 100;
                        double b = GiamGia + (TongTien * km / 100);
                        GiamGia = GiamGia + (TongTien * km / 100) > toida ? toida : (TongTien * km / 100);
                        if (GiamGia > ThanhToan)
                            GiamGia = ThanhToan;
                    }

                    else
                    {
                        GiamGia = GiamGia + km;
                        if (GiamGia > TongTien)
                            GiamGia = TongTien;
                    }

                    MessageBox.Show("Đã áp dụng mã giảm giá", "Thông báo", MessageBoxButtons.OK);
                    ThanhToan = TongTien - GiamGia;
                    lblGiamGia.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", GiamGia);
                    lblThanhToan.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", ThanhToan);
                    txtMaGiam.Enabled = false;
                    btnGiamGia.Enabled = false;
                    btnHuyGG.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        bool gg = false;
        private void ckbSDDiem_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSDDiem.Checked)
            {
                if ((ThanhToan - GiamGia) < (Diem - Diem % 1000))
                {
                    MessageBox.Show("Số tiền cần thanh toán nhỏ hơn số điểm đổi, không thể áp dụng đổi điểm khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    gg = true;
                    ckbSDDiem.Checked = false;
                }
                else
                {
                    GiamGia = GiamGia + (Diem - Diem % 1000);
                    ThanhToan = TongTien - GiamGia;
                    lblGiamGia.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", GiamGia);
                    lblThanhToan.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", ThanhToan);
                }
            }
            else
            {
                if (!gg)
                {
                    GiamGia = GiamGia - (Diem - Diem % 1000);
                    ThanhToan = TongTien - GiamGia;
                    lblGiamGia.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", GiamGia);
                    lblThanhToan.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", ThanhToan);
                }
            }
        }

        private void btnHuyGG_Click(object sender, EventArgs e)
        {
            txtMaGiam.Enabled = true;
            btnGiamGia.Enabled = true;
            btnHuyGG.Enabled = false;

            GiamGia = 0;
            ThanhToan = TongTien;
            lblGiamGia.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", GiamGia);
            lblThanhToan.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", ThanhToan);
            MessageBox.Show("Đã hủy giảm giá, Số tiền thanh toán trở về giá trị ban đầu", "Thông báo", MessageBoxButtons.OK);
        }

        private void lblThanhToan_TextChanged(object sender, EventArgs e)
        {
            //if (lblThanhToan.Text == "0 VNĐ")
            //    ckbSDDiem.Enabled = false;
        }
    }
}
