using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NET_QLKS.Model;

namespace NET_QLKS
{
    public partial class TrangChu : Form
    { 
        DB_GTXQLKS DB = new DB_GTXQLKS();
        public string UserCurrent { get;set; }
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            var USER = DB.NHANVIENs.FirstOrDefault(x => x.TENTK.Equals(UserCurrent));
            Title.Text = Title.Text + USER.NHOMQUYEN.PHANQUYEN.CHUCNANG + " " + USER.TENNV;
            TenUser.Text = USER.TENNV;
            ChucVuUser.Text = USER.NHOMQUYEN.PHANQUYEN.CHUCNANG;
            NgSinhUser.Text = USER.NGAYSINH.ToString();
            QueQuanUser.Text = USER.QUEQUAN;
            DTUser.Text = USER.SDT;
            EmailUser.Text = USER.EMAIL;
            DiaChiUser.Text = USER.DIACHI;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DangNhap LoginForm = new DangNhap();
            this.Hide();
            LoginForm.ShowDialog();
        }
    }
}
