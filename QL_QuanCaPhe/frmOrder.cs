using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }
        Color UnreadTextColor = Color.FromArgb(248, 124, 50);
        Color red = Color.FromArgb(255, 0, 0);
        Color green = Color.FromArgb(0, 255, 0);
        Color blue = Color.FromArgb(0, 0, 255);

        
        private void LoadData()
        {
            SqlConnection cnn = new SqlConnection("Data Source=DOTHANHTUNG;Initial Catalog=QuanLyQuanCafe;Integrated Security=True");

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.Menu", cnn);
            da.Fill(dt);
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            //SqlConnection cnn = new SqlConnection("Data Source=165079-NVMUOI;Initial Catalog=QuanLyQuanCafe;Integrated Security=True");

            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.Menu", cnn);
            //da.Fill(dt);

            //List<clsMenu> lt = new List<clsMenu>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    try
            //    {
            //        clsMenu m = new clsMenu();
            //        m.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            //        m.Name = dt.Rows[i]["Name"].ToString();
            //        m.GiaBan = Convert.ToDecimal(dt.Rows[i]["GiaBan"].ToString());
            //        m.LoaiID = Convert.ToInt32(dt.Rows[i]["LoaiID"]);
            //        string hinhanh = Convert.ToString(dt.Rows[i]["HinhAnh"]);
            //        if (hinhanh != null)
            //        {
            //            //MemoryStream st = new MemoryStream(hinhanh.ToArray());
            //            //m.HinhAnh = Image.FromStream(st);
            //            m.HinhAnh = ByteToImg(dt.Rows[i]["HinhAnh"].ToString());
            //        }
            //        else
            //            m.HinhAnh = Image.FromFile(Application.StartupPath + @"\ErrorImage.png");
            //        lt.Add(m);
            //    }
            //    catch { }
            //}
            //gcMenu.DataSource = lt;
        }
        // chuyển string thành Image
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtMaBan.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            //BanBLL banBLL = new BanBLL();
            //BanBO banBO = banBLL.LayThongTinBan(int.Parse(txtMaBan.Text));

            //txtTenBan.Text = banBO.TenBan;
            //txtTrangThai.Text = banBO.TrangThai;

            //txtTenBan.Text = banBO.MaKhuVuc;


        }
    }

    public class clsMenu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal GiaBan { get; set; }
        public Image HinhAnh { get; set; }
        public int LoaiID { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }
    }
}
