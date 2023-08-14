using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using NguyenThanhNhan_2121110075.BAL;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenThanhNhan_2121110075.GUI
{
    public partial class QuanLyTaiKhoan : Form
    {
        private QLTaiKhoanBAL qltkBAL = new QLTaiKhoanBAL();
        private string selectedTaiKhoan;

        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadDataToDataGridView();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.ReadOnly = true; // Tắt chế độ chỉnh sửa trong DataGridView
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
        }
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Hiển thị thông báo để thông báo cho người dùng rằng chế độ chỉnh sửa đã bị tắt
            MessageBox.Show("Chế độ chỉnh sửa đã bị tắt cho DataGridView này.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Cancel = true; // Hủy việc chỉnh sửa ô
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                if (selectedRow.Cells["tenTaiKhoanDataGridViewTextBoxColumn"].Value is string selectedTaiKhoanValue)
                {
                    selectedTaiKhoan = selectedTaiKhoanValue;

                    // Lấy thông tin tài khoản được chọn từ cơ sở dữ liệu
                    TaiKhoan tk = qltkBAL.GetTaiKhoanByTenTaiKhoan(selectedTaiKhoan);

                    if (tk != null)
                    {
                        // Điền dữ liệu vào các điều khiển UI từ dữ liệu tài khoản được chọn
                        tbPassword.Text = tk.MatKhau;
                        tbEmail.Text = tk.Email;
                        tbNameND.Text = tk.TenNguoiDung;
                        tbMaTK.Text = tk.MaNV;
                        cbbChucVu.SelectedItem = tk.ChucVu;
                        tbSDT.Text = tk.SoDienThoai;
                        tbNameTK.Text = tk.TenTaiKhoan; // Trường này không thể chỉnh sửa trong biểu mẫu
                    }
                    else
                    {
                        MessageBox.Show("Không thể tìm thấy tài khoản được chọn trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ cho trường 'tenTaiKhoanDataGridViewTextBoxColumn'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDataToDataGridView()
        {
            List<TaiKhoan> lstTaiKhoan = qltkBAL.ReadQLTaiKhoan();
            dataGridView1.DataSource = lstTaiKhoan;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các điều khiển UI
            string tenTaiKhoan = tbNameTK.Text.Trim();
            string matKhau = tbPassword.Text.Trim();
            string email = tbEmail.Text.Trim();
            string tenNguoiDung = tbNameND.Text.Trim();
            string maNV = tbMaTK.Text.Trim();
            string chucVu = cbbChucVu.SelectedItem?.ToString();
            string soDienThoai = tbSDT.Text.Trim();

            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(tenTaiKhoan) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo một đối tượng mới của TaiKhoan
                TaiKhoan tk = new TaiKhoan
                {
                    TenTaiKhoan = tenTaiKhoan,
                    MatKhau = matKhau,
                    Email = email,
                    TenNguoiDung = tenNguoiDung,
                    MaNV = maNV,
                    ChucVu = chucVu,
                    SoDienThoai = soDienThoai
                };

                // Gọi phương thức AddTaiKhoan trong QLTaiKhoanBAL
                qltkBAL.AddTaiKhoan(tk);

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới DataGridView và làm sạch các ô văn bản
                LoadDataToDataGridView();
                ClearTextBoxes();
            }
            catch (DbUpdateException dbEx)
            {
                // Hiển thị thông báo lỗi chi tiết hơn
                MessageBox.Show($"Đã xảy ra lỗi khi thêm tài khoản: {dbEx.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedTaiKhoan))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        TaiKhoan tkToDelete = qltkBAL.GetTaiKhoanByTenTaiKhoan(selectedTaiKhoan);
                        if (tkToDelete != null)
                        {
                            qltkBAL.DeleteTaiKhoan(tkToDelete);
                            MessageBox.Show("Xóa tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadDataToDataGridView();
                            ClearTextBoxes();
                            selectedTaiKhoan = null;
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
                MessageBox.Show("Vui lòng chọn tài khoản để xóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedTaiKhoan))
            {
                // Lấy dữ liệu từ các điều khiển UI
                string newTenTaiKhoan = tbNameTK.Text.Trim();
                string newMatKhau = tbPassword.Text.Trim();
                string newEmail = tbEmail.Text.Trim();
                string newTenNguoiDung = tbNameND.Text.Trim();
                string newMaNV = tbMaTK.Text.Trim();
                string newChucVu = cbbChucVu.SelectedItem?.ToString();
                string newSoDienThoai = tbSDT.Text.Trim();

                try
                {
                    TaiKhoan tkToUpdate = qltkBAL.GetTaiKhoanByTenTaiKhoan(selectedTaiKhoan);
                    if (tkToUpdate != null)
                    {
                        // Cập nhật TenTaiKhoan nếu nó đã thay đổi
                        if (newTenTaiKhoan != tkToUpdate.TenTaiKhoan)
                        {
                            // Kiểm tra xem TenTaiKhoan mới có sẵn không
                            if (qltkBAL.IsTenTaiKhoanExists(newTenTaiKhoan))
                            {
                                MessageBox.Show("Tên tài khoản đã tồn tại.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            tkToUpdate.TenTaiKhoan = newTenTaiKhoan;
                        }
                        tkToUpdate.MatKhau = newMatKhau;
                        tkToUpdate.Email = newEmail;
                        tkToUpdate.TenNguoiDung = newTenNguoiDung;
                        tkToUpdate.MaNV = newMaNV;
                        tkToUpdate.ChucVu = newChucVu;
                        tkToUpdate.SoDienThoai = newSoDienThoai;
                        qltkBAL.UpdateTaiKhoan(tkToUpdate);
                        MessageBox.Show("Cập nhật tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToDataGridView();
                        ClearTextBoxes();
                        selectedTaiKhoan = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearTextBoxes()
        {
            tbNameTK.Text = "";
            tbPassword.Text = "";
            tbEmail.Text = "";
            tbNameND.Text = "";
            tbMaTK.Text = "";
            cbbChucVu.SelectedItem = null;
            tbSDT.Text = "";
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedTaiKhoan))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        TaiKhoan tkToDelete = qltkBAL.GetTaiKhoanByTenTaiKhoan(selectedTaiKhoan);
                        if (tkToDelete != null)
                        {
                            qltkBAL.DeleteTaiKhoan(tkToDelete);
                            MessageBox.Show("Xóa tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadDataToDataGridView();
                            ClearTextBoxes();
                            selectedTaiKhoan = null;
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
                MessageBox.Show("Vui lòng chọn tài khoản để xóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedTaiKhoan))
            {
                // Lấy dữ liệu từ các điều khiển UI
                string newTenTaiKhoan = tbNameTK.Text.Trim();
                string newMatKhau = tbPassword.Text.Trim();
                string newEmail = tbEmail.Text.Trim();
                string newTenNguoiDung = tbNameND.Text.Trim();
                string newMaNV = tbMaTK.Text.Trim();
                string newChucVu = cbbChucVu.SelectedItem?.ToString();
                string newSoDienThoai = tbSDT.Text.Trim();

                try
                {
                    TaiKhoan tkToUpdate = qltkBAL.GetTaiKhoanByTenTaiKhoan(selectedTaiKhoan);
                    if (tkToUpdate != null)
                    {
                        // Cập nhật TenTaiKhoan nếu nó đã thay đổi
                        if (newTenTaiKhoan != tkToUpdate.TenTaiKhoan)
                        {
                            // Kiểm tra xem TenTaiKhoan mới có sẵn không
                            if (qltkBAL.IsTenTaiKhoanExists(newTenTaiKhoan))
                            {
                                MessageBox.Show("Tên tài khoản đã tồn tại.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            tkToUpdate.TenTaiKhoan = newTenTaiKhoan;
                        }
                        tkToUpdate.MatKhau = newMatKhau;
                        tkToUpdate.Email = newEmail;
                        tkToUpdate.TenNguoiDung = newTenNguoiDung;
                        tkToUpdate.MaNV = newMaNV;
                        tkToUpdate.ChucVu = newChucVu;
                        tkToUpdate.SoDienThoai = newSoDienThoai;
                        qltkBAL.UpdateTaiKhoan(tkToUpdate);
                        MessageBox.Show("Cập nhật tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToDataGridView();
                        ClearTextBoxes();
                        selectedTaiKhoan = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
