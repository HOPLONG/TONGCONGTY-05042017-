//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Web.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class BH_CT_BAO_GIA
    {
        public int ID { get; set; }
        public string SO_BAO_GIA { get; set; }
        public string MA_HANG { get; set; }
        public int SO_LUONG { get; set; }
        public decimal DON_GIA { get; set; }
        public double CHIET_KHAU { get; set; }
        public string CACH_TINH_THANH_TIEN { get; set; }
        public decimal THANH_TIEN { get; set; }
        public Nullable<double> CK_VAT { get; set; }
        public Nullable<decimal> TIEN_VAT { get; set; }
        public string TINH_TRANG_HANG { get; set; }
        public string THOI_GIAN_GIAO_HANG { get; set; }
        public DateTime NGAY_GIAO_HANG { get; set; }
        public string DIA_DIEM_GIAO_HANG { get; set; }
        public string GHI_CHU { get; set; }
        public decimal DON_GIA_SAU_CHIET_KHAU { get; set; }
    
        public virtual BH_BAO_GIA BH_BAO_GIA { get; set; }
        public virtual HH HH { get; set; }
    }
}
