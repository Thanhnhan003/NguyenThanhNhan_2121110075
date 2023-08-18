using System;
using System.Collections.Generic;
using System.Linq;
using NguyenThanhNhan_2121110075.DAL;

namespace NguyenThanhNhan_2121110075.DAL
{
    public class QLDocGiaDAL
    {
        private saleEntities _context;

        public QLDocGiaDAL()
        {
            _context = new saleEntities();
        }

        public List<DocGia> ReadQuanLyDocGia()
        {
            return _context.DocGias.ToList();
        }

        public void AddDocGia(DocGia docGia)
        {
            _context.DocGias.Add(docGia);
            _context.SaveChanges();
        }

        public void RemoveDocGia(DocGia docGia)
        {
            _context.DocGias.Remove(docGia);
            _context.SaveChanges();
        }

        public void UpdateDocGia(DocGia docGia)
        {
            DocGia existingDocGia = _context.DocGias.Find(docGia.MaDocGia);
            if (existingDocGia != null)
            {
                existingDocGia.TenDocGia = docGia.TenDocGia;
                existingDocGia.NgayCap = docGia.NgayCap;
                existingDocGia.HanSD = docGia.HanSD;
                existingDocGia.TinhTrang = docGia.TinhTrang;
                existingDocGia.NgayCN = docGia.NgayCN;
                existingDocGia.HinhAnh = docGia.HinhAnh;
                _context.SaveChanges();
            }
        }

        public bool IsTenDocGiaExists(string tenDocGia)
        {
            return _context.DocGias.Any(d => d.TenDocGia == tenDocGia);
        }

        public DocGia GetQuanLyDocGiaByMaDocGia(string maDocGia)
        {
            return _context.DocGias.FirstOrDefault(d => d.MaDocGia == maDocGia);
        }
    }
}
