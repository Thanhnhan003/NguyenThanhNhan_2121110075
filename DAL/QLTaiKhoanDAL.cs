using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhNhan_2121110075;

namespace NguyenThanhNhan_2121110075.DAL
{
    public class QLTaiKhoanDAL
    {
        private saleEntities _context;

        public QLTaiKhoanDAL()
        {
            _context = new saleEntities();
        }

        public List<TaiKhoan> ReadQLTaiKhoan()
        {
            return _context.TaiKhoans.ToList();
        }

        public void AddTaiKhoan(TaiKhoan tk)
        {
            _context.TaiKhoans.Add(tk);
            _context.SaveChanges();
        }

        public void RemoveTaiKhoan(TaiKhoan tk)
        {
            _context.TaiKhoans.Remove(tk);
            _context.SaveChanges();
        }

        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            TaiKhoan existingTK = _context.TaiKhoans.Find(tk.TenTaiKhoan);
            if (existingTK != null)
            {
                existingTK.MatKhau = tk.MatKhau;
                existingTK.Email = tk.Email;
                existingTK.TenNguoiDung = tk.TenNguoiDung;
                existingTK.MaNV = tk.MaNV;
                existingTK.ChucVu = tk.ChucVu;
                existingTK.SoDienThoai = tk.SoDienThoai;
                _context.SaveChanges();
            }
        }

        public bool IsTenTaiKhoanExists(string tenTaiKhoan)
        {
            return _context.TaiKhoans.Any(tk => tk.TenTaiKhoan == tenTaiKhoan);
        }

        public TaiKhoan GetTaiKhoanByTenTaiKhoan(string tenTaiKhoan)
        {
            return _context.TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == tenTaiKhoan);
        }
    }
}
