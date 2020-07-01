namespace CuaHangBanMayTInh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            MuaHangs = new HashSet<MuaHang>();
        }

        [Key]
        [StringLength(20)]
        public string maNV { get; set; }

        [StringLength(100)]
        public string tenNV { get; set; }

        [StringLength(100)]
        public string diaChi { get; set; }

        public int? SDT { get; set; }

        [StringLength(20)]
        public string matKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuaHang> MuaHangs { get; set; }
    }
}
