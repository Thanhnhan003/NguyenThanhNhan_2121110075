using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using NguyenThanhNhan_2121110075.BAL;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenThanhNhan_2121110075.GUI
{
    public partial class QuanLyTaiKhoan : Form
    {
        private QLTaiKhoanBAL _qlTaiKhoanBAL;
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            _qlTaiKhoanBAL = new QLTaiKhoanBAL();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void LoadDataToDataGridView()
        {
            List<TaiKhoan> lstTaiKhoan = _qlTaiKhoanBAL.ReadQLTaiKhoan();
            dataGridView1.DataSource = lstTaiKhoan;
        }
    }
}
