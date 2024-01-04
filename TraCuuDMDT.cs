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
    public partial class TraCuuDMDT : Form
    {
        DataTable dtTraCuu;
        public TraCuuDMDT()
        {
            InitializeComponent();
        }

        private void TraCuu_Load(object sender, EventArgs e)
        {
            string sql;

            sql = "SELECT * FROM LoaiDeTai";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtMaLoai, "MaLoai", "TenLoai");
            cbtxtMaLoai.SelectedIndex = -1;

            sql = "SELECT * FROM MucDoHoanThanh";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtMDHT, "MaMucDo", "TenMucDo");
            cbtxtMDHT.SelectedIndex = -1;

            sql = "SELECT * FROM DonViThucHien";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtMaDV, "MaDonVi", "TenDonVi");
            cbtxtMaDV.SelectedIndex = -1;

            sql = "SELECT * FROM TroLy";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtMaTroLy, "MaTroLy", "TenTroLy");
            cbtxtMaTroLy.SelectedIndex = -1;

            txtMaLoai.Enabled = false;
            txtMaDV.Enabled = false;
            txtMaTroLy.Enabled = false;
            txtMaMucDo.Enabled = false;
            TaiDuLieuVaoGridView(); //Hiển thị bảng tài liệu
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimDT_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaDT.Text == "") && (txtTenDT.Text == "") && (cbtxtMaLoai.Text == "") && (cbtxtMaTroLy.Text == "")
                && (cbtxtMaDV.Text == "") && (txtNamBatDau.Text == "") && (cbtxtMDHT.Text == "")
                && (txtNamNT.Text == "") && (txtKinhPhi.Text == "") && (rtxtGhiChu.Text == ""))
            {
                TaiDuLieuVaoGridView();
                return;
            }
            sql = "SELECT * from DeTaiNghienCuu WHERE 1=1";
            if (txtMaDT.Text != "")
                sql += " AND MaDeTai LIKE N'%" + txtMaDT.Text.Trim() + "%'";
            if (txtTenDT.Text != "")
                sql += " AND TenDeTai LIKE N'%" + txtTenDT.Text.Trim() + "%'";
            if (txtMaLoai.Text != "")
                sql += " AND MaLoai LIKE N'%" + txtMaLoai.Text.Trim() + "%'";
            if (txtMaTroLy.Text != "")
                sql += " AND MaTroLy LIKE N'%" + txtMaTroLy.Text.Trim() + "%'";
            if (txtMaDV.Text != "")
                sql += " AND MaDonVi LIKE N'%" + txtMaDV.Text.Trim() + "%'";
            if (txtNamBatDau.Text != "")
                sql += " AND NamBatDau LIKE N'%" + txtNamBatDau.Text.Trim() + "%'";
            if (txtNamNT.Text != "")
                sql += " AND NamNghiemThu LIKE N'%" + txtNamNT.Text.Trim() + "%'";
            if (txtKinhPhi.Text != "")
                sql += " AND KinhPhi LIKE N'%" + txtKinhPhi.Text.Trim() + "%'";
            if (txtMaMucDo.Text != "")
                sql += " AND MaMucDo LIKE N'%" + txtMaMucDo.Text.Trim() + "%'";
            if (rtxtGhiChu.Text != "")
                sql += " AND GhiChu LIKE N'%" + rtxtGhiChu.Text.Trim() + "%'";

            dtTraCuu = ChucNang.TaiDuLieuVaoBang(sql);
            if (dtTraCuu.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + dtTraCuu.Rows.Count + "  dữ liệu thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtgDeTai.DataSource = dtTraCuu;

            XoaDuLieuTextBox();
        }

        private void dtgDeTai_Click(object sender, EventArgs e)
        {
            
            if (dtTraCuu.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaDT.Text = dtgDeTai.CurrentRow.Cells["MaDeTai"].Value.ToString();
            txtTenDT.Text = dtgDeTai.CurrentRow.Cells["TenDeTai"].Value.ToString();
            txtMaLoai.Text = dtgDeTai.CurrentRow.Cells["MaLoai"].Value.ToString();
            txtMaTroLy.Text = dtgDeTai.CurrentRow.Cells["MaTroLy"].Value.ToString();
            txtMaDV.Text = dtgDeTai.CurrentRow.Cells["MaDonVi"].Value.ToString();
            txtNamBatDau.Text = dtgDeTai.CurrentRow.Cells["NamBatDau"].Value.ToString();
            txtNamNT.Text = dtgDeTai.CurrentRow.Cells["NamNghiemThu"].Value.ToString();
            txtKinhPhi.Text = dtgDeTai.CurrentRow.Cells["KinhPhi"].Value.ToString();
            txtMaMucDo.Text = dtgDeTai.CurrentRow.Cells["MaMucDo"].Value.ToString();
            rtxtGhiChu.Text = dtgDeTai.CurrentRow.Cells["GhiChu"].Value.ToString();
        }

        private void TaiDuLieuVaoGridView()
        {
            string sql;
            sql = "SELECT * FROM DeTaiNghienCuu";
            dtTraCuu = ChucNang.TaiDuLieuVaoBang(sql); //Đọc dữ liệu từ bảng
            dtgDeTai.DataSource = dtTraCuu; //Nguồn dữ liệu            
            dtgDeTai.Columns[0].HeaderText = "Mã đề tài";
            dtgDeTai.Columns[1].HeaderText = "Tên đề tài";
            dtgDeTai.Columns[2].HeaderText = "Loại đề tài";
            dtgDeTai.Columns[3].HeaderText = "Trợ lý phụ trách";
            dtgDeTai.Columns[4].HeaderText = "Đơn vị thực hiện";
            dtgDeTai.Columns[5].HeaderText = "Năm bắt đầu";
            dtgDeTai.Columns[6].HeaderText = "Năm nghiệm thu";
            dtgDeTai.Columns[7].HeaderText = "Kinh phí";
            dtgDeTai.Columns[8].HeaderText = "Mức độ hoàn thành";
            dtgDeTai.Columns[9].HeaderText = "Ghi chú";

            dtgDeTai.Columns[0].Width = 80;
            dtgDeTai.Columns[1].Width = 150;
            dtgDeTai.Columns[2].Width = 120;
            dtgDeTai.Columns[3].Width = 150;
            dtgDeTai.Columns[4].Width = 150;
            dtgDeTai.Columns[5].Width = 150;
            dtgDeTai.Columns[6].Width = 150;
            dtgDeTai.Columns[7].Width = 80;
            dtgDeTai.Columns[8].Width = 180;
            dtgDeTai.Columns[9].Width = 120;

            dtgDeTai.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dtgDeTai.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void XoaDuLieuTextBox()
        {
            txtMaDT.Text = "";
            txtTenDT.Text = "";
            cbtxtMaLoai.Text = "";
            cbtxtMaDV.Text = "";
            txtMaLoai.Text = "";
            cbtxtMaTroLy.Text = "";
            txtNamNT.Text = "";
            txtKinhPhi.Text = "";
            rtxtGhiChu.Text = "";
            txtMaLoai.Text = "";
            txtNamBatDau.Text = "";
            txtMaTroLy.Text = "";
            txtMaMucDo.Text = "";
            txtMaDV.Text = "";
        }

        private void cbtxtMaLoai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaLoai FROM LoaiDeTai WHERE TenLoai=N'" + cbtxtMaLoai.Text + "'";
            txtMaLoai.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtMaDV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaDonVi FROM DonViThucHien WHERE TenDonVi=N'" + cbtxtMaDV.Text + "'";
            txtMaDV.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtMaTroLy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaTroLy FROM TroLy WHERE TenTroLy=N'" + cbtxtMaTroLy.Text + "'";
            txtMaTroLy.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtMDHT_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaMucDo FROM MucDoHoanThanh WHERE TenMucDo=N'" + cbtxtMDHT.Text + "'";
            txtMaMucDo.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaLoai_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenLoai FROM LoaiDeTai WHERE MaLoai=N'" + txtMaLoai.Text + "'";
            cbtxtMaLoai.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenDonVi FROM DonViThucHien WHERE MaDonVi=N'" + txtMaDV.Text + "'";
            cbtxtMaDV.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaTroLy_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenTroLy FROM TroLy WHERE MaTroLy=N'" + txtMaTroLy.Text + "'";
            cbtxtMaTroLy.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaMucDo_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenMucDo FROM MucDoHoanThanh WHERE MaMucDo=N'" + txtMaMucDo.Text + "'";
            cbtxtMDHT.Text = ChucNang.LayDuLieuTuSQL(sql);
        }
    }
}
;