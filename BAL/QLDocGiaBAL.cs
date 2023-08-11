using System;
using System.Collections.Generic;
using System.Linq;
using NguyenThanhNhan_2121110075.DAL;

namespace NguyenThanhNhan_2121110075.BAL
{
    public class QLDocGiaBAL
    {
        private QLDocGiaDAL _qlDocGiaDAL;

        public QLDocGiaBAL()
        {
            _qlDocGiaDAL = new QLDocGiaDAL();
        }

        public List<DocGia> ReadQuanLyDocGia()
        {
            return _qlDocGiaDAL.ReadQuanLyDocGia();
        }
        public void AddDocGia(DocGia docGia)
        {
            _qlDocGiaDAL.AddDocGia(docGia);
        }
        public bool IsTenDocGiaExists(string tenDocGia)
        {
            return _qlDocGiaDAL.IsTenDocGiaExists(tenDocGia);
        }
    }
}
