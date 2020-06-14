namespace CuaHangBanMayTInh.Models.Enites
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiMayTinh> LoaiMayTinhs { get; set; }
        public virtual DbSet<MayTinh> MayTinhs { get; set; }
        public virtual DbSet<MuaHang> MuaHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.gmail)
                .IsFixedLength();

            modelBuilder.Entity<ChiTietDonHang>()
                .HasOptional(e => e.DonHang)
                .WithRequired(e => e.ChiTietDonHang);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.tenDangNhap)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.matKhau)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.gmail)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiMayTinh>()
                .Property(e => e.ghiChu)
                .IsFixedLength();
        }
    }
}
