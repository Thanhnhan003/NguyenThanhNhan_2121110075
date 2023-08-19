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
    public partial class QuanLyMuon : Form
    {
        private QLMuonBAL qlmbal = new QLMuonBAL();
        public QuanLyMuon()
        {
            InitializeComponent();
            LoadDataToDataGridView();
            LoadDocGiaComboBox();
            LoadQLSachComboBox();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true; // Tắt chế độ chỉnh sửa trong DataGridView
            ClearTextBoxes();

        }
        private void ClearTextBoxes()
        {
            cbbDocGiaMuon.DataSource = null;
            cbbMaSachMuon.DataSource = null;
            cbbDocGiaMuon.Items.Clear();
            cbbMaSachMuon.Items.Clear();
            LoadDocGiaComboBox();
            LoadQLSachComboBox();
            cbbDocGiaMuon.SelectedIndex = -1;
            cbbMaSachMuon.SelectedIndex = -1;
            dateNgayMuon.Value = DateTime.Now;
            dateHanTra.Value = DateTime.Now;
        }



        private void LoadDocGiaComboBox()
        {
            List<string> docGiaIDs = qlmbal.ReadDocGiaIDs();
            cbbDocGiaMuon.DataSource = docGiaIDs;

        }
        private void LoadQLSachComboBox()
        {
            List<string> qlSachIDs = qlmbal.ReadQLSachIDs();
            cbbMaSachMuon.DataSource = qlSachIDs;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maDocGia = cbbDocGiaMuon.SelectedItem as string;
            string maSach = cbbMaSachMuon.SelectedItem as string;
            DateTime ngayMuon = dateNgayMuon.Value;
            DateTime hanTra = dateHanTra.Value;

            if (string.IsNullOrWhiteSpace(maDocGia) || string.IsNullOrWhiteSpace(maSach))
            {
                MessageBox.Show("Vui lòng chọn độc giả và sách trước khi thêm phiếu mượn.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the selected maTaiLieuMuon already exists in the loans
            List<QLMuon> lstqlmuon = qlmbal.ReadQuanLyMuon();
            bool isDuplicate = lstqlmuon.Any(m => m.maTaiLieuMuon == maSach);
            if (isDuplicate)
            {
                MessageBox.Show("Mã tài liệu đã tồn tại trong danh sách mượn.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate the new code for maPhieuMuon
            string newMaPhieuMuon = qlmbal.GenerateCode();

            QLMuon newMuon = new QLMuon
            {
                maPhieuMuon = newMaPhieuMuon,
                maDocGiaMuon = maDocGia,
                maTaiLieuMuon = maSach,
                NgayMuon = ngayMuon,
                HanTra = hanTra
            };

            try
            {
                qlmbal.AddQuanLyMuon(newMuon);
                MessageBox.Show("Thêm phiếu mượn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToDataGridView();
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void LoadDataToDataGridView()
        {

            List<QLMuon> lstqlmuon = qlmbal.ReadQuanLyMuon();
            dataGridView1.DataSource = lstqlmuon;
        }




        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy thông tin từ dòng đã chọn
                string maDocGiaMuon = selectedRow.Cells["maDocGiaMuonDataGridViewTextBoxColumn"].Value.ToString();
                string maTaiLieuMuon = selectedRow.Cells["maTaiLieuMuonDataGridViewTextBoxColumn"].Value.ToString();
                DateTime ngayMuon = (DateTime)selectedRow.Cells["ngayMuonDataGridViewTextBoxColumn"].Value;
                DateTime hanTra = (DateTime)selectedRow.Cells["hanTraDataGridViewTextBoxColumn"].Value;

                // Điền dữ liệu vào các điều khiển tương ứng
                cbbDocGiaMuon.SelectedItem = maDocGiaMuon;
                cbbMaSachMuon.SelectedItem = maTaiLieuMuon;
                dateNgayMuon.Value = ngayMuon;
                dateHanTra.Value = hanTra;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phiếu mượn này?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string maPhieuMuon = dataGridView1.SelectedRows[0].Cells["maPhieuMuonDataGridViewTextBoxColumn"].Value.ToString();

                    try
                    {
                        // Xóa phiếu mượn trong cơ sở dữ liệu
                        QLMuon muonToDelete = qlmbal.GetQuanLyMuonByMaPhieuMuon(maPhieuMuon);
                        if (muonToDelete != null)
                        {
                            qlmbal.DeleteQuanLyMuon(muonToDelete);
                            MessageBox.Show("Xóa phiếu mượn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataToDataGridView();
                            ClearTextBoxes();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bạn đã dính ràng buột bên quản lý trả không thể xóa khi bên đó tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn để xóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string newMaDocGia = cbbDocGiaMuon.SelectedItem as string;
                string newMaSach = cbbMaSachMuon.SelectedItem as string;
                DateTime newNgayMuon = dateNgayMuon.Value;
                DateTime newHanTra = dateHanTra.Value;

                if (!string.IsNullOrWhiteSpace(newMaDocGia) && !string.IsNullOrWhiteSpace(newMaSach))
                {
                    QLMuon selectedMuon = dataGridView1.SelectedRows[0].DataBoundItem as QLMuon;

                    // Check if the selected maTaiLieuMuon already exists in the loans (excluding the selected loan)
                    List<QLMuon> lstqlmuon = qlmbal.ReadQuanLyMuon();
                    string selectedMaPhieuMuon = selectedMuon.maPhieuMuon;
                    bool isDuplicate = lstqlmuon.Any(m => m.maTaiLieuMuon == newMaSach && m.maPhieuMuon != selectedMaPhieuMuon);
                    if (isDuplicate)
                    {
                        MessageBox.Show("Mã tài liệu đã tồn tại trong danh sách mượn.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    selectedMuon.maDocGiaMuon = newMaDocGia;
                    selectedMuon.maTaiLieuMuon = newMaSach;
                    selectedMuon.NgayMuon = newNgayMuon;
                    selectedMuon.HanTra = newHanTra;

                    try
                    {
                        qlmbal.UpdateMuon(selectedMuon);
                        MessageBox.Show("Cập nhật thông tin phiếu mượn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToDataGridView();
                        ClearTextBoxes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn độc giả và sách trước khi cập nhật phiếu mượn.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnReport_Click(object sender, EventArgs e) 
        { 
            ThongKe thongKe = new ThongKe(); 
            thongKe.ShowDialog(); 
        }
    }
}