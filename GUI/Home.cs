using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenThanhNhan_2121110075.GUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastFormLocation;
        private void Home_Load(object sender, EventArgs e)
        {
            pnTop.BackColor = Color.FromArgb(192, 255, 192);
            pnTop.Dock = DockStyle.Top;

            pnLeft.BackColor = Color.Silver;
            pnLeft.Dock = DockStyle.Left;
        }
        private void Home_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int dx = Cursor.Position.X - lastCursor.X;
                int dy = Cursor.Position.Y - lastCursor.Y;
                this.Location = new Point(lastFormLocation.X + dx, lastFormLocation.Y + dy);
            }
        }

        private void Home_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastFormLocation = this.Location;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnPanelSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLySach());
        }
        private void btnDocGia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyDocGia());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }
    }
}
