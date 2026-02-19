using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission6Assignment.Models;

public partial class FormContext : DbContext
{
    public FormContext()
    {
    }

    public FormContext(DbContextOptions<FormContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=JoelHiltonMovieCollection.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Movies).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
