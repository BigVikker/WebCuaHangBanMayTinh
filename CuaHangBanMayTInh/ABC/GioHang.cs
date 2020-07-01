namespace CuaHangBanMayTInh.ABC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang()
        {
            DonHangs = new HashSet<DonHang>();
            MuaHangs = new HashSet<MuaHang>();
        }

        [Key]
        [StringLength(20)]
        public string maGioHang { get; set; }

        [StringLength(50)]
        public string tenSanPham { get; set; }

        public int soLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayTao { get; set; }

        public long donGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuaHang> MuaHangs { get; set; }
    }
}
