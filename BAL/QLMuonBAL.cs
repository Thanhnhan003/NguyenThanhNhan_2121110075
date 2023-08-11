using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddMuon(QLMuon qlm)
        {
            _context.QLMuons.Add(qlm);
            _context.SaveChanges();
        }

        public void RemoveMuon(QLMuon qlm)
        {
            _context.QLMuons.Remove(qlm);
            _context.SaveChanges();
        }

        public void UpdateMuon(QLMuon qlm)
        {
            QLMuon existingMuon = _context.QLMuons.Find(qlm.maPhieuMuon);
            if (existingMuon != null)
            {
                existingMuon.maNVMuon = qlm.maNVMuon;
                existingMuon.maDocGiaMuon = qlm.maDocGiaMuon;
                existingMuon.maTaiLieuMuon = qlm.maTaiLieuMuon;
                existingMuon.NgayMuon = qlm.NgayMuon;
                existingMuon.HanTra = qlm.HanTra;
                existingMuon.maSach = qlm.maSach;
                _context.SaveChanges();
            }
        }

        public QLMuon GetQuanLyMuonByMaPhieuMuon(string maPhieuMuon)
        {
            return _context.QLMuons.FirstOrDefault(m => m.maPhieuMuon == maPhieuMuon);
        }
    }
}
