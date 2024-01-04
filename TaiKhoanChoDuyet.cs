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
    public partial class TaiKhoanChoDuyet : Form
    {
        DataTable dtTKCD;
        public TaiKhoanChoDuyet()
        {
            InitializeComponent();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql

            sql = "Select TenDangNhap From TaiKhoanDuyet where TenDangNhap=N'" + txtTenDangNhap.Text.Trim() + "'";
            if (ChucNang.KiemTraTrung(sql))
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }

            if ((cbtxtPhanQuyen.Text == "") || (txtTenDangNhap.Text == "") || (txtMatKhau.Text == ""))
            {
                MessageBox.Show("Chưa phân quyền tài khoản!");
            }
            else
            {
                sql = "INSERT INTO TaiKhoanDuyet VALUES(N'" + txtTenDangNhap.Text.ToString().Trim()
                + "',N'" + txtMatKhau.Text + "',N'" + txtMaPhanQuyen.Text + "')";
                ChucNang.ChayCauLenhSQL(sql); //Thực hiện câu lệnh sql

                sql = "DELETE TaiKhoanDangKy WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
                ChucNang.ChayCauLenhSQL(sql);

                TaiDuLieuVaoGridView(); //Nạp lại DataGridView
                btnDuyet.Enabled = false;
                MessageBox.Show("Cấp tài khoản thành công!");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dtgTKCD.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDangNhap.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE TaiKhoanDangKy WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
                ChucNang.ChayCauLenhSQL(sql);
                TaiDuLieuVaoGridView();
            }
        }

        private void TaiKhoanChoDuyet_Load(object sender, EventArgs e)
        {
            btnDuyet.Enabled = false;
            string sql = "SELECT * FROM PhanQuyen";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtPhanQuyen, "MaPhanQuyen", "TenPhanQuyen");
            cbtxtPhanQuyen.SelectedIndex = -1;

            TaiDuLieuVaoGridView(); //Hiển thị bảng tài liệu
        }

        private void dtgTKCD_Click(object sender, EventArgs e)
        {
            
            if (dtgTKCD.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtTenDangNhap.Text = dtgTKCD.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            txtMatKhau.Text = dtgTKCD.CurrentRow.Cells["MatKhau"].Value.ToString();

            btnDuyet.Enabled = true;
        }

        private void TaiDuLieuVaoGridView()
        {
            string sql;
            sql = "SELECT * FROM TaiKhoanDangKy";
            dtTKCD = ChucNang.TaiDuLieuVaoBang(sql); //Đọc dữ liệu từ bảng
            dtgTKCD.DataSource = dtTKCD; //Nguồn dữ liệu            
            dtgTKCD.Columns[0].HeaderText = "Tên đăng nhập";
            dtgTKCD.Columns[1].HeaderText = "Mật khẩu";

            dtgTKCD.Columns[0].Width = 150;
            dtgTKCD.Columns[1].Width = 150;

            dtgTKCD.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dtgTKCD.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbtxtPhanQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaPhanQuyen FROM PhanQuyen WHERE TenPhanQuyen=N'" + cbtxtPhanQuyen.Text + "'";
            txtMaPhanQuyen.Text = ChucNang.LayDuLieuTuSQL(sql);
        }
    }
}
;