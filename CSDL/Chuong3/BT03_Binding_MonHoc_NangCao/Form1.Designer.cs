
namespace BT03_Binding_MonHoc_NangCao
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtloaimh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttenmh = new System.Windows.Forms.TextBox();
            this.txtsotiet = new System.Windows.Forms.TextBox();
            this.txtmamh = new System.Windows.Forms.TextBox();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnkhong = new System.Windows.Forms.Button();
            this.btnghi = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btncuoi = new System.Windows.Forms.Button();
            this.btnsau = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btndau = new System.Windows.Forms.Button();
            this.btntruoc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSTT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bdnmonhoc = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.bdnmonhoc)).BeginInit();
            this.bdnmonhoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtloaimh
            // 
            this.txtloaimh.Location = new System.Drawing.Point(90, 160);
            this.txtloaimh.Name = "txtloaimh";
            this.txtloaimh.Size = new System.Drawing.Size(335, 20);
            this.txtloaimh.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "Loại môn";
            // 
            // txttenmh
            // 
            this.txttenmh.Location = new System.Drawing.Point(90, 97);
            this.txttenmh.Name = "txttenmh";
            this.txttenmh.Size = new System.Drawing.Size(335, 20);
            this.txttenmh.TabIndex = 94;
            // 
            // txtsotiet
            // 
            this.txtsotiet.Location = new System.Drawing.Point(90, 128);
            this.txtsotiet.Name = "txtsotiet";
            this.txtsotiet.Size = new System.Drawing.Size(335, 20);
            this.txtsotiet.TabIndex = 93;
            // 
            // txtmamh
            // 
            this.txtmamh.Location = new System.Drawing.Point(90, 66);
            this.txtmamh.Name = "txtmamh";
            this.txtmamh.ReadOnly = true;
            this.txtmamh.Size = new System.Drawing.Size(335, 20);
            this.txtmamh.TabIndex = 92;
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.Navy;
            this.btnthoat.Location = new System.Drawing.Point(334, 246);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(72, 34);
            this.btnthoat.TabIndex = 91;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = false;
            // 
            // btnkhong
            // 
            this.btnkhong.BackColor = System.Drawing.Color.Navy;
            this.btnkhong.Location = new System.Drawing.Point(259, 246);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(72, 34);
            this.btnkhong.TabIndex = 90;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = false;
            this.btnkhong.Click += new System.EventHandler(this.btnkhong_Click);
            // 
            // btnghi
            // 
            this.btnghi.BackColor = System.Drawing.Color.Navy;
            this.btnghi.Location = new System.Drawing.Point(184, 246);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(72, 34);
            this.btnghi.TabIndex = 89;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = false;
            this.btnghi.Click += new System.EventHandler(this.btnghi_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.Color.Navy;
            this.btnhuy.Location = new System.Drawing.Point(109, 246);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(72, 34);
            this.btnhuy.TabIndex = 88;
            this.btnhuy.Text = "Huỷ";
            this.btnhuy.UseVisualStyleBackColor = false;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btncuoi
            // 
            this.btncuoi.BackColor = System.Drawing.Color.Navy;
            this.btncuoi.Location = new System.Drawing.Point(334, 204);
            this.btncuoi.Name = "btncuoi";
            this.btncuoi.Size = new System.Drawing.Size(72, 34);
            this.btncuoi.TabIndex = 87;
            this.btncuoi.Text = "Cuối";
            this.btncuoi.UseVisualStyleBackColor = false;
            this.btncuoi.Click += new System.EventHandler(this.btncuoi_Click);
            // 
            // btnsau
            // 
            this.btnsau.BackColor = System.Drawing.Color.Navy;
            this.btnsau.Location = new System.Drawing.Point(259, 204);
            this.btnsau.Name = "btnsau";
            this.btnsau.Size = new System.Drawing.Size(72, 34);
            this.btnsau.TabIndex = 86;
            this.btnsau.Text = "Sau";
            this.btnsau.UseVisualStyleBackColor = false;
            this.btnsau.Click += new System.EventHandler(this.btnsau_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.Navy;
            this.btnthem.Location = new System.Drawing.Point(34, 246);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(72, 34);
            this.btnthem.TabIndex = 85;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btndau
            // 
            this.btndau.BackColor = System.Drawing.Color.Navy;
            this.btndau.Location = new System.Drawing.Point(34, 204);
            this.btndau.Name = "btndau";
            this.btndau.Size = new System.Drawing.Size(72, 34);
            this.btndau.TabIndex = 84;
            this.btndau.Text = "Đầu";
            this.btndau.UseVisualStyleBackColor = false;
            this.btndau.Click += new System.EventHandler(this.btndau_Click);
            // 
            // btntruoc
            // 
            this.btntruoc.BackColor = System.Drawing.Color.Navy;
            this.btntruoc.Location = new System.Drawing.Point(109, 204);
            this.btntruoc.Name = "btntruoc";
            this.btntruoc.Size = new System.Drawing.Size(72, 34);
            this.btntruoc.TabIndex = 83;
            this.btntruoc.Text = "Trước";
            this.btntruoc.UseVisualStyleBackColor = false;
            this.btntruoc.Click += new System.EventHandler(this.btntruoc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "Số tiết";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Tên MH";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(469, 49);
            this.label8.TabIndex = 79;
            this.label8.Text = "DANH SÁCH MÔN HỌC";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSTT
            // 
            this.lblSTT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSTT.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(184, 204);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(72, 34);
            this.lblSTT.TabIndex = 80;
            this.lblSTT.Text = "STT";
            this.lblSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Mã MH";
            // 
            // bdnmonhoc
            // 
            this.bdnmonhoc.AddNewItem = null;
            this.bdnmonhoc.CountItem = this.bindingNavigatorCountItem;
            this.bdnmonhoc.DeleteItem = null;
            this.bdnmonhoc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bdnmonhoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdnmonhoc.Location = new System.Drawing.Point(0, 307);
            this.bdnmonhoc.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnmonhoc.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnmonhoc.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnmonhoc.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnmonhoc.Name = "bdnmonhoc";
            this.bdnmonhoc.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnmonhoc.Size = new System.Drawing.Size(469, 25);
            this.bdnmonhoc.TabIndex = 97;
            this.bdnmonhoc.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "/";
            this.bindingNavigatorPositionItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(469, 332);
            this.Controls.Add(this.bdnmonhoc);
            this.Controls.Add(this.txtloaimh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttenmh);
            this.Controls.Add(this.txtsotiet);
            this.Controls.Add(this.txtmamh);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnkhong);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btncuoi);
            this.Controls.Add(this.btnsau);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.btndau);
            this.Controls.Add(this.btntruoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binding Môn Học Nâng Cao";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdnmonhoc)).EndInit();
            this.bdnmonhoc.ResumeLayout(false);
            this.bdnmonhoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtloaimh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttenmh;
        private System.Windows.Forms.TextBox txtsotiet;
        private System.Windows.Forms.TextBox txtmamh;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnkhong;
        private System.Windows.Forms.Button btnghi;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btncuoi;
        private System.Windows.Forms.Button btnsau;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btndau;
        private System.Windows.Forms.Button btntruoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator bdnmonhoc;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    }
}

