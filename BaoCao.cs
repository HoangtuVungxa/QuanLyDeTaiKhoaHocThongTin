using Microsoft.Reporting.WinForms;
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
    public partial class BaoCao : Form
    {
        string sql;
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {

            this.rpv.RefreshReport();
        }

        private void btnXuatBC_Click(object sender, EventArgs e)
        {
            if ((cbtxtTK.Text == "") || (cbtxtTK.Text == "Theo Năm") || (cbtxtTK.Text == "Theo Khoa") || (cbtxtTK.Text == "Theo tác giả") || (cbtxtTK.Text == "Tất cả"))
            {
                sql = "SELECT TG.MaTacGia,TenTacGia,DT.MaDeTai,TenDeTai,TenCapBac,TenChucVu,TenHocVi,TenVaiTro,NamSinh,SoDienThoai,Email,TG.GhiChu " +
                    " FROM DeTaiNghienCuu AS DT, CapBac AS CB, ChucVu AS CV, HocVi AS HV, TacGia_DeTai AS TGDT, VaiTro AS VT, TacGia AS TG " +
                    " WHERE DT.MaDeTai = TGDT.MaDeTai AND TG.MaTacGia = TGDT.MaTacGia AND VT.MaVaiTro = TGDT.MaVaiTro  AND TG.MaCapBac = CB.MaCapBac AND TG.MaChucVu = CV.MaChucVu AND TG.MaHocVi = HV.MaHocVi " +
                    " ORDER BY TG.MaTacGia";
                DataTable dt = new DataTable();
                dt = ChucNang.TaiDuLieuVaoBang(sql);
                rpv.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                rpv.LocalReport.ReportPath = @"C:\11.LAPTRINH\C#\BT.QuanLyDeTai\QuanLyDeTai\BaoCao.rdlc";
                rpv.LocalReport.DataSources.Add(rds);
                rpv.RefreshReport();
            }
        }
    }
}
