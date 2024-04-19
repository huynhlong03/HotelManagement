﻿using System;
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
    public partial class DangNhap : Form
    {
        DB_GTXQLKS DB = new DB_GTXQLKS();
        public DangNhap()
        {
            InitializeComponent();
        }
        private void BTNTENTK_Click(object sender, EventArgs e)
        {
            BTNTENTK.Clear();
        }
        private void BTNTENTK_Leave(object sender, EventArgs e)
        {
            if(BTNTENTK.Text.Trim() == "")
            {
                BTNTENTK.Text = "Nhập tên tài khoản của bạn";
            }    
        }

        private void BTNMK_Click(object sender, EventArgs e)
        {
            BTNMK.Clear();
        }

        private void BTNMK_Leave(object sender, EventArgs e)
        {
            if (BTNMK.Text.Trim() == "")
            {
                BTNMK.Text = "Nhập tên tài khoản của bạn";
            }
        }

        private void BTNLOGIN_Click(object sender, EventArgs e)
        {
            if(BTNTENTK.Text.Trim() != "" && BTNMK.Text.Trim() != "")
            {
                string USERNAME = BTNTENTK.Text.Trim();
                string PASS = BTNMK.Text.Trim();
                var CheckUser = DB.NHANVIENs.Any(x => x.TENTK.Equals(USERNAME) && x.PASSNV.Equals(PASS));
                if(CheckUser)
                {
                    TrangChu LoginForm = new TrangChu();
                    LoginForm.UserCurrent = USERNAME;
                    this.Hide();
                    LoginForm.ShowDialog();
                }    
                else
                {
                    BTNTENTK.Clear();
                    BTNTENTK.Text = "Nhập tên tài khoản của bạn";
                    BTNMK.Clear();
                    BTNMK.Text = "Nhập tên tài khoản của bạn";
                    ErrorTK.Visible = true;
                    ErrorMK.Visible = true;
                }    
            }
            else
            {
                BTNTENTK.Clear();
                BTNTENTK.Text = "Nhập tên tài khoản của bạn";
                BTNMK.Clear();
                BTNMK.Text = "Nhập tên tài khoản của bạn";
                ErrorTK.Visible = true;
                ErrorMK.Visible = true;
            }
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            ErrorTK.Visible = false;
            ErrorMK.Visible = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result  == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
