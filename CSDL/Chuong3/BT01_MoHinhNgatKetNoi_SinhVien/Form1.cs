using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //sử dụng khi dùng Access

namespace BT01_MoHinhNgatKetNoi_SinhVien
{
    public partial class Form1 : Form
    {
        //khai báo các đối tượng cần sử dụng
        //1. Khai báo các đối tượng cần sử dụng
        // 1.1. Chuỗi kết nối
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
        //1.2. Đối tượng kết nối ==> k cần khai báo
        // Khai báo các đối tượng lưu dữ liệu
        DataSet ds = new DataSet();

        //Khai báo các command để đọc ghi dữ liệu với CSDL ==>k cần khai báo

        //1.3 khai báo các DataAdapter với ngtac 1 dataTable thì tương ứng với 1 dataAdapter
        OleDbDataAdapter adpKhoa, adpSinhVien, adpKetQua;

        //1.4 khai báo đối tượng CommandBuider tương ứng để cập nhập dữ liệu cho bản SinhVien .
        // Lưu ý chỉ kbao commandBuider cho đối tượng bảng cần cập nhập.
        OleDbCommandBuilder cmbSinhVien;

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

        private void Doc_du_lieu()
        {
            //1. đọc dữ liệu của bảng Khoa
            //1.1 Sao chép cấu trúc của Table KHOA vào dataTable trong dataSet ds
            adpKhoa.FillSchema(ds, SchemaType.Source, "KHOA");
            //1.2 Sao chép dữ liệu của Table KHOA vào dataTable trong dataset ds
            adpKhoa.Fill(ds, "KHOA");


            //2. đọc dữ liệu cho bảng SINHVIEN
            adpSinhVien.FillSchema(ds, SchemaType.Source, "SINHVIEN");
            adpSinhVien.Fill(ds, "SINHVIEN");

            //3. Đọc dữ liệu bảng KETQUA
            adpKetQua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetQua.Fill(ds, "KETQUA");

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

        private void btntruoc_Click(object sender, EventArgs e)
        {
            if(stt == 0)
            {
                stt = ds.Tables["SINHVIEN"].Rows.Count - 1;
                Gan_du_lieu(stt);
            }
            else
            {
                stt--;
                Gan_du_lieu(stt);
            }
        }
        private void btnsau_Click(object sender, EventArgs e)
        {
            if(stt == ds.Tables["SINHVIEN"].Rows.Count - 1)
            {
                stt = 0;
                Gan_du_lieu(stt);
                return;
            }
            else
            {
                stt++;
                Gan_du_lieu(stt);
            }
        }
        private void btnhuy_Click(object sender, EventArgs e)
        {
            DataTable tblSinhVien = ds.Tables["SINHVIEN"];
            // Xác định dòng cần huỷ ==> sử dụng hàm Find tìm theo khoá chính của DataTable
            DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);
            // Cần kiểm tra: Nếu rsv có tồn tại những dòng liên quan trong tblKetQua => không cho xoá. Ngược lại thì cho xoá
            // Sử dụng hàm GetChildRow để kiểm tra những dòng liên quan có tồn tại hay không? Giá trị trả về của hàm này là một mảng
            DataRow[] Mang_dong_Lien_quan = rsv.GetChildRows("FK_SV_KQ");
            if (Mang_dong_Lien_quan.Length > 0) // Có tồn tại những dòng liên quan trong tblKetQua
                MessageBox.Show("Không xoá được do tồn tại những dòng liên quan trong kETQUA");
            else
            {
                rsv.Delete();

                //xóa trong CSDL
                int n = adpSinhVien.Update(ds, "SINHVIEN");
                if (n > 0)
                    MessageBox.Show("Hủy sinh viên thành công!");
                stt = 0;
                Gan_du_lieu(stt);
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            DataTable tblSinhVien = ds.Tables["SINHVIEN"];
            if (txtmasv.ReadOnly == true) // Ghi sau khi sửa
            {
                
                // Xác định dòng cần sửa
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);

                // 1. Tiến hành sửa trong DataTable
                rsv["HoSV"] = txthosv.Text;
                rsv["TenSV"] = txttensv.Text;
                rsv["Phai"] = chkphai.Checked;
                rsv["NgaySinh"] = dtpngaysinh.Value;
                rsv["NoiSinh"] = txtnoisinh.Text;
                rsv["MaKH"] = cbomakh.SelectedValue.ToString();
                rsv["HocBong"] = txthocbong.Text;


            }
            else // Ghi sau khi thêm mới
            {
                // Kiểm tra khoá chính có trùng hay không?
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);
                if (rsv != null) // Đã trùng khoá chính
                {
                    MessageBox.Show("Trùng khoá chính. Nhập lại Mã SV");
                    txtmasv.Focus();
                    return;
                }
                // Tạo mới sinh viên và thêm sinh viên vào DataTable
                rsv = tblSinhVien.NewRow();
                rsv["MaSV"] = txtmasv.Text;
                rsv["HoSV"] = txthosv.Text;
                rsv["TenSV"] = txttensv.Text;
                rsv["Phai"] = chkphai.Checked;
                rsv["NgaySinh"] = dtpngaysinh.Value;
                rsv["NoiSinh"] = txtnoisinh.Text;
                rsv["MaKH"] = cbomakh.SelectedValue.ToString();
                rsv["HocBong"] = txthocbong.Text;
                tblSinhVien.Rows.Add(rsv);
                txtmasv.ReadOnly = true;
             
            }
            int n = adpSinhVien.Update(ds, "SINHVIEN");
            if (n > 0)
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
        }


    }
}
