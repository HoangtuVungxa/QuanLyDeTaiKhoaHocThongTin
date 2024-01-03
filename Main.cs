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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng nhập thành công!");
            string data = Login.Data;
            String sql = "SELECT TenDangNhap FROM TaiKhoanDuyet WHERE TenDangNhap=N'" + data + "'";
            string username = ChucNang.LayDuLieuTuSQL(sql);
            //MessageBox.Show(username);
            lblUsername.Text = username;
        }

        private void subMenuTaiKhoanChoDuyet_Click(object sender, EventArgs e)
        {
            TaiKhoanChoDuyet taiKhoanChoDuyet = new TaiKhoanChoDuyet();
            taiKhoanChoDuyet.ShowDialog();
        }

        private void subMenuThayDoiTaiKhoan_Click(object sender, EventArgs e)
        {
            Main.ActiveForm.Close();
            Login login = new Login();
            login.ShowDialog();
        }

        private void MenuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm quản lý nhiệm vụ khoa học công nghệ 1.0!");
        }

        private void subMenuDanhMucDeTai_Click(object sender, EventArgs e)
        {
            DeTai deTai = new DeTai();
            deTai.ShowDialog();
        }

        private void subMenuLyLichKhoaHoc_Click(object sender, EventArgs e)
        {
            LyLichKhoaHoc lyLichKhoaHoc = new LyLichKhoaHoc();
            lyLichKhoaHoc.ShowDialog();
        }

        private void subMenuDanhSachTroLy_Click(object sender, EventArgs e)
        {
            TroLy troly = new TroLy();
            troly.ShowDialog();
        }

        private void subMenuTaiKhoanDaDuyet_Click(object sender, EventArgs e)
        {
            TaiKhoanDaDuyet taiKhoanDaDuyet = new TaiKhoanDaDuyet();
            taiKhoanDaDuyet.ShowDialog();
        }

        public void DisableTKD()
        {
            subMenuTaiKhoanDaDuyet.Visible = false;
        }

        public void DisableTKCD()
        {
            subMenuTaiKhoanChoDuyet.Visible = false;
        }

        public void DisableDSTL()
        {
            subMenuDanhSachTroLy.Visible = false;   
        }

        public void DisableUser()
        {
            MenuDanhMuc.Visible = false;
        }

        private void subMenuThoat_Click(object sender, EventArgs e)
        {
            ChucNang.NgatKetNoi(); //Đóng kết nối
            Application.Exit(); //Thoát
            Login.ActiveForm.Close();
        }

        private void subMenuDanhMucTacGia_Click(object sender, EventArgs e)
        {
            TacGia_DeTai tacGia_DeTai = new TacGia_DeTai();
            tacGia_DeTai.ShowDialog();
        }

        private void subMenuDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.ShowDialog();    
        }

        
    }
}
