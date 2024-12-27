using QL_QuanCaPhe.BLL;
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
    public partial class uscMenu : UserControl
    {
        ChiTietThucDonBLL objChiTietThucDonBLL = new ChiTietThucDonBLL();
        public uscMenu()
        {
            InitializeComponent();
        }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int Gia { get; set; }

        public Image HinhAnh { get; set; } 

        public string CTSize { get; set; }
        private void uscMenu_Load(object sender, EventArgs e)
        {
            pixHinhAnh.Image = HinhAnh;
            lblTenMon.Text = TenMon;
            string gia = objChiTietThucDonBLL.GopGia(MaMon);
            lblGia.Text = "Giá (VNĐ): " + gia.Remove(gia.Length - 2);
            CTSize = objChiTietThucDonBLL.GopSize(MaMon);
            lblSize.Text = "Size: " + CTSize.Remove(CTSize.Length - 2);
        }

        private void uscMenu_MouseHover(object sender, EventArgs e)
        {
            this.Width = 380;            
            this.Height = 190;
            lblTenMon.BackColor = Color.Thistle;
            lblGia.BackColor = Color.Thistle;
            lblSize.BackColor = Color.Thistle;
            panel1.BackColor = Color.Thistle;
            pixHinhAnh.BackColor = Color.Thistle;
        }

        private void uscMenu_MouseLeave(object sender, EventArgs e)
        {
            this.Width = 350;
            this.Height = 180;
            lblTenMon.BackColor = Color.White;
            lblGia.BackColor = Color.White;
            lblSize.BackColor = Color.White;
            panel1.BackColor = Color.White;
            pixHinhAnh.BackColor = Color.White;
        }
    }
}
