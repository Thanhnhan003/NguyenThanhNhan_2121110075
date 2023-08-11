using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<QLMuon> lstMuon = _qlMuonDAL.ReadQuanLyMuon();
            return lstMuon;
        }

        public void AddQuanLyMuon(QLMuon qlm)
        {
            _qlMuonDAL.AddMuon(qlm);
        }

        public void DeleteQuanLyMuon(QLMuon qlm)
        {
            _qlMuonDAL.RemoveMuon(qlm);
        }

        public void UpdateQuanLyMuon(QLMuon qlm)
        {
            _qlMuonDAL.UpdateMuon(qlm);
        }

        public QLMuon GetQuanLyMuonByMaPhieuMuon(string maPhieuMuon)
        {
            return _qlMuonDAL.GetQuanLyMuonByMaPhieuMuon(maPhieuMuon);
        }
    }
}