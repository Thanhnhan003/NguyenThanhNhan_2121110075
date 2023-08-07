using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhNhan_2121110075.DAL;
using NguyenThanhNhan_2121110075; // Thêm namespace cho lớp TaiKhoan

namespace NguyenThanhNhan_2121110075.DAL
{
    class LoginDAL
    {
        private saleEntities _context; // Thay "YourDbContext" bằng tên thật của lớp DbContext của bạn

        public LoginDAL()
        {
            _context = new saleEntities();
        }

        public TaiKhoan GetTaiKhoanByTenTaiKhoan(string tenTaiKhoan)
        {
            return _context.TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == tenTaiKhoan);
        }
    }
}
