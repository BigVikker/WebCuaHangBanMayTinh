namespace CuaHangBanMayTInh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [StringLength(20)]
        public string maDonHang { get; set; }

        [Required]
        [StringLength(20)]
        public string maKH { get; set; }

        [StringLength(20)]
        public string maGioHang { get; set; }

        public virtual ChiTietDonHang ChiTietDonHang { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
