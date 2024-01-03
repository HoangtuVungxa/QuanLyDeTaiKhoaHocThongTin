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
    public partial class TroLy : Form
    {
        DataTable dtTL;
        public TroLy()
        {
            InitializeComponent();
        }

        private void TroLy_Load(object sender, EventArgs e)
        {
            string sql;
            txtMaTroLy.Enabled = false;
            btnLuuTroLy.Enabled = false;
            btnHuy.Enabled = false;

            sql = "SELECT * FROM CapBac";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtCapBac, "MaCapBac", "TenCapBac");
            cbtxtCapBac.SelectedIndex = -1;

            sql = "SELECT * FROM HocVi";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtHocVi, "MaHocVi", "TenHocVi");
            cbtxtHocVi.SelectedIndex = -1;

            txtMaCapBac.Enabled = false;
            txtMaHocVi.Enabled = false;
            TaiDuLieuVaoGridView(); //Hiển thị bảng tài liệu
        }

        private void dtgTroLy_Click(object sender, EventArgs e)
        {
            if (btnThemTroLy.Enabled == false) //Không cho lấy dữ liệu từ datagrid lên textbox
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTroLy.Focus();
                return;
            }
            if (dtTL.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTroLy.Text = dtgTroLy.CurrentRow.Cells["MaTroLy"].Value.ToString();
            txtTenTroLy.Text = dtgTroLy.CurrentRow.Cells["TenTroLy"].Value.ToString();
            txtMaCapBac.Text = dtgTroLy.CurrentRow.Cells["MaCapBac"].Value.ToString();
            txtMaHocVi.Text = dtgTroLy.CurrentRow.Cells["MaHocVi"].Value.ToString();
            rtxtGhiChu.Text = dtgTroLy.CurrentRow.Cells["GhiChu"].Value.ToString();

            btnSuaTroLy.Enabled = true;
            btnXoaTroLy.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnThemTroLy_Click(object sender, EventArgs e)
        {
            btnSuaTroLy.Enabled = false;
            btnXoaTroLy.Enabled = false;
            btnHuy.Enabled = true;
            btnLuuTroLy.Enabled = true;
            btnThemTroLy.Enabled = false;
            XoaDuLieuTextBox(); //Xoá trắng các textbox
            txtMaTroLy.Enabled = true; //cho phép nhập mới
            txtMaTroLy.Focus();
        }

        private void btnSuaTroLy_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (dtTL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTroLy.Text == "") //nếu chưa chọn dữ liệu nào
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((txtMaTroLy.Text.Trim().Length == 0) || (txtTenTroLy.Text.Trim().Length == 0) 
                || (cbtxtCapBac.Text.Trim().Length == 0) || (cbtxtHocVi.Text.Trim().Length == 0))
            {
                MessageBox.Show("Còn ô dữ liệu chưa được nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTroLy.Focus();
                return;
            }
            sql = "UPDATE TroLy SET TenTroLy=N'" + txtTenTroLy.Text.ToString() + "',MaCapBac=N'" + txtMaCapBac.Text.ToString()
                + "',MaHocVi=N'" + txtMaHocVi.Text.ToString() + "',GhiChu=N'" + rtxtGhiChu.Text.Trim()
                + "' WHERE MaTroLy=N'" + txtMaTroLy.Text.ToString().Trim() + "'";
            ChucNang.ChayCauLenhSQL(sql);
            TaiDuLieuVaoGridView();
            XoaDuLieuTextBox();
            btnHuy.Enabled = false;
        }

        private void btnXoaTroLy_Click(object sender, EventArgs e)
        {
            string sql;
            if (dtTL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTroLy.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE TroLy WHERE MaTroLy=N'" + txtMaTroLy.Text + "'";
                ChucNang.ChayCauLenhSQL(sql);
                TaiDuLieuVaoGridView();
                XoaDuLieuTextBox();
            }
        }

        private void btnLuuTroLy_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if ((txtMaTroLy.Text.Trim().Length == 0) || (txtTenTroLy.Text.Trim().Length == 0) || (txtMaCapBac.Text.Trim().Length == 0)
                || (txtMaHocVi.Text.Trim().Length == 0))
            {
                MessageBox.Show("Còn ô dữ liệu chưa được nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTroLy.Focus();
                return;
            }

            sql = "Select MaTroLy From TroLy where MaTroLy=N'" + txtMaTroLy.Text.Trim() + "'";
            if (ChucNang.KiemTraTrung(sql))
            {
                MessageBox.Show("Mã tài liệu này đã có, bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTroLy.Focus();
                return;
            }

            sql = "INSERT INTO TroLy VALUES(N'" + txtMaTroLy.Text.ToString().Trim() + "',N'" + txtTenTroLy.Text
                + "',N'" + txtMaCapBac.Text + "',N'" + txtMaHocVi.Text + "',N'" + rtxtGhiChu.Text + "')";
            ChucNang.ChayCauLenhSQL(sql); //Thực hiện câu lệnh sql
            TaiDuLieuVaoGridView(); //Nạp lại DataGridView
            XoaDuLieuTextBox();
            btnXoaTroLy.Enabled = true;
            btnThemTroLy.Enabled = true;
            btnSuaTroLy.Enabled = true;
            btnHuy.Enabled = false;
            btnLuuTroLy.Enabled = false;
            txtMaTroLy.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaDuLieuTextBox();
            btnHuy.Enabled = false;
            btnThemTroLy.Enabled = true;
            btnXoaTroLy.Enabled = true;
            btnSuaTroLy.Enabled = true;
            btnLuuTroLy.Enabled = false;
            txtMaTroLy.Enabled = false;
            TaiDuLieuVaoGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaiDuLieuVaoGridView()
        {
            string sql;
            sql = "SELECT * FROM TroLy";
            dtTL = ChucNang.TaiDuLieuVaoBang(sql); //Đọc dữ liệu từ bảng
            dtgTroLy.DataSource = dtTL; //Nguồn dữ liệu            
            dtgTroLy.Columns[0].HeaderText = "Mã trợ lý";
            dtgTroLy.Columns[1].HeaderText = "Tên trợ lý";
            dtgTroLy.Columns[2].HeaderText = "Cấp bậc";
            dtgTroLy.Columns[3].HeaderText = "Học vị";
            dtgTroLy.Columns[4].HeaderText = "Ghi chú";

            dtgTroLy.Columns[0].Width = 80;
            dtgTroLy.Columns[1].Width = 150;
            dtgTroLy.Columns[2].Width = 120;
            dtgTroLy.Columns[3].Width = 120;
            dtgTroLy.Columns[4].Width = 80;

            dtgTroLy.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dtgTroLy.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void XoaDuLieuTextBox()
        {
            txtMaTroLy.Text = "";
            txtTenTroLy.Text = "";
            cbtxtCapBac.Text = "";
            cbtxtHocVi.Text = "";
            rtxtGhiChu.Text = "";
        }

        private void cbtxtCapBac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaCapBac FROM CapBac WHERE TenCapBac=N'" + cbtxtCapBac.Text + "'";
            txtMaCapBac.Text = ChucNang.LayDuLieuTuSQL(sql);
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

        private void txtMaHocVi_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenHocVi FROM HocVi WHERE MaHocVi=N'" + txtMaHocVi.Text + "'";
            cbtxtHocVi.Text = ChucNang.LayDuLieuTuSQL(sql);
        }
    }
}
