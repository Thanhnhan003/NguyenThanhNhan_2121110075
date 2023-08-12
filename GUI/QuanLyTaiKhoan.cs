using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity.Infrastructure;

using System.Linq;
using System.Text;
using NguyenThanhNhan_2121110075.BAL;

using System.Threading.Tasks;
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
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedTaiKhoan = selectedRow.Cells["tenTaiKhoanDataGridViewTextBoxColumn"].Value.ToString();

                // Retrieve the selected TaiKhoan entity from the database
                TaiKhoan tk = qltkBAL.GetTaiKhoanByTenTaiKhoan(selectedTaiKhoan);

                // Populate the UI controls with the selected TaiKhoan's data
                tbPassword.Text = tk.MatKhau;
                tbEmail.Text = tk.Email;
                tbNameND.Text = tk.TenNguoiDung;
                tbMaTK.Text = tk.MaNV;
                cbbChucVu.SelectedItem = tk.ChucVu;
                tbSDT.Text = tk.SoDienThoai;
                tbNameTK.Text = tk.TenTaiKhoan;
            }
        }

        private void LoadDataToDataGridView()
        {
            List<TaiKhoan> lstTaiKhoan = qltkBAL.ReadQLTaiKhoan();
            dataGridView1.DataSource = lstTaiKhoan;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Retrieve data from UI controls
            string tenTaiKhoan = tbNameTK.Text.Trim();
            string matKhau = tbPassword.Text.Trim();
            string email = tbEmail.Text.Trim();
            string tenNguoiDung = tbNameND.Text.Trim();
            string maNV = tbMaTK.Text.Trim();
            string chucVu = cbbChucVu.SelectedItem?.ToString();
            string soDienThoai = tbSDT.Text.Trim();

            // Validate the data
            if (string.IsNullOrWhiteSpace(tenTaiKhoan) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create a new instance of TaiKhoan
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

                // Call the AddTaiKhoan method in the QLTaiKhoanBAL
                qltkBAL.AddTaiKhoan(tk);

                // Display success message
                MessageBox.Show("Thêm tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh DataGridView and clear textboxes
                LoadDataToDataGridView();
                ClearTextBoxes();
            }
            catch (DbUpdateException dbEx)
            {
                // Display a more detailed error message
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
                // Retrieve data from UI controls
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

    }
}
