//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NguyenThanhNhan_2121110075
{
    using System;
    using System.Collections.Generic;
    
    public partial class QLTra
    {
        public string maPhieuTra { get; set; }
        public string maNVTra { get; set; }
        public string maPhieuMuon { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
        public string maSach { get; set; }
    
        public virtual QLMuon QLMuon { get; set; }
        public virtual QLSach QLSach { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}