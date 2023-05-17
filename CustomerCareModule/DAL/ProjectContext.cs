using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerCareModule.DAL;

public partial class ProjectContext : DbContext
{
    public ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StatusMaster> StatusMasters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=CustomerCareDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Complain__3214EC07FD85427E");

            entity.Property(e => e.DateOfAction).HasColumnType("datetime");
            entity.Property(e => e.DateOfRegistration).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Status).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Complaint__Statu__4BAC3F29");

            entity.HasOne(d => d.User).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Complaint__UserI__4CA06362");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0788F341BD");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusMa__3214EC0758FE6972");

            entity.ToTable("StatusMaster");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B9B2F522");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
