using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhNhan_2121110075.DAL
{
    class QLSachDAL
    {
        private saleEntities _context;

        public QLSachDAL()
        {
            _context = new saleEntities();
        }

        public bool AddSach(QLSach sach)
        {
            try
            {
                _context.QLSach.Add(sach);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Thêm các phương thức xử lý khác liên quan đến sách ở đây
    }
}
