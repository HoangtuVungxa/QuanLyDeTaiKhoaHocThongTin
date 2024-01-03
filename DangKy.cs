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
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            
            if ((txtTenDangNhap.Text.Trim() == "") || (txtMatKhau.Text.Trim() == ""))
            {
                MessageBox.Show("Còn ô thông tin chưa nhập!");
                return;
            }

            ChucNang.KetNoi();
            String sql = "SELECT TenDangNhap FROM TaiKhoanDangKy WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
            if (ChucNang.KiemTraTrung(sql))
            {
                MessageBox.Show("Tên đăng nhập này đã có, bạn phải nhập tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT TenDangNhap FROM TaiKhoanDuyet WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
            if (ChucNang.KiemTraTrung(sql))
            {
                MessageBox.Show("Tên đăng nhập này đã có, bạn phải nhập tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {

                if (txtMatKhau.Text == txtXacNhanMatKhau.Text)
                {
                    String sql1 = "INSERT INTO TaiKhoanDangKy VALUES (N'" + txtTenDangNhap.Text + "', N'" + txtXacNhanMatKhau.Text
                        + "')";
                    ChucNang.ChayCauLenhSQL(sql1);
                    MessageBox.Show("Bạn đã đăng ký tài khoản, hãy chờ quản trị viên duyệt!");
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!");
                }
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            DangKy.ActiveForm.Close();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
