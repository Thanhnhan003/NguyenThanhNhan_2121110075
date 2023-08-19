using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NguyenThanhNhan_2121110075.DAL
{
     public class QLTraDAL
     {
        private saleEntities _context;

        public QLTraDAL()
        {
            _context = new saleEntities();
        }

        public List<QLTra> ReadQuanLyTra()
        {
            return _context.QLTras.ToList();
        }
        public List<string> ReadMaMuonIDs()
        {
            return _context.QLMuons.Select(d => d.maPhieuMuon).ToList();
        }
        public void AddTra(QLTra qlt)
        {
            _context.QLTras.Add(qlt);
            _context.SaveChanges();
        }
        public void RemoveTra(QLTra qlt)
        {
            _context.QLTras.Remove(qlt);
            _context.SaveChanges();
        }
        public void UpdateTra(QLTra qlt)
        {
            _context.Entry(qlt).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public QLTra GetQuanLyTraByMaPhieuTra(string maPhieuTra)
        {
            return _context.QLTras.FirstOrDefault(m => m.maPhieuTra == maPhieuTra);
        }
        public QLTra GetQuanLyTraByMaPhieuMuon(string maPhieuMuon)
        {
            return _context.QLTras.FirstOrDefault(tra => tra.maPhieuMuon == maPhieuMuon);
        }
        public bool IsMaPhieuMuonExists(string maPhieuMuon)
        {
            return _context.QLTras.Any(tra => tra.maPhieuMuon == maPhieuMuon);
        }


        public List<int> ReadQuanLyTraCodeNumbers()
        {
            return _context.QLTras.Select(m => m.maPhieuTra.Substring(2)).Select(int.Parse).ToList();
        }
    }
}
