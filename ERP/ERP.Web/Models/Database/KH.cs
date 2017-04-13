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
    
    public partial class KH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH()
        {
            this.BH_BAO_GIA = new HashSet<BH_BAO_GIA>();
            this.BH_DE_NGHI_GIU_HANG = new HashSet<BH_DE_NGHI_GIU_HANG>();
            this.BH_DON_HANG_DU_KIEN = new HashSet<BH_DON_HANG_DU_KIEN>();
            this.KH_LIEN_HE = new HashSet<KH_LIEN_HE>();
            this.KH_TK_NGAN_HANG = new HashSet<KH_TK_NGAN_HANG>();
            this.KH_CHUYEN_SALES = new HashSet<KH_CHUYEN_SALES>();
            this.KH_DC_XUAT_HANG = new HashSet<KH_DC_XUAT_HANG>();
            this.KH_PHAN_HOI_KHACH_HANG = new HashSet<KH_PHAN_HOI_KHACH_HANG>();
            this.KHO_DNXH = new HashSet<KHO_DNXH>();
            this.KHO_GIU_HANG = new HashSet<KHO_GIU_HANG>();
            this.KHO_XUAT_KHO = new HashSet<KHO_XUAT_KHO>();
            this.KH_PHAN_LOAI_KHACH = new HashSet<KH_PHAN_LOAI_KHACH>();
        }
    
        public string MA_KHACH_HANG { get; set; }
        public string TEN_CONG_TY { get; set; }
        public string VAN_PHONG_GIAO_DICH { get; set; }
        public string DIA_CHI_XUAT_HOA_DON { get; set; }
        public string TINH { get; set; }
        public string QUOC_GIA { get; set; }
        public string MST { get; set; }
        public string HOTLINE { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string LOGO { get; set; }
        public string WEBSITE { get; set; }
        public string DIEU_KHOAN_THANH_TOAN { get; set; }
        public string TINH_TRANG_HOAT_DONG { get; set; }
        public Nullable<int> SO_NGAY_DUOC_NO { get; set; }
        public Nullable<int> SO_NO_TOI_DA { get; set; }
        public string GHI_CHU { get; set; }
        public string TRUC_THUOC { get; set; }
        public string SALES_TAO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BH_BAO_GIA> BH_BAO_GIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BH_DE_NGHI_GIU_HANG> BH_DE_NGHI_GIU_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BH_DON_HANG_DU_KIEN> BH_DON_HANG_DU_KIEN { get; set; }
        public virtual CCTC_CONG_TY CCTC_CONG_TY { get; set; }
        public virtual CCTC_NHAN_VIEN CCTC_NHAN_VIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_LIEN_HE> KH_LIEN_HE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_TK_NGAN_HANG> KH_TK_NGAN_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_CHUYEN_SALES> KH_CHUYEN_SALES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_DC_XUAT_HANG> KH_DC_XUAT_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_PHAN_HOI_KHACH_HANG> KH_PHAN_HOI_KHACH_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_DNXH> KHO_DNXH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_GIU_HANG> KHO_GIU_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_XUAT_KHO> KHO_XUAT_KHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_PHAN_LOAI_KHACH> KH_PHAN_LOAI_KHACH { get; set; }
    }
}
