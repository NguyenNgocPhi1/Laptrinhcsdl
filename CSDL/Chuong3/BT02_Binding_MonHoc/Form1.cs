using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //sử dụng với CSDL là Access
                         //Sử dụng thư viện Data.SqlClient nếu dùng CSDL là SQL

namespace BT02_Binding_MonHoc
{
    public partial class Form1 : Form
    {
        //Bài toán muốn xây dựng 1 đối tượng có thể thực hiện tự động các thao tác:
        //1. Liên kết các điều khiển trên form với 1 dòng dữ liệu trong DataTable
        //===> Việc gán dữ liệu sẽ được thực hiện tự động
        //2. tự động di chuyển qua lại giữa các dòng dữ liệu trong DataTable
        //3. Việc cập nhâp mẫu tin( thêm mới, Ghi mới, sửa xóa,...) được thực hiện tự động
        //4. Một số chức năng khác...

        //===> sử dụng đối tượng có kiểu BindingSource và đối tượng DataBinding


        //khai báo các đối tượng cần sử dụng:
        //1.1 Chuỗi liên kết:
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";

        //1.2. Khai báo các đối tượng lưu dữ liệu
        DataSet ds = new DataSet();

        //1.3 Khai báo DataAdapter sử dụng với nguyên tắc: 1 DataTable tương ứng với 1 DataAdapter
        OleDbDataAdapter adpMonHoc, adpKetQua;


        //1.4 Khai báo đối tượng CommandBuilder tương ứng để cập nhập dữ liệu cho bảng MONHOC
        OleDbCommandBuilder cmbMonHoc;

        //1.5 Khai báo đối tượng BindingSource để liên kết và thực hiện 1 số chức năng trên Form 
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_tao_du_lieu();
            Doc_du_lieu();
            Moc_noi_quan_he();
            Khoi_tao_BindingSource();
            Lien_ket_dieu_khien();
        }

        private void Khoi_tao_BindingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = "MONHOC";
        }

        private void Lien_ket_dieu_khien()
        {
            //Mỗi điều khiển trên Form liên kết thông qua tập hợp DataBindings
            txtmamh.DataBindings.Add("text", bs, "MaMH", true);
            txttenmh.DataBindings.Add("text", bs, "TenMH", true);
            txtsotiet.DataBindings.Add("text", bs, "SoTiet", true);
            txtloaimh.DataBindings.Add("text", bs, "LoaiMH", true);
        }

        private void Moc_noi_quan_he()
        {
            ds.Relations.Add("FK_MH_KQ", ds.Tables["MONHOC"].Columns["MaMH"], ds.Tables["KETQUA"].Columns["MaMH"], true);

            //Loại bảo cascade delete trong các quan hệ
            ds.Relations["FK_MH_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void Khoi_tao_du_lieu()
        {
            //1. Khởi tạo các đối tượng DataAdapter
            adpMonHoc = new OleDbDataAdapter("select * from monhoc", strcon);
            adpKetQua = new OleDbDataAdapter("select * from ketqua", strcon);

            //2.Khởi tạo đối tượng CommandBuilder
            cmbMonHoc = new OleDbCommandBuilder(adpMonHoc);
        }

        private void Doc_du_lieu()
        {
            adpMonHoc.FillSchema(ds, SchemaType.Source, "MONHOC");
            adpMonHoc.Fill(ds, "MONHOC");

            adpKetQua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetQua.Fill(ds, "KETQUA");
        }

        private void btndau_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }
    }
}
