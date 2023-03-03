
namespace BT04_Binding_SinhVien_Controls
{
    partial class Form1
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
            this.dtpngaysinh = new System.Windows.Forms.DateTimePicker();
            this.cbomakh = new System.Windows.Forms.ComboBox();
            this.txthosv = new System.Windows.Forms.TextBox();
            this.txttongdiem = new System.Windows.Forms.TextBox();
            this.txthocbong = new System.Windows.Forms.TextBox();
            this.txtnoisinh = new System.Windows.Forms.TextBox();
            this.txttensv = new System.Windows.Forms.TextBox();
            this.txtmasv = new System.Windows.Forms.TextBox();
            this.btnkhong = new System.Windows.Forms.Button();
            this.btnghi = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnsau = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btntruoc = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkphai = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSTT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpngaysinh
            // 
            this.dtpngaysinh.CustomFormat = "dd/MM/yyyy";
            this.dtpngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaysinh.Location = new System.Drawing.Point(336, 121);
            this.dtpngaysinh.Name = "dtpngaysinh";
            this.dtpngaysinh.Size = new System.Drawing.Size(183, 20);
            this.dtpngaysinh.TabIndex = 77;
            // 
            // cbomakh
            // 
            this.cbomakh.FormattingEnabled = true;
            this.cbomakh.Location = new System.Drawing.Point(336, 151);
            this.cbomakh.Name = "cbomakh";
            this.cbomakh.Size = new System.Drawing.Size(183, 21);
            this.cbomakh.TabIndex = 76;
            // 
            // txthosv
            // 
            this.txthosv.Location = new System.Drawing.Point(93, 91);
            this.txthosv.Name = "txthosv";
            this.txthosv.Size = new System.Drawing.Size(321, 20);
            this.txthosv.TabIndex = 75;
            // 
            // txttongdiem
            // 
            this.txttongdiem.Location = new System.Drawing.Point(336, 181);
            this.txttongdiem.Name = "txttongdiem";
            this.txttongdiem.Size = new System.Drawing.Size(183, 20);
            this.txttongdiem.TabIndex = 74;
            // 
            // txthocbong
            // 
            this.txthocbong.Location = new System.Drawing.Point(93, 181);
            this.txthocbong.Name = "txthocbong";
            this.txthocbong.Size = new System.Drawing.Size(155, 20);
            this.txthocbong.TabIndex = 73;
            // 
            // txtnoisinh
            // 
            this.txtnoisinh.Location = new System.Drawing.Point(93, 151);
            this.txtnoisinh.Name = "txtnoisinh";
            this.txtnoisinh.Size = new System.Drawing.Size(155, 20);
            this.txtnoisinh.TabIndex = 72;
            // 
            // txttensv
            // 
            this.txttensv.Location = new System.Drawing.Point(416, 91);
            this.txttensv.Name = "txttensv";
            this.txttensv.Size = new System.Drawing.Size(103, 20);
            this.txttensv.TabIndex = 71;
            // 
            // txtmasv
            // 
            this.txtmasv.Location = new System.Drawing.Point(93, 61);
            this.txtmasv.Name = "txtmasv";
            this.txtmasv.ReadOnly = true;
            this.txtmasv.Size = new System.Drawing.Size(426, 20);
            this.txtmasv.TabIndex = 70;
            // 
            // btnkhong
            // 
            this.btnkhong.BackColor = System.Drawing.Color.Navy;
            this.btnkhong.Location = new System.Drawing.Point(447, 209);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(72, 34);
            this.btnkhong.TabIndex = 69;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = false;
            this.btnkhong.Click += new System.EventHandler(this.btnkhong_Click);
            // 
            // btnghi
            // 
            this.btnghi.BackColor = System.Drawing.Color.Navy;
            this.btnghi.Location = new System.Drawing.Point(375, 209);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(72, 34);
            this.btnghi.TabIndex = 68;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = false;
            this.btnghi.Click += new System.EventHandler(this.btnghi_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.Color.Navy;
            this.btnhuy.Location = new System.Drawing.Point(303, 209);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(72, 34);
            this.btnhuy.TabIndex = 67;
            this.btnhuy.Text = "Huỷ";
            this.btnhuy.UseVisualStyleBackColor = false;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnsau
            // 
            this.btnsau.BackColor = System.Drawing.Color.Navy;
            this.btnsau.Location = new System.Drawing.Point(159, 209);
            this.btnsau.Name = "btnsau";
            this.btnsau.Size = new System.Drawing.Size(72, 34);
            this.btnsau.TabIndex = 66;
            this.btnsau.Text = "Sau";
            this.btnsau.UseVisualStyleBackColor = false;
            this.btnsau.Click += new System.EventHandler(this.btnsau_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.Navy;
            this.btnthem.Location = new System.Drawing.Point(231, 209);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(72, 34);
            this.btnthem.TabIndex = 65;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btntruoc
            // 
            this.btntruoc.BackColor = System.Drawing.Color.Navy;
            this.btntruoc.Location = new System.Drawing.Point(15, 209);
            this.btntruoc.Name = "btntruoc";
            this.btntruoc.Size = new System.Drawing.Size(72, 34);
            this.btntruoc.TabIndex = 64;
            this.btntruoc.Text = "Trước";
            this.btntruoc.UseVisualStyleBackColor = false;
            this.btntruoc.Click += new System.EventHandler(this.btntruoc_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Tổng điểm";
            // 
            // chkphai
            // 
            this.chkphai.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkphai.Location = new System.Drawing.Point(15, 121);
            this.chkphai.Name = "chkphai";
            this.chkphai.Size = new System.Drawing.Size(92, 24);
            this.chkphai.TabIndex = 63;
            this.chkphai.Text = "Phái";
            this.chkphai.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Học bỗng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Khoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Nơi sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Họ tên SV";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(547, 49);
            this.label8.TabIndex = 55;
            this.label8.Text = "DANH SÁCH SINH VIÊN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSTT
            // 
            this.lblSTT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSTT.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(87, 209);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(72, 34);
            this.lblSTT.TabIndex = 56;
            this.lblSTT.Text = "STT";
            this.lblSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Mã SV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(547, 266);
            this.Controls.Add(this.dtpngaysinh);
            this.Controls.Add(this.cbomakh);
            this.Controls.Add(this.txthosv);
            this.Controls.Add(this.txttongdiem);
            this.Controls.Add(this.txthocbong);
            this.Controls.Add(this.txtnoisinh);
            this.Controls.Add(this.txttensv);
            this.Controls.Add(this.txtmasv);
            this.Controls.Add(this.btnkhong);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnsau);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.btntruoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkphai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binding sinh viên Contols";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpngaysinh;
        private System.Windows.Forms.ComboBox cbomakh;
        private System.Windows.Forms.TextBox txthosv;
        private System.Windows.Forms.TextBox txttongdiem;
        private System.Windows.Forms.TextBox txthocbong;
        private System.Windows.Forms.TextBox txtnoisinh;
        private System.Windows.Forms.TextBox txttensv;
        private System.Windows.Forms.TextBox txtmasv;
        private System.Windows.Forms.Button btnkhong;
        private System.Windows.Forms.Button btnghi;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnsau;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btntruoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkphai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSTT;
        private System.Windows.Forms.Label label1;
    }
}

