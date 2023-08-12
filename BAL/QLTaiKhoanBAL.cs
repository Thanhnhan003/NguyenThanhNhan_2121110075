using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhNhan_2121110075.DAL;


namespace NguyenThanhNhan_2121110075.BAL
{
    public class QLTaiKhoanBAL
    {
        private QLTaiKhoanDAL _qlTaiKhoanDAL;

        public QLTaiKhoanBAL()
        {
            _qlTaiKhoanDAL = new QLTaiKhoanDAL();
        }

        public List<TaiKhoan> ReadQLTaiKhoan()
        {
            return _qlTaiKhoanDAL.ReadQLTaiKhoan();
        }

        public void AddTaiKhoan(TaiKhoan tk)
        {
            _qlTaiKhoanDAL.AddTaiKhoan(tk);
        }

        public void DeleteTaiKhoan(TaiKhoan tk)
        {
            _qlTaiKhoanDAL.RemoveTaiKhoan(tk);
        }

        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            _qlTaiKhoanDAL.UpdateTaiKhoan(tk);
        }
    }
}