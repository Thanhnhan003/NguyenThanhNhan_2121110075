using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.ComponentModel;
using NguyenThanhNhan_2121110075.BAL;
using System.Linq;
using System.Data.SqlClient;
using ClosedXML.Excel;

namespace NguyenThanhNhan_2121110075.GUI
{
    public partial class QuanLySach : Form
    {
        private QLSachBAL qlsBAL = new QLSachBAL();
        private int currentCodeNumber;
        private QLSach selectedSach;
        public QuanLySach()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadDataToDataGridView();
            currentCodeNumber = qlsBAL.GetNextAvailableCodeNumber(); // Khởi tạo giá trị currentCodeNumber dựa trên dữ liệu có sẵn
            dataGridView1.ReadOnly = true; // Tắt chế độ chỉnh sửa trong DataGridView
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
        }
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Hiển thị thông báo để thông báo cho người dùng rằng chế độ chỉnh sửa đã bị tắt
            MessageBox.Show("Chế độ chỉnh sửa đã bị tắt cho DataGridView này.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Cancel = true; // Hủy việc chỉnh sửa ô
        }

        




        private void LoadDataToDataGridView()
        {
            List<QLSach> lstForm = qlsBAL.ReadQuanLySach();
            dataGridView1.DataSource = lstForm;
        }

        private string GenerateCode(List<QLSach> existingBooks)
        {
            int nextAvailableCodeNumber = qlsBAL.GetNextAvailableCodeNumber(existingBooks);
            string codePrefix = "TL";
            string codeNumber = nextAvailableCodeNumber.ToString("D4");
            return $"{codePrefix}{codeNumber}";
        }


 

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenSach = tbNameS.Text.Trim();
            string tenTacGia = tbTacGia.Text.Trim();
            DateTime? namXuatBan = dtNamSB.Value;
            int? soLuong = null;
            if (int.TryParse(tbSoLuong.Text, out int parsedSoLuong))
            {
                soLuong = parsedSoLuong;
            }
            string theLoai = cmTheLoai.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(tenSach) || string.IsNullOrWhiteSpace(theLoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho sách.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soLuong == null || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<QLSach> existingBooks = qlsBAL.ReadQuanLySach(); // Đọc danh sách sách hiện tại

            // Kiểm tra xem tên sách đã tồn tại trong cơ sở dữ liệu chưa
            if (qlsBAL.IsTenSachExists(tenSach))
            {
                MessageBox.Show("Tên sách đã tồn tại trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QLSach qls = new QLSach
            {
                MaSach = GenerateCode(existingBooks), // Sử dụng phương thức GenerateCode để tạo mã sách
                TenSach = tenSach,
                TenTacGia = tenTacGia,
                NamXuatBan = namXuatBan,
                SoLuong = soLuong,
                TheLoai = theLoai
            };

            try
            {
                qlsBAL.AddQuanLySach(qls);
                MessageBox.Show("Thêm sách thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBoxes();
                LoadDataToDataGridView();
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật cơ sở dữ liệu. Chi tiết lỗi: " + innerException.Message, "Lỗi Cơ Sở Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    innerException = innerException.InnerException;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string maSach = dataGridView1.SelectedRows[0].Cells["maSachDataGridViewTextBoxColumn"].Value.ToString();

                    try
                    {
                        QLSach qlsToDelete = qlsBAL.GetQuanLySachByMaSach(maSach);
                        if (qlsToDelete != null)
                        {
                            qlsBAL.DeleteQuanLySach(qlsToDelete);
                            MessageBox.Show("Xóa sách thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadDataToDataGridView();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để xóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedSach != null)
            {
                string newTenSach = tbNameS.Text.Trim();
                int? newSoLuong = null;

                // Kiểm tra TenSach không trùng
                if (!string.IsNullOrWhiteSpace(newTenSach) && !TenSachExists(newTenSach, selectedSach.MaSach))
                {
                    // Kiểm tra SoLuong là số
                    if (int.TryParse(tbSoLuong.Text, out int parsedSoLuong))
                    {
                        newSoLuong = parsedSoLuong;

                        // Cập nhật dữ liệu của selectedSach từ các điều khiển chỉnh sửa
                        selectedSach.TenSach = newTenSach;
                        selectedSach.TenTacGia = tbTacGia.Text.Trim();
                        selectedSach.NamXuatBan = dtNamSB.Value;
                        selectedSach.SoLuong = newSoLuong;
                        selectedSach.TheLoai = cmTheLoai.SelectedItem?.ToString();

                        // Thực hiện cập nhật dữ liệu
                        qlsBAL.UpdateQuanLySach(selectedSach);

                        // Refresh DataGridView để hiển thị dữ liệu mới sau khi cập nhật
                        LoadDataToDataGridView();

                        // Xóa dữ liệu trong các điều khiển chỉnh sửa và bỏ chọn dòng
                        ClearTextBoxes();
                        selectedSach = null;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Tên sách đã tồn tại.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để sửa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Kiểm tra xem TenSach có tồn tại trong cơ sở dữ liệu không
        private bool TenSachExists(string tenSach, string maSachToExclude)
        {
            List<QLSach> existingBooks = qlsBAL.ReadQuanLySach();
            return existingBooks.Any(book => book.TenSach.Equals(tenSach, StringComparison.OrdinalIgnoreCase) && book.MaSach != maSachToExclude);
        }
        private void ClearTextBoxes()
        {
            tbNameS.Text = "";
            tbTacGia.Text = "";
            dtNamSB.Value = DateTime.Now;
            tbSoLuong.Text = "";
            cmTheLoai.SelectedItem = null;
        }

        private void btnExExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Export to Excel";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Sach");

                            // Thêm tiêu đề cột vào worksheet
                            worksheet.Cell(1, 1).Value = "Mã Sách";
                            worksheet.Cell(1, 2).Value = "Tên Sách";
                            worksheet.Cell(1, 3).Value = "Tác Giả";
                            worksheet.Cell(1, 4).Value = "Năm Xuất Bản";
                            worksheet.Cell(1, 5).Value = "Số Lượng";
                            worksheet.Cell(1, 6).Value = "Thể Loại";

                            // Điều chỉnh độ rộng cột "Năm Xuất Bản" trước
                            worksheet.Column(4).Width = 15; // Điều chỉnh độ rộng theo nhu cầu

                            // Định dạng ngày tháng cho cột "Năm Xuất Bản"
                            worksheet.Column(4).Style.DateFormat.Format = "mm/dd/yyyy";

                            // Thêm dữ liệu từ DataGridView vào Excel
                            for (int row = 0; row < dataGridView1.Rows.Count; row++)
                            {
                                var dgvRow = dataGridView1.Rows[row];
                                worksheet.Cell(row + 2, 1).Value = dgvRow.Cells["maSachDataGridViewTextBoxColumn"].Value.ToString();
                                worksheet.Cell(row + 2, 2).Value = dgvRow.Cells["tenSachDataGridViewTextBoxColumn"].Value.ToString();
                                worksheet.Cell(row + 2, 3).Value = dgvRow.Cells["tenTacGiaDataGridViewTextBoxColumn"].Value.ToString();
                                worksheet.Cell(row + 2, 4).Value = Convert.ToDateTime(dgvRow.Cells["namXuatBanDataGridViewTextBoxColumn"].Value);
                                worksheet.Cell(row + 2, 5).Value = Convert.ToInt32(dgvRow.Cells["soLuongDataGridViewTextBoxColumn"].Value);
                                worksheet.Cell(row + 2, 6).Value = dgvRow.Cells["theLoaiDataGridViewTextBoxColumn"].Value.ToString();
                            }

                            // Lưu tệp Excel vào vị trí đã chọn
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất Excel thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearch.Text.Trim().ToLower(); // Chuyển về chữ thường và loại bỏ khoảng trắng

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                List<QLSach> matchedBooks;

                if (rbSearchByMaSach.Checked) // Tìm kiếm theo mã sách
                {
                    matchedBooks = qlsBAL.ReadQuanLySach().Where(book =>
                        book.MaSach.ToLower().Contains(searchText)
                    ).ToList();
                }
                else if (rbSearchByTenSach.Checked) // Tìm kiếm theo tên sách
                {
                    matchedBooks = qlsBAL.ReadQuanLySach().Where(book =>
                        book.TenSach.ToLower().Contains(searchText)
                    ).ToList();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn kiểu tìm kiếm.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dataGridView1.DataSource = matchedBooks;
            }
            else
            {
                LoadDataToDataGridView(); // Nếu không có dữ liệu tìm kiếm, hiển thị lại toàn bộ dữ liệu
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng được chọn vào biến selectedSach
                selectedSach = new QLSach
                {
                    MaSach = selectedRow.Cells["maSachDataGridViewTextBoxColumn"].Value.ToString(),
                    TenSach = selectedRow.Cells["tenSachDataGridViewTextBoxColumn"].Value.ToString(),
                    TenTacGia = selectedRow.Cells["tenTacGiaDataGridViewTextBoxColumn"].Value.ToString(),
                    NamXuatBan = selectedRow.Cells["namXuatBanDataGridViewTextBoxColumn"].Value as DateTime?,
                    SoLuong = selectedRow.Cells["soLuongDataGridViewTextBoxColumn"].Value as int?,
                    TheLoai = selectedRow.Cells["theLoaiDataGridViewTextBoxColumn"].Value.ToString()
                };

                // Hiển thị dữ liệu lên các điều khiển chỉnh sửa
                tbNameS.Text = selectedSach.TenSach;
                tbTacGia.Text = selectedSach.TenTacGia;
                dtNamSB.Value = selectedSach.NamXuatBan ?? DateTime.Now;
                tbSoLuong.Text = selectedSach.SoLuong?.ToString() ?? "0";
                cmTheLoai.SelectedItem = selectedSach.TheLoai;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // ... Xử lý thay đổi ngày tháng ...
        }
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (XLWorkbook workbook = new XLWorkbook(filePath))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);

                        var headerRow = worksheet.Row(1);
                        string maSachColumnHeader = headerRow.Cell(1).Value.ToString();
                        string tenSachColumnHeader = headerRow.Cell(2).Value.ToString();
                        string tenTacGiaColumnHeader = headerRow.Cell(3).Value.ToString();
                        string namXuatBanColumnHeader = headerRow.Cell(4).Value.ToString();
                        string soLuongColumnHeader = headerRow.Cell(5).Value.ToString();
                        string theLoaiColumnHeader = headerRow.Cell(6).Value.ToString();

                        List<QLSach> existingBooks = qlsBAL.ReadQuanLySach();
                        bool dataChanged = false;

                        for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                        {
                            // Đọc giá trị từ tệp Excel
                            string maSach = worksheet.Cell(row, 1).Value.ToString();
                            string tenSach = worksheet.Cell(row, 2).Value.ToString();
                            string tenTacGia = worksheet.Cell(row, 3).Value.ToString();
                            DateTime? namXuatBan = worksheet.Cell(row, 4).GetValue<DateTime?>();
                            int? soLuong = worksheet.Cell(row, 5).GetValue<int?>();
                            string theLoai = worksheet.Cell(row, 6).Value.ToString();

                            if (!existingBooks.Any(book => book.MaSach == maSach))
                            {
                                // Thêm dữ liệu vào cơ sở dữ liệu
                                QLSach qls = new QLSach
                                {
                                    MaSach = maSach,
                                    TenSach = tenSach,
                                    TenTacGia = tenTacGia,
                                    NamXuatBan = namXuatBan,
                                    SoLuong = soLuong,
                                    TheLoai = theLoai
                                };

                                qlsBAL.AddQuanLySach(qls);
                                dataChanged = true;
                                LoadDataToDataGridView();
                            }
                        }

                        if (dataChanged)
                        {
                            MessageBox.Show("Import dữ liệu từ Excel thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu không có thay đổi từ tệp Excel.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("File excel không hợp lệ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }




    }
}
