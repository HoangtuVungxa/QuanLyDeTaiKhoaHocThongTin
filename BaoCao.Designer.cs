namespace QuanLyDeTai
{
    partial class BaoCao
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
            this.rpv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnXuatBC = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbtxtTK = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpv
            // 
            this.rpv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rpv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpv.DocumentMapCollapsed = true;
            this.rpv.LocalReport.ReportEmbeddedResource = "QuanLyDeTai.BaoCao.rdlc";
            this.rpv.Location = new System.Drawing.Point(0, 0);
            this.rpv.Name = "rpv";
            this.rpv.ServerReport.BearerToken = null;
            this.rpv.Size = new System.Drawing.Size(800, 450);
            this.rpv.TabIndex = 0;
            // 
            // btnXuatBC
            // 
            this.btnXuatBC.Location = new System.Drawing.Point(320, 14);
            this.btnXuatBC.Name = "btnXuatBC";
            this.btnXuatBC.Size = new System.Drawing.Size(89, 23);
            this.btnXuatBC.TabIndex = 21;
            this.btnXuatBC.Text = "Xuất báo cáo";
            this.btnXuatBC.UseVisualStyleBackColor = true;
            this.btnXuatBC.Click += new System.EventHandler(this.btnXuatBC_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rpv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnXuatBC);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbtxtTK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 340);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 110);
            this.panel3.TabIndex = 24;
            // 
            // cbtxtTK
            // 
            this.cbtxtTK.FormattingEnabled = true;
            this.cbtxtTK.Items.AddRange(new object[] {
            "Theo Năm",
            "Theo Khoa",
            "Theo tác giả",
            "Tất cả"});
            this.cbtxtTK.Location = new System.Drawing.Point(132, 14);
            this.cbtxtTK.Name = "cbtxtTK";
            this.cbtxtTK.Size = new System.Drawing.Size(121, 21);
            this.cbtxtTK.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Chọn kiểu báo cáo";
            // 
            // BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "BaoCao";
            this.Text = "BaoCao";
            this.Load += new System.EventHandler(this.BaoCao_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv;
        private System.Windows.Forms.Button btnXuatBC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbtxtTK;
    }
}