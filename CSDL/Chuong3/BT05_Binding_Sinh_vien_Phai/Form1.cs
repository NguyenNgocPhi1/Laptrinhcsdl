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

namespace BT05_Binding_Sinh_vien_Phai
{
    public partial class Form1 : Form
    {
        //Khai báo đối tượng
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
        DataSet ds = new DataSet();
        OleDbDataAdapter adpSinhVien, adpKetQua, adpKhoa;
        OleDbCommandBuilder cmbSinhVien;
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
