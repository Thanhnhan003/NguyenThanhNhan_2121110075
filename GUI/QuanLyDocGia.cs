using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using NguyenThanhNhan_2121110075.BAL;
using System.Linq;

namespace NguyenThanhNhan_2121110075.GUI
{
    public partial class QuanLyDocGia : Form
    {
        private QLDocGiaBAL qldgBAL = new QLDocGiaBAL();
        private string currentCodeNumber;
        private DocGia selectedDocGia;

        public QuanLyDocGia()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadDataToDataGridView();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.ReadOnly = true; // Tắt chế độ chỉnh sửa trong DataGridView
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;

            // Read existing readers data
            List<DocGia> existingReaders = qldgBAL.ReadQuanLyDocGia();
            currentCodeNumber = qldgBAL.GetNextAvailableCodeNumber(existingReaders).ToString();

            // Rest of your constructor code...
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Hiển thị thông báo để thông báo cho người dùng rằng chế độ chỉnh sửa đã bị tắt
            MessageBox.Show("Chế độ chỉnh sửa đã bị tắt cho DataGridView này.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Cancel = true; // Hủy việc chỉnh sửa ô
        }
        private string GenerateCode(List<DocGia> existingReaders)
        {
            int nextAvailableCodeNumber = qldgBAL.GetNextAvailableCodeNumber(existingReaders);
            string codePrefix = "DG";
            string codeNumber = nextAvailableCodeNumber.ToString("D4");
            return $"{codePrefix}{codeNumber}";
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                selectedDocGia = new DocGia
                {
                    MaDocGia = selectedRow.Cells["dataGridViewTextBoxColumn1"].Value.ToString(),
                    TenDocGia = selectedRow.Cells["tenDocGiaDataGridViewTextBoxColumn"].Value.ToString(),
                    NgayCap = selectedRow.Cells["ngayCapDataGridViewTextBoxColumn"].Value as DateTime?,
                    HanSD = selectedRow.Cells["hanSDDataGridViewTextBoxColumn"].Value as DateTime?,
                    TinhTrang = selectedRow.Cells["tinhTrangDataGridViewTextBoxColumn"].Value.ToString(),
                    NgayCN = selectedRow.Cells["ngayCNDataGridViewTextBoxColumn"].Value as DateTime?
                };

                tbNameDG.Text = selectedDocGia.TenDocGia;
                dateNC.Value = selectedDocGia.NgayCap ?? DateTime.Now;
                dateHSD.Value = selectedDocGia.HanSD ?? DateTime.Now;
                cmTT.Text = selectedDocGia.TinhTrang;
                dateNCN.Value = selectedDocGia.NgayCN ?? DateTime.Now; // Thêm dòng này
            }
        }

        private void LoadDataToDataGridView()
        {
            List<DocGia> lstDocGia = qldgBAL.ReadQuanLyDocGia();
            dataGridView1.DataSource = lstDocGia;
        }

     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenDocGia = tbNameDG.Text.Trim();
            DateTime ngayCap = dateNC.Value;
            DateTime hanSD = dateHSD.Value;
            DateTime ngayCapNhat = dateNCN.Value;
            string tinhTrang = cmTT.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenDocGia) || string.IsNullOrWhiteSpace(tinhTrang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho độc giả.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DocGia> existingReaders = qldgBAL.ReadQuanLyDocGia();

            

            DocGia qldg = new DocGia
            {
                MaDocGia = GenerateCode(existingReaders),
                TenDocGia = tenDocGia,
                NgayCap = ngayCap,
                HanSD = hanSD,
                TinhTrang = tinhTrang,
                NgayCN = ngayCapNhat

            };

            try
            {
                qldgBAL.AddQuanLyDocGia(qldg);
                MessageBox.Show("Thêm độc giả thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa độc giả này?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string maDocGia = dataGridView1.SelectedRows[0].Cells["dataGridViewTextBoxColumn1"].Value.ToString();

                    try
                    {
                        DocGia qldgToDelete = qldgBAL.GetQuanLyDocGiaByMaDocGia(maDocGia);
                        if (qldgToDelete != null)
                        {
                            qldgBAL.DeleteQuanLyDocGia(qldgToDelete);
                            MessageBox.Show("Xóa độc giả thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn độc giả để xóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedDocGia != null)
            {
                string newTenDocGia = tbNameDG.Text.Trim();

                // Kiểm tra newTenDocGia không trống
                if (!string.IsNullOrWhiteSpace(newTenDocGia))
                {
                    // Tạo một bản sao của selectedDocGia để không thay đổi dữ liệu trực tiếp trong grid view
                    DocGia updatedDocGia = new DocGia
                    {
                        MaDocGia = selectedDocGia.MaDocGia,
                        TenDocGia = newTenDocGia,
                        NgayCap = dateNC.Value,
                        HanSD = dateHSD.Value,
                        TinhTrang = cmTT.Text.Trim(),
                        NgayCN = dateNCN.Value // Thêm ngày cập nhật
                    };

                    try
                    {
                        qldgBAL.UpdateDocGia(updatedDocGia);
                        MessageBox.Show("Cập nhật thông tin độc giả thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Xóa dữ liệu trong các điều khiển chỉnh sửa và bỏ chọn dòng
                        ClearTextBoxes();
                        selectedDocGia = null;
                    }
                }
                else
                {
                    MessageBox.Show("Tên độc giả không được để trống.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private bool TenDocGiaExists(string tenDocGia, string maDocGiaToExclude)
        {
            List<DocGia> existingReaders = qldgBAL.ReadQuanLyDocGia();
            return existingReaders.Any(reader => reader.TenDocGia.Equals(tenDocGia, StringComparison.OrdinalIgnoreCase) && reader.MaDocGia != maDocGiaToExclude);
        }

        private void ClearTextBoxes()
        {
            tbNameDG.Text = "";
            dateNC.Value = DateTime.Now;
            dateHSD.Value = DateTime.Now;
            cmTT.Text = "";
            dateNCN.Value = DateTime.Now;
        }

        

        // Additional event handlers and methods can be added here
    }
}
