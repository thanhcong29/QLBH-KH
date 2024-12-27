using DevExpress.XtraSplashScreen;
using QL_QuanCaPhe.BLL;
using QL_QuanCaPhe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmQuanLyKhuyenMai : Form
    {
        GiamGiaBLL objGiamGiaBLL = new GiamGiaBLL();
        KhachHangBLL objKhachHangBLL = new KhachHangBLL();
        public frmQuanLyKhuyenMai()
        {
            InitializeComponent();
        }
        private bool them = false;
        private void rdoSoTien_CheckedChanged(object sender, EventArgs e)
        {
            if (them)
                txtToiDa.ReadOnly = true;
        }

        private void rdoPhanTram_CheckedChanged(object sender, EventArgs e)
        {
            if (them)
                txtToiDa.ReadOnly = false;
        }

        private void LoadData()
        {
            dtgvDS.DataSource = objGiamGiaBLL.SearchData("0");

            txtMaGiam.ReadOnly = true;
            txtGiam.ReadOnly = true;
            txtToiDa.ReadOnly = true;
            txtNgayBD.ReadOnly = true;
            txtNgayKT.ReadOnly = true;
            txtSoLuot.ReadOnly = true;
            //rdoPhanTram.Checked = false;
            //rdoSoTien.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnXuatExcel.Enabled = false;
        }
        private void frmQuanLyKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaGiam.Text = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            txtGiam.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            txtToiDa.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
            txtNgayBD.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString().Substring(0, 10);
            txtNgayKT.Text = dtgvDS.CurrentRow.Cells[4].Value.ToString().Substring(0, 10);
            txtSoLuot.Text = dtgvDS.CurrentRow.Cells[5].Value.ToString();

            if (Convert.ToInt32(txtGiam.Text) > 100)
            {
                rdoSoTien.Checked = true;
            }
            else
            {
                rdoPhanTram.Checked = true;
            }

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnXuatExcel.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMaGiam.Focus();
            txtMaGiam.ResetText();
            txtGiam.ResetText();
            txtToiDa.ResetText();
            txtNgayBD.ResetText();
            txtNgayKT.ResetText();
            txtSoLuot.ResetText();

            txtMaGiam.ReadOnly = false;
            txtMaGiam.ReadOnly = false;
            txtGiam.ReadOnly = false;
            txtToiDa.ReadOnly = false;
            txtNgayBD.ReadOnly = false;
            txtNgayKT.ReadOnly = false;
            txtSoLuot.ReadOnly = false;

            rdoPhanTram.Checked = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnXuatExcel.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
          
            txtMaGiam.ReadOnly = true;
            txtMaGiam.ReadOnly = false;
            txtGiam.ReadOnly = false;
            txtToiDa.ReadOnly = false;
            txtNgayBD.ReadOnly = false;
            txtNgayKT.ReadOnly = false;
            txtSoLuot.ReadOnly = false;

            rdoPhanTram.Checked = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnReload.Enabled = true;
            btnXuatExcel.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa mã giảm giá này chứ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.Yes)
            {
                try
                {
                    if (objGiamGiaBLL.Delete(txtMaGiam.Text))
                    {
                        MessageBox.Show("Xóa mã giảm giá thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mã giảm giá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi xóa mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValiDateUpdate()
        {
            if (string.IsNullOrEmpty(txtMaGiam.Text))
            {
                MessageBox.Show("Vui lòng nhập mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGiam.Focus();
                return false;
            }           
            if (string.IsNullOrEmpty(txtGiam.Text))
            {
                MessageBox.Show("Nhập giá trị của mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiam.Focus();
                return false;
            }
            if(rdoPhanTram.Checked)
            {
                if (string.IsNullOrEmpty(txtToiDa.Text))
                {
                    MessageBox.Show("Nhập số tiền tối đa được giảm mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtToiDa.Focus();
                    return false;
                }
                if (Convert.ToInt32(txtGiam.Text) > 100)
                {
                    MessageBox.Show("Giá trị giảm theo phần trăm không được lớn hơn 100", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiam.Focus();
                    return false;
                }
            }    
            if (string.IsNullOrEmpty(txtNgayBD.Text))
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayBD.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNgayKT.Text))
            {
                MessageBox.Show("Vui lòng chọn ngày kết thúc giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayKT.Focus();
                return false;
            }
            DateTime bd = Convert.ToDateTime(txtNgayBD.Text);
            DateTime now = DateTime.Now;
            TimeSpan Time = bd - now;
            int TongSoNgay = Time.Days;          
            if (TongSoNgay < 0)
            {
                MessageBox.Show("Ngày bắt đầu không được nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayBD.Focus();
                return false;
            }
            if (Convert.ToDateTime(txtNgayKT.Text) <= Convert.ToDateTime(txtNgayBD.Text))
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayKT.Focus();
                return false;
            }
            else
            {
                return true;
            }    
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValiDateUpdate()) return;
                else
                {
                    GiamGiaBO objGiamGiaBO = new GiamGiaBO();
                    objGiamGiaBO.MaGiamGia = txtMaGiam.Text.Trim();
                    objGiamGiaBO.Giam = Convert.ToInt32(txtGiam.Text);
                    if (rdoPhanTram.Checked)
                        objGiamGiaBO.GiamToiDa = Convert.ToInt32(txtToiDa.Text);
                    objGiamGiaBO.NgayBatDau = Convert.ToDateTime(txtNgayBD.Text);
                    objGiamGiaBO.NgayKetThuc = Convert.ToDateTime(txtNgayKT.Text);
                    if (txtSoLuot.Text != "")
                        objGiamGiaBO.SoLuot = Convert.ToInt32(txtSoLuot.Text);

                    if (them)
                    {
                        try
                        {
                            if (objGiamGiaBLL.Insert(objGiamGiaBO))
                            {
                                MessageBox.Show("Thêm mã giảm giá thành công", "Thông báo", MessageBoxButtons.OK);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Thêm mã giảm giá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi thêm mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {

                            if (objGiamGiaBLL.Update(objGiamGiaBO))
                            {
                                MessageBox.Show("Cập nhật thông tin mã giảm giá thành công", "Thông báo", MessageBoxButtons.OK);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thông tin mã giảm giá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi cập nhật thông tin mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi thêm mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdoPhanTram.Checked)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
                if (txtGiam.Text.Length == 3 && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtMaGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtMaGiam.Text.Length == 10 && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }    
        }

        private void txtToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdoPhanTram.Checked)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void txtSoLuot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length == 10 && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiam_Validating(object sender, CancelEventArgs e)
        {
            //
        }

        private void txtToiDa_Validating(object sender, CancelEventArgs e)
        {
            //
        }

        private void txtMaGiam_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                DataTable dt = objKhachHangBLL.SearchData(-1, "NULL", 0);
                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    string _from = "thecoffeeql@gmail.com"; // Email của Sender (của bạn)
                    string _pass = "123451211_Nm"; // Mật khẩu Email của Sender 
                    string sendto = ""; //: Email receiver (người nhận)
                    string subject = "";//: Tiêu đề email
                    string content = "";//: Nội dung của email, bạn có thể viết mã HTML
                    
                    if (dt != null && dt.Rows.Count > 1)
                    {
                        for (int i = 0; i < dt.Rows.Count / 2; i++)
                        {
                            sendto = dt.Rows[i]["EMAIL"].ToString();
                            string ten = dt.Rows[i]["TENKHACHHANG"].ToString();
                            subject = "Xin chào " + ten + "";
                            if (rdoPhanTram.Checked)
                                content = "Quán cà phê THE COFFEE xin gửi bạn mã khuyến mãi " + txtMaGiam.Text + " giảm " + txtGiam.Text + " % tối đa " + txtToiDa.Text + " VNĐ trên hóa đơn có hiệu lực từ ngày " + txtNgayBD.Text + " đến ngày " + txtNgayKT.Text + ". Xin cảm ơn bạn đã ủng hộ quán !";
                            if (rdoSoTien.Checked)
                                content = "Quán cà phê THE COFFEE xin gửi bạn mã khuyến mãi " + txtMaGiam.Text + " giảm " + txtGiam.Text + " VNĐ trên hóa đơn có hiệu lực từ ngày " + txtNgayBD.Text + " đến ngày " + txtNgayKT.Text + ". Xin cảm ơn bạn đã ủng hộ quán !";
                            if (sendto != "")
                            {
                                SendMail(_from, sendto, subject, content, _pass);
                            }
                        }
                    }
                });
                thread.Start();
                System.Threading.Thread thread2 = new System.Threading.Thread(() =>
                {
                    string _from = "thecoffeeql@gmail.com"; // Email của Sender (của bạn)
                    string _pass = "123451211_Nm"; // Mật khẩu Email của Sender 
                    string sendto = ""; //: Email receiver (người nhận)
                    string subject = "";//: Tiêu đề email
                    string content = "";//: Nội dung của email, bạn có thể viết mã HTML
                    if (dt != null && dt.Rows.Count > 1)
                    {
                        for (int i = dt.Rows.Count / 2; i < dt.Rows.Count; i++)
                        {
                            sendto = dt.Rows[i]["EMAIL"].ToString();
                            string ten = dt.Rows[i]["TENKHACHHANG"].ToString();
                            subject = "Xin chào " + ten + "";
                            if (rdoPhanTram.Checked)
                                content = "Quán cà phê THE COFFEE xin gửi bạn mã khuyến mãi " + txtMaGiam.Text + " giảm " + txtGiam.Text + " % tối đa " + txtToiDa.Text + " VNĐ trên hóa đơn có hiệu lực từ ngày " + txtNgayBD.Text + " đến ngày " + txtNgayKT.Text + ". Xin cảm ơn bạn đã ủng hộ quán !";
                            if (rdoSoTien.Checked)
                                content = "Quán cà phê THE COFFEE xin gửi bạn mã khuyến mãi " + txtMaGiam.Text + " giảm " + txtGiam.Text + " VNĐ trên hóa đơn có hiệu lực từ ngày " + txtNgayBD.Text + " đến ngày " + txtNgayKT.Text + ". Xin cảm ơn bạn đã ủng hộ quán !";
                            if (sendto != "")
                            {
                                SendMail(_from, sendto, subject, content, _pass);
                            }
                        }
                    }   
                });
                thread2.Start();
                MessageBox.Show("Gửi thành công mã khuyến mãi về mail của khách hàng");
                SplashScreenManager.CloseForm(true);
            }
            catch
            {
                MessageBox.Show("Gửi mã khuyến mãi về mail của khách hàng thất bại");
            }
        }
        private void SendMail(string _from, string sendto, string subject, string content, string _pass)
        {
            //Nếu gửi email thành công, sẽ trả về kết quả: OK, không thành công sẽ trả về thông tin l�-i
            try
            {                              
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(_from);
                mail.To.Add(sendto);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = content;

                mail.Priority = MailPriority.High;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_from, _pass);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
               // MessageBox.Show("Gửi tin nhắn thanh công");
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Lỗi gửi tin nhắn");
            }
        }
    }
}
