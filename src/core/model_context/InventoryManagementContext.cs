using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inventory_api.src.core.model_context;

public partial class InventoryManagementContext : IdentityDbContext<User>
{
    public InventoryManagementContext() { }

    public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
        : base(options) { }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductEntry> ProductEntries { get; set; }

    public virtual DbSet<ProductOutput> ProductOutputs { get; set; }

    public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.HasIndex(e => e.Ruc, "UQ__Company__CAF03673ADCD5AE3").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.BusinessName).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Ruc).HasMaxLength(20).IsUnicode(false);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");

            entity.Property(e => e.Description).HasMaxLength(100).IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.Code, "UQ__Product__A25C5AA734D5C967").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Warehouse).HasMaxLength(50).IsUnicode(false);

            entity
                .HasOne(d => d.UnitMeasure)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitMeasureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UnitMeasure_Product");
        });

        modelBuilder.Entity<ProductEntry>(entity =>
        {
            entity.HasKey(e => e.EntryId).HasName("PK_Entry");

            entity.ToTable("ProductEntry");

            entity.HasIndex(e => e.DocumentNumber, "UQ__ProductE__6899391894054452").IsUnique();

            entity.Property(e => e.ClientDocument).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.ClientName).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.DocumentNumber).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Warehouse).HasMaxLength(50).IsUnicode(false);

            entity
                .HasOne(d => d.Company)
                .WithMany(p => p.ProductEntries)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entry_Company");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.ProductEntries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entry_Product");

            entity
                .HasOne(d => d.RegisteredByNavigation)
                .WithMany(p => p.ProductEntries)
                .HasForeignKey(d => d.RegisteredBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entry_User");
        });

        modelBuilder.Entity<ProductOutput>(entity =>
        {
            entity.HasKey(e => e.ProductOutputsId).HasName("PK_Product_Outputs");

            entity.HasIndex(e => e.DocumentNumber, "UQ__ProductO__689939182DC13B32").IsUnique();

            entity.Property(e => e.ClientDocument).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.ClientName).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.DocumentNumber).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Warehouse).HasMaxLength(50).IsUnicode(false);

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.ProductOutputs)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exit_Product");

            entity
                .HasOne(d => d.RegisteredByNavigation)
                .WithMany(p => p.ProductOutputs)
                .HasForeignKey(d => d.RegisteredBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exit_User");
        });

        modelBuilder.Entity<UnitMeasure>(entity =>
        {
            entity.ToTable("UnitMeasure");

            entity.HasIndex(e => e.Name, "UQ__UnitMeas__737584F6E3E3348A").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(20).IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E4B690AA6C").IsUnique();

            entity.HasIndex(e => e.DocumentNumber, "UQ__User__689939180534C214").IsUnique();

            entity.Property(e => e.DocumentNumber).HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(50).IsUnicode(false);

            entity
                .HasOne(d => d.Permission)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Permission");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
