using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_BTL.Models;

public partial class TheTicketMovieContext : DbContext
{
    public TheTicketMovieContext()
    {
    }

    public TheTicketMovieContext(DbContextOptions<TheTicketMovieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TGhe> TGhes { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TLichChieu> TLichChieus { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TPhim> TPhims { get; set; }

    public virtual DbSet<TPhong> TPhongs { get; set; }

    public virtual DbSet<TRap> TRaps { get; set; }

    public virtual DbSet<TVe> TVes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-QJ3VDN2U\\MANHH;Initial Catalog=_TheTicketMovie;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TGhe>(entity =>
        {
            entity.HasKey(e => e.MaGhe).HasName("PK__tGhe__3CD3C67BB76985DB");

            entity.ToTable("tGhe");

            entity.Property(e => e.MaGhe).HasMaxLength(50);
            entity.Property(e => e.LoaiGhe).HasMaxLength(50);
            entity.Property(e => e.MaPhong).HasMaxLength(50);
            entity.Property(e => e.TrangThaiGhe).HasMaxLength(50);
            entity.Property(e => e.ViTri).HasMaxLength(50);

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.TGhes)
                .HasForeignKey(d => d.MaPhong)
                .HasConstraintName("fk_tGhe_tPhong");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.AccKhachHang).HasName("PK__tKhachHa__5F23F608D2A67A62");

            entity.ToTable("tKhachHang");

            entity.Property(e => e.AccKhachHang).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<TLichChieu>(entity =>
        {
            entity.HasKey(e => e.MaLichChieu).HasName("PK__tLichChi__DC740197B7EABCE4");

            entity.ToTable("tLichChieu");

            entity.Property(e => e.MaLichChieu).HasMaxLength(50);
            entity.Property(e => e.MaPhong).HasMaxLength(50);
            entity.Property(e => e.MaVe).HasMaxLength(50);
            entity.Property(e => e.ThoiGianChieu).HasColumnType("smalldatetime");
            entity.Property(e => e.ThoiGianKetThuc).HasColumnType("smalldatetime");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.TLichChieus)
                .HasForeignKey(d => d.MaPhong)
                .HasConstraintName("fk_tLichChieu_tPhong");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.TLichChieus)
                .HasForeignKey(d => d.MaVe)
                .HasConstraintName("fk_tLichChieu_tVe");

            entity.HasMany(d => d.MaPhims).WithMany(p => p.MaLichChieus)
                .UsingEntity<Dictionary<string, object>>(
                    "TPhimVaLichChieu",
                    r => r.HasOne<TPhim>().WithMany()
                        .HasForeignKey("MaPhim")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tPhimVaLichChieu_tPhim"),
                    l => l.HasOne<TLichChieu>().WithMany()
                        .HasForeignKey("MaLichChieu")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tPhimVaLichChieu_tLichChieu"),
                    j =>
                    {
                        j.HasKey("MaLichChieu", "MaPhim");
                        j.ToTable("tPhimVaLichChieu");
                        j.IndexerProperty<string>("MaLichChieu").HasMaxLength(50);
                        j.IndexerProperty<string>("MaPhim").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.HasKey(e => e.AccNhanVien).HasName("PK__tNhanVie__D4EAF47F6A26AD94");

            entity.ToTable("tNhanVien");

            entity.Property(e => e.AccNhanVien).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.Quyen).HasMaxLength(50);
        });

        modelBuilder.Entity<TPhim>(entity =>
        {
            entity.HasKey(e => e.MaPhim).HasName("PK__tPhim__4AC03DE3B76DCC78");

            entity.ToTable("tPhim");

            entity.Property(e => e.MaPhim).HasMaxLength(50);
            entity.Property(e => e.AccNhanVien).HasMaxLength(50);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(100);
            entity.Property(e => e.Background).HasMaxLength(100);
            entity.Property(e => e.DaoDien).HasMaxLength(50);
            entity.Property(e => e.DienVienChinh).HasMaxLength(50);
            entity.Property(e => e.NoiDung).HasMaxLength(50);
            entity.Property(e => e.TenPhim).HasMaxLength(50);
            entity.Property(e => e.TheLoai).HasMaxLength(50);
            entity.Property(e => e.ThoiLuong).HasMaxLength(50);

            entity.HasMany(d => d.MaRaps).WithMany(p => p.MaPhims)
                .UsingEntity<Dictionary<string, object>>(
                    "TPhimVaRap",
                    r => r.HasOne<TRap>().WithMany()
                        .HasForeignKey("MaRap")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tPhimVaRap_tRap"),
                    l => l.HasOne<TPhim>().WithMany()
                        .HasForeignKey("MaPhim")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tPhimVaRap_tPhim"),
                    j =>
                    {
                        j.HasKey("MaPhim", "MaRap");
                        j.ToTable("tPhimVaRap");
                        j.IndexerProperty<string>("MaPhim").HasMaxLength(50);
                        j.IndexerProperty<string>("MaRap").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<TPhong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__tPhong__20BD5E5B6A9FAC59");

            entity.ToTable("tPhong");

            entity.Property(e => e.MaPhong).HasMaxLength(50);
            entity.Property(e => e.MaRap).HasMaxLength(50);

            entity.HasOne(d => d.MaRapNavigation).WithMany(p => p.TPhongs)
                .HasForeignKey(d => d.MaRap)
                .HasConstraintName("fk_tPhong_tRap");
        });

        modelBuilder.Entity<TRap>(entity =>
        {
            entity.HasKey(e => e.MaRap).HasName("PK__tRap__3961207F02E72F74");

            entity.ToTable("tRap");

            entity.Property(e => e.MaRap).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.TenRap).HasMaxLength(50);
        });

        modelBuilder.Entity<TVe>(entity =>
        {
            entity.HasKey(e => e.MaVe).HasName("PK__tVe__2725100FA22D32DB");

            entity.ToTable("tVe");

            entity.Property(e => e.MaVe).HasMaxLength(50);
            entity.Property(e => e.AccKhachHang).HasMaxLength(50);
            entity.Property(e => e.GiaTien).HasMaxLength(50);
            entity.Property(e => e.MaGhe).HasMaxLength(50);
            entity.Property(e => e.MaPhim).HasMaxLength(50);
            entity.Property(e => e.TenVe).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
