using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhNhan_2121110075.DAL;

namespace NguyenThanhNhan_2121110075.BAL
{
    public class QLSachBAL
    {
        private QLSachDAL _qlSachDAL;

        public QLSachBAL()
        {
            _qlSachDAL = new QLSachDAL();
        }

        public List<QLSach> ReadQuanLySach()
        {
            List<QLSach> lstForm = _qlSachDAL.ReadQuanLySach();
            return lstForm;
        }

        public void AddQuanLySach(QLSach qls)
        {
            _qlSachDAL.AddSach(qls);
        }
        public int GetNextAvailableCodeNumber()
        {
            List<QLSach> existingBooks = ReadQuanLySach(); // Đọc tất cả sách từ nguồn dữ liệu
            int maxCodeNumber = 0;

            foreach (var book in existingBooks)
            {
                if (book.MaSach.StartsWith("TL"))
                {
                    // Tách phần số thứ tự từ mã sách
                    if (int.TryParse(book.MaSach.Substring(2), out int codeNumber))
                    {
                        // Tìm số thứ tự lớn nhất hiện có
                        maxCodeNumber = Math.Max(maxCodeNumber, codeNumber);
                    }
                }
            }

            // Tăng giá trị lớn nhất lên 1 để có số thứ tự mới
            return maxCodeNumber + 1;
        }
        public bool IsTenSachExists(string tenSach)
        {
            return _qlSachDAL.IsTenSachExists(tenSach);
        }
        public void DeleteQuanLySach(QLSach qls)
        {
            _qlSachDAL.RemoveSach(qls);
        }
        public QLSach GetQuanLySachByMaSach(string maSach)
        {
            return _qlSachDAL.GetQuanLySachByMaSach(maSach);
        }
        public int GetNextAvailableCodeNumber(List<QLSach> existingBooks)
        {
            int maxCodeNumber = 0;

            foreach (var book in existingBooks)
            {
                if (book.MaSach.StartsWith("TL"))
                {
                    // Tách phần số thứ tự từ mã sách
                    if (int.TryParse(book.MaSach.Substring(2), out int codeNumber))
                    {
                        // Tìm số thứ tự lớn nhất hiện có
                        maxCodeNumber = Math.Max(maxCodeNumber, codeNumber);
                    }
                }
            }

            // Tìm số thứ tự nhỏ nhất đã bị xóa trước đó
            int smallestDeletedCodeNumber = GetSmallestDeletedCodeNumber(existingBooks);

            // Nếu có mã bị xóa trước đó, trả về mã đó
            if (smallestDeletedCodeNumber > 0 && smallestDeletedCodeNumber < maxCodeNumber)
            {
                return smallestDeletedCodeNumber;
            }

            // Nếu không có mã bị xóa trước đó hoặc mã bị xóa lớn hơn mã hiện tại, trả về mã kế tiếp
            return maxCodeNumber + 1;
        }

        private int GetSmallestDeletedCodeNumber(List<QLSach> existingBooks)
        {
            List<int> deletedCodeNumbers = new List<int>();
            foreach (var book in existingBooks)
            {
                if (book.MaSach.StartsWith("TL"))
                {
                    if (int.TryParse(book.MaSach.Substring(2), out int codeNumber))
                    {
                        deletedCodeNumbers.Add(codeNumber);
                    }
                }
            }

            deletedCodeNumbers.Sort();

            // Tìm số thứ tự nhỏ nhất đã bị xóa trước đó
            int smallestDeletedCodeNumber = 1;
            foreach (int codeNumber in deletedCodeNumbers)
            {
                if (codeNumber == smallestDeletedCodeNumber)
                {
                    smallestDeletedCodeNumber++;
                }
                else
                {
                    break;
                }
            }

            return smallestDeletedCodeNumber;
        }
        public void UpdateQuanLySach(QLSach qls)
        {
            _qlSachDAL.UpdateSach(qls);
        }


    }
}
