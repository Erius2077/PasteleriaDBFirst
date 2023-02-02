using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PasteleriaDBFirst.Models;

public partial class PasteleriaContext : DbContext
{
    public PasteleriaContext()
    {
    }

    public PasteleriaContext(DbContextOptions<PasteleriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendary> Calendario { get; set; }

    public virtual DbSet<CakeTime> CakeTime { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<UserRole> UserRole { get; set; }

    public virtual DbSet<Cake> Cakes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CALENDAR__3214EC277AF5644D");

            entity.ToTable("CALENDARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("DATE");
            entity.Property(e => e.Idcalendary).HasColumnName("IDCALENDARY");

            entity.HasOne(d => d.IdcalendaryNavigation).WithMany(p => p.Calendary)
                .HasForeignKey(d => d.IdCalendary)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CALENDARI__IDHOR__300424B4");
        });

        modelBuilder.Entity<CakeTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CAKE__3214EC27BB14FFD7");

            entity.ToTable("CAKETIME");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Calendary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CALENDARY");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Idreservation).HasName("PK__RESERVAC__E18E99FBB05EACD0");

            entity.ToTable("RESERVATION");

            entity.Property(e => e.Idreservation).HasColumnName("IDRESERVATION");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("DATE");
            entity.Property(e => e.Idtratamiento).HasColumnName("IDCAKE");
            entity.Property(e => e.Idclient).HasColumnName("IDCLIENT");
            entity.Property(e => e.Total).HasColumnName("TOTAL");
            entity.Property(e => e.Cake)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CAKE");
            entity.Property(e => e.Client)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLIENT");

            entity.HasOne(d => d.IdCakeNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Idcake)
                .HasConstraintName("FK__RESERVATI__IDTRA__33D4B598");

            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Idclient)
                .HasConstraintName("FK__RESERVATI__IDUSU__32E0915F");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.IdUserRole).HasName("PK__IDUSE__ECE2CF389C0D9383");

            entity.ToTable("USERROLE");

            entity.Property(e => e.IdUserRole).HasColumnName("IdUserRole");
            entity.Property(e => e.IdUserRole1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("IDUSERROLE");
        });

        modelBuilder.Entity<Cake>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cak__3214EC277EF3CA05");

            entity.ToTable("CAKE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Precio).HasColumnName("PRICE");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Idclient).HasName("PK__CLIENT__B6D90A2A578D82F8");

            entity.ToTable("CLIENT");

            entity.Property(e => e.Id).HasColumnName("IDCLIENT");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.IdUserRole).HasColumnName("IDUSERROLE");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Clientimage)
                .IsUnicode(false)
                .HasColumnName("CLIENTIMAGE");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.IdUserRoleNavigation).WithMany(p => p.Client)
                .HasForeignKey(d => d.IdUserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CLIENT__CODIGOT__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
