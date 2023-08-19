using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using NguyenThanhNhan_2121110075.BAL;
using System.Linq;
using System.IO;

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
            dataGridView1.ReadOnly = true; // Tắt chế độ chỉnh sửa trong DataGridView
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
            List<DocGia> existingReaders = qldgBAL.ReadQuanLyDocGia();
            currentCodeNumber = qldgBAL.GetNextAvailableCodeNumber(existingReaders).ToString();
            //dateNC.Format = DateTimePickerFormat.Custom;
            //dateNC.CustomFormat = " ";

            //// Đăng ký sự kiện khi giá trị thay đổi
            //dateNC.ValueChanged += dateNC_ValueChanged;


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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
                dateNCN.Value = selectedDocGia.NgayCN ?? DateTime.Now;

                // Load the image into the PictureBox
                if (selectedRow.Cells["hinhAnhDataGridViewImageColumn"].Value != null)
                {
                    byte[] imageData = (byte[])selectedRow.Cells["hinhAnhDataGridViewImageColumn"].Value;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pbIMG.Image = Image.FromStream(ms);
                        // Tạo một bản sao của hình ảnh và gán nó vào PictureBox
                        pbIMG.Image = new Bitmap(pbIMG.Image);
                    }
                }
                else
                {
                    pbIMG.Image = null; // Clear the PictureBox if no image
                }
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

            // Tạo một bản sao của hình ảnh trong PictureBox
            Image copyOfImage = pbIMG.Image;
            byte[] imageData = ImageToByteArray(copyOfImage);

            if (imageData == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                NgayCN = ngayCapNhat,
                HinhAnh = imageData // Sử dụng dữ liệu hình ảnh đã chuyển đổi
            };

            try
            {
                qldgBAL.AddQuanLyDocGia(qldg);
                MessageBox.Show("Thêm độc giả thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private byte[] ImageToByteArray(Image image)
        {
            if (image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg); // You can change the format if needed
                    return memoryStream.ToArray();
                }
            }
            else
            {
                return null; // Return null or handle this case according to your needs
            }
        }

        private QLMuonBAL qlmbal = new QLMuonBAL();


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
                        // Xóa các phiếu mượn của độc giả trước
                        List<QLMuon> muonsToDelete = qlmbal.ReadQuanLyMuon().Where(m => m.maDocGiaMuon == maDocGia).ToList();
                        foreach (QLMuon muon in muonsToDelete)
                        {
                            qlmbal.DeleteQuanLyMuon(muon);
                        }

                        // Tiếp theo, xóa độc giả trong bảng DocGia
                        DocGia qldgToDelete = qldgBAL.GetQuanLyDocGiaByMaDocGia(maDocGia);
                        if (qldgToDelete != null)
                        {
                            qldgBAL.DeleteQuanLyDocGia(qldgToDelete);
                            MessageBox.Show("Xóa độc giả và các phiếu mượn liên quan thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTextBoxes();
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
                        NgayCN = dateNCN.Value, // Thêm ngày cập nhật
                        HinhAnh = ImageToByteArray(pbIMG.Image) // Convert image to byte array
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
                    }
                }
                else
                {
                    MessageBox.Show("Tên độc giả không được để trống.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ClearTextBoxes()
        {
            tbNameDG.Text = "";
            dateNC.Value = DateTime.Now;
            dateHSD.Value = DateTime.Now;
            cmTT.SelectedItem = null;
            dateNCN.Value = DateTime.Now;
            pbIMG.Image = null;
        }

        private void btnAddIMG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    pbIMG.Image = Image.FromFile(imagePath);

                    pbIMG.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }


        private void pbIMG_Click(object sender, EventArgs e)
        {

        }

        private void sqlDataAdapter1_RowUpdated(object sender, Microsoft.Data.SqlClient.SqlRowUpdatedEventArgs e)
        {

        }

        private void dateNC_ValueChanged(object sender, EventArgs e)
        {
            //dateNC.Format = DateTimePickerFormat.Long;
            //dateNC.CustomFormat = null;
        }
    }
}
