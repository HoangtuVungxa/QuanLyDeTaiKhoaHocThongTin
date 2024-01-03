using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeTai
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {     
            if ((txtMatKhauCu.Text.Trim() == "") || (txtMatKhauMoi.Text.Trim() == "") || (txtXacNhanMatKhauMoi.Text.Trim() == ""))
            {
                MessageBox.Show("Còn ô thông tin chưa nhập!");
                return;
            }
            
            String sql = "SELECT MatKhau FROM TaiKhoanDuyet WHERE TenDangNhap=N'" + lblUsername.Text + "'";
            String matKhauCu = ChucNang.LayDuLieuTuSQL(sql);
            if (matKhauCu != txtMatKhauCu.Text)
            {
                MessageBox.Show("Mật khẩu cũ nhập sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (txtMatKhauMoi.Text == txtXacNhanMatKhauMoi.Text)
                {
                    String sql1 = "UPDATE TaiKhoanDuyet SET MatKhau = N'" + txtMatKhauMoi.Text + "' " +
                        "WHERE TenDangNhap = '" + lblUsername.Text + "'";
                    ChucNang.ChayCauLenhSQL(sql1);
                    MessageBox.Show("Thay đổi mật khẩu thành công!");
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không trùng khớp!");
                }
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            string data = Login.Data;
            String sql = "SELECT TenDangNhap FROM TaiKhoanDuyet WHERE TenDangNhap=N'" + data + "'";
            string username = ChucNang.LayDuLieuTuSQL(sql);
            //MessageBox.Show(username);
            lblUsername.Text = username;
        }
    }
}
