using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhNhan_2121110075.DAL
{
    public class QLSachDAL
    {
        private saleEntities _context;

        public QLSachDAL()
        {
            _context = new saleEntities();
        }

        public List<QLSach> ReadQuanLySach()
        {
            return _context.QLSaches.ToList();
        }

        public void AddSach(QLSach qls)
        {
            _context.QLSaches.Add(qls);
            _context.SaveChanges();
        }
        public bool IsTenSachExists(string tenSach)
        {
            return _context.QLSaches.Any(s => s.TenSach == tenSach);
        }
        public void RemoveSach(QLSach qls)
        {
            _context.QLSaches.Remove(qls);
            _context.SaveChanges();
        }
        public QLSach GetQuanLySachByMaSach(string maSach)
        {
            return _context.QLSaches.FirstOrDefault(s => s.MaSach == maSach);
        }
        public void UpdateSach(QLSach qls)
        {
            QLSach existingSach = _context.QLSaches.Find(qls.MaSach);
            if (existingSach != null)
            {
                existingSach.TenSach = qls.TenSach;
                existingSach.TenTacGia = qls.TenTacGia;
                existingSach.NamXuatBan = qls.NamXuatBan;
                existingSach.SoLuong = qls.SoLuong;
                existingSach.TheLoai = qls.TheLoai;
                _context.SaveChanges();
            }
        }


    }
}
