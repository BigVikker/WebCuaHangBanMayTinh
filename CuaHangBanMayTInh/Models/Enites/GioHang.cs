namespace CuaHangBanMayTInh.Models.Enites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using CuaHangBanMayTInh.Models.Enites;
    using System.Web.Mvc;
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
        public string maMayTinh { get; set; }
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
            this.maMayTinh = id;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }
        public List<GioHang> listGioHang = new List<GioHang>();
        public void addGioHang(GioHang obj_add)
        {
            bool co = false;
            foreach (GioHang i in listGioHang)
                if (i.maMayTinh == obj_add.maMayTinh)
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
                if (i.maMayTinh == obj_updated.maMayTinh)
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
                if (i.maMayTinh == id)
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
        public GioHang SelectTop()
        {
            Model1 db = new Model1();
            return db.GioHangs.SqlQuery("Select Top(1) * from GioHang order by maMayTinh").SingleOrDefault();
        }
        public long getTongTien()
        {
            long tong = 0;
            foreach (GioHang i in listGioHang)
                tong += i.soLuong * i.donGia;
            return tong;
        }
        public void ThemVaoDuLieu(string maMayTInh, string maDonHang, int soLuong, long donGia, DateTime ngayTao)
        {
            Model1 db = new Model1();
            db.Database.ExecuteSqlCommand("insert into GioHang values ('{0}','{1}','{2}','{3}','{4}')"
                , maMayTInh, maDonHang, soLuong, donGia, ngayTao.Date.ToString());
            db.SaveChanges();
        }
    }
}
