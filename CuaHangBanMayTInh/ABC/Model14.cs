namespace CuaHangBanMayTInh.ABC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model14 : DbContext
    {
        public Model14()
            : base("name=Model14")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
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
