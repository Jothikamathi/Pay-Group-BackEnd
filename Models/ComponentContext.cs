using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace payapi.Models;

public partial class ComponentContext : DbContext
{
    public ComponentContext()
    {
    }

    public ComponentContext(DbContextOptions<ComponentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbComponent> TbComponents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    
}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbComponent>(entity =>
        {
            entity.HasKey(e => e.ComponentCode).HasName("PK__tb_compo__898CFBF911C5AA0A");

            entity.ToTable("tb_component");

            entity.Property(e => e.ComponentDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FortNightLimit)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyLimit)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
