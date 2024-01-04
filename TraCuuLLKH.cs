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
    public partial class TraCuuLLKH : Form
    {
        DataTable dtLLKH;
        public TraCuuLLKH()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TraCuuLLKH_Load(object sender, EventArgs e)
        {
            string sql;
            txtMaTG.Enabled = false;

            sql = "SELECT * FROM CapBac";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtCapBac, "MaCapBac", "TenCapBac");
            cbtxtCapBac.SelectedIndex = -1;

            sql = "SELECT * FROM ChucVu";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtChucVu, "MaChucVu", "TenChucVu");
            cbtxtChucVu.SelectedIndex = -1;

            sql = "SELECT * FROM HocVi";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtHocVi, "MaHocVi", "TenHocVi");
            cbtxtHocVi.SelectedIndex = -1;

            txtMaCapBac.Enabled = false;
            txtMaChucVu.Enabled = false;
            txtMaHocVi.Enabled = false;
            TaiDuLieuVaoGridView(); //Hiển thị bảng tài liệu
        }

        private void dtgTacGia_Click(object sender, EventArgs e)
        {
            
            if (dtLLKH.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTG.Text = dtgTacGia.CurrentRow.Cells["MaTacGia"].Value.ToString();
            txtTenTG.Text = dtgTacGia.CurrentRow.Cells["TenTacGia"].Value.ToString();
            txtMaCapBac.Text = dtgTacGia.CurrentRow.Cells["MaCapBac"].Value.ToString();
            txtMaChucVu.Text = dtgTacGia.CurrentRow.Cells["MaChucVu"].Value.ToString();
            txtMaHocVi.Text = dtgTacGia.CurrentRow.Cells["MaHocVi"].Value.ToString();
            txtNamSinh.Text = dtgTacGia.CurrentRow.Cells["NamSinh"].Value.ToString();
            txtSDT.Text = dtgTacGia.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            txtEmail.Text = dtgTacGia.CurrentRow.Cells["Email"].Value.ToString();
            rtxtGhiChu.Text = dtgTacGia.CurrentRow.Cells["GhiChu"].Value.ToString();
        }

        private void btnTimTG_Click(object sender, EventArgs e)
        {
            txtMaTG.Enabled = true;
            txtMaCapBac.Enabled = true;
            cbtxtCapBac.Enabled = true;
            txtMaChucVu.Enabled = true;
            txtMaChucVu.Enabled = true;
            txtMaHocVi.Enabled = true;
            cbtxtHocVi.Enabled = true;
            string sql;
            if ((txtMaTG.Text == "") && (txtTenTG.Text == "") && (cbtxtCapBac.Text == "") && (cbtxtChucVu.Text == "")
                && (cbtxtHocVi.Text == "") && (txtNamSinh.Text == "") && (txtSDT.Text == "")
                && (txtEmail.Text == "") && (rtxtGhiChu.Text == ""))
            {
                TaiDuLieuVaoGridView();
                return;
            }
            sql = "SELECT * from TacGia WHERE 1=1";
            if (txtMaTG.Text != "")
                sql += " AND MaTacGia LIKE N'%" + txtMaTG.Text.Trim() + "%'";
            if (txtTenTG.Text != "")
                sql += " AND TenTacGia LIKE N'%" + txtTenTG.Text.Trim() + "%'";
            if (txtMaCapBac.Text != "")
                sql += " AND MaCapBac LIKE N'%" + txtMaCapBac.Text.Trim() + "%'";
            if (txtMaChucVu.Text != "")
                sql += " AND MaChucVu LIKE N'%" + txtMaChucVu.Text.Trim() + "%'";
            if (txtMaHocVi.Text != "")
                sql += " AND MaHocVi LIKE N'%" + txtMaHocVi.Text.Trim() + "%'";
            if (txtNamSinh.Text != "")
                sql += " AND NamSinh LIKE N'%" + txtNamSinh.Text.Trim() + "%'";
            if (txtSDT.Text != "")
                sql += " AND SoDienThoai LIKE N'%" + txtSDT.Text.Trim() + "%'";
            if (txtEmail.Text != "")
                sql += " AND Email LIKE N'%" + txtEmail.Text.Trim() + "%'";
            if (rtxtGhiChu.Text != "")
                sql += " AND GhiChu LIKE N'%" + rtxtGhiChu.Text.Trim() + "%'";

            dtLLKH = ChucNang.TaiDuLieuVaoBang(sql);
            if (dtLLKH.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + dtLLKH.Rows.Count + "  dữ liệu thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtgTacGia.DataSource = dtLLKH;

            XoaDuLieuTextBox();
        }

        private void TaiDuLieuVaoGridView()
        {
            string sql;
            sql = "SELECT * FROM TacGia";
            dtLLKH = ChucNang.TaiDuLieuVaoBang(sql); //Đọc dữ liệu từ bảng
            dtgTacGia.DataSource = dtLLKH; //Nguồn dữ liệu            
            dtgTacGia.Columns[0].HeaderText = "Mã tác giả";
            dtgTacGia.Columns[1].HeaderText = "Tên tác giả";
            dtgTacGia.Columns[2].HeaderText = "Cấp bậc";
            dtgTacGia.Columns[3].HeaderText = "Chức vụ";
            dtgTacGia.Columns[4].HeaderText = "Học vị";
            dtgTacGia.Columns[5].HeaderText = "Năm sinh";
            dtgTacGia.Columns[6].HeaderText = "Số điện thoại";
            dtgTacGia.Columns[7].HeaderText = "Email";
            dtgTacGia.Columns[8].HeaderText = "Ghi chú";

            dtgTacGia.Columns[0].Width = 80;
            dtgTacGia.Columns[1].Width = 150;
            dtgTacGia.Columns[2].Width = 120;
            dtgTacGia.Columns[3].Width = 120;
            dtgTacGia.Columns[4].Width = 80;
            dtgTacGia.Columns[5].Width = 120;
            dtgTacGia.Columns[6].Width = 80;
            dtgTacGia.Columns[7].Width = 80;
            dtgTacGia.Columns[8].Width = 120;

            dtgTacGia.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dtgTacGia.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void XoaDuLieuTextBox()
        {
            txtMaTG.Text = "";
            txtTenTG.Text = "";
            cbtxtCapBac.Text = "";
            cbtxtChucVu.Text = "";
            cbtxtHocVi.Text = "";
            txtNamSinh.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            rtxtGhiChu.Text = "";
            txtMaCapBac.Text = "";
            txtMaChucVu.Text = "";
            txtMaHocVi.Text = "";
        }

        private void cbtxtCapBac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaCapBac FROM CapBac WHERE TenCapBac=N'" + cbtxtCapBac.Text + "'";
            txtMaCapBac.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaChucVu FROM ChucVu WHERE TenChucVu=N'" + cbtxtChucVu.Text + "'";
            txtMaChucVu.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtHocVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaHocVi FROM HocVi WHERE TenHocVi=N'" + cbtxtHocVi.Text + "'";
            txtMaHocVi.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaCapBac_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenCapBac FROM CapBac WHERE MaCapBac=N'" + txtMaCapBac.Text + "'";
            cbtxtCapBac.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaChucVu_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenChucVu FROM ChucVu WHERE MaChucVu=N'" + txtMaChucVu.Text + "'";
            cbtxtChucVu.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaHocVi_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenHocVi FROM HocVi WHERE MaHocVi=N'" + txtMaHocVi.Text + "'";
            cbtxtHocVi.Text = ChucNang.LayDuLieuTuSQL(sql);
        }
    }
}
