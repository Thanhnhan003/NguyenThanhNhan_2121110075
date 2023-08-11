
namespace NguyenThanhNhan_2121110075.GUI
{
    partial class Home
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
            this.btExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnBody = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.btnDocGia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPanelSach = new System.Windows.Forms.Button();
            this.taiKhoanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pnBody.SuspendLayout();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.AutoSize = true;
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.White;
            this.btExit.Location = new System.Drawing.Point(1395, 11);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(97, 40);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1106, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Admin";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbName.Location = new System.Drawing.Point(1105, 12);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(68, 28);
            this.lbName.TabIndex = 14;
            this.lbName.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(377, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 41);
            this.label1.TabIndex = 16;
            this.label1.Text = "PHẦM MỀN QUẢN LÝ THƯ VIỆN";
            // 
            // pnBody
            // 
            this.pnBody.Controls.Add(this.label4);
            this.pnBody.Location = new System.Drawing.Point(200, 100);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1295, 555);
            this.pnBody.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(365, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(400, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nguyễn Thành Nhân-2121110075";
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnTop.Controls.Add(this.btExit);
            this.pnTop.Controls.Add(this.pictureBox1);
            this.pnTop.Controls.Add(this.label1);
            this.pnTop.Controls.Add(this.label3);
            this.pnTop.Controls.Add(this.pictureBox2);
            this.pnTop.Controls.Add(this.lbName);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1495, 100);
            this.pnTop.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NguyenThanhNhan_2121110075.Properties.Resources.icons8_user_5;
            this.pictureBox1.Location = new System.Drawing.Point(998, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::NguyenThanhNhan_2121110075.Properties.Resources.logo1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.Silver;
            this.pnLeft.Controls.Add(this.button1);
            this.pnLeft.Controls.Add(this.btnDocGia);
            this.pnLeft.Controls.Add(this.label2);
            this.pnLeft.Controls.Add(this.btnPanelSach);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 100);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(200, 555);
            this.pnLeft.TabIndex = 23;
            // 
            // btnDocGia
            // 
            this.btnDocGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(43)))), ((int)(((byte)(72)))));
            this.btnDocGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDocGia.FlatAppearance.BorderSize = 0;
            this.btnDocGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocGia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocGia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDocGia.Image = global::NguyenThanhNhan_2121110075.Properties.Resources.icons8_people_50;
            this.btnDocGia.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDocGia.Location = new System.Drawing.Point(19, 176);
            this.btnDocGia.Margin = new System.Windows.Forms.Padding(4);
            this.btnDocGia.Name = "btnDocGia";
            this.btnDocGia.Size = new System.Drawing.Size(163, 91);
            this.btnDocGia.TabIndex = 17;
            this.btnDocGia.Text = "Độc giả";
            this.btnDocGia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDocGia.UseVisualStyleBackColor = false;
            this.btnDocGia.Click += new System.EventHandler(this.btnDocGia_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(10, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Danh Mục";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPanelSach
            // 
            this.btnPanelSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(99)))), ((int)(((byte)(25)))));
            this.btnPanelSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPanelSach.FlatAppearance.BorderSize = 0;
            this.btnPanelSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanelSach.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanelSach.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPanelSach.Image = global::NguyenThanhNhan_2121110075.Properties.Resources.icons8_book_50;
            this.btnPanelSach.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPanelSach.Location = new System.Drawing.Point(19, 85);
            this.btnPanelSach.Margin = new System.Windows.Forms.Padding(4);
            this.btnPanelSach.Name = "btnPanelSach";
            this.btnPanelSach.Size = new System.Drawing.Size(163, 91);
            this.btnPanelSach.TabIndex = 15;
            this.btnPanelSach.Text = "Quản Lý Sách";
            this.btnPanelSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPanelSach.UseVisualStyleBackColor = false;
            this.btnPanelSach.Click += new System.EventHandler(this.btnPanelSach_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::NguyenThanhNhan_2121110075.Properties.Resources.icons8_people_50;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(19, 267);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 91);
            this.button1.TabIndex = 18;
            this.button1.Text = "Quản Lý Mượn";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 655);
            this.ControlBox = false;
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Home_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Home_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Home_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Home_MouseUp);
            this.pnBody.ResumeLayout(false);
            this.pnBody.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource taiKhoanBindingSource;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnBody;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Button btnDocGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPanelSach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}