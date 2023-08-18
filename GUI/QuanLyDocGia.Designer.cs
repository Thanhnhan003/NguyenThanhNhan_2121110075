
namespace NguyenThanhNhan_2121110075.GUI
{
    partial class QuanLyDocGia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDocGiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayCapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hanSDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhTrangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayCNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hinhAnhDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.docGiaBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddIMG = new System.Windows.Forms.Button();
            this.pbIMG = new System.Windows.Forms.PictureBox();
            this.dateNC = new System.Windows.Forms.DateTimePicker();
            this.dateNCN = new System.Windows.Forms.DateTimePicker();
            this.dateHSD = new System.Windows.Forms.DateTimePicker();
            this.cmTT = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbNameDG = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.docGiaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.docGiaBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.docGiaBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.docGiaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.docGiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.docGiaBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource6)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource5)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(7, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(871, 117);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(250, 44);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(553, 31);
            this.tbSearch.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.tenDocGiaDataGridViewTextBoxColumn,
            this.ngayCapDataGridViewTextBoxColumn,
            this.hanSDDataGridViewTextBoxColumn,
            this.tinhTrangDataGridViewTextBoxColumn,
            this.ngayCNDataGridViewTextBoxColumn,
            this.hinhAnhDataGridViewImageColumn});
            this.dataGridView1.DataSource = this.docGiaBindingSource6;
            this.dataGridView1.Location = new System.Drawing.Point(7, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 70;
            this.dataGridView1.Size = new System.Drawing.Size(871, 430);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaDocGia";
            this.dataGridViewTextBoxColumn1.HeaderText = "MaDocGia";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tenDocGiaDataGridViewTextBoxColumn
            // 
            this.tenDocGiaDataGridViewTextBoxColumn.DataPropertyName = "TenDocGia";
            this.tenDocGiaDataGridViewTextBoxColumn.HeaderText = "TenDocGia";
            this.tenDocGiaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tenDocGiaDataGridViewTextBoxColumn.Name = "tenDocGiaDataGridViewTextBoxColumn";
            // 
            // ngayCapDataGridViewTextBoxColumn
            // 
            this.ngayCapDataGridViewTextBoxColumn.DataPropertyName = "NgayCap";
            this.ngayCapDataGridViewTextBoxColumn.HeaderText = "NgayCap";
            this.ngayCapDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ngayCapDataGridViewTextBoxColumn.Name = "ngayCapDataGridViewTextBoxColumn";
            // 
            // hanSDDataGridViewTextBoxColumn
            // 
            this.hanSDDataGridViewTextBoxColumn.DataPropertyName = "HanSD";
            this.hanSDDataGridViewTextBoxColumn.HeaderText = "HanSD";
            this.hanSDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hanSDDataGridViewTextBoxColumn.Name = "hanSDDataGridViewTextBoxColumn";
            // 
            // tinhTrangDataGridViewTextBoxColumn
            // 
            this.tinhTrangDataGridViewTextBoxColumn.DataPropertyName = "TinhTrang";
            this.tinhTrangDataGridViewTextBoxColumn.HeaderText = "TinhTrang";
            this.tinhTrangDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tinhTrangDataGridViewTextBoxColumn.Name = "tinhTrangDataGridViewTextBoxColumn";
            // 
            // ngayCNDataGridViewTextBoxColumn
            // 
            this.ngayCNDataGridViewTextBoxColumn.DataPropertyName = "NgayCN";
            this.ngayCNDataGridViewTextBoxColumn.HeaderText = "NgayCN";
            this.ngayCNDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ngayCNDataGridViewTextBoxColumn.Name = "ngayCNDataGridViewTextBoxColumn";
            // 
            // hinhAnhDataGridViewImageColumn
            // 
            this.hinhAnhDataGridViewImageColumn.DataPropertyName = "HinhAnh";
            this.hinhAnhDataGridViewImageColumn.HeaderText = "HinhAnh";
            this.hinhAnhDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.hinhAnhDataGridViewImageColumn.MinimumWidth = 6;
            this.hinhAnhDataGridViewImageColumn.Name = "hinhAnhDataGridViewImageColumn";
            // 
            // docGiaBindingSource6
            // 
            this.docGiaBindingSource6.DataSource = typeof(NguyenThanhNhan_2121110075.DocGia);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.btnAddIMG);
            this.groupBox1.Controls.Add(this.pbIMG);
            this.groupBox1.Controls.Add(this.dateNC);
            this.groupBox1.Controls.Add(this.dateNCN);
            this.groupBox1.Controls.Add(this.dateHSD);
            this.groupBox1.Controls.Add(this.cmTT);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.tbNameDG);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(884, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 556);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // btnAddIMG
            // 
            this.btnAddIMG.Location = new System.Drawing.Point(251, 380);
            this.btnAddIMG.Name = "btnAddIMG";
            this.btnAddIMG.Size = new System.Drawing.Size(107, 44);
            this.btnAddIMG.TabIndex = 8;
            this.btnAddIMG.Text = "Thêm ảnh";
            this.btnAddIMG.UseVisualStyleBackColor = true;
            this.btnAddIMG.Click += new System.EventHandler(this.btnAddIMG_Click);
            // 
            // pbIMG
            // 
            this.pbIMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbIMG.Location = new System.Drawing.Point(72, 327);
            this.pbIMG.Name = "pbIMG";
            this.pbIMG.Size = new System.Drawing.Size(100, 126);
            this.pbIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIMG.TabIndex = 7;
            this.pbIMG.TabStop = false;
            this.pbIMG.Click += new System.EventHandler(this.pbIMG_Click);
            // 
            // dateNC
            // 
            this.dateNC.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNC.CustomFormat = "dd - MM - yyyy";
            this.dateNC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNC.Location = new System.Drawing.Point(145, 85);
            this.dateNC.Name = "dateNC";
            this.dateNC.Size = new System.Drawing.Size(257, 31);
            this.dateNC.TabIndex = 6;
            // 
            // dateNCN
            // 
            this.dateNCN.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNCN.CustomFormat = "dd - MM - yyyy";
            this.dateNCN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNCN.Location = new System.Drawing.Point(145, 236);
            this.dateNCN.Name = "dateNCN";
            this.dateNCN.Size = new System.Drawing.Size(257, 31);
            this.dateNCN.TabIndex = 4;
            // 
            // dateHSD
            // 
            this.dateHSD.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateHSD.CustomFormat = "dd - MM - yyyy";
            this.dateHSD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHSD.Location = new System.Drawing.Point(146, 137);
            this.dateHSD.Name = "dateHSD";
            this.dateHSD.Size = new System.Drawing.Size(257, 31);
            this.dateHSD.TabIndex = 4;
            // 
            // cmTT
            // 
            this.cmTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmTT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmTT.FormattingEnabled = true;
            this.cmTT.Items.AddRange(new object[] {
            "Khóa",
            "Hoạt động"});
            this.cmTT.Location = new System.Drawing.Point(146, 186);
            this.cmTT.Name = "cmTT";
            this.cmTT.Size = new System.Drawing.Size(260, 33);
            this.cmTT.TabIndex = 3;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(295, 497);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 43);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(146, 497);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 43);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(10, 497);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 43);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbNameDG
            // 
            this.tbNameDG.Location = new System.Drawing.Point(146, 39);
            this.tbNameDG.Name = "tbNameDG";
            this.tbNameDG.Size = new System.Drawing.Size(260, 31);
            this.tbNameDG.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(6, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày Cập Nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(6, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Trình Trạng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(6, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hạn Sử dụng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày Cấp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên Độc Giả";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // docGiaBindingSource4
            // 
            this.docGiaBindingSource4.DataSource = typeof(NguyenThanhNhan_2121110075.DocGia);
            // 
            // docGiaBindingSource3
            // 
            this.docGiaBindingSource3.DataSource = typeof(NguyenThanhNhan_2121110075.DocGia);
            // 
            // docGiaBindingSource2
            // 
            this.docGiaBindingSource2.DataSource = typeof(NguyenThanhNhan_2121110075.DocGia);
            // 
            // docGiaBindingSource
            // 
            this.docGiaBindingSource.DataSource = typeof(NguyenThanhNhan_2121110075.DocGia);
            // 
            // docGiaBindingSource5
            // 
            this.docGiaBindingSource5.DataSource = typeof(NguyenThanhNhan_2121110075.DocGia);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm mã độc giả";
            // 
            // QuanLyDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1295, 555);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyDocGia";
            this.Text = "QuanLyDocGia";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource6)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docGiaBindingSource5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource docGiaBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateNC;
        private System.Windows.Forms.DateTimePicker dateHSD;
        private System.Windows.Forms.ComboBox cmTT;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbNameDG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource docGiaBindingSource1;
        private System.Windows.Forms.BindingSource docGiaBindingSource2;
        private System.Windows.Forms.DateTimePicker dateNCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDocGiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource docGiaBindingSource3;
        private System.Windows.Forms.BindingSource docGiaBindingSource4;
        private System.Windows.Forms.BindingSource docGiaBindingSource6;
        private System.Windows.Forms.Button btnAddIMG;
        private System.Windows.Forms.PictureBox pbIMG;
        private System.Windows.Forms.BindingSource docGiaBindingSource5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDocGiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayCapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hanSDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhTrangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayCNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn hinhAnhDataGridViewImageColumn;
        private System.Windows.Forms.Label label1;
    }
}