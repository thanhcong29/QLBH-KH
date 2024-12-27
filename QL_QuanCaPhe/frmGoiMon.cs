using QL_QuanCaPhe.BLL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QL_QuanCaPhe.BO;
using System.Net;
using DevExpress.XtraSplashScreen;

namespace QL_QuanCaPhe
{
    public partial class frmGoiMon : Form
    {
        ThucDonBLL objThucDonBLL = new ThucDonBLL();
        LoaiMonBLL objLoaiMonBLL = new LoaiMonBLL();
        HoaDonBLL objHoaDonBLL = new HoaDonBLL();
        ChiTietHoaDonBLL objChiTietHoaDonBLL = new ChiTietHoaDonBLL();
        ChiTietThucDonBLL objChiTietThucDonBLL = new ChiTietThucDonBLL();
        KhachHangBLL objKhachHangBLL = new KhachHangBLL();
        NguyenLieuBLL objNguyenLieuBLL = new NguyenLieuBLL();
        CongThucBLL objCongThucBLL = new CongThucBLL();
        DatBanBLL objDatBanBLL = new DatBanBLL();
        public frmGoiMon()
        {
            InitializeComponent();
        }
        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string TenMon { get; set; }
        public string TrangThaiBan { get; set; }
        public string MaMon { get; set; }
        public string MaCTMon { get; set; }

        private bool Them = false;
        private bool load = false;
        private string MaLoai = "0";
        private DataTable dtMon = null;
        public DataTable table = null;
        public int Gia { get; set; }
        public class Mon
        {
            public uscMenu btn;
            public Label lblTenBan;
            public ToolTip tTip;
        }
        public class LoaiMon
        {
            public List<Mon> LMon;
        }
        public List<Mon> ListMon = new List<Mon>();
        public int index = 0;
        // chuyển string thành Image
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            uscMenu bt = sender as uscMenu;
            MaMon = bt.MaMon; // Gắn giá trị cho món
            TenMon = bt.TenMon; // gắn giá trị cho tên món
            lblTenMon.Text = TenMon; // gắn giá trị cho label Tên món
            //Gia = bt.Gia; // gắn giá trị cho giá
            Them = true;
            cbbSize.Enabled = true;

            objChiTietThucDonBLL.LoadCbbSize(cbbSize, MaMon);
            cbbSize.Text = "Chọn Size";
        }

        private void frmGoiMon_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
            lblBan.Text = MaBan + " - " + TenBan;
            
            dtMon = objThucDonBLL.SearchData(-1, "null");
            LoadThucDon(dtMon);
            dtgvTTDat.DataSource = objHoaDonBLL.LayThongTinHoaDonTheoBan(MaBan);

            table = objHoaDonBLL.LayThongTinHoaDonTheoBan(MaBan);

            // Load khách hàng
            cbbKhachHang.Properties.DataSource = objKhachHangBLL.SearchData(-1, "NULL", 0);
            cbbKhachHang.Properties.DisplayMember = "TENKHACHHANG";
            cbbKhachHang.Properties.ValueMember = "MAKHACHHANG";
            //
            if (dtgvTTDat.Rows != null && dtgvTTDat.Rows.Count > 0)
            {
                if (dtgvTTDat.Rows[0].Cells[5].Value != null)
                {
                    MaKhachHang = dtgvTTDat.Rows[0].Cells[5].Value.ToString();
                }
                cbbKhachHang.Text = MaKhachHang;
                cbbKhachHang.Enabled = false;
            }
            if (MaKhachHang != null)
            {
                cbbKhachHang.Enabled = false;
                cbbKhachHang.Text = MaKhachHang.ToString();
            }           
            LoadCBBLoaiMon();
            SplashScreenManager.CloseForm(true);
        }
        private void LoadThucDon(DataTable dt)
        {
            floDanhSachBan.Controls.Clear();
            //var LayMon = objThucDonBLL.SearchData(-1, "null");
            if (dt != null)
            {
                // đổi DataTable thành list
                List<DataRow> Mons = new List<DataRow>(dt.Select());

                var table = from x in Mons
                            select new
                            {
                                maMon = x["MAMON"].ToString().Trim(),
                                tenMon = x["TENMON"].ToString().Trim(),
                                hinhAnh = x["HINHANH"].ToString()
                            };
                foreach (var a in table)
                {
                    Mon b = new Mon();
                    ListMon.Add(b);
                    ListMon[index].btn = new uscMenu();
                    ListMon[index].btn.Size = new Size(400, 180);
                    ListMon[index].btn.MaMon = a.maMon.ToString();
                    ListMon[index].btn.TenMon = a.tenMon.ToString();
                    //ListMon[index].btn.Gia = Convert.ToInt32(a.gia.ToString());
                    try
                    {
                        if (a.hinhAnh != "")
                        {
                            var request = WebRequest.Create(a.hinhAnh);
                            var response = request.GetResponse();
                            var stream = response.GetResponseStream();
                            ListMon[index].btn.HinhAnh = Bitmap.FromStream(stream);
                        }
                        else
                            ListMon[index].btn.HinhAnh = global::QL_QuanCaPhe.Properties.Resources.error_Image1;

                    }
                    catch
                    {
                        ListMon[index].btn.HinhAnh = global::QL_QuanCaPhe.Properties.Resources.error_Image1;
                    }
                    ListMon[index].btn.Click += btn_Click;
                    floDanhSachBan.Controls.Add(ListMon[index].btn);
                }
            }
        }

        private void dtgvTTDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoLuong.Value = Convert.ToInt32(dtgvTTDat.CurrentRow.Cells[2].Value.ToString());
            Them = false;
            MaCTMon = dtgvTTDat.CurrentRow.Cells[0].Value.ToString();
            Gia = Convert.ToInt32(objChiTietThucDonBLL.LoadInfo(MaCTMon).Rows[0][2].ToString());
            MaMon = dtgvTTDat.CurrentRow.Cells[7].Value.ToString();
            cbbSize.Enabled = false;
        }
        private bool KiemTraMon(string strMaMon)
        {
            int soMon = 0;
            foreach (DataGridViewRow dgr in dtgvTTDat.Rows)
            {
                if (dgr.Cells[0].Value != null)
                {
                    if (dgr.Cells[0].Value.ToString().Trim() == strMaMon)
                        soMon++;
                    else
                        continue;
                }
            }
            if (soMon > 0)
                return true;
            else return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Value < 1)
                MessageBox.Show("Số lượng món phải lớn hơn 0 !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (Them)
                {
                    ThemMon();

                }
                else
                {
                    CapNhatSoLuong();
                }
            }
        }

        //Thêm Món
        private void ThemMon()
        {
            if (cbbSize.Text == "Chọn Size")
            {
                MessageBox.Show("Bạn chưa chọn size", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraMon(MaCTMon))
            {
                MessageBox.Show("Món đã tồn tại, hãy kiểm tra lại danh sách món đã đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int ThanhTien = Gia * Convert.ToInt32(txtSoLuong.Value);
                try
                {
                    DataRow newRow = table.NewRow();
                    newRow[1] = TenMon;
                    newRow[2] = txtSoLuong.Value;
                    newRow[3] = cbbSize.Text;
                    newRow[4] = ThanhTien;
                    newRow[0] = MaCTMon;


                    table.Rows.Add(newRow);

                    dtgvTTDat.DataSource = table;

                    MessageBox.Show("Đã thêm " + txtSoLuong.Value + " - " + TenMon + " - " + cbbSize.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Lỗi cập nhật món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Cập nhật số lượng món
        private void CapNhatSoLuong()
        {
            foreach (DataGridViewRow dgr in dtgvTTDat.Rows)
            {
                if (dgr.Cells[0].Value.ToString().Trim() == MaCTMon)
                {
                    dgr.Cells[2].Value = txtSoLuong.Value;
                    dgr.Cells[4].Value = Gia * txtSoLuong.Value;
                }
            }
            MessageBox.Show("Đã cập nhật số lượng " + lblTenMon.Text + " thành " + txtSoLuong.Value, "Thông báo");
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MaKhachHang == null)
            {
                if (cbbKhachHang.Text == "Chọn khách hàng")
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            HoaDonBO objHoaDonBO = new HoaDonBO();
            List<ChiTietHoaDonBO> chiTietHoaDonBOs = new List<ChiTietHoaDonBO>();
            objHoaDonBO.MaHoaDon = objHoaDonBLL.TaoMaHoaDon();
            objHoaDonBO.NgayLap = DateTime.Now;
            objHoaDonBO.MaBan = MaBan;
            objHoaDonBO.MaNhanVien = MaNhanVien;
            objHoaDonBO.MaKhachHang = MaKhachHang;
            objHoaDonBO.TongTien = 0;

            // kiểm tra tình trạng bàn
            // nếu bàn có người đặt thì cập nhật tinh trạng bàn thành "Trống"
            if (TrangThaiBan == "Đã đặt")
            {
                BanBLL objBanBLL = new BanBLL();
                objBanBLL.CapNhatTrangThaiBan(MaBan, "Trống");
                objDatBanBLL.CapNhatTrangThaiDatBan(MaBan, "Đã nhận");
                TrangThaiBan = "Trống";
            }
            // Kiểm tra bàn trống
            // nếu bàn trống thì thêm mới hóa đơn
            if (TrangThaiBan == "Trống")
            {

                foreach (DataGridViewRow dr in dtgvTTDat.Rows)
                {
                    //if()
                    ChiTietHoaDonBO objChiTietHoaDonBO = new ChiTietHoaDonBO();
                    objChiTietHoaDonBO.MaHoaDon = objHoaDonBLL.TaoMaHoaDon();
                    objChiTietHoaDonBO.MaCTMon = dr.Cells[0].Value.ToString().Trim();
                    objChiTietHoaDonBO.SoLuong = Convert.ToInt32(dr.Cells[2].Value.ToString().Trim());
                    objHoaDonBO.TongTien += Convert.ToInt32(dr.Cells[4].Value.ToString());

                    chiTietHoaDonBOs.Add(objChiTietHoaDonBO);
                }
                objHoaDonBO.lstChiTietHoaDonBOs = chiTietHoaDonBOs;

                if (objHoaDonBLL.Insert(objHoaDonBO))
                {
                    MessageBox.Show("Lưu thông tin gọi món thành công", "Thông báo");
                    BanBLL objBanBLL = new BanBLL();
                    objBanBLL.CapNhatTrangThaiBan(MaBan, "Có Khách");
                    CapNhatSoLuongNL(true, objHoaDonBO);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin gọi món thất bại", "Thông báo");
                }
            }
            // Nếu bàn Có khách (Đã gọi món trước đó) -> cập nhật hóa đơn
            else
            {
                string MaHoaDon = objHoaDonBLL.LayHoaDon(MaBan.ToString());
                // lấy Hóa đơn

                //
                foreach (DataRow dr in table.Rows)
                {
                    string MaMonXoa = dr["MACTMON"].ToString().Trim();
                    ChiTietHoaDonBO objChiTietHoaDonBO = new ChiTietHoaDonBO();
                    objChiTietHoaDonBO.MaHoaDon = MaHoaDon;
                    objChiTietHoaDonBO.MaCTMon = dr[0].ToString().Trim();
                    objChiTietHoaDonBO.SoLuong = Convert.ToInt32(dr[2].ToString().Trim());
                    chiTietHoaDonBOs.Add(objChiTietHoaDonBO);
                    objHoaDonBO.lstChiTietHoaDonBOs = chiTietHoaDonBOs;
                    CapNhatSoLuongNL(false, objHoaDonBO);
                    // Xóa chi tiết hóa đơn
                    objChiTietHoaDonBLL.Delete(MaHoaDon, MaMonXoa);
                    objHoaDonBO.lstChiTietHoaDonBOs = null;
                }

                foreach (DataGridViewRow dgr in dtgvTTDat.Rows)
                {
                    // Thêm chi tiết mới
                    ChiTietHoaDonBO objChiTietHoaDonBO = new ChiTietHoaDonBO();
                    objChiTietHoaDonBO.MaHoaDon = MaHoaDon;
                    objChiTietHoaDonBO.MaCTMon = dgr.Cells[0].Value.ToString().Trim();
                    objChiTietHoaDonBO.SoLuong = Convert.ToInt32(dgr.Cells[2].Value.ToString().Trim());
                    objHoaDonBO.TongTien += Convert.ToInt32(dgr.Cells[4].Value.ToString());

                    chiTietHoaDonBOs.Add(objChiTietHoaDonBO);
                }

                foreach (ChiTietHoaDonBO ct in chiTietHoaDonBOs)
                {
                    objChiTietHoaDonBLL.Insert(ct);
                }
                objHoaDonBO.lstChiTietHoaDonBOs = chiTietHoaDonBOs;
                CapNhatSoLuongNL(true, objHoaDonBO);
                if (objHoaDonBLL.CapNhatTongTien(MaHoaDon, objHoaDonBO.TongTien))
                {
                    MessageBox.Show("Lưu thông tin gọi món thành công", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin gọi món thất bại", "Thông báo");
                }
            }

        }
        private void CapNhatSoLuongNL(bool them, HoaDonBO objHoaDonBO)
        {
            DataTable ct = objCongThucBLL.SearchData(MaMon);
            foreach (DataRow dr in ct.Rows)
            {
                if (dr["MaCTMon"].ToString() == MaCTMon)
                {
                    foreach (ChiTietHoaDonBO item in objHoaDonBO.lstChiTietHoaDonBOs)
                    {
                        int intMaNguyenLieu = Convert.ToInt32(dr["MANGUYENLIEU"].ToString());
                        float floSoLuong = (float)(float.Parse(dr["HAMLUONG"].ToString()) * item.SoLuong);
                        if (them)
                            objNguyenLieuBLL.CapNhatSoLuong(intMaNguyenLieu, floSoLuong);
                        else
                            objNguyenLieuBLL.CapNhatSoLuong(intMaNguyenLieu, -floSoLuong);
                    }
                }
            }

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dtgvTTDat.Rows)
            {
                if (dgr.Cells[0].Value.ToString().Trim() == MaCTMon)
                {
                    dtgvTTDat.Rows.RemoveAt(dgr.Index);
                }
            }
        }

        private void cbbSize_TextChanged(object sender, EventArgs e)
        {
            if (cbbSize.Text != "Chọn Size")
            {
                DataTable dt = objChiTietThucDonBLL.LayChiTiet(MaMon, cbbSize.Text);
                Gia = Convert.ToInt32(dt.Rows[0][2].ToString());
                MaCTMon = dt.Rows[0][0].ToString();
            }
        }

        private void cbbKhachHang_TextChanged(object sender, EventArgs e)
        {
            MaKhachHang = cbbKhachHang.EditValue.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCBBLoaiMon()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MALOAI");
            dt.Columns.Add("TENLOAI");
            dt.Rows.Add("0", "Tất cả");
            foreach (DataRow dr in objLoaiMonBLL.LoadData().Rows)
            {
                dt.Rows.Add(dr["MALOAI"], dr["TENLOAI"]);
            }
            cbbLoaiMon.DataSource = dt;
            cbbLoaiMon.DisplayMember = "TENLOAI";
            cbbLoaiMon.ValueMember = "MALOAI";
            load = true;
        }

        private void cbbLoaiMon_TextChanged(object sender, EventArgs e)
        {
            if (load)
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                if (cbbLoaiMon.SelectedValue.ToString() == "0")
                {
                    LoadThucDon(dtMon);
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MAMON");
                    dt.Columns.Add("TENMON");
                    dt.Columns.Add("MALOAI");
                    dt.Columns.Add("DVT");
                    dt.Columns.Add("HINHANH");
                    foreach (DataRow dr in dtMon.Rows)
                    {
                        if(dr["MALOAI"].ToString() == cbbLoaiMon.SelectedValue.ToString())
                        {
                            dt.Rows.Add(dr["MAMON"], dr["TENMON"], dr["MALOAI"], dr["DVT"], dr["HINHANH"]);
                        }    
                    }
                    LoadThucDon(dt);
                }
                SplashScreenManager.CloseForm(true);
            }
        }

        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            if (load)
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                if (cbbLoaiMon.SelectedValue.ToString() == "0")
                {
                    LoadThucDon(dtMon);
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MAMON");
                    dt.Columns.Add("TENMON");
                    dt.Columns.Add("MALOAI");
                    dt.Columns.Add("DVT");
                    dt.Columns.Add("HINHANH");
                    foreach (DataRow dr in dtMon.Rows)
                    {
                        if (dr["MALOAI"].ToString() == cbbLoaiMon.SelectedValue.ToString())
                        {
                            dt.Rows.Add(dr["MAMON"], dr["TENMON"], dr["MALOAI"], dr["DVT"], dr["HINHANH"]);
                        }
                    }
                    LoadThucDon(dt);
                }
                SplashScreenManager.CloseForm(true);
            }
        }
    }
}
