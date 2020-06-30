namespace CuaHangBanMayTInh.Models.Enites
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


        public GioHang(string id,string ten,int soLuong,long donGia)
        {
            this.maGioHang = id;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }
        public List<GioHang> listGioHang = new List<GioHang>();
        public void addGioHang(GioHang obj_add)
        {
            bool co = false;
            foreach (GioHang i in listGioHang)
                if (i.maGioHang == obj_add.maGioHang)
                {
                    i.soLuong += obj_add.soLuong;
                    co = true;
                    break;
                }
            if (!co)
                listGioHang.Add(obj_add);
        }
        public void updateHangHoa(GioHang obj_updated)
        {
            foreach (GioHang i in listGioHang)
                if (i.maGioHang == obj_updated.maGioHang)
                {
                    i.soLuong = obj_updated.soLuong;
                    if (obj_updated.soLuong == 0)
                        listGioHang.Remove(obj_updated);
                    return;
                }
        }
        public void deleteHangHoa(string id)
        {
            foreach (GioHang i in listGioHang)
                if (i.maGioHang == id)
                {
                    listGioHang.Remove(i);
                }
            return;
        }

        public int getSL()
        {
            int sll = 0;
            foreach (var i in listGioHang)
            {
                sll = sll + i.soLuong;
            }
            return sll;

        }
        public long getTongTien()
        {
            long tong = 0;
            foreach (GioHang i in listGioHang)
                tong += i.soLuong * i.donGia;
            return tong;
        }
    }
}
