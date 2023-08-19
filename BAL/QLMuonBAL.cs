using System;
using System.Collections.Generic;
using System.Linq;
using NguyenThanhNhan_2121110075.DAL;

namespace NguyenThanhNhan_2121110075.BAL
{
    public class QLMuonBAL
    {
        private QLMuonDAL _qlMuonDAL;

        public QLMuonBAL()
        {
            _qlMuonDAL = new QLMuonDAL();
        }

        public List<QLMuon> ReadQuanLyMuon()
        {
            return _qlMuonDAL.ReadQuanLyMuon();
        }

        public List<string> ReadDocGiaIDs()
        {
            return _qlMuonDAL.ReadDocGiaIDs();
        }

        public List<string> ReadQLSachIDs()
        {
            return _qlMuonDAL.ReadQLSachIDs();
        }

        public void AddQuanLyMuon(QLMuon muon)
        {
            _qlMuonDAL.AddQuanLyMuon(muon);
        }

        public void DeleteQuanLyMuon(QLMuon muon)
        {
            _qlMuonDAL.RemoveQuanLyMuon(muon);
        }

        public void UpdateMuon(QLMuon muon)
        {
            _qlMuonDAL.UpdateMuon(muon);
        }

        public QLMuon GetQuanLyMuonByMaPhieuMuon(string maPhieuMuon)
        {
            return _qlMuonDAL.GetQuanLyMuonByMaPhieuMuon(maPhieuMuon);
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
            List<int> existingCodeNumbers = _qlMuonDAL.ReadQuanLyMuonCodeNumbers();

            if (existingCodeNumbers.Any()) // Check if the list is not empty
            {
                int maxCodeNumber = existingCodeNumbers.Max();

                int smallestDeletedCodeNumber = GetSmallestDeletedCodeNumber(existingCodeNumbers);

                if (smallestDeletedCodeNumber > 0 && smallestDeletedCodeNumber < maxCodeNumber)
                {
                    return smallestDeletedCodeNumber;
                }

                return maxCodeNumber + 1;
            }

            return 1; // Default value when the list is empty
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