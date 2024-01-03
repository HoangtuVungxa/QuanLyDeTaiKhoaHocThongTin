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
    public partial class TaiKhoanDaDuyet : Form
    {
        DataTable dtTKD;
        public TaiKhoanDaDuyet()
        {
            InitializeComponent();
        }

        private void TaiKhoanDaDuyet_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            txtPhanQuyen.Enabled = false;
            TaiDuLieuVaoGridView(); //Hiển thị bảng tài liệu
        }

        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dtgTKD.Rows.Count == 0)
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
                sql = "DELETE TaiKhoanDuyet WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
                ChucNang.ChayCauLenhSQL(sql);
                TaiDuLieuVaoGridView();
            }
        }

        private void TaiDuLieuVaoGridView()
        {
            string sql;
            sql = "SELECT * FROM TaiKhoanDuyet";
            dtTKD = ChucNang.TaiDuLieuVaoBang(sql); //Đọc dữ liệu từ bảng
            dtgTKD.DataSource = dtTKD; //Nguồn dữ liệu            
            dtgTKD.Columns[0].HeaderText = "Tên đăng nhập";
            dtgTKD.Columns[1].HeaderText = "Mật khẩu";
            dtgTKD.Columns[2].HeaderText = "Phân quyền";

            dtgTKD.Columns[0].Width = 150;
            dtgTKD.Columns[1].Width = 150;
            dtgTKD.Columns[2].Width = 150;

            dtgTKD.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dtgTKD.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgTKD_Click(object sender, EventArgs e)
        {
            if (dtgTKD.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtTenDangNhap.Text = dtgTKD.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            txtMatKhau.Text = dtgTKD.CurrentRow.Cells["MatKhau"].Value.ToString();
            txtPhanQuyen.Text = dtgTKD.CurrentRow.Cells["MaPhanQuyen"].Value.ToString();
        }
    }
}
