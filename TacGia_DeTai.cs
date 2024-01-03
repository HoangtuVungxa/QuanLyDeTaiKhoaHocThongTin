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
    public partial class TacGia_DeTai : Form
    {
        DataTable dtTGDT;
        public TacGia_DeTai()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            XoaDuLieuTextBox(); //Xoá trắng các textbox
            cbtxtTG.Enabled = true; //cho phép nhập mới
            cbtxtDT.Enabled = true;
            cbtxtVT.Enabled = true;
            cbtxtTG.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (dtTGDT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((cbtxtTG.Text == "") || (cbtxtDT.Text == "")) //nếu chưa chọn dữ liệu nào
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((cbtxtTG.Text.Trim().Length == 0) || (cbtxtDT.Text.Trim().Length == 0) || (cbtxtVT.Text.Trim() == "")
                || (rtxtGhiChu.Text.Trim().Length == 0))
            {
                MessageBox.Show("Còn ô dữ liệu chưa được nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtxtGhiChu.Focus();
                return;
            }
            sql = "UPDATE TacGia_DeTai SET MaDeTai=N'" + txtMaDT.Text.ToString().Trim()
                + "',MaVaiTro=N'" + cbtxtVT.Text.Trim() + "',GhiChu=N'" + rtxtGhiChu.Text.Trim()
                + "' WHERE MaTacGia=N'" + txtMaTG.Text.ToString().Trim() + "' AND MaDeTai=N'" + txtMaDT.Text.ToString().Trim() + "'";
            ChucNang.ChayCauLenhSQL(sql);
            TaiDuLieuVaoGridView();
            XoaDuLieuTextBox();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dtTGDT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbtxtTG.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE TacGia_DeTai WHERE MaTacGia=N'" + txtMaTG.Text + "' AND MaDeTai=N'" + txtMaDT.Text.ToString().Trim() + "'";
                ChucNang.ChayCauLenhSQL(sql);
                TaiDuLieuVaoGridView();
                XoaDuLieuTextBox();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if ((cbtxtTG.Text.Trim().Length == 0) || (cbtxtDT.Text.Trim().Length == 0) || (cbtxtVT.Text == ""))
            {
                MessageBox.Show("Còn ô dữ liệu chưa được nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbtxtTG.Focus();
                return;
            }

            sql = "Select MaDeTai, MaVaiTro From TacGia_DeTai where MaDeTai=N'" + txtMaDT.Text.Trim()
                + "' AND MaVaiTro = 'VT1'";
            if (ChucNang.KiemTraTrung(sql))
            {
                if (cbtxtVT.Text == "Chủ nhiệm")
                {
                    MessageBox.Show("Đề tài này đã có chủ nhiệm , bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbtxtVT.Focus();
                    return;
                }
                else
                {
                    sql = "Select MaDeTai, MaVaiTro From TacGia_DeTai where MaDeTai=N'" + txtMaDT.Text.Trim()
                    + "' AND MaVaiTro = 'VT2'";
                    if (ChucNang.KiemTraTrung(sql))
                    {
                        if (cbtxtVT.Text == "Thư ký")
                        {
                            MessageBox.Show("Đề tài này đã có thư ký , bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cbtxtVT.Focus();
                            return;
                        }
                        else
                        {
                            sql = "Select MaDeTai, MaTacGia, MaVaiTro From TacGia_DeTai where MaDeTai=N'" + txtMaDT.Text.Trim()
                                  + "' AND MaTacGia='" + txtMaTG.Text + "'";
                            if (ChucNang.KiemTraTrung(sql))
                            {
                                MessageBox.Show("Đề tài này đã tham gia, bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cbtxtVT.Focus();
                                return;
                            }
                            else
                            {
                                sql = "INSERT INTO TacGia_DeTai VALUES('" + txtMaTG.Text.ToString().Trim() + "','" + txtMaDT.Text.ToString().Trim()
                                        + "',N'" + txtMaVaiTro.Text.Trim() + "',N'" + rtxtGhiChu.Text.Trim() + "')";
                                ChucNang.ChayCauLenhSQL(sql); //Thực hiện câu lệnh sql
                                MessageBox.Show("Lưu thành công!");
                            }
                        }
                    }
                    else
                    {
                        sql = "INSERT INTO TacGia_DeTai VALUES('" + txtMaTG.Text.ToString().Trim() + "','" + txtMaDT.Text.ToString().Trim()
                                        + "',N'" + txtMaVaiTro.Text.Trim() + "',N'" + rtxtGhiChu.Text.Trim() + "')";
                        ChucNang.ChayCauLenhSQL(sql); //Thực hiện câu lệnh sql
                        MessageBox.Show("Lưu thành công!");
                    }
                }
            }
            else
            {
                sql = "INSERT INTO TacGia_DeTai VALUES('" + txtMaTG.Text.ToString().Trim() + "','" + txtMaDT.Text.ToString().Trim()
                                + "',N'" + txtMaVaiTro.Text.Trim() + "',N'" + rtxtGhiChu.Text.Trim() + "')";
                ChucNang.ChayCauLenhSQL(sql); //Thực hiện câu lệnh sql
                MessageBox.Show("Lưu thành công!");
            }

            TaiDuLieuVaoGridView(); //Nạp lại DataGridView
            XoaDuLieuTextBox();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            cbtxtTG.Enabled = false;
            cbtxtDT.Enabled = false;
            cbtxtVT.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaDuLieuTextBox();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            cbtxtTG.Enabled = false;
            cbtxtDT.Enabled = false;
            TaiDuLieuVaoGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TacGia_DeTai_Load(object sender, EventArgs e)
        {
            string sql;
            cbtxtTG.Enabled = false;
            cbtxtDT.Enabled = false;
            cbtxtVT.Enabled = false;
            txtMaTG.Enabled = false;
            txtMaDT.Enabled = false;
            txtMaVaiTro.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            sql = "SELECT * FROM TacGia";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtTG, "MaTacGia", "TenTacGia");
            cbtxtTG.SelectedIndex = -1;
            sql = "SELECT * FROM DeTaiNghienCuu";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtDT, "MaDeTai", "TenDeTai");
            cbtxtDT.SelectedIndex = -1;
            sql = "SELECT * FROM VaiTro";
            ChucNang.DuaDuLieuVaoComboBox(sql, cbtxtVT, "MaVaiTro", "TenVaiTro");
            cbtxtVT.SelectedIndex = -1;
            TaiDuLieuVaoGridView(); //Hiển thị bảng
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            cbtxtTG.Enabled = true;
            cbtxtDT.Enabled = true;
            cbtxtVT.Enabled = true;
            txtMaDT.Enabled = false;
            txtMaTG.Enabled = false;
            txtMaVaiTro.Enabled = true;
            btnHuy.Enabled = true;
            string sql;
            if ((cbtxtTG.Text == "") && (cbtxtDT.Text == "") && (cbtxtVT.Text == "")
                && (rtxtGhiChu.Text == ""))
            {
                TaiDuLieuVaoGridView();
                return;
            }
            sql = "SELECT * from TacGia_DeTai WHERE 1=1";
            if (txtMaTG.Text != "")
                sql += " AND MaTacGia LIKE N'%" + txtMaTG.Text + "%'";
            if (txtMaDT.Text != "")
                sql += " AND MaDeTai LIKE N'%" + txtMaDT.Text + "%'";
            if (txtMaVaiTro.Text != "")
                sql += " AND MaVaiTro LIKE N'%" + txtMaVaiTro.Text + "%'";
            if (rtxtGhiChu.Text != "")
                sql += " AND GhiChu LIKE N'%" + rtxtGhiChu.Text + "%'";

            dtTGDT = ChucNang.TaiDuLieuVaoBang(sql);
            if (dtTGDT.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + dtTGDT.Rows.Count + "  dữ liệu thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtgTGDT.DataSource = dtTGDT;

            XoaDuLieuTextBox();
        }


        //Lấy dữ liệu từ sql server đưa vào datagridview
        private void TaiDuLieuVaoGridView()
        {
            string sql;
            sql = "SELECT * FROM TacGia_DeTai";
            dtTGDT = ChucNang.TaiDuLieuVaoBang(sql); //Đọc dữ liệu từ bảng
            dtgTGDT.DataSource = dtTGDT; //Nguồn dữ liệu            
            dtgTGDT.Columns[0].HeaderText = "Mã tác giả";
            dtgTGDT.Columns[1].HeaderText = "Mã đề tài";
            dtgTGDT.Columns[2].HeaderText = "Mã vai trò";
            dtgTGDT.Columns[3].HeaderText = "Ghi chú";

            dtgTGDT.Columns[0].Width = 120;
            dtgTGDT.Columns[1].Width = 120;
            dtgTGDT.Columns[2].Width = 120;
            dtgTGDT.Columns[3].Width = 120;

            dtgTGDT.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dtgTGDT.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void XoaDuLieuTextBox()
        {
            cbtxtTG.Text = "";
            cbtxtDT.Text = "";
            cbtxtVT.Text = "";
            rtxtGhiChu.Text = "";
            txtMaTG.Text = "";
            txtMaDT.Text = "";
            txtMaVaiTro.Text = "";
        }

        private void cbtxtTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaTacGia FROM TacGia WHERE TenTacGia=N'" + cbtxtTG.Text + "'";
            txtMaTG.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaTG_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenTacGia FROM TacGia WHERE MaTacGia=N'" + txtMaTG.Text + "'";
            cbtxtTG.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaDeTai FROM DeTaiNghienCuu WHERE TenDeTai=N'" + cbtxtDT.Text + "'";
            txtMaDT.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaDT_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenDeTai FROM DeTaiNghienCuu WHERE MaDeTai=N'" + txtMaDT.Text + "'";
            cbtxtDT.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void cbtxtVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaVaiTro FROM VaiTro WHERE TenVaiTro=N'" + cbtxtVT.Text + "'";
            txtMaVaiTro.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void txtMaVaiTro_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TenVaiTro FROM VaiTro WHERE MaVaiTro=N'" + txtMaVaiTro.Text + "'";
            cbtxtVT.Text = ChucNang.LayDuLieuTuSQL(sql);
        }

        private void dtgTGDT_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false) //Không cho lấy dữ liệu từ datagrid lên textbox
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbtxtTG.Focus();
                return;
            }
            if (dtTGDT.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTG.Text = dtgTGDT.CurrentRow.Cells["MaTacGia"].Value.ToString();
            txtMaDT.Text = dtgTGDT.CurrentRow.Cells["MaDeTai"].Value.ToString();
            txtMaVaiTro.Text = dtgTGDT.CurrentRow.Cells["MaVaiTro"].Value.ToString();
            rtxtGhiChu.Text = dtgTGDT.CurrentRow.Cells["GhiChu"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }
    }
}
