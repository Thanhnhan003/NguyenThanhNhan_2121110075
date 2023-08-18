using System;
using System.Collections.Generic;
using System.Linq;

namespace NguyenThanhNhan_2121110075.DAL
{
    public class QLMuonDAL
    {
        private saleEntities _context;

        public QLMuonDAL()
        {
            _context = new saleEntities();
        }

        public List<QLMuon> ReadQuanLyMuon()
        {
            return _context.QLMuons.ToList();
        }
        public List<string> ReadDocGiaIDs()
        {
            return _context.DocGias.Select(d => d.MaDocGia).ToList();
        }
        public List<string> ReadQLSachIDs()
        {
            return _context.QLSaches.Select(d => d.MaSach).ToList();
        }


        public void AddQuanLyMuon(QLMuon muon)
        {
            _context.QLMuons.Add(muon);
            _context.SaveChanges();
        }

        public void RemoveQuanLyMuon(QLMuon muon)
        {
            _context.QLMuons.Remove(muon);
            _context.SaveChanges();
        }

        public void UpdateMuon(QLMuon muon)
        {
            QLMuon existingMuon = _context.QLMuons.Find(muon.maPhieuMuon);
            if (existingMuon != null)
            {
                existingMuon.maTaiLieuMuon = muon.maTaiLieuMuon;
                existingMuon.NgayMuon = muon.NgayMuon;
                existingMuon.HanTra = muon.HanTra;
                _context.SaveChanges();
            }
        }

        public QLMuon GetQuanLyMuonByMaPhieuMuon(string maPhieuMuon)
        {
            return _context.QLMuons.FirstOrDefault(m => m.maPhieuMuon == maPhieuMuon);
        }

        public List<int> ReadQuanLyMuonCodeNumbers()
        {
            return _context.QLMuons.Select(m => m.maPhieuMuon.Substring(2)).Select(int.Parse).ToList();
        }


    }
}

