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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        public static string Data { get; set; }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ChucNang.KetNoi();
            Data = txtTenDangNhap.Text.Trim();
            String sql = "SELECT TenDangNhap FROM TaiKhoanDuyet WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
            List<string> listDN = ChucNang.LayDuLieuCotDuaVaoList(sql, "TenDangNhap");
            sql = "SELECT MatKhau FROM TaiKhoanDuyet WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
            List<string> listMK = ChucNang.LayDuLieuCotDuaVaoList(sql, "MatKhau");
            
            if (listDN.Count == 0)
            {
                MessageBox.Show("Tên đăng nhập không đúng");
                return;
            }

            foreach (string TenDN in listDN)
            {
                if (txtTenDangNhap.Text == TenDN)
                {
                    foreach (string password in listMK)
                    {
                        if (txtMatKhau.Text == password)
                        {
                            this.Hide();
                            Main main = new Main();
                            main.Show();
                            sql = "SELECT MaPhanQuyen FROM TaiKhoanDuyet WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
                            int phanquyen = int.Parse(ChucNang.LayDuLieuTuSQL(sql));
                            if (phanquyen == 3)
                            {
                                main.DisableTKD();
                                main.DisableTKCD();
                                main.DisableDSTL();
                            }
                            else if (phanquyen == 4)
                            {
                                main.DisableTKD();
                                main.DisableTKCD();
                                main.DisableUser();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không đúng");
                        }
                    }
                }
            }

            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Thoát
            this.Close();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy dangKy = new DangKy();
            dangKy.Show();
        }
    }
}
