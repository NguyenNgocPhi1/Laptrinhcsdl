using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Dataset_Co_dinh_kieu_Sinhvien
{
    public partial class Form1 : Form
    {
        QLSV ds = new QLSV();
        QLSVTableAdapters.KHOATableAdapter dapKhoa = new QLSVTableAdapters.KHOATableAdapter();
        QLSVTableAdapters.KETQUATableAdapter dapKetqua = new QLSVTableAdapters.KETQUATableAdapter();
        QLSVTableAdapters.SINHVIENTableAdapter dapSinhvien = new QLSVTableAdapters.SINHVIENTableAdapter();
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }
        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
        }
        private double Tong_diem(string msv)
        {
            double kq = 0;
            Object td = ds.Tables["KETQUA"].Compute("sum(Diem)", "MaSV='" + msv + "'");
            // Lưu ý: trường hợp sinh viên không có điểm thì phương thức Compute trả về giá trị DBNull
            if (td == DBNull.Value)
                kq = 0;
            else
                kq = Convert.ToDouble(td);
            return kq;
        }
        private void Khoi_tao_comboBox()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = ds.Tables["KHOA"];
        }

        private void Khoi_tao_BindingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = ds.SINHVIEN.TableName;
        }

        private void Doc_du_lieu()
        {
            dapKhoa.Fill(ds.KHOA);
            dapSinhvien.Fill(ds.SINHVIEN);
            dapKetqua.Fill(ds.KETQUA);
        }
        private void Lien_ket_dieu_khien()
        {
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name != "txttongdiem")
                    ctl.DataBindings.Add("text", bs, ctl.Name.Substring(3), true);
                else if (ctl is CheckBox)
                    ctl.DataBindings.Add("checked", bs, ctl.Name.Substring(3), true);
                else if (ctl is ComboBox)
                    ctl.DataBindings.Add("selectedvalue", bs, ctl.Name.Substring(3), true);
                else if (ctl is DateTimePicker)
                    ctl.DataBindings.Add("value", bs, ctl.Name.Substring(3), true);
            //ĐỊnh dạng lại học bỗng trước khi hiển thị
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";
        }
        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmasv.ReadOnly = true;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            QLSV.SINHVIENRow r = (bs.Current as DataRowView).Row as QLSV.SINHVIENRow;
            if (r.GetKETQUARows().Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên qua trong KETQUA!");
                return;
            }
            bs.RemoveCurrent();

            //hủy trong CSDL
            int n = dapSinhvien.Update(ds.SINHVIEN);
            if (n > 0)
                MessageBox.Show("Hủy sinh viên thành công!");
            txtmasv.ReadOnly = true;
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmasv.ReadOnly) //thêm mới
            {
                QLSV.SINHVIENRow r = ds.SINHVIEN.FindByMaSV(txtmasv.Text);
                if (r != null)
                {
                    MessageBox.Show("Trùng khóa chính! Nhập lại");
                    txtmasv.Focus();
                    return;
                }

            }
            txtmasv.ReadOnly = true;

            //Cập nhập lạ việ thêm mới hay sửa trong DataTable
            bs.EndEdit();
            int n = dapSinhvien.Update(ds.SINHVIEN);
            if (n > 0)
                MessageBox.Show("Cập nhập sinh viên thành công!");

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            //Thêm mới
            bs.AddNew();
            txtmasv.Focus();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Doc_du_lieu();
            Khoi_tao_BindingSource();
            Lien_ket_dieu_khien();
            Khoi_tao_comboBox();
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();
        }
    }
}
