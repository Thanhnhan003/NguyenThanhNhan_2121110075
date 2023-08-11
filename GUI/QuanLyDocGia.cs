using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NguyenThanhNhan_2121110075.BAL;

namespace NguyenThanhNhan_2121110075.GUI
{
    public partial class QuanLyDocGia : Form
    {
        private QLDocGiaBAL _qlDocGiaBAL = new QLDocGiaBAL();
        public QuanLyDocGia()
        {
            InitializeComponent();
            LoadDataToDataGridView();
        }
        private void LoadDataToDataGridView()
        {
            List<DocGia> lstDocGia = _qlDocGiaBAL.ReadQuanLyDocGia();
            dataGridView1.DataSource = lstDocGia;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenDocGia = tbNameDG.Text.Trim();
            DateTime? ngayCap = dateNC.Value;
            DateTime? hanSD = dateHSD.Value;
            string tinhTrang = cmTT.SelectedItem?.ToString();
            DateTime? ngayCN = dateNCN.Value;

            if (string.IsNullOrWhiteSpace(tenDocGia) || string.IsNullOrWhiteSpace(tinhTrang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho đọc giả.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DocGia> existingReaders = docGiaBindingSource3.DataSource as List<DocGia>; // Đọc danh sách đọc giả hiện tại

            // Kiểm tra xem tên đọc giả đã tồn tại trong cơ sở dữ liệu chưa
            if (existingReaders.Any(reader => reader.TenDocGia.Equals(tenDocGia, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên đọc giả đã tồn tại trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocGia newReader = new DocGia
            {
                MaDocGia = GenerateCode(existingReaders), // Sử dụng phương thức GenerateCode để tạo mã đọc giả
                TenDocGia = tenDocGia,
                NgayCap = ngayCap,
                HanSD = hanSD,
                TinhTrang = tinhTrang,
                NgayCN = ngayCN
            };

            try
            {
                // Thêm đọc giả mới vào danh sách và cập nhật DataSource của DataGridView
                existingReaders.Add(newReader);
                docGiaBindingSource3.DataSource = existingReaders;
                dataGridView1.Refresh();

                MessageBox.Show("Thêm đọc giả thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
