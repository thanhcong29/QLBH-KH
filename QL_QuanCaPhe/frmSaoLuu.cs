using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCaPhe
{
    public partial class frmSaoLuu : Form
    {
        public frmSaoLuu()
        {
            InitializeComponent();
        }
        SqlConnection con = QL_QuanCaPhe.BLL.PhanQuyenBLL.con;
        private void btnChon_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.SelectedPath;
                btnSave.Enabled = true;
            }    
        }

        private void frmSaoLuu_Load(object sender, EventArgs e)
        {
            txtDuongDan.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string db = con.Database.ToString();
                if (string.IsNullOrEmpty(txtDuongDan.Text))
                {
                    MessageBox.Show("Vui lòng chọn đường dẫn lưu bản sao lưu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                    string sql = "BACKUP DATABASE [" + db + "] TO DISK = '" + txtDuongDan.Text + "\\" + db + "-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".bak '";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    SplashScreenManager.CloseForm(true);
                    MessageBox.Show("Sao lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi sao lưu dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
    }
}
