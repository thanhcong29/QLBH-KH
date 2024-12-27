using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
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
    public partial class frmHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        NguoiDungNhomNguoiDungBLL objNguoiDungNhomNguoiDungBLL = new NguoiDungNhomNguoiDungBLL();
        PhanQuyenBLL objPhanQuyenBLL = new PhanQuyenBLL();
        public string TenDangNhap { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string Quyen { get; set; }
        public frmHome()
        {
            InitializeComponent();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDMManHinh frm = new frmDMManHinh();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNguoiDung frm = new frmNguoiDung();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNhomNguoiDung frm = new frmNhomNguoiDung();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmXemThongTinBan frm = new frmXemThongTinBan();
            frm.MaNhanVien = MaNhanVien;
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblNhanVien.Caption = MaNhanVien + " - " + TenNhanVien;
            lblQuyen.Caption = Quyen;

            // Phân quyền
            List<string> nhomND = objNguoiDungNhomNguoiDungBLL.GetMaNhomNguoiDung(TenDangNhap);

            foreach (string item in nhomND)
            {
                DataTable dsQuyen = objPhanQuyenBLL.GetMaManHinh(item);
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    FindMenuPhanQuyen(this.ribbon.Pages, mh[1].ToString(), Convert.ToBoolean(mh[2].ToString()));
                    //FindMenuGroupPhanQuyen(this.ribbHeThong.Groups, mh[1].ToString(), Convert.ToBoolean(mh[2].ToString()));
                }
            }

            frmXemThongTinBan frm = new frmXemThongTinBan();
            frm.MaNhanVien = MaNhanVien;
            frm.MdiParent = this;
            frm.Show();
        }
        private void FindMenuPhanQuyen(RibbonPageCollection items, string pScreenName, bool pEnable)
        {
            foreach (RibbonPage menu in items)
            {
                if (string.Equals(pScreenName, menu.Tag))
                {
                    menu.Visible = pEnable;
                }

            }
        }
        private void FindMenuGroupPhanQuyen(RibbonPageGroupCollection items, string pScreenName, bool pEnable)
        {
            foreach (RibbonPageGroup menu in items)
            {
                if (string.Equals(pScreenName, menu.Tag))
                {
                    menu.Visible = pEnable;
                }

            }
        }

        private void btnDX_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn đăng xuất tài khoản này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                frmDangNhap dangNhap = new frmDangNhap();
                dangNhap.Show();
                this.Close();
            }
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void btnQLTD_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyThucDon frm = new frmQuanLyThucDon();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnQLKM_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyKhuyenMai frm = new frmQuanLyKhuyenMai();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnQLNL_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyNguyenLieu frm = new frmQuanLyNguyenLieu();
            frm.UserName = lblNhanVien.Caption;
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnQLKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmDatBan frm = new frmDatBan();
            frm.MaNhanVien = MaNhanVien;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ktrBtn = false;
            frm.Show();
        }

        private void btnTKDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTKDTTheoTG frm = new frmTKDTTheoTG();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTKMatHangBanChay frm = new frmTKMatHangBanChay();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnQLB_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyBan_KhuVuc frm = new frmQuanLyBan_KhuVuc();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void btnCC_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    frmQuanLyLuonNV1 frm = new frmQuanLyLuonNV1();
        //    frm.TenNhanVien = lblNhanVien.Caption;
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        private void barButtonItem7_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmSaoLuu frm = new frmSaoLuu();
            frm.ShowDialog();
        }

        private void btnCC_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmQuanLyLuonNV1 frm = new frmQuanLyLuonNV1();
            frm.TenNhanVien = lblNhanVien.Caption;
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnDanhSachHD_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmXemHoaDon frm = new frmXemHoaDon();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}