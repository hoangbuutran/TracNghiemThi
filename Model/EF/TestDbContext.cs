namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
            : base("name=TestDbContext")
        {
        }

        public virtual DbSet<BAILAM> BAILAMs { get; set; }
        public virtual DbSet<CAPTHI> CAPTHIs { get; set; }
        public virtual DbSet<CAUHOI> CAUHOIs { get; set; }
        public virtual DbSet<CHUYENNGANH_DH> CHUYENNGANH_DH { get; set; }
        public virtual DbSet<CT_BAIlAM_CAUHOI> CT_BAIlAM_CAUHOI { get; set; }
        public virtual DbSet<CT_CHUYENNGANH_MON> CT_CHUYENNGANH_MON { get; set; }
        public virtual DbSet<CT_DANHGIA_DETHI> CT_DANHGIA_DETHI { get; set; }
        public virtual DbSet<CT_DETHI_CAUHOI> CT_DETHI_CAUHOI { get; set; }
        public virtual DbSet<DANHGIA> DANHGIAs { get; set; }
        public virtual DbSet<DETHI> DETHIs { get; set; }
        public virtual DbSet<LIENHE> LIENHEs { get; set; }
        public virtual DbSet<LOAINGUOIDUNG> LOAINGUOIDUNGs { get; set; }
        public virtual DbSet<MONTHI> MONTHIs { get; set; }
        public virtual DbSet<MUCDO> MUCDOes { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<SOCAU> SOCAUs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAILIEU> TAILIEUx { get; set; }
        public virtual DbSet<THOIGIAN> THOIGIANs { get; set; }
        public virtual DbSet<THONGBAO> THONGBAOs { get; set; }
        public virtual DbSet<TINTUC> TINTUCs { get; set; }
        public virtual DbSet<YKIEN_DETHI> YKIEN_DETHI { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAUHOI>()
                .Property(e => e.DAPAN_DUNG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT_BAIlAM_CAUHOI>()
                .Property(e => e.TRALOI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LIENHE>()
                .Property(e => e.EMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.TENDANGNHAP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MATKHAU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.EMAIL)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
