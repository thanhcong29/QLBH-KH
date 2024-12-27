using Microsoft.Office.Interop.Excel;
using QL_QuanCaPhe.BLL;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace QL_QuanCaPhe
{
    public partial class frmLuongQL_ChamCong : Form
    {
        LuongNV_BLL1 luongBLL = new LuongNV_BLL1();
        public frmLuongQL_ChamCong()
        {
            InitializeComponent();
            //frmQuanLyLuongNV luong = new frmQuanLyLuongNV;
            //luong.MaBL = 
        }
        public string UserName { get; set; }
        //khai bao o day thoi
        public string MaBL { get; set; }
        public string MaNV { get; set; }
        public string MaCa { get; set; }

        public DateTime NgayPL { get; set; }

        private void frmLuongQL_ChamCong_Load(object sender, EventArgs e)
        {
            cbox_MaCC.DataSource = luongBLL.LoadChamCong();
            cbox_MaCC.DisplayMember = "TENBANGCHAMCONG";
            cbox_MaCC.ValueMember = "MACHAMCONG";

            data_gv_ChamCong.DataSource = luongBLL.LoadChamCongLUONG_TheoMaQL(MaBL, MaNV);
        }


        private void btnLuuChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (MaCa.Length < 0 || MaBL.Length < 0 || MaNV.Length < 0 || cbox_MaCC.SelectedIndex < 0 || txtNgayLam_QL.Text == string.Empty)
                {
                    MessageBox.Show("Mời bạn chọn dữ liệu");
                }
                else
                {

                    DateTime ngaylamQL = DateTime.Parse(txtNgayLam_QL.Text);
                    DateTime ngayPLQL = NgayPL;

                    if (ngaylamQL > ngayPLQL)
                    {
                        MessageBox.Show("Ngày làm phải nhỏ hơn ngày phát lương!", "Thông báo");
                    }
                    else

                    {
                        string macc = cbox_MaCC.SelectedValue.ToString();
                        string mabl = MaBL.ToString();
                        string manv = MaNV.ToString();
                        string maca = MaCa.ToString();
                        string ngaylam = txtNgayLam_QL.Text;
                        string ghichu = txtGhiChu_ChamCong.Text;

                        if (luongBLL.KTRAKHOACHINHChamCongLUONGQL(macc, mabl, manv, maca, ngaylam))
                        {
                            if (luongBLL.Them_CHAMCONGBANGLUONGQL(macc, mabl, manv, maca, ngaylam, ghichu))
                            {
                                MessageBox.Show("Thêm Thành Công");
                                data_gv_ChamCong.DataSource = luongBLL.LoadChamCongLUONG_TheoMaQL(mabl, manv);
                                btnXoaChamCong.Enabled = true;

                            }

                        }
                        else
                        {
                            MessageBox.Show("Trùng Khóa Chính");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai!");
            }
        }

        private void btnXoaChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbox_MaCC.SelectedIndex < 0)
                {
                    MessageBox.Show("Mời Click vào bảng");
                }
                else
                {
                    string macc = cbox_MaCC.SelectedValue.ToString();
                    string mabl = MaBL.ToString();
                    string manv = MaNV.ToString();
                    string maca = MaCa.ToString();
                    string ngaylam = txtNgayLam_QL.Text;
                    if (luongBLL.XoaChamCongBangLuongQL(macc, mabl, manv, maca, ngaylam))
                    {
                        MessageBox.Show("Xóa Thành Công");
                        data_gv_ChamCong.DataSource = luongBLL.LoadChamCongLUONG_TheoMaQL(mabl, manv);


                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa được");

                    }
                }
            }
            catch
            {

            }
        }

        private void data_gv_ChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbox_MaCC.Text = data_gv_ChamCong.CurrentRow.Cells[0].Value.ToString();
            txtNgayLam_QL.Text = data_gv_ChamCong.CurrentRow.Cells[4].Value.ToString();
            txtGhiChu_ChamCong.Text = data_gv_ChamCong.CurrentRow.Cells[5].Value.ToString();
            btnLuuChamCong.Enabled = true;
        }
    }
}
