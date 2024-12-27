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
    public partial class frmNhaCungCap : Form
    {
        NhaCungCapBLL objNhaCungCap = new NhaCungCapBLL();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private bool them = false;
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dtgvDS.DataSource = objNhaCungCap.SearchData(-1, "NULL");

            txtMa.ReadOnly = true;
            txtTen.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            button2.Enabled = true;
            button1.Enabled = true;
        }

        private void dtgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dtgvDS.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dtgvDS.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dtgvDS.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = dtgvDS.CurrentRow.Cells[3].Value.ToString();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            button2.Enabled = true;
            button1.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMa.ReadOnly = true;
            txtTen.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            txtMa.ResetText();
            txtTen.ResetText();
            txtSDT.ResetText();
            txtDiaChi.ResetText();

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            button2.Enabled = true;
            button1.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMa.ReadOnly = true;
            txtTen.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            button2.Enabled = true;
            button1.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa thông tin nhà cung cấp này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.Yes)
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    //if ()
                    //{
                    //    MessageBox.Show("Thêm thông tin nhà cùng cấp thành công", "Thông báo", MessageBoxButtons.OK);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Thêm thông tin nhà cùng cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                catch
                {
                    MessageBox.Show("Lỗi thêm thông tin nhà cùng cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    //if ()
                    //{
                    //    MessageBox.Show("Cập nhật thông tin nhà cùng cấp thành công", "Thông báo", MessageBoxButtons.OK);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Cập nhật thông tin nhà cùng cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                catch
                {
                    MessageBox.Show("Lỗi cập nhật thông tin nhà cùng cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (txtSDT.Text.Length == 10 && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            List<int> lst = new List<int>(new int[] { 09, 03, 07, 08, 05 });
            if (string.IsNullOrEmpty(txtSDT.Text) || txtSDT.Text.Length != 10)
            {
                e.Cancel = true;
                txtSDT.Focus();
                errorProvider.SetError(txtSDT, "Vui lòng nhập số điện thoại gồm 10 số");
            }
            else if (!lst.Contains(Convert.ToInt32(txtSDT.Text.Substring(0, 2))))
            {
                e.Cancel = true;
                txtSDT.Focus();
                errorProvider.SetError(txtSDT, "Số điện thoại không đúng định dạng");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtSDT, null);
            }
        }
    }
}
