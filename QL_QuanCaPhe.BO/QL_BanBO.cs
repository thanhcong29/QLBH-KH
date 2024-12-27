using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCaPhe.BO 
{
    //Quản lý Bàn
    public class QL_BanBO
    {

        public QL_BanBO() { }

        public int intMaBan = 0; 
        public int MaBan
        { 
            get { return intMaBan; }
            set { intMaBan = value; }
        }


        private string strTenBan = string.Empty;
        public string TenBan
        {
            get { return strTenBan; }
            set { strTenBan = value; }
        }
        public int SoChoNgoi { get; set; }

        private string strTrangThai = string.Empty;
        public string TrangThai
        {
            get { return strTrangThai; }
            set { strTrangThai = value; }
        }
        private string strMaKhuVuc = string.Empty;
        public string MaKhuVuc
        {
            get { return strMaKhuVuc; }
            set { strMaKhuVuc = value; }
        }

        private string strTenKhuVuc = string.Empty;

        public string TenKhuVuc
        {
            get { return strTenKhuVuc; }
            set { strTenKhuVuc = value; }
        }
    }
}
