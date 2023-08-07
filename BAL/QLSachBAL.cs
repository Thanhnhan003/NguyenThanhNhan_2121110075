using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhNhan_2121110075.DAL; // Import namespace cho QLSachDAL

namespace NguyenThanhNhan_2121110075.BAL
{
    class QLSachBAL
    {
        private QLSachDAL _qlSachDAL;

        public QLSachBAL()
        {
            _qlSachDAL = new QLSachDAL();
        }

        public bool AddSach(QLSach sach)
        {
            // Gọi phương thức tương ứng trong QLSachDAL
            return _qlSachDAL.AddSach(sach);
        }
        // Thêm các phương thức xử lý khác liên quan đến sách ở đây
    }
}
