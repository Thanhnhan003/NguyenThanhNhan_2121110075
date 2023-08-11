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

        public void AddQuanLyDocGia(DocGia docGia)
        {
            _qlDocGiaDAL.AddDocGia(docGia);
        }

        public void DeleteQuanLyDocGia(DocGia docGia)
        {
            _qlDocGiaDAL.RemoveDocGia(docGia);
        }

        public void UpdateDocGia(DocGia docGia)
        {
            _qlDocGiaDAL.UpdateDocGia(docGia);
        }


        public int GetNextAvailableCodeNumber(List<DocGia> existingReaders)
        {
            int maxCodeNumber = 0;

            foreach (var reader in existingReaders)
            {
                if (reader.MaDocGia.StartsWith("DG"))
                {
                    if (int.TryParse(reader.MaDocGia.Substring(2), out int codeNumber))
                    {
                        maxCodeNumber = Math.Max(maxCodeNumber, codeNumber);
                    }
                }
            }

            int smallestDeletedCodeNumber = GetSmallestDeletedCodeNumber(existingReaders);

            if (smallestDeletedCodeNumber > 0 && smallestDeletedCodeNumber < maxCodeNumber)
            {
                return smallestDeletedCodeNumber;
            }

            return maxCodeNumber + 1;
        }

        private int GetSmallestDeletedCodeNumber(List<DocGia> existingReaders)
        {
            List<int> deletedCodeNumbers = new List<int>();
            foreach (var reader in existingReaders)
            {
                if (reader.MaDocGia.StartsWith("DG"))
                {
                    if (int.TryParse(reader.MaDocGia.Substring(2), out int codeNumber))
                    {
                        deletedCodeNumbers.Add(codeNumber);
                    }
                }
            }

            deletedCodeNumbers.Sort();

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
        public bool IsTenDocGiaExists(string tenDocGia)
        {
            return _qlDocGiaDAL.IsTenDocGiaExists(tenDocGia);
        }

        public DocGia GetQuanLyDocGiaByMaDocGia(string maSach)
        {
            return _qlDocGiaDAL.GetQuanLyDocGiaByMaDocGia(maSach);
        }
    }
}
