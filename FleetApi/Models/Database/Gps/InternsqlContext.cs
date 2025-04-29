using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetApi.Models.Database.Gps;

public partial class InternsqlContext : DbContext
{
    public InternsqlContext()
    {
    }

    public InternsqlContext(DbContextOptions<InternsqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BrandsModel> BrandsModels { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<GeoDatum> GeoData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sqlidotmp.database.windows.net,1433;Initial Catalog=internsql;Persist Security Info=False;User ID=sqladminido;Password=Ido#Gesfrota2025;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");

        modelBuilder.Entity<BrandsModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brands_m__3213E83F411CC2F3");

            entity.ToTable("brands_models");

            entity.HasIndex(e => new { e.BrandName, e.ModelName, e.Year }, "UQ_brand_model_year").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .HasColumnName("brand_name");
            entity.Property(e => e.ModelName)
                .HasMaxLength(100)
                .HasColumnName("model_name");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cars__3213E83F9C01227B");

            entity.ToTable("cars");

            entity.HasIndex(e => e.Vin, "UQ__cars__DDB00C660BD333B1").IsUnique();

            entity.HasIndex(e => e.LicensePlate, "UQ__cars__F72CD56E917D81CD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandModelId).HasColumnName("brand_model_id");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(20)
                .HasColumnName("license_plate");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .HasColumnName("vin");

            entity.HasOne(d => d.BrandModel).WithMany(p => p.Cars)
                .HasForeignKey(d => d.BrandModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cars__brand_mode__6383C8BA");
        });

        modelBuilder.Entity<GeoDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__geo_data__3213E83F4C0902F1");

            entity.ToTable("geo_data");

            entity.HasIndex(e => new { e.CarId, e.RecordedAt }, "IX_geo_car_time").IsDescending(false, true);

            entity.HasIndex(e => new { e.Latitude, e.Longitude }, "IX_geo_lat_lon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.HeadingDeg)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("heading_deg");
            entity.Property(e => e.Ignition).HasColumnName("ignition");
            entity.Property(e => e.Latitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("longitude");
            entity.Property(e => e.RecordedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("recorded_at");
            entity.Property(e => e.SpeedKph)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("speed_kph");

            entity.HasOne(d => d.Car).WithMany(p => p.GeoData)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__geo_data__car_id__6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
