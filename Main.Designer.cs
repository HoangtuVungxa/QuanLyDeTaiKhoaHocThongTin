namespace QuanLyDeTai
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuTaiKhoanDaDuyet = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuTaiKhoanChoDuyet = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuThayDoiTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuDanhMucDeTai = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuLyLichKhoaHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuDanhSachTroLy = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuDanhMucTacGia = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuTraCuu = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuTraCuuTheoDMDT = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuTraCuuTheoLLKH = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHeThong,
            this.MenuDanhMuc,
            this.subMenuTraCuu,
            this.MenuGioiThieu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuHeThong
            // 
            this.MenuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuBaoCao,
            this.subMenuTaiKhoanDaDuyet,
            this.subMenuTaiKhoanChoDuyet,
            this.subMenuDoiMatKhau,
            this.subMenuThayDoiTaiKhoan,
            this.subMenuThoat});
            this.MenuHeThong.Name = "MenuHeThong";
            this.MenuHeThong.Size = new System.Drawing.Size(69, 20);
            this.MenuHeThong.Text = "Hệ thống";
            // 
            // subMenuBaoCao
            // 
            this.subMenuBaoCao.Name = "subMenuBaoCao";
            this.subMenuBaoCao.Size = new System.Drawing.Size(180, 22);
            this.subMenuBaoCao.Text = "Báo cáo";
            this.subMenuBaoCao.Click += new System.EventHandler(this.subMenuBaoCao_Click);
            // 
            // subMenuTaiKhoanDaDuyet
            // 
            this.subMenuTaiKhoanDaDuyet.Name = "subMenuTaiKhoanDaDuyet";
            this.subMenuTaiKhoanDaDuyet.Size = new System.Drawing.Size(180, 22);
            this.subMenuTaiKhoanDaDuyet.Text = "Tài khoản đã duyệt";
            this.subMenuTaiKhoanDaDuyet.Click += new System.EventHandler(this.subMenuTaiKhoanDaDuyet_Click);
            // 
            // subMenuTaiKhoanChoDuyet
            // 
            this.subMenuTaiKhoanChoDuyet.Name = "subMenuTaiKhoanChoDuyet";
            this.subMenuTaiKhoanChoDuyet.Size = new System.Drawing.Size(180, 22);
            this.subMenuTaiKhoanChoDuyet.Text = "Tài khoản chờ duyệt";
            this.subMenuTaiKhoanChoDuyet.Click += new System.EventHandler(this.subMenuTaiKhoanChoDuyet_Click);
            // 
            // subMenuThayDoiTaiKhoan
            // 
            this.subMenuThayDoiTaiKhoan.Name = "subMenuThayDoiTaiKhoan";
            this.subMenuThayDoiTaiKhoan.Size = new System.Drawing.Size(180, 22);
            this.subMenuThayDoiTaiKhoan.Text = "Thay đổi tài khoản";
            this.subMenuThayDoiTaiKhoan.Click += new System.EventHandler(this.subMenuThayDoiTaiKhoan_Click);
            // 
            // subMenuThoat
            // 
            this.subMenuThoat.Name = "subMenuThoat";
            this.subMenuThoat.Size = new System.Drawing.Size(180, 22);
            this.subMenuThoat.Text = "Thoát";
            this.subMenuThoat.Click += new System.EventHandler(this.subMenuThoat_Click);
            // 
            // MenuDanhMuc
            // 
            this.MenuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuDanhMucDeTai,
            this.subMenuLyLichKhoaHoc,
            this.subMenuDanhSachTroLy,
            this.subMenuDanhMucTacGia});
            this.MenuDanhMuc.Name = "MenuDanhMuc";
            this.MenuDanhMuc.Size = new System.Drawing.Size(74, 20);
            this.MenuDanhMuc.Text = "Danh mục";
            // 
            // subMenuDanhMucDeTai
            // 
            this.subMenuDanhMucDeTai.Name = "subMenuDanhMucDeTai";
            this.subMenuDanhMucDeTai.Size = new System.Drawing.Size(180, 22);
            this.subMenuDanhMucDeTai.Text = "Danh mục đề tài";
            this.subMenuDanhMucDeTai.Click += new System.EventHandler(this.subMenuDanhMucDeTai_Click);
            // 
            // subMenuLyLichKhoaHoc
            // 
            this.subMenuLyLichKhoaHoc.Name = "subMenuLyLichKhoaHoc";
            this.subMenuLyLichKhoaHoc.Size = new System.Drawing.Size(180, 22);
            this.subMenuLyLichKhoaHoc.Text = "Lý lịch khoa học";
            this.subMenuLyLichKhoaHoc.Click += new System.EventHandler(this.subMenuLyLichKhoaHoc_Click);
            // 
            // subMenuDanhSachTroLy
            // 
            this.subMenuDanhSachTroLy.Name = "subMenuDanhSachTroLy";
            this.subMenuDanhSachTroLy.Size = new System.Drawing.Size(180, 22);
            this.subMenuDanhSachTroLy.Text = "Danh sách trợ lý";
            this.subMenuDanhSachTroLy.Click += new System.EventHandler(this.subMenuDanhSachTroLy_Click);
            // 
            // subMenuDanhMucTacGia
            // 
            this.subMenuDanhMucTacGia.Name = "subMenuDanhMucTacGia";
            this.subMenuDanhMucTacGia.Size = new System.Drawing.Size(180, 22);
            this.subMenuDanhMucTacGia.Text = "Danh mục tác giả";
            this.subMenuDanhMucTacGia.Click += new System.EventHandler(this.subMenuDanhMucTacGia_Click);
            // 
            // subMenuTraCuu
            // 
            this.subMenuTraCuu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuTraCuuTheoDMDT,
            this.subMenuTraCuuTheoLLKH});
            this.subMenuTraCuu.Name = "subMenuTraCuu";
            this.subMenuTraCuu.Size = new System.Drawing.Size(57, 20);
            this.subMenuTraCuu.Text = "Tra cứu";
            // 
            // subMenuTraCuuTheoDMDT
            // 
            this.subMenuTraCuuTheoDMDT.Name = "subMenuTraCuuTheoDMDT";
            this.subMenuTraCuuTheoDMDT.Size = new System.Drawing.Size(189, 22);
            this.subMenuTraCuuTheoDMDT.Text = "Theo danh mục đề tài";
            this.subMenuTraCuuTheoDMDT.Click += new System.EventHandler(this.subMenuTraCuuTheoDMDT_Click);
            // 
            // subMenuTraCuuTheoLLKH
            // 
            this.subMenuTraCuuTheoLLKH.Name = "subMenuTraCuuTheoLLKH";
            this.subMenuTraCuuTheoLLKH.Size = new System.Drawing.Size(189, 22);
            this.subMenuTraCuuTheoLLKH.Text = "Theo lý lịch khoa học";
            this.subMenuTraCuuTheoLLKH.Click += new System.EventHandler(this.subMenuTraCuuTheoLLKH_Click);
            // 
            // MenuGioiThieu
            // 
            this.MenuGioiThieu.Name = "MenuGioiThieu";
            this.MenuGioiThieu.Size = new System.Drawing.Size(70, 20);
            this.MenuGioiThieu.Text = "Giới thiệu";
            this.MenuGioiThieu.Click += new System.EventHandler(this.MenuGioiThieu_Click);
            // 
            // subMenuDoiMatKhau
            // 
            this.subMenuDoiMatKhau.Name = "subMenuDoiMatKhau";
            this.subMenuDoiMatKhau.Size = new System.Drawing.Size(180, 22);
            this.subMenuDoiMatKhau.Text = "Đổi mật khẩu";
            this.subMenuDoiMatKhau.Click += new System.EventHandler(this.subMenuDoiMatKhau_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("UTM Flavour", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(688, 34);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 27);
            this.lblUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("UTM Flavour", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(608, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Xin chào";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRANG CHỦ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuHeThong;
        private System.Windows.Forms.ToolStripMenuItem subMenuThoat;
        private System.Windows.Forms.ToolStripMenuItem MenuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem MenuGioiThieu;
        private System.Windows.Forms.ToolStripMenuItem subMenuDanhMucDeTai;
        private System.Windows.Forms.ToolStripMenuItem subMenuLyLichKhoaHoc;
        private System.Windows.Forms.ToolStripMenuItem subMenuDanhSachTroLy;
        private System.Windows.Forms.ToolStripMenuItem subMenuTaiKhoanChoDuyet;
        private System.Windows.Forms.ToolStripMenuItem subMenuThayDoiTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem subMenuTaiKhoanDaDuyet;
        private System.Windows.Forms.ToolStripMenuItem subMenuTraCuu;
        private System.Windows.Forms.ToolStripMenuItem subMenuTraCuuTheoDMDT;
        private System.Windows.Forms.ToolStripMenuItem subMenuTraCuuTheoLLKH;
        private System.Windows.Forms.ToolStripMenuItem subMenuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem subMenuDanhMucTacGia;
        private System.Windows.Forms.ToolStripMenuItem subMenuDoiMatKhau;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label2;
    }
}