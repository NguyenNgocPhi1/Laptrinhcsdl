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

namespace BT03_Binding_MonHoc_NangCao
{
    
    public partial class Form1 : Form
    {

        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
        DataSet ds = new DataSet();
        OleDbDataAdapter adpMonHoc, adpKetQua;
        OleDbCommandBuilder cmbMonHoc;
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            //Phát sinh sự kiện Current_changed của BindingSource
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            //Phương thức này đc tự động thi hành khi có sự di chuyển mẫu tin
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
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

            //Khởi tạo đối tượng BindingNavigator
            bdnmonhoc.BindingSource = bs;
        }

        private void Lien_ket_dieu_khien()
        {
            ////Mỗi điều khiển trên Form liên kết thông qua tập hợp DataBindings
            //txtmamh.DataBindings.Add("text", bs, "MaMH", true);
            //txttenmh.DataBindings.Add("text", bs, "TenMH", true);
            //txtsotiet.DataBindings.Add("text", bs, "SoTiet", true);
            //txtloaimh.DataBindings.Add("text", bs, "LoaiMH", true);
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name!="txtloaimh")
                    ctl.DataBindings.Add("text", bs, ctl.Name.Substring(3), true);
            //ĐỊnh dạng lại số tiết trước khi hiển thị
            txtsotiet.DataBindings[0].FormatString = "00 tiết";


            //Binding riêng cho txtloaimh chứa dữ liệu kiểu Boolean
            Binding bdmh = new Binding("text", bs, "LoaiMH", true);
            //phát sinh sự kiện Format và Parse cho đối tượng bdmh
            bdmh.Format += Bdmh_Format;
            bdmh.Parse += Bdmh_Parse;
            //Thêm đối tượng Binding bdmh vào điều khiển txtloaimh
            txtloaimh.DataBindings.Add(bdmh);
        }

        private void Bdmh_Parse(object sender, ConvertEventArgs e)
        {
            //Xảy ra khi dữ liệu được chuyển từ trên Form về dataTable (dữ liệu được chứa trong e.Value)
            if (e.Value == null) return;
            e.Value = e.Value.ToString().ToUpper() == "BẮT BUỘC" ? true : false; 
        }

        private void Bdmh_Format(object sender, ConvertEventArgs e)
        {
            //Xảy  ra khi dữ liệu được chuyển từ DataTablr đến  Form or khi chỉnh sửa dữ liệu của điều khiển trên Form
            if (e.Value == DBNull.Value || e.Value == null) return;
            e.Value = (Boolean)(e.Value) ? "Bắt buộc" : "Tự chọn";
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

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmamh.ReadOnly = true;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            //hủy trong DataTable
            //Kiểm tra có tồn tại các mẫu tin có liên quan trong KETQUA hay không trước khi hủy
            DataRow[] Mang_dong_lien_quan = ds.Tables["KETQUA"].Select("MaMH = '" + txtmamh.Text + "'");
            if(Mang_dong_lien_quan.Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên qua trong KETQUA!");
                return;
            }
            bs.RemoveCurrent();

            //hủy trong CSDL
            int n = adpMonHoc.Update(ds, "MONHOC");
            if (n > 0)
                MessageBox.Show("Hủy môn học thành công!");
           
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if(!txtmamh.ReadOnly) //thêm mới
            {
                DataRow[] Mang_dong = ds.Tables["MONHOC"].Select("MaMH = '" + txtmamh.Text + "'");
                if (Mang_dong.Length > 0)
                {
                    MessageBox.Show("Trùng khóa chính! Nhập lại");
                    txtmamh.Focus();
                    return;
                }
                
            }

            //Cập nhập lạ việ thêm mới hay sửa trong DataTable
            bs.EndEdit();
            int n = adpMonHoc.Update(ds, "MONHOC");
            if (n > 0)
                MessageBox.Show("Cập nhập môn học thành công!");

            txtmamh.ReadOnly = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            //Thêm mới
            bs.AddNew();
            txtmamh.Focus();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }
    }
}

//các vấn đề thực hiện trong bài tập:
//1. sử dụng vòng lặp để liên kết các điều khiển trên form với bindingSource
//2. Tạo các đối tư Binding liên kết với điều khiển TextBox chứa dữ liệu kiểu boolean
//3. Cách phát sinh sự kiện Current_Changed (của đối tượng BindingSource) và sự kiện Format, parse (của đối tượng Binding của điều khiển)
//3.1: Sự kiện Current_Changed: xảy ra khi có sự di chuyển mẫu tin hiện hành trên đối tượng BindingSource
//3.2: Thuộc tính Position: cho biết số thứ tự của mẫu tin hiện hành của đối tượng BindingSource
//3.3: Sự kiện Format của đối tượng Binding: xảy ra khi dữ liệu được chuyển từ DataTable lên Form (or khi hiệu chỉnh dữ liệu)
// ==> Lưu ý: Nếu dữ liệu cần chuyển không có trong DataTable thì gtri của dữ liệu là DBNull
//3.4: Sự kiện Parse: xảy ra khi dữ liệu được chuyển từ Form về DataTable
//4. Sử dụng điều khiển BindingNavigator để di chuyển dữ liệu trên form
//5. Sử dụng các phương thức của đối tượng BindingSource: 
//  + AddNew(): thêm mới dòng dữ liệu
//  + EndEdit(): Ghi sau khi sửa hay Thêm mới
//  + CancelEdit(): Để hủy bỏ thao tác vừa thực hiện
//  + RemoveCurrent(): Hủy mẫu tin hiện hành trên Form trong DataTable