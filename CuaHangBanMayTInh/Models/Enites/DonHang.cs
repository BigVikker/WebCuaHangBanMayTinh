namespace CuaHangBanMayTInh.Models.Enites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        [Required]
        [StringLength(20)]
        public string maNV{ get; set; }

        [StringLength(20)]
        public string trangThai { get; set; }

        public virtual ChiTietDonHang ChiTietDonHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public DonHang SelectTop()
        {
            Model1 db = new Model1();
            return db.DonHangs.SqlQuery("Select Top(1) * from DonHang order by maDonHang").SingleOrDefault();
        }
    }
}
