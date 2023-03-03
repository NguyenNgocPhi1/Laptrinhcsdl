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

namespace Dataset_Co_dinh_kieu_Monhoc
{
    public partial class Form1 : Form
    {
        QLSinhVien ds = new QLSinhVien();
        QLSinhVienTableAdapters.MONHOCTableAdapter dapMonhoc = new QLSinhVienTableAdapters.MONHOCTableAdapter();
        QLSinhVienTableAdapters.KETQUATableAdapter dapKetqua = new QLSinhVienTableAdapters.KETQUATableAdapter();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_du_lieu();
            Khoi_tao_BindingSource();
            Lien_ket_dieu_khien();
        }

        private void Khoi_tao_BindingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = ds.MONHOC.TableName;
            bdnMonhoc.BindingSource = bs;
        }

        private void Doc_du_lieu()
        {
            dapMonhoc.Fill(ds.MONHOC);
            dapKetqua.Fill(ds.KETQUA);         
        }
        private void Lien_ket_dieu_khien()
        {
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name != "txtloaimh")
                    ctl.DataBindings.Add("text", bs, ctl.Name.Substring(3), true);
            txtsotiet.DataBindings[0].FormatString = "00 tiết";
            //Binding riêng cho txtloaimh chứa dữ liệu kiểu boolean
            Binding bdmh = new Binding("text", bs, "LoaiMH", true);
            bdmh.Format += Bdmh_Format;
            bdmh.Parse += Bdmh_Parse; 
            txtloaimh.DataBindings.Add(bdmh);
        }

        private void Bdmh_Parse(object sender, ConvertEventArgs e)
        {
            if (e.Value == null) return;
            e.Value = e.Value.ToString().ToUpper() == "BẮT BUỘC" ? true : false;
        }

        private void Bdmh_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value == DBNull.Value || e.Value == null) return;
            e.Value = (Boolean)e.Value ? "Bắt buộc" : "Tự chọn";
        }

        private void bdnMonhoc_RefreshItems(object sender, EventArgs e)
        {

        }

        private void btndau_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            //Thêm mới
            bs.AddNew();
            txtmamh.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            QLSinhVien.MONHOCRow rmh = (bs.Current as DataRowView).Row as QLSinhVien.MONHOCRow;
            if (rmh.GetKETQUARows().Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên qua trong KETQUA!");
                return;
            }
            bs.RemoveCurrent();
            int n = dapMonhoc.Update(ds.MONHOC);
            if (n > 0)
                MessageBox.Show("Hủy môn học thành công!");
            txtmamh.ReadOnly = true;
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmamh.ReadOnly) //thêm mới
            {
                QLSinhVien.MONHOCRow rmh = ds.MONHOC.FindByMaMH(txtmamh.Text);
                if (rmh != null)
                {
                    MessageBox.Show("Trùng khóa chính! Nhập lại");
                    txtmamh.Focus();
                    return;
                }

            }
            txtmamh.ReadOnly = true;

            //Cập nhập lạ việ thêm mới hay sửa trong DataTable
            bs.EndEdit();
            int n = dapMonhoc.Update(ds.MONHOC);
            if (n > 0)
                MessageBox.Show("Cập nhập môn học thành công!");
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmamh.ReadOnly = true;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

        }
    }
}
