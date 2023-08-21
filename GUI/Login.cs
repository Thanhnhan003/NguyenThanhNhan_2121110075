using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NguyenThanhNhan_2121110075.BAL;
using NguyenThanhNhan_2121110075.GUI;

namespace NguyenThanhNhan_2121110075
{
    public partial class Login : Form
    {
        private LoginBAL _loginBAL;

        public Login()
        {
            InitializeComponent();
            _loginBAL = new LoginBAL();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public delegate void AccountInfoHandler(string tenNguoiDung, string chucVu);

        public event AccountInfoHandler OnAccountInfoReceived;

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = txtUSER.Text;
            string matKhau = txtPASS.Text;

            if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                return;
            }

            bool isValidLogin = _loginBAL.CheckLogin(tenTaiKhoan, matKhau);

            if (isValidLogin)
            {
                TaiKhoan account = _loginBAL.GetTaiKhoanByTenTaiKhoan(tenTaiKhoan);

                if (account != null)
                {
                    // Gửi thông tin tài khoản về form Home
                    OnAccountInfoReceived?.Invoke(account.TenNguoiDung, account.ChucVu);
                }
                MessageBox.Show("Đăng nhập thành công.");
                // Tạo instance của form Home
                Home home = new Home(account);
                // Hiển thị form Home và đóng form Login
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
            }
        }





        private bool isDragging = false;
        private Point lastCursor;
        private Point lastFormLocation;
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastFormLocation = this.Location;
            }
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int dx = Cursor.Position.X - lastCursor.X;
                int dy = Cursor.Position.Y - lastCursor.Y;
                this.Location = new Point(lastFormLocation.X + dx, lastFormLocation.Y + dy);
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            //new Register().Show();
            //this.Hide();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                //Application.Exit();
            }
        }

    }
}
