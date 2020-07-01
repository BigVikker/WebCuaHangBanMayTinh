namespace CuaHangBanMayTInh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MayTinh")]
    public partial class MayTinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MayTinh()
        {
            MuaHangs = new HashSet<MuaHang>();
        }

        [Key]
        [StringLength(20)]
        public string maMayTinh { get; set; }

        [StringLength(50)]
        public string tenMayTinh { get; set; }

        [StringLength(20)]
        public string maLoai { get; set; }

        public int? namSanXuat { get; set; }

        public long Gia { get; set; }

        public virtual LoaiMayTinh LoaiMayTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuaHang> MuaHangs { get; set; }
    }
}
