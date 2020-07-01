namespace CuaHangBanMayTInh.ABC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuaHang")]
    public partial class MuaHang
    {
        [Key]
        [StringLength(20)]
        public string maMuaHang { get; set; }

        [StringLength(20)]
        public string maGioHang { get; set; }

        [StringLength(20)]
        public string maMayTinh { get; set; }

        [StringLength(20)]
        public string maNV { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual MayTinh MayTinh { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
