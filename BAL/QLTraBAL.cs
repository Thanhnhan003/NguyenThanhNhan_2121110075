using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhNhan_2121110075.DAL;

namespace NguyenThanhNhan_2121110075.BAL
{
    public class QLTraBAL
    {
        private QLTraDAL _qlTraDAL;

        public QLTraBAL()
        {
            _qlTraDAL = new QLTraDAL();
        }

        public List<QLTra> ReadQuanLyTra()
        {
            List<QLTra> lstForm = _qlTraDAL.ReadQuanLyTra();
            return lstForm;
        }
        public List<string> ReadMaMuonIDs()
        {
            return _qlTraDAL.ReadMaMuonIDs();
        }

        public void AddQuanLyTra(QLTra qlt)
        {
            _qlTraDAL.AddTra(qlt);
        }
        public void DeleteQuanLyTra(QLTra qlt)
        {
            _qlTraDAL.RemoveTra(qlt);
        }
        public void UpdateQuanLyTra(QLTra qlt)
        {
            _qlTraDAL.UpdateTra(qlt);
        }
        public QLTra GetQuanLyTraByMaPhieuTra(string maPhieuTra)
        {
            return _qlTraDAL.GetQuanLyTraByMaPhieuTra(maPhieuTra);
        }
        public QLTra GetQuanLyTraByMaPhieuMuon(string maPhieuMuon)
        {
            return _qlTraDAL.GetQuanLyTraByMaPhieuMuon(maPhieuMuon);
        }
        public bool IsMaPhieuMuonExists(string maPhieuMuon)
        {
            return _qlTraDAL.IsMaPhieuMuonExists(maPhieuMuon);
        }

        public string GenerateCode()
        {
            int nextAvailableCodeNumber = GetNextAvailableCodeNumber();
            string codePrefix = "PM";
            string codeNumber = nextAvailableCodeNumber.ToString("D4");
            return $"{codePrefix}{codeNumber}";
        }

        private int GetNextAvailableCodeNumber()
        {
            List<int> existingCodeNumbers = _qlTraDAL.ReadQuanLyTraCodeNumbers();

            if (existingCodeNumbers.Any())
            {
                int maxCodeNumber = existingCodeNumbers.Max();

                int smallestDeletedCodeNumber = GetSmallestDeletedCodeNumber(existingCodeNumbers);

                if (smallestDeletedCodeNumber > 0 && smallestDeletedCodeNumber < maxCodeNumber)
                {
                    return smallestDeletedCodeNumber;
                }

                return maxCodeNumber + 1;
            }

            return 1; // Gán giá trị mặc định nếu không có mã nào trong cơ sở dữ liệu
        }

        private int GetSmallestDeletedCodeNumber(List<int> existingCodeNumbers)
        {
            existingCodeNumbers.Sort();

            int smallestDeletedCodeNumber = 1;
            foreach (int codeNumber in existingCodeNumbers)
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
    }
}
