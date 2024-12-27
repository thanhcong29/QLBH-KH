using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmDatBan : Form
    {
        KhachHangBLL objKhachHangBLL = new KhachHangBLL();
        DatBanBLL objDatBanBLL = new DatBanBLL();

        public frmDatBan()
        {
            InitializeComponent();
        }

        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string TrangThaiBan { get; set; }
        public bool ktrBtn { get; set; }

        public delegate void LoadDaTa();

        public LoadDaTa LoadDataFormDatBan;

        public DataTable table = null;

        private bool them = false;

 
        private void LoadData()
        {
            cbbKhachHang.ResetText();
            ccbGio.ResetText();
            ccbPhut.ResetText();

            cbbKhachHang.Enabled = false;
            ccbGio.Enabled = false;
            ccbPhut.Enabled = false;
            dtpNgayNhanBan.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = false;

            table = objDatBanBLL.LayDanhSachDatBan();
            dtgvDanhSachDatBan.DataSource = table;
            dtgvDanhSachDatBan.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
        }

        private void loadcbbTinhTrang()
        {
            cbbTinhTrang.Items.Add("Tất cả");
            cbbTinhTrang.Items.Add("Đã đặt");
            cbbTinhTrang.Items.Add("Đã nhận");
            cbbTinhTrang.Items.Add("Đã hủy");
            cbbTinhTrang.SelectedIndex = 0;
        }

        private void frmDatBan_Load(object sender, EventArgs e)
        {
            LoadData();
            loadcbbTinhTrang();

            lblBan.Text = MaBan + " - " + TrangThaiBan;
            // Load khách hàng
            cbbKhachHang.Properties.DataSource = objKhachHangBLL.SearchData(-1, "NULL", 0);
            cbbKhachHang.Properties.DisplayMember = "TENKHACHHANG";
            cbbKhachHang.Properties.ValueMember = "MAKHACHHANG";

            MaKhachHang = cbbKhachHang.Properties.ValueMember;
            Console.WriteLine(MaKhachHang);
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbbKhachHang.EditValue != null)
            {
                MaKhachHang = cbbKhachHang.EditValue.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không nhận kh hàng lẻ
            string str1 = "KH001";
            if (String.Compare(str1, MaKhachHang, true) == 0)
            {
                MessageBox.Show("Khách hàng chưa đăng ký thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int gio = -1;
            int phut = -1;

            if (ccbGio.Text != "")
            {
                gio = int.Parse(ccbGio.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn giờ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ccbPhut.Text != "")
            {
                phut = int.Parse(ccbPhut.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phút", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dtHienTai = DateTime.Now;
            DateTime aDateTime = dtpNgayNhanBan.Value;
            DateTime dtTGNhanBan = new DateTime(aDateTime.Year, aDateTime.Month, aDateTime.Day, gio, phut, 0);
            if (dtHienTai > dtTGNhanBan)
            {
                MessageBox.Show("Thời gian nhận bàn phải lớn hơn thời gian hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbKhachHang.Text == "Chọn khách hàng")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatBanBO objDatBanBO = new DatBanBO();
            objDatBanBO.MaDatBan = objDatBanBLL.TaoMaDatBan();
            objDatBanBO.ThoiGianNhanBan = dtTGNhanBan;
            objDatBanBO.GhiChu = txtGhiChu.Text;
            objDatBanBO.MaKhachHang = MaKhachHang;
            objDatBanBO.MaBan = MaBan;
            objDatBanBO.MaNhanVien = MaNhanVien;

            if (TrangThaiBan == "Trống")
            {
                DataTable tbDatBan = objDatBanBLL.LayDanhSachDatBan();
                DateTime tgNhanBan;
                TimeSpan aInterval = new System.TimeSpan(0, 3, 0, 0);

                foreach (DataRow row in tbDatBan.Rows)
                {
                    if ( row["TINHTRANG"].ToString() == "Đã đặt" && int.Parse(row["MABAN"].ToString()) == MaBan)
                    {
                        tgNhanBan = DateTime.Parse(row["THOIGIANNHANBAN"].ToString());
                        if (DateTime.Compare(dtTGNhanBan, tgNhanBan) > 0)
                        {
                            tgNhanBan = tgNhanBan.Subtract(aInterval);
                            if (DateTime.Compare(tgNhanBan, dtTGNhanBan) < 0)
                            {
                                MessageBox.Show("Đã có khách đặt bàn trong thời gian này", "Thông báo");
                                return;
                            }
                        }
                        else
                        {
                            dtTGNhanBan = dtTGNhanBan.Subtract(aInterval);
                            if (DateTime.Compare(tgNhanBan, tgNhanBan) < 0)
                            {
                                MessageBox.Show("Đã có khách đặt bàn trong thời gian này", "Thông báo");
                                return;
                            }
                        }
                    }
                }

                if (objDatBanBLL.Insert(objDatBanBO))
                {
                    MessageBox.Show("Đặt bàn thành công", "Thông báo");
                    //BanBLL objBanBLL = new BanBLL();
                    //objBanBLL.CapNhatTrangThaiBan(MaBan, "Đã đặt");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đặt bàn thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Không thể đặt bàn", "Thông báo");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.Width = 1400;
            frm.Show();
        }

        private void dtgvDanhSachDatBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;

            cbbKhachHang.Text = dtgvDanhSachDatBan.CurrentRow.Cells[6].Value.ToString();
            MaBan = int.Parse(dtgvDanhSachDatBan.CurrentRow.Cells[5].Value.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            cbbKhachHang.Enabled = true;
            ccbGio.Enabled = true;
            ccbPhut.Enabled = true;
            dtpNgayNhanBan.Enabled = true;

            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvDanhSachDatBan.CurrentRow.Cells[4].Value.ToString() == "Đã hủy")
            {
                MessageBox.Show("Bàn đã hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa thông tin đặt bàn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.Yes)
            {
                if (objDatBanBLL.Delete(dtgvDanhSachDatBan.CurrentRow.Cells[0].Value.ToString()))
                {
                    BanBLL objBanBLL = new BanBLL();
                    objBanBLL.CapNhatTrangThaiBan(MaBan, "Trống");
                    MessageBox.Show("Xóa thành công thông tin đặt bàn ", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }
                else
                    MessageBox.Show("Xóa thông tin đặt bàn thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult huy = MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.YesNo);
            if (huy == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDatBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (ktrBtn)
                {
                    LoadDataFormDatBan();
                }

            }
            catch (Exception )
            {
                MessageBox.Show("Reload lại giao diện quản lý bàn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbTinhTrang.SelectedItem.ToString() == "Tất cả")
            {
                LoadData();
            }
            else
            {
                if (dtgvDanhSachDatBan.DataSource != null)
                {
                    table.DefaultView.RowFilter = string.Format("TINHTRANG LIKE '%{0}%'", cbbTinhTrang.SelectedItem.ToString());
                }
            } 
        }
        public bool ValidateInputs()
        {
            // Kiểm tra khách hàng có được chọn không
            if (cbbKhachHang.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return false;
            }

            // Kiểm tra thời gian nhận bàn có hợp lệ không
            DateTime selectedTime = dtpNgayNhanBan.Value.AddHours(int.Parse(ccbGio.Text)).AddMinutes(int.Parse(ccbPhut.Text));
            if (selectedTime <= DateTime.Now)
            {
                MessageBox.Show("Thời gian nhận bàn không được nhỏ hơn thời gian hiện tại.");
                return false;
            }

            // Nếu tất cả điều kiện hợp lệ
            return true;
        }

    }
}
