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
    public partial class DeTai : Form
    {
        DataTable dtDT;
        public DeTai()
        {
            InitializeComponent();
        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
            btnSuaDT.Enabled = false;
            btnXoaDT.Enabled = false;
            btnHuy.Enabled = true;
            btnLuuDT.Enabled = true;
            btnThemDT.Enabled = false;
            XoaDuLieuTextBox(); //Xoá trắng các textbox
            txtMaDT.Enabled = true; //cho phép nhập mới
            txtMaDT.Focus();
        }

        private void btnSuaDT_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (dtDT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDT.Text == "") //nếu chưa chọn dữ liệu nào
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((txtMaDT.Text.Trim().Length == 0) || (txtTenDT.Text.Trim().Length == 0) || (cbtxtMaLoai.Text.Trim().Length == 0)
                || (cbtxtMaDV.Text.Trim().Length == 0) || (cbtxtMaTroLy.Text.Trim().Length == 0)
                || (txtNamBatDau.Text.Trim().Length == 0) || (txtNamNT.Text.Trim().Length == 0)
                || (txtKinhPhi.Text.Trim().Length == 0) || (cbtxtMDHT.Text.Trim().Length == 0))
                
            {
                MessageBox.Show("Còn ô dữ liệu chưa được nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDT.Focus();
                return;
            }
            sql = "UPDATE DeTaiNghienCuu SET TenDeTai=N'" + txtTenDT.Text.ToString() + "',MaLoai=N'" + txtMaLoai.Text.ToString()
                + "',MaTroLy=N'" + txtMaTroLy.Text.ToString() + "',MaDonVi=N'" + txtMaDV.Text.ToString()
                + "',NamBatDau=N'" + txtNamBatDau.Text.ToString() + "',NamNghiemThu=N'" + txtNamNT.Text.Trim()
                + "',MaMucDo=N'" + txtMaMucDo.Text.Trim()
                + "',KinhPhi=N'" + txtKinhPhi.Text.Trim() + "',GhiChu=N'" + rtxtGhiChu.Text.Trim()
                + "' WHERE MaDeTai=N'" + txtMaDT.Text.ToString().Trim() + "'";
            ChucNang.ChayCauLenhSQL(sql);
            TaiDuLieuVaoGridView();
            XoaDuLieuTextBox();
            btnHuy.Enabled = false;
        }

        private void btnXoaDT_Click(object sender, EventArgs e)
        {
            string sql;
            if (dtDT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDT.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE DeTaiNghienCuu WHERE MaDeTai=N'" + txtMaDT.Text + "'";
                ChucNang.ChayCauLenhSQL(sql);
                TaiDuLieuVaoGridView();
                XoaDuLieuTextBox();
            }
        }

        private void btnLuuDT_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if ((txtMaDT.Text.Trim().Length == 0) || (txtTenDT.Text.Trim().Length == 0) || (cbtxtMaLoai.Text.Trim().Length == 0)
                || (cbtxtMaTroLy.Text.Trim().Length == 0) || (cbtxtMaDV.Text.Trim().Length == 0) || (txtNamBatDau.Text.Trim().Length == 0)
                || (txtNamNT.Text.Trim().Length == 0) || (txtKinhPhi.Text.Trim().Length == 0)
                || (cbtxtMDHT.Text.Trim().Length == 0))
            {
                MessageBox.Show("Còn ô dữ liệu chưa được nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDT.Focus();
                return;
            }

            sql = "Select MaDeTai From DeTaiNghienCuu where MaDeTai=N'" + txtMaDT.Text.Trim() + "'";
            if (ChucNang.KiemTraTrung(sql))
            {
                MessageBox.Show("Mã đề tài này đã có, bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDT.Focus();
                return;
            }

            sql = "INSERT INTO DeTaiNghienCuu VALUES(N'" + txtMaDT.Text.ToString().Trim() + "',N'" + txtTenDT.Text 
                + "',N'" + txtMaLoai.Text + "',N'" + txtMaTroLy.Text + "',N'" + txtMaDV.Text + "',N'" 
                + txtNamBatDau.Text + "',N'" + txtNamNT.Text + "',N'" + txtKinhPhi.Text
                + "',N'" + txtMaMucDo.Text + "',N'" + rtxtGhiChu.Text + "')";
            ChucNang.ChayCauLenhSQL(sql); //Thực hiện câu lệnh sql
            TaiDuLieuVaoGridView(); //Nạp lại DataGridView
            XoaDuLieuTextBox();
            btnXoaDT.Enabled = true;
            btnThemDT.Enabled = true;
            btnSuaDT.Enabled = true;
            btnHuy.Enabled = false;
            btnLuuDT.Enabled = false;
            txtMaDT.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaDuLieuTextBox();
            btnHuy.Enabled = false;
            btnThemDT.Enabled = true;
            btnXoaDT.Enabled = true;
            btnSuaDT.Enabled = true;
            btnLuuDT.Enabled = false;
            txtMaDT.Enabled = false;
            TaiDuLieuVaoGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeTai_Load(object sender, EventArgs e)
        {
            string sql;
            txtMaDT.Enabled = false;
            btnLuuDT.Enabled = false;
            btnHuy.Enabled = false;

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

        private void btnTimDT_Click(object sender, EventArgs e)
        {
            txtMaDT.Enabled = true;
            txtMaLoai.Enabled = false;
            cbtxtMaLoai.Enabled = true;
            txtMaTroLy.Enabled = false;
            cbtxtMaTroLy.Enabled = true;
            txtMaDV.Enabled = false;
            cbtxtMaDV.Enabled = true;
            txtMaMucDo.Enabled = false;
            cbtxtMDHT.Enabled = true;
            btnHuy.Enabled = true;
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

            dtDT = ChucNang.TaiDuLieuVaoBang(sql);
            if (dtDT.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + dtDT.Rows.Count + "  dữ liệu thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtgDeTai.DataSource = dtDT;

            XoaDuLieuTextBox();
        }

        private void dtgDeTai_Click(object sender, EventArgs e)
        {
            if (btnThemDT.Enabled == false) //Không cho lấy dữ liệu từ datagrid lên textbox
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDT.Focus();
                return;
            }
            if (dtDT.Rows.Count == 0) //Nếu không có dữ liệu
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
            txtMaMucDo.Text = dtgDeTai.CurrentRow.Cells["MaMucDo"].Value.ToString() ;
            rtxtGhiChu.Text = dtgDeTai.CurrentRow.Cells["GhiChu"].Value.ToString();

            btnSuaDT.Enabled = true;
            btnXoaDT.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void TaiDuLieuVaoGridView()
        {
            string sql;
            sql = "SELECT * FROM DeTaiNghienCuu";
            dtDT = ChucNang.TaiDuLieuVaoBang(sql); //Đọc dữ liệu từ bảng
            dtgDeTai.DataSource = dtDT; //Nguồn dữ liệu            
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
            dtgDeTai.Columns[5].Width = 120;
            dtgDeTai.Columns[6].Width = 120;
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

        private void cbtxtMaLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaLoai FROM LoaiDeTai WHERE TenLoai=N'" + cbtxtMaLoai.Text + "'";
            txtMaLoai.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtMaDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaDonVi FROM DonViThucHien WHERE TenDonVi=N'" + cbtxtMaDV.Text + "'";
            txtMaDV.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtMaTroLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaTroLy FROM TroLy WHERE TenTroLy=N'" + cbtxtMaTroLy.Text + "'";
            txtMaTroLy.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtMDHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaMucDo FROM MucDoHoanThanh WHERE TenMucDo=N'" + cbtxtMDHT.Text + "'";
            txtMaMucDo.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        public void DisableUser()
        {
            btnThemDT.Enabled = false;
            btnSuaDT.Enabled = false;
            btnLuuDT.Enabled = false;
            btnXoaDT.Enabled = false;
            btnHuy.Enabled = false;
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbtxtMaLoai.SelectedValue.ToString() + " + " + cbtxtMaLoai.Text.ToString());
        }
    }
}
