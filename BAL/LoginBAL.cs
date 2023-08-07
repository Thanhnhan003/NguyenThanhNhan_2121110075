using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhNhan_2121110075.DAL;
using NguyenThanhNhan_2121110075; // Thêm namespace cho lớp TaiKhoan

namespace NguyenThanhNhan_2121110075.BAL
{
    class LoginBAL
    {
        private LoginDAL _loginDAL;

        public LoginBAL()
        {
            _loginDAL = new LoginDAL();
        }

        public TaiKhoan GetTaiKhoanByTenTaiKhoan(string tenTaiKhoan)
        {
            return _loginDAL.GetTaiKhoanByTenTaiKhoan(tenTaiKhoan);
        }

        public bool CheckLogin(string tenTaiKhoan, string matKhau)
        {
            TaiKhoan taiKhoan = _loginDAL.GetTaiKhoanByTenTaiKhoan(tenTaiKhoan);

            if (taiKhoan == null)
            {
                return false; // Tài khoản không tồn tại
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                return false; // Không nhập mật khẩu
            }

            return taiKhoan.MatKhau == matKhau;
        }
    }
}
