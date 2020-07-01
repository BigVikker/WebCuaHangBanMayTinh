namespace CuaHangBanMayTInh.Models.Enites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiMayTinh")]
    public partial class LoaiMayTinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiMayTinh()
        {
            MayTinhs = new HashSet<MayTinh>();
        }

        [Key]
        [StringLength(20)]
        public string maLoai { get; set; }

        [StringLength(20)]
        public string tenLoai { get; set; }

        [StringLength(100)]
        public string ghiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MayTinh> MayTinhs { get; set; }
    }
}
