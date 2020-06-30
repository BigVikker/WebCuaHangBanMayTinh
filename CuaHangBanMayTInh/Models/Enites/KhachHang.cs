namespace CuaHangBanMayTInh.Models.Enites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public KhachHang SelectTop(string tenDangNhap)
        {
            Model1 db = new Model1();
            return db.KhachHangs.SqlQuery("Select Top(1) * from KhachHang where tenDangNhap = '"+tenDangNhap+"'").SingleOrDefault();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
