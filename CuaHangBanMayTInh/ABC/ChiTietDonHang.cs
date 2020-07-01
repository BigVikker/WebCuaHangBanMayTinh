namespace CuaHangBanMayTInh.ABC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [StringLength(20)]
        public string maChiTietDonHang { get; set; }

        public int? soLuong { get; set; }

        public long? thanhTien { get; set; }

        [StringLength(100)]
        public string tenKH { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string gmail { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
