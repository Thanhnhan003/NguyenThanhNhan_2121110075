using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using NguyenThanhNhan_2121110075.BAL;
using System.Linq;
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
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            currentCodeNumber = qlsBAL.GetNextAvailableCodeNumber(); // Khởi tạo giá trị currentCodeNumber dựa trên dữ liệu có sẵn
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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


        private void UpdateCurrentCodeNumber()
        {
            currentCodeNumber++;
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

                            // Thêm dữ liệu từ DataGridView vào Excel
                            for (int row = 0; row < dataGridView1.Rows.Count; row++)
                            {
                                var dgvRow = dataGridView1.Rows[row];
                                worksheet.Cell(row + 2, 1).Value = dgvRow.Cells["maSachDataGridViewTextBoxColumn"].Value.ToString();
                                worksheet.Cell(row + 2, 2).Value = dgvRow.Cells["tenSachDataGridViewTextBoxColumn"].Value.ToString();
                                worksheet.Cell(row + 2, 3).Value = dgvRow.Cells["tenTacGiaDataGridViewTextBoxColumn"].Value.ToString();
                                worksheet.Cell(row + 2, 4).Value = dgvRow.Cells["namXuatBanDataGridViewTextBoxColumn"].Value.ToString();
                                worksheet.Cell(row + 2, 5).Value = dgvRow.Cells["soLuongDataGridViewTextBoxColumn"].Value.ToString();
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




        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // ... Tìm kiếm sách dựa trên mã sách ...
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ... Xử lý sự kiện click trên DataGridView ...
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // ... Xử lý thay đổi ngày tháng ...
        }
    }
}
