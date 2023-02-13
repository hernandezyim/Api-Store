using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StoreApi.Models;

public partial class StoreContext : DbContext
{
    public StoreContext()
    {
    }

    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Cubicle> Cubicles { get; set; }

    public virtual DbSet<Footwear> Footwears { get; set; }

    public virtual DbSet<Undergarment> Undergarments { get; set; }

    public virtual DbSet<Uppergarment> Uppergarments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83F1F4C1FBA");

            entity.ToTable("clients");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Dni)
                .HasMaxLength(50)
                .HasColumnName("dni");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Cubicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cubicles__3213E83F972D81B0");

            entity.ToTable("cubicles");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.IdClient)
                .HasMaxLength(50)
                .HasColumnName("id_client");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Cubicles)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cubicles__id_cli__4CA06362");
        });

        modelBuilder.Entity<Footwear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__footwear__3213E83F9661969D");

            entity.ToTable("footwear");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.IdClient)
                .HasMaxLength(50)
                .HasColumnName("id_client");
            entity.Property(e => e.IdCubicle)
                .HasMaxLength(50)
                .HasColumnName("id_cubicle");
            entity.Property(e => e.Kind)
                .HasMaxLength(50)
                .HasColumnName("kind");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.States).HasColumnName("states");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Footwears)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__footwear__id_cli__4F7CD00D");

            entity.HasOne(d => d.IdCubicleNavigation).WithMany(p => p.Footwears)
                .HasForeignKey(d => d.IdCubicle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__footwear__id_cub__5070F446");
        });

        modelBuilder.Entity<Undergarment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__undergar__3213E83F3CFCDB19");

            entity.ToTable("undergarments");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.IdClient)
                .HasMaxLength(50)
                .HasColumnName("id_client");
            entity.Property(e => e.IdCubicle)
                .HasMaxLength(50)
                .HasColumnName("id_cubicle");
            entity.Property(e => e.Kind)
                .HasMaxLength(50)
                .HasColumnName("kind");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.States).HasColumnName("states");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Undergarments)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__undergarm__id_cl__571DF1D5");

            entity.HasOne(d => d.IdCubicleNavigation).WithMany(p => p.Undergarments)
                .HasForeignKey(d => d.IdCubicle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__undergarm__id_cu__5812160E");
        });

        modelBuilder.Entity<Uppergarment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__uppergar__3213E83FBF2CAF80");

            entity.ToTable("uppergarments");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.IdClient)
                .HasMaxLength(50)
                .HasColumnName("id_client");
            entity.Property(e => e.IdCubicle)
                .HasMaxLength(50)
                .HasColumnName("id_cubicle");
            entity.Property(e => e.Kind)
                .HasMaxLength(50)
                .HasColumnName("kind");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.States).HasColumnName("states");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Uppergarments)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uppergarm__id_cl__534D60F1");

            entity.HasOne(d => d.IdCubicleNavigation).WithMany(p => p.Uppergarments)
                .HasForeignKey(d => d.IdCubicle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uppergarm__id_cu__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
