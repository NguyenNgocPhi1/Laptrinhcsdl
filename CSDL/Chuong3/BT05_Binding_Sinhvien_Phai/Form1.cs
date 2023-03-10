using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BT05_Binding_Sinhvien_Phai
{
    public partial class Form1 : Form
    {
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
        DataSet ds = new DataSet();
        OleDbDataAdapter adpSinhVien, adpKetQua, adpKhoa;
        OleDbCommandBuilder cmbSinhVien;
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }
        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_tao_doi_tuong();
            Doc_du_lieu();
            Moc_noi_quan_he();
            Khoi_tao_BindingSource();
            Khoi_tao_comboBox();
            Lien_ket_dieu_khien();

        }
        private void Khoi_tao_comboBox()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = ds.Tables["KHOA"];
        }
        private void Doc_du_lieu()
        {
            adpKhoa.FillSchema(ds, SchemaType.Source, "KHOA");
            adpKhoa.Fill(ds, "KHOA");

            adpKetQua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetQua.Fill(ds, "KETQUA");

            adpSinhVien.FillSchema(ds, SchemaType.Source, "SINHVIEN");
            adpSinhVien.Fill(ds, "SINHVIEN");
        }
        private void Khoi_tao_doi_tuong()
        {
            //1. Khởi tạo các đối tượng DataAdapter
            adpKhoa = new OleDbDataAdapter("select * from khoa", strcon);
            adpSinhVien = new OleDbDataAdapter("select * from sinhvien", strcon);
            adpKetQua = new OleDbDataAdapter("select * from ketqua", strcon);

            //2. khởi tạo đối tượng commandBuider
            cmbSinhVien = new OleDbCommandBuilder(adpSinhVien);

        }
        private void Moc_noi_quan_he()
        {
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            //Loại bảo cascade delete trong các quan hệ
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }
        private void Khoi_tao_BindingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = "SINHVIEN";

        }
        private void Lien_ket_dieu_khien()
        {
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name != "txttongdiem" && ctl.Name != "txtphai")
                    ctl.DataBindings.Add("text", bs, ctl.Name.Substring(3), true);
                else if (ctl is CheckBox)
                    ctl.DataBindings.Add("checked", bs, ctl.Name.Substring(3), true);
                else if (ctl is ComboBox)
                    ctl.DataBindings.Add("selectedvalue", bs, ctl.Name.Substring(3), true);
                else if (ctl is DateTimePicker)
                    ctl.DataBindings.Add("value", bs, ctl.Name.Substring(3), true);
            //Binding cho điều khiển txtphai
            //Binding bdphai = new Binding("text", bs, "Phai", true);
            //bdphai.Format += Bdphai_Format;
            //bdphai.Parse += Bdphai_Parse;
            //txtphai.DataBindings.Add(bdphai);
            //ĐỊnh dạng lại học bỗng trước khi hiển thị
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";


        }

        private void Bdphai_Parse(object sender, ConvertEventArgs e)
        {
            if (e.Value == null) return;
            e.Value = e.Value.ToString().ToUpper() == "NAM" ? true : false;
        }

        private void Bdphai_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value == DBNull.Value || e.Value == null) return;
            e.Value = (Boolean)e.Value ? "Nam" : "Nữ";
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
        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmasv.ReadOnly = true;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            //hủy trong DataTable
            //Kiểm tra có tồn tại các mẫu tin có liên quan trong KETQUA hay không trước khi hủy
            //dòng hiện hành đang hiển thị trên Form ==> bs.Current có kiểu Object
            DataRow r = (bs.Current as DataRowView).Row;
            DataRow[] Mang_dong_lien_quan = r.GetChildRows("FK_SV_KQ");
            if (Mang_dong_lien_quan.Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên qua trong KETQUA!");
                return;
            }
            bs.RemoveCurrent();

            //hủy trong CSDL
            int n = adpSinhVien.Update(ds, "SINHVIEN");
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
                DataRow r = ds.Tables["SINHVIEN"].Rows.Find(txtmasv.Text);
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
            int n = adpSinhVien.Update(ds, "SINHVIEN");
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
    }
}
