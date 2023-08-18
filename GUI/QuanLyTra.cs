using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhNhan_2121110075.BAL;
using System.Windows.Forms;

namespace NguyenThanhNhan_2121110075.GUI
{
    public partial class QuanLyTra : Form
    {
        public QuanLyTra()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true; // Tắt chế độ chỉnh sửa trong DataGridView
            LoadDataToDataGridView();
        }

        private QLTraBAL qltBAL = new QLTraBAL();

        private void LoadDataToDataGridView()
        {
            List<QLTra> lstForm = qltBAL.ReadQuanLyTra();
            dataGridView1.DataSource = lstForm;
            LoadQLMuonComboBox();
            ClearTextBoxes();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maPhieuMuon = cbbMaPhieuMuon.SelectedItem as string;
            DateTime ngayTra = dateNgayTra.Value;

            if (string.IsNullOrWhiteSpace(maPhieuMuon))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu mượn trước khi thêm phiếu trả.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem mã phiếu mượn đã tồn tại trong cơ sở dữ liệu hay chưa
            if (qltBAL.IsMaPhieuMuonExists(maPhieuMuon))
            {
                MessageBox.Show("Mã phiếu mượn đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn mã phiếu mượn khác.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QLTra newTra = new QLTra
            {
                maPhieuTra = qltBAL.GenerateCode(),
                maPhieuMuon = maPhieuMuon,
                NgayTra = ngayTra
            };

            try
            {
                qltBAL.AddQuanLyTra(newTra);
                MessageBox.Show("Thêm phiếu trả thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToDataGridView();
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm phiếu trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phiếu trả này?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string maPhieuTra = dataGridView1.SelectedRows[0].Cells["maPhieuTraDataGridViewTextBoxColumn"].Value.ToString();

                    try
                    {
                        QLTra traToDelete = qltBAL.GetQuanLyTraByMaPhieuTra(maPhieuTra);
                        if (traToDelete != null)
                        {
                            qltBAL.DeleteQuanLyTra(traToDelete);
                            MessageBox.Show("Xóa phiếu trả thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataToDataGridView();
                            ClearTextBoxes();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xóa phiếu trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu trả để xóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maPhieuTra = dataGridView1.SelectedRows[0].Cells["maPhieuTraDataGridViewTextBoxColumn"].Value.ToString();
                string newMaPhieuMuon = cbbMaPhieuMuon.SelectedItem as string;
                DateTime newNgayTra = dateNgayTra.Value;

                if (string.IsNullOrWhiteSpace(newMaPhieuMuon))
                {
                    MessageBox.Show("Vui lòng chọn mã phiếu mượn trước khi cập nhật phiếu trả.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                QLTra selectedTra = qltBAL.GetQuanLyTraByMaPhieuTra(maPhieuTra);

                // Kiểm tra xem mã phiếu mượn đã tồn tại trong cơ sở dữ liệu hay chưa
                if (qltBAL.IsMaPhieuMuonExists(newMaPhieuMuon) && newMaPhieuMuon != selectedTra.maPhieuMuon)
                {
                    MessageBox.Show("Mã phiếu mượn đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn mã phiếu mượn khác.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedTra.maPhieuMuon = newMaPhieuMuon;
                selectedTra.NgayTra = newNgayTra;

                try
                {
                    qltBAL.UpdateQuanLyTra(selectedTra);
                    MessageBox.Show("Cập nhật thông tin phiếu trả thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToDataGridView();
                    ClearTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật phiếu trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu trả để cập nhật.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy dữ liệu từ dòng được chọn và hiển thị trên ComboBox và DateTimePicker
                cbbMaPhieuMuon.SelectedItem = selectedRow.Cells["maPhieuMuonDataGridViewTextBoxColumn"].Value.ToString();
                dateNgayTra.Value = Convert.ToDateTime(selectedRow.Cells["ngayTraDataGridViewTextBoxColumn"].Value);
            }

        }

  
        private void LoadQLMuonComboBox()
        {
            List<string> qlSachIDs = qltBAL.ReadMaMuonIDs();
            cbbMaPhieuMuon.DataSource = qlSachIDs;
        }
        private void ClearTextBoxes()
        {
            cbbMaPhieuMuon.SelectedItem = null;

        }
    }
}
