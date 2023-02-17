using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BT01
{
    public partial class Form1 : Form
    {
        // Khai báo các đối tượng
        //1. Khai báo một biến (đối tượng) Dataset
        DataSet ds = new DataSet();
        //2. khai báo các DataTable tương ứng với các bảng có chứa dữ liệu
        DataTable tblKhoa = new DataTable("KHOA");
        DataTable tblSinhVien = new DataTable("SINHVIEN");
        DataTable tblKetQua = new DataTable("KETQUA");
        int stt = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tạo cấu trúc cho các DataTable
            Tao_Cau_truc_cac_bang();
            Moc_noi_Quan_he_Cac_bang();
            Nhap_lieu_Cac_bang();
            Khoi_tao_Combo_Khoa();
            btndau.PerformClick();
        }
        private void Khoi_tao_Combo_Khoa()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = tblKhoa;
        }
        private void Nhap_lieu_Cac_bang()
        {
            Nhap_lieu_tblKhoa();
            Nhap_lieu_tblSinhVien();
            Nhap_lieu_tblKetQua();
        }
        public void GanDuLieu(int stt)
        {
            // Lấy dòng dữ liệu thứ stt trong tblSinhVien
            DataRow rsv = tblSinhVien.Rows[stt];
            txtmasv.Text = rsv["MaSV"].ToString();
            txthosv.Text = rsv["HoSV"].ToString();
            txttensv.Text = rsv["TenSV"].ToString();
            chkphai.Checked = (Boolean)rsv["Phai"];
            txtngaysinh.Text = rsv["NgaySinh"].ToString();
            txtnoisinh.Text = rsv["NoiSinh"].ToString();
            cbomakh.SelectedValue = rsv["MaKH"].ToString();
            txthocbong.Text = rsv["HocBong"].ToString();

            // Tính tổng điểm
            //txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();

            // Thể hiện số thứ tự mẫu tin hiện hành
            //lblSTT.Text = (stt + 1) + " / " + tblSinhvien.Rows.Count;
        }
        private void Nhap_lieu_tblKetQua()
        {
            // Nhập liệu cho tblKetQua => Đọc dữ liệu từ tập tin KETQUA.txt
            string[] Mang_KQ = File.ReadAllLines(@"..\..\..\data\KETQUA.txt");
            foreach (string Chuoi_KQ in Mang_KQ)
            {
                // Tách Chuoi_KQ thành các thành phần tương ứng với các cột trong tblKetQua
                string[] Mang_thanh_phan = Chuoi_KQ.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấu trúc giống cấu trúc của một dòng trong tblKetQua
                DataRow rkq = tblKetQua.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra
                for (int i = 0; i < Mang_thanh_phan.Length; i++)
                    rkq[i] = Mang_thanh_phan[i];

                // Thêm dòng vừa tạo vào tblKetQua
                tblKetQua.Rows.Add(rkq);
            }

        }
        private void Nhap_lieu_tblSinhVien()
        {
            // Nhập liệu cho tblSinhVien => Đọc dữ liệu từ tập tin SINHVIEN.txt
            string[] Mang_SV = File.ReadAllLines(@"..\..\..\data\SINHVIEN.txt");
            foreach (string Chuoi_SV in Mang_SV)
            {
                // Tách Chuoi_SV thành các thành phần tương ứng với các cột trong tblSinhVien
                string[] Mang_thanh_phan = Chuoi_SV.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấu trúc giống cấu trúc của một dòng trong tblSinhVien
                DataRow rsv = tblSinhVien.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra
                for(int i=0;i<Mang_thanh_phan.Length;i++)
                    rsv[i] = Mang_thanh_phan[i];

                // Thêm dòng vừa tạo vào tblSinhVien
                tblSinhVien.Rows.Add(rsv);
            }
        }
        private void Nhap_lieu_tblKhoa()
        {
            // Nhập liệu cho tblKhoa => Đọc dữ liệu từ tập tin KHOA.txt
            string[] Mang_Khoa = File.ReadAllLines(@"..\..\..\data\KHOA.txt");
            foreach (string Chuoi_khoa in Mang_Khoa)
            {
                // Tách Chuoi_khoa thành các thành phần tương ứng với MaKH và TenKH
                string[] Mang_thanh_phan = Chuoi_khoa.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấu trúc giống cấu trúc của một dòng trong tblKhoa
                DataRow rkh = tblKhoa.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra
                rkh[0] = Mang_thanh_phan[0];
                rkh[1] = Mang_thanh_phan[1];

                // Thêm dòng vừa tạo vào tblKhoa
                tblKhoa.Rows.Add(rkh);
            }
        }
        private void Moc_noi_Quan_he_Cac_bang()
        {
            // Tạo quan hệ giữa tblKhoa và tblSinhVien
            ds.Relations.Add("FK_KH_SV",ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            // Tạo quan hệ giữa tblSinhVien và tblKetQua
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            // Loại bỏ Cascade delete trong các quan hệ
            ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }
        private void Tao_Cau_truc_cac_bang()
        {
            // Tạo cấu trúc cho DataTable tương ứng với bảng KHOA
            tblKhoa.Columns.Add("MaKH",typeof(string));
            tblKhoa.Columns.Add("TenKH", typeof(string));
            // Tạo khoá chính cho tblKhoa
            tblKhoa.PrimaryKey = new DataColumn[]{ tblKhoa.Columns["MaKH"]};

            // Tạo cấu trúc cho DataTable tương ứng với bảng SINHVIEN
            tblSinhVien.Columns.Add("MaSV", typeof(string));
            tblSinhVien.Columns.Add("HoSV", typeof(string));
            tblSinhVien.Columns.Add("TenSV", typeof(string));
            tblSinhVien.Columns.Add("Phai", typeof(Boolean));
            tblSinhVien.Columns.Add("NgaySinh", typeof(DateTime));
            tblSinhVien.Columns.Add("NoiSinh", typeof(string));
            tblSinhVien.Columns.Add("MaKH", typeof(string));
            tblSinhVien.Columns.Add("HocBong", typeof(double));
            // Tạo khoá chính cho tblSinhVien
            tblSinhVien.PrimaryKey = new DataColumn[] { tblSinhVien.Columns["MaSV"] };

            // Tạo cấu trúc cho DataTable tương ứng với bảng KETQUA
            tblKetQua.Columns.Add("MaSV", typeof(string));
            tblKetQua.Columns.Add("MaMH", typeof(string));
            tblKetQua.Columns.Add("Diem", typeof(Single));
            tblKetQua.PrimaryKey = new DataColumn[] { tblKetQua.Columns["MaSV"], tblKetQua.Columns["MaMH"] };

            // Thêm các DataTable vào Dataset
            //ds.Tables.Add(tblKhoa);
            //ds.Tables.Add(tblSinhVien);
            //ds.Tables.Add(tblKetQua);

            // Thêm đồng thời nhiều DataTable vào Dataset
            ds.Tables.AddRange(new DataTable[] { tblKhoa,tblSinhVien, tblKetQua});
        }
        private void btndau_Click(object sender, EventArgs e)
        {
            stt = 0;
            GanDuLieu(stt);
        }
        private void btntruoc_Click(object sender, EventArgs e)
        {
            stt--;
            GanDuLieu(stt);
        }
        private void btnsau_Click(object sender, EventArgs e)
        {
            stt++;
            GanDuLieu(stt);
        }
        private void btncuoi_Click(object sender, EventArgs e)
        {
            stt = tblSinhVien.Rows.Count - 1;
            GanDuLieu(stt);
        }
    }
}

// Thành phần DataTable:
//1. Dùng để lưu trữ dữ liệu của một Table trong bộ nhớ
//2. Tạo một đối tượng DataTable: new DataTable("<Tên DataTable>");
//3. Tạo ra các cột (DataColumn): <Biến DataTable>.Columns.Add("<Tên cột>", <Kiểu dữ liệu>);
//4. Tạo khoá chính cho DataTable => PrimaryKey => là mảng các DataColumn
//5. Thêm các DataTable vào Dataset
//6. Móc nối quan hệ giữa các DataTable
