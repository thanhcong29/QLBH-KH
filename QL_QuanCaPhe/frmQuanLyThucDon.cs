using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmQuanLyThucDon : Form
    {
        LoaiMonBLL objLoaiMonBLL = new LoaiMonBLL();
        ThucDonBLL objThucDonBLL = new ThucDonBLL();
        ChiTietThucDonBLL objChiTietThucDonBLL = new ChiTietThucDonBLL();
        public frmQuanLyThucDon()
        {
            InitializeComponent();
        }

        bool them = false;
        bool bolIsThemLoai = true;
        private string FileName = null;
        private void frmQuanLyThucDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            LoadDanhMuc();

            txtMaMon.ReadOnly = true;
            txtTenMon.ReadOnly = true;
            txtDVT.ReadOnly = true;
            txtGia.ReadOnly = true;
            cbbLoai.Enabled = false;
            cbbSize.Enabled = false;
            txtHinhAnh.ReadOnly = true;
            txtTenMon2.ReadOnly = true;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            btnUpImg.Visible = false;

            dtgvDS.Enabled = true;
            cbbSize.Items.Clear();
            cbbSize.Text = "Chọn Size";
            txtMaMon.ResetText();
            txtTenMon.ResetText();
            txtMaMon2.ResetText();
            txtTenMon2.ResetText();
            txtDVT.ResetText();
            txtGia.ResetText();
            cbbLoai.ResetText();
            
            txtHinhAnh.ResetText();

            

            txtHinhAnh.ReadOnly = true;
            txtTenMon2.ReadOnly = true;

            tabTableLoai.SelectedTab = tabDS;
            tabctlThongTin.SelectedTab = tabTTMon;
            grbQLDM.Enabled = true;
            grctrlQLMon.Enabled = true;
            pictureBox1.Image = global::QL_QuanCaPhe.Properties.Resources.error_Image1;
        }

        private void LoadDanhMuc()
        {
            trvDMMon.Nodes.Clear();
            DataTable dt = objLoaiMonBLL.LoadData();
            trvDMMon.Nodes.Add("Tất Cả");
            foreach (DataRow dr in dt.Rows)
            {
                trvDMMon.Nodes.Add(dr["MALOAI"].ToString() + " - " + dr["TENLOAI"].ToString());
            }
        }

        private void trvDMMon_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(trvDMMon.SelectedNode.Text == "Tất Cả")
            {
                dtgvDS.DataSource = objThucDonBLL.SearchData(-1, "NULL");
            }
            else
            {
                string MaLoai = trvDMMon.SelectedNode.Text.Substring(0, 4);
                dtgvDS.DataSource = objThucDonBLL.SearchTheoLoai(MaLoai);
            }    
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
         {
            txtMaMon.Text = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            txtTenMon.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            txtDVT.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString();
            cbbLoai.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
            txtHinhAnh.Text = dtgvDS.CurrentRow.Cells[4].Value.ToString();

            objChiTietThucDonBLL.LoadCbbSize(cbbSize, txtMaMon.Text);
            cbbSize.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            try
            {
                string strHinhAnh = dtgvDS.CurrentRow.Cells[4].Value.ToString();
                if (strHinhAnh != "")
                {
                    var request = WebRequest.Create(strHinhAnh);
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
                else
                {
                    pictureBox1.Image = global::QL_QuanCaPhe.Properties.Resources.error_Image1;
                }
            }
            catch
            {
                pictureBox1.Image = global::QL_QuanCaPhe.Properties.Resources.error_Image1;
            }

            tabctlThongTin.SelectedTab = tabTTMon;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMaMon.ReadOnly = true;
            txtTenMon.ReadOnly = false;
            txtDVT.ReadOnly = false;
            txtGia.ReadOnly = false;
            cbbLoai.Enabled = true;
            cbbSize.Enabled = true;
            txtHinhAnh.ReadOnly = false;
            txtTenMon2.ReadOnly = false;

            txtMaMon.Text = objThucDonBLL.TaoMaTuTang();
            txtTenMon.ResetText();
            txtDVT.ResetText();
            txtGia.ResetText();
            cbbLoai.Text = "Chọn loại món";
            txtHinhAnh.ResetText();
            objLoaiMonBLL.LoadCBBLoaiMon(cbbLoai);
            
            pictureBox1.Image = global::QL_QuanCaPhe.Properties.Resources.error_Image1;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            btnUpImg.Visible = true;

            dtgvDS.Enabled = false;
            grbQLDM.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có chắc muốn xóa món " + txtMaMon.Text + " - " + txtTenMon.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(xoa == DialogResult.Yes)
            {
                if(objThucDonBLL.Delete(txtMaMon.Text))
                {
                    MessageBox.Show("Xóa thành công món " + txtMaMon.Text + " - " + txtTenMon.Text, "Thông báo");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            them = false;

            // tab thông tin món
            txtMaMon.ReadOnly = true;
            txtTenMon.ReadOnly = false;
            txtDVT.ReadOnly = false;
            txtGia.ReadOnly = false;
            cbbLoai.Enabled = true;
            cbbSize.Enabled = true;
            txtHinhAnh.ReadOnly = false;
            txtTenMon2.ReadOnly = false;

            objLoaiMonBLL.LoadCBBLoaiMon(cbbLoai);

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            btnUpImg.Visible = true;

            // tab size
            txtTenMon2.ReadOnly = true;
            cbbSize.Enabled = false;

            btnThemSize.Enabled = false;
            btnXoaSize.Enabled = false;
            btnSuaSize.Enabled = false;
            btnReLoadSize.Enabled = false;
            btnLuuSize.Enabled = false;
            btnHuySize.Enabled = false;

            // bên ngoài tab
            dtgvDS.Enabled = false;
            grbQLDM.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThucDonBO objThucDonBO = new ThucDonBO();
            objThucDonBO.MaMon = txtMaMon.Text;
            objThucDonBO.TenMon = txtTenMon.Text;
            objThucDonBO.DVT = txtDVT.Text;
            objThucDonBO.MaLoai = cbbLoai.Text.Substring(0,4);
            objThucDonBO.HinhAnh = txtHinhAnh.Text;
            if(them)
            {
                if(objThucDonBLL.Insert(objThucDonBO))
                {
                    MessageBox.Show("Thêm thành công món " + txtMaMon.Text + " - " + txtTenMon.Text, "Thông báo");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            else if(!them)
            {
                if (objThucDonBLL.Update(objThucDonBO))
                {
                    MessageBox.Show("Cập nhật thành công món " + txtMaMon.Text, "Thông báo");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void EditLoaiMon()
        {
            txtMaLoai.Text = trvDMMon.SelectedNode.Text.Substring(0, 4);
            txtTenLoai.Text = trvDMMon.SelectedNode.Text.Remove(0, 7);
            bolIsThemLoai = false;
            txtTenLoai.Focus();
        }

        private void trvDMMon_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(trvDMMon.SelectedNode.Text != "Tất Cả")
            {
                EditLoaiMon();
                tabTableLoai.SelectedTab = tabXuLy;
                txtTenLoai.Focus();
            }    
        }

        private void tabTableLoai_Selected(object sender, TabControlEventArgs e)
        {
            if (tabTableLoai.SelectedTab == tabDS)
            {
                txtMaLoai.ResetText();
                txtTenLoai.ResetText();
                grctrlQLMon.Enabled = true;
                bolIsThemLoai = true;
            }
            else
            {
                grctrlQLMon.Enabled = false;
            }    
        }

        private void btnLuuLoai_Click(object sender, EventArgs e)
        {
            LoaiMonBO objLoaiMonBO = new LoaiMonBO();
            if(bolIsThemLoai)
            {
                try 
                {
                    objLoaiMonBO.MaLoai = objLoaiMonBLL.TaoMaLoaiMon();
                    objLoaiMonBO.TenLoai = txtTenLoai.Text.Trim();
                    DialogResult them = MessageBox.Show("Bạn có muốn thêm loại món " + txtTenLoai.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(them == DialogResult.Yes)
                    {
                        if (objLoaiMonBLL.Insert(objLoaiMonBO))
                        {
                            MessageBox.Show("Thêm loại món thành công", "Thông báo", MessageBoxButtons.OK);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm loại món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi thêm loại món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            else
            {
                try
                {
                    objLoaiMonBO.MaLoai = txtMaLoai.Text.Trim();
                    objLoaiMonBO.TenLoai = txtTenLoai.Text.Trim();
                    DialogResult them = MessageBox.Show("Bạn có muốn cập nhật loại món " + txtMaLoai.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (them == DialogResult.Yes)
                    {
                        if (objLoaiMonBLL.Update(objLoaiMonBO))
                        {
                            MessageBox.Show("Cập nhật loại món thành công", "Thông báo", MessageBoxButtons.OK);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật loại món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi cập nhật loại món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa loại món " + txtMaLoai.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.Yes)
            {
                if (objLoaiMonBLL.Delete(txtMaLoai.Text.Trim()))
                {
                    MessageBox.Show("Xóa loại món thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa loại món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbbSize_TextChanged(object sender, EventArgs e)
        {
            if(!bolIsThemLoai)
            {
                if (cbbSize.Text != "Chọn Size")
                {
                    DataTable dt = objChiTietThucDonBLL.LayChiTiet(txtMaMon.Text, cbbSize.Text);
                    txtGia.Text = dt.Rows[0]["GIA"].ToString();

                    btnSuaSize.Enabled = true;
                    btnXoaSize.Enabled = true;
                }
                else
                {
                    txtGia.ResetText();
                    btnSuaSize.Enabled = false;
                    btnXoaSize.Enabled = false;
                }
            }
            if(cbbSize.Text == "Chọn Size")
            {
                btnSuaSize.Enabled = false;
                btnXoaSize.Enabled = false;
            }    
        }
        private void LoadCbbSizeKhiThem()
        {
            try
            {
                // Thêm các size từ S, M, L, XL vào cbb
                for (int i = cbbSize.Items.Count - 1; i >= 0; i--)
                {
                    cbbSize.Items.RemoveAt(i);
                }
                cbbSize.Items.Add("S");
                cbbSize.Items.Add("M");
                cbbSize.Items.Add("L");
                cbbSize.Items.Add("XL");
                // Kiểm tra Món đã có Size hay chưa, nếu có xóa Size đã có khỏi cbb
                DataTable dt = objChiTietThucDonBLL.LoadDataTheoMon(txtMaMon2.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    string strSize = dr["Size"].ToString().Trim();
                    for (int i = cbbSize.Items.Count - 1; i >= 0; i--)
                    {
                        if (cbbSize.Items[i].Equals(strSize))
                        {
                            cbbSize.Items.RemoveAt(i);
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show("Lỗi load danh sách size khi thêm", "Thông báo");
            }
        }

        private void btnThemFile_Click(object sender, EventArgs e)
        {
            
        }

        private void txtHinhAnh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtHinhAnh.Text != "")
                {
                    var request = WebRequest.Create(txtHinhAnh.Text);
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
                else
                {
                    pictureBox1.Image = global::QL_QuanCaPhe.Properties.Resources.error_Image1;
                }
            }
            catch
            {
                pictureBox1.Image = global::QL_QuanCaPhe.Properties.Resources.error_Image1;
            }
            
        }

        private void tabctlThongTin_Selected(object sender, TabControlEventArgs e)
        {
            if(tabctlThongTin.SelectedTab == tabCTMon)
            {
                bolIsThemLoai = false;
                txtMaMon2.Text = txtMaMon.Text;
                txtTenMon2.Text = txtTenMon.Text;

                if(txtMaMon.Text != "" && !bolIsThemLoai)
                {
                    objChiTietThucDonBLL.LoadCbbSize(cbbSize, txtMaMon.Text);
                }

                btnLuuSize.Enabled = false;
                btnSuaSize.Enabled = false;
                btnXoaSize.Enabled = false;
            }
            else
            {
                bolIsThemLoai = false;
                txtGia.ReadOnly = true;

                btnThemSize.Enabled = true;
                btnXoaSize.Enabled = true;
                btnSuaSize.Enabled = true;
                btnReLoadSize.Enabled = true;
                btnLuuSize.Enabled = false;
                btnHuySize.Enabled = true;

                grbQLDM.Enabled = true;
                dtgvDS.Enabled = true;
            }    
        }

        private void btnThemSize_Click(object sender, EventArgs e)
        {
            bolIsThemLoai = true;
            LoadCbbSizeKhiThem();
            txtGia.ResetText();
            txtGia.ReadOnly = false;

            btnThemSize.Enabled = false;
            btnXoaSize.Enabled = false;
            btnSuaSize.Enabled = false;
            btnReLoadSize.Enabled = true;
            btnLuuSize.Enabled = true;
            btnHuySize.Enabled = true;
            grbQLDM.Enabled = false;
            dtgvDS.Enabled = false;
        }

        private void btnSuaSize_Click(object sender, EventArgs e)
        {
            if (cbbSize.Text == "Chọn Size")
            {
                MessageBox.Show("Bạn chưa chọn Size cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bolIsThemLoai = false;
            txtGia.ReadOnly = false;
            cbbSize.Enabled = false;

            btnThemSize.Enabled = false;
            btnXoaSize.Enabled = false;
            btnSuaSize.Enabled = false;
            btnReLoadSize.Enabled = true;
            btnLuuSize.Enabled = true;
            btnHuySize.Enabled = true;
            grbQLDM.Enabled = false;
            dtgvDS.Enabled = false;

            
        }

        private void btnXoaSize_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa Size " + cbbSize.Text + " của món " + txtTenMon2.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.Yes)
            {
                if (objChiTietThucDonBLL.Delete(cbbSize.Text, txtMaMon2.Text.Trim()))
                {
                    MessageBox.Show("Xóa thành công " + cbbSize.Text + " của món " + txtTenMon2.Text, "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa Size thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuuSize_Click(object sender, EventArgs e)
        {
            if(bolIsThemLoai)
            {
                try
                {
                    ChiTietThucDonBO objChiTietThucDonBO = new ChiTietThucDonBO();
                    objChiTietThucDonBO.MaCTMon = objChiTietThucDonBLL.TaoMaChiTietThucDon(txtMaMon2.Text);
                    objChiTietThucDonBO.Size = cbbSize.Text;
                    objChiTietThucDonBO.Gia = float.Parse(txtGia.Text);
                    objChiTietThucDonBO.MaMon = txtMaMon2.Text;
                    if (objChiTietThucDonBLL.Insert(objChiTietThucDonBO))
                    {
                        MessageBox.Show("Thêm thành công món " + txtTenMon2.Text + " - Size: " + cbbSize.Text, "Thông báo");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Size cho món" + txtTenMon2.Text + " thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi khi thêm Size", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
            else
            {
                try
                {
                    ChiTietThucDonBO objChiTietThucDonBO = new ChiTietThucDonBO();
                    objChiTietThucDonBO.Size = cbbSize.Text;
                    objChiTietThucDonBO.Gia = float.Parse(txtGia.Text);
                    objChiTietThucDonBO.MaMon = txtMaMon2.Text;
                    if (objChiTietThucDonBLL.Update(objChiTietThucDonBO))
                    {
                        MessageBox.Show("Sửa thành công món " + txtTenMon2.Text + " - Size: " + cbbSize.Text, "Thông báo");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Sửa giá cho món" + txtTenMon2.Text + " thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi khi cập nhật giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnReLoadSize_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtHinhAnh.Text = "http://kltnquanlyquancaphe.somee.com/HinhAnh/" + Path.GetFileName(open.FileName);
                upLoadFile(open.FileName);
            }
        }
        private void upLoadFile(string filename)
        {
            try
            {
                var client = new WebClient();
                var uri = new Uri("http://kltnquanlyquancaphe.somee.com/Home.aspx");
                {
                    client.Headers.Add("fileName", System.IO.Path.GetFileName(filename));
                    client.UploadFileAsync(uri, filename);
                    MessageBox.Show("Tải hình ảnh thành công, xem đường dẫn hình ảnh tại textbox Hình Ảnh");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hình ảnh" + ex.Message);
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
