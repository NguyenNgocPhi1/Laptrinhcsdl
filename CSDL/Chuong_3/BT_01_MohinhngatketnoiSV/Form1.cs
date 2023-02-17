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

namespace BT_01_MohinhngatketnoiSV
{
    public partial class Form1 : Form
    {
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
        DataSet ds = new DataSet();
        OleDbDataAdapter adpKhoa, adpSinhvien, adpKetqua;
        OleDbCommandBuilder cmbSinhvien;
        int stt = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_tao_doi_tuong();
            Doc_du_lieu();
            Moc_noi_quan_he();
            Khoi_tao_comboBox();
            stt = 0;
            Gan_du_lieu(stt);

        }

        private void Gan_du_lieu(int stt)
        {
            // Lấy dòng dữ liệu thứ stt trong tblSinhVien
            DataRow rsv = ds.Tables["SINHVIEN"].Rows[stt];
            txtmasv.Text = rsv["MaSV"].ToString();
            txthosv.Text = rsv["HoSV"].ToString();
            txttensv.Text = rsv["TenSV"].ToString();
            chkphai.Checked = (Boolean)rsv["Phai"];
            dtpngaysinh.Value = (DateTime)rsv["NgaySinh"];
            txtnoisinh.Text = rsv["NoiSinh"].ToString();
            cbomakh.SelectedValue = rsv["MaKH"].ToString();
            txthocbong.Text = rsv["HocBong"].ToString();

            // Tính tổng điểm
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();

            // Thể hiện số thứ tự mẫu tin hiện hành
            lblSTT.Text = (stt + 1) + " / " + ds.Tables["SINHVIEN"].Rows.Count;
        }

        private object Tong_diem(string msv)
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

        private void Moc_noi_quan_he()
        {
            // Tạo quan hệ giữa tblKhoa và tblSinhVien
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            // Tạo quan hệ giữa tblSinhVien và tblKetQua
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            // Loại bỏ Cascade delete trong các quan hệ
            ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            if (stt == 0)
            {
                stt = ds.Tables["SINHVIEN"].Rows.Count - 1;
                Gan_du_lieu(stt);
                return;
            }
            stt--;
            Gan_du_lieu(stt);
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            if(stt == ds.Tables["SINHVIEN"].Rows.Count-1)
            {
                stt = 0;
                Gan_du_lieu(stt);
                return;
            }    
            stt++;
            Gan_du_lieu(stt);                   
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            DataTable tblSinhvien = ds.Tables["SINHVIEN"];
            DataRow rsv = tblSinhvien.Rows.Find(txtmasv.Text);

            DataRow[] Mang_dong_Lien_quan = rsv.GetChildRows("FK_SV_KQ");
            if (Mang_dong_Lien_quan.Length > 0)
                MessageBox.Show("Không xóa được do tồn tại những dòng liên quan trong kết quả");
            else
            {
                rsv.Delete();
                int n = adpSinhvien.Update(ds, "SINHVIEN");
                if (n > 0)
                    MessageBox.Show("Hủy sinh viên thành công !");
                stt = 0;
                Gan_du_lieu(stt);
            }    
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            DataTable tblSinhvien = ds.Tables["SINHVIEN"];
            if(txtmasv.ReadOnly == true)
            {
                DataRow rsv = tblSinhvien.Rows.Find(txtmasv.Text);
                rsv["HoSV"] = txthosv.Text;
                rsv["TenSV"] = txttensv.Text;
                rsv["Phai"] = chkphai.Checked;
                rsv["NgaySinh"] = dtpngaysinh.Value;
                rsv["NoiSinh"] = txtnoisinh.Text;
                rsv["MaKH"] = cbomakh.SelectedValue.ToString();
                rsv["HocBong"] = txthocbong.Text;
            }
            else
            {
                // Kiểm tra khoá chính có trùng hay không?
                DataRow rsv = tblSinhvien.Rows.Find(txtmasv.Text);
                if (rsv != null) // Đã trùng khoá chính
                {
                    MessageBox.Show("Trùng khoá chính. Nhập lại Mã SV");
                    txtmasv.Focus();
                    return;
                }
                // Tạo mới sinh viên
                rsv = tblSinhvien.NewRow();
                rsv["MaSV"] = txtmasv.Text;
                rsv["HoSV"] = txthosv.Text;
                rsv["TenSV"] = txttensv.Text;
                rsv["Phai"] = chkphai.Checked;
                rsv["NgaySinh"] = dtpngaysinh.Value;
                rsv["NoiSinh"] = txtnoisinh.Text;
                rsv["MaKH"] = cbomakh.SelectedValue.ToString();
                rsv["HocBong"] = txthocbong.Text;
                tblSinhvien.Rows.Add(rsv);
                txtmasv.ReadOnly = true;
            }
            int n = adpSinhvien.Update(ds, "SINHVIEN");
            if (n > 0)
                MessageBox.Show("Cập nhập sinh viên thành công !");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox)
                    (ctl as TextBox).Clear();
                else if (ctl is CheckBox)
                    (ctl as CheckBox).Checked = true;
                else if (ctl is ComboBox)
                    (ctl as ComboBox).SelectedIndex = 0;
                else if (ctl is DateTimePicker)
                    (ctl as DateTimePicker).Value = new DateTime(2005, 1, 1);
            txtmasv.Focus();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Gan_du_lieu(stt);
        }

        private void Doc_du_lieu()
        {
            adpKhoa.FillSchema(ds, SchemaType.Source, "KHOA");
            adpKhoa.Fill(ds, "KHOA");
            adpSinhvien.FillSchema(ds, SchemaType.Source, "SINHVIEN");
            adpSinhvien.Fill(ds, "SINHVIEN");
            adpKetqua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetqua.Fill(ds, "KETQUA");
        }

        private void Khoi_tao_doi_tuong()
        {
            adpKhoa = new OleDbDataAdapter("select * from khoa", strcon);
            adpSinhvien = new OleDbDataAdapter("select * from sinhvien", strcon);
            adpKetqua = new OleDbDataAdapter("select * from ketqua", strcon);

            cmbSinhvien = new OleDbCommandBuilder(adpSinhvien);
        }
    }
}
