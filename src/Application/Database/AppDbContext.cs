using System;
using Microsoft.EntityFrameworkCore;
using Vilnius1.Application.Models;
using Task = System.Threading.Tasks.Task;

namespace Vilnius1.Application.Database;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<FacilityAssignment> FacilityAssignments { get; set; }

    public virtual DbSet<FacilityAssignmentLog> FacilityAssignmentLogs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.ToTable("assignments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.ToTable("facilities");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<FacilityAssignment>(entity =>
        {
            entity.ToTable("facility-assignments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AssignmentId).HasColumnName("assignment-id");
            entity.Property(e => e.FacilityId).HasColumnName("facility-id");

            entity.HasOne(d => d.Assignment).WithMany(p => p.FacilityAssignments)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Facility).WithMany(p => p.FacilityAssignments)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FacilityAssignmentLog>(entity =>
        {
            entity.ToTable("facility-assignment-log");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AssignmentId).HasColumnName("assignment-id");
            entity.Property(e => e.FacilityId).HasColumnName("facility-id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Assignment).WithMany(p => p.FacilityAssignmentLogs)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Facility).WithMany(p => p.FacilityAssignmentLogs)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
