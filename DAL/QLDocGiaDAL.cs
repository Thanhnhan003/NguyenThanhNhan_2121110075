using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool IsTenDocGiaExists(string tenDocGia)
        {
            return _context.DocGias.Any(dg => dg.TenDocGia == tenDocGia);
        }

    }
}
