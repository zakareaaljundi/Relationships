using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Relationships.Models;

public partial class DbA9b7cfLayersdbContext : DbContext
{
    public DbA9b7cfLayersdbContext()
    {
    }

    public DbA9b7cfLayersdbContext(DbContextOptions<DbA9b7cfLayersdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Doh> Dohs { get; set; }

    public virtual DbSet<FacilityType> FacilityTypes { get; set; }

    public virtual DbSet<Governorate> Governorates { get; set; }

    public virtual DbSet<HealthInstitution> HealthInstitutions { get; set; }

    public virtual DbSet<Nahia> Nahias { get; set; }

 /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SQL5106.site4now.net;Database=db_a9b7cf_layersdb;User Id=db_a9b7cf_layersdb_admin;Password=ZS123456zs;");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => new { e.DistrictId, e.GovernorateId, e.DohId });

            entity.HasOne(d => d.Governorate).WithMany(p => p.Districts)
                .HasForeignKey(d => d.GovernorateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Districts_Governorates");

            entity.HasOne(d => d.Doh).WithMany(p => p.Districts)
                .HasForeignKey(d => new { d.DohId, d.GovernorateId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Districts_Dohs");
        });

        modelBuilder.Entity<Doh>(entity =>
        {
            entity.HasKey(e => new { e.DohId, e.GovernorateId });

            entity.HasOne(d => d.Governorate).WithMany(p => p.Dohs)
                .HasForeignKey(d => d.GovernorateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dohs_Governorates");
        });

        modelBuilder.Entity<FacilityType>(entity =>
        {
            entity.Property(e => e.FacilityTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Governorate>(entity =>
        {
            entity.Property(e => e.GovernorateId).ValueGeneratedNever();
        });

        modelBuilder.Entity<HealthInstitution>(entity =>
        {
            entity.HasKey(e => new { e.HealthInstitutionId, e.GovernorateId, e.FacilityTypeId, e.DohId });

            entity.HasOne(d => d.FacilityType).WithMany(p => p.HealthInstitutions)
                .HasForeignKey(d => d.FacilityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HealthInstitutions_FacilityTypes");

            entity.HasOne(d => d.Governorate).WithMany(p => p.HealthInstitutions)
                .HasForeignKey(d => d.GovernorateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HealthInstitutions_Governorates");

            entity.HasOne(d => d.Doh).WithMany(p => p.HealthInstitutions)
                .HasForeignKey(d => new { d.DohId, d.GovernorateId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HealthInstitutions_Dohs");
        });

        modelBuilder.Entity<Nahia>(entity =>
        {
            entity.HasKey(e => new { e.NahiaId, e.GovernorateId, e.DistrictId, e.DohId });

            entity.HasOne(d => d.Governorate).WithMany(p => p.Nahia)
                .HasForeignKey(d => d.GovernorateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nahias_Governorates");

            entity.HasOne(d => d.Doh).WithMany(p => p.Nahia)
                .HasForeignKey(d => new { d.DohId, d.GovernorateId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nahias_Dohs");

            entity.HasOne(d => d.District).WithMany(p => p.Nahia)
                .HasForeignKey(d => new { d.DistrictId, d.GovernorateId, d.DohId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nahias_Districts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
