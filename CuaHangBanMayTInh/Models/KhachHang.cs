namespace CuaHangBanMayTInh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [StringLength(20)]
        public string maKH { get; set; }

        [StringLength(100)]
        public string tenKH { get; set; }

        [StringLength(50)]
        public string tenDangNhap { get; set; }

        [StringLength(50)]
        public string matKhau { get; set; }

        [StringLength(50)]
        public string gmail { get; set; }

        public int? SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
