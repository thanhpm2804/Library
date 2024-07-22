using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Library.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BorrowRecord> BorrowRecords { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ReservationRecord> ReservationRecords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MylibraryDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C22781A88C67");

            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BorrowRecord>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.BookId }).HasName("PK__BorrowRe__7456C08E25384067");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.IsReturned).HasColumnName("isReturned");

            entity.HasOne(d => d.Book).WithMany(p => p.BorrowRecords)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BorrowRec__BookI__3D5E1FD2");

            entity.HasOne(d => d.User).WithMany(p => p.BorrowRecords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BorrowRec__UserI__3C69FB99");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.BookId }).HasName("PK__Comments__7456C08E80209F48");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Book).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__BookID__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__UserID__44FF419A");
        });

        modelBuilder.Entity<ReservationRecord>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.BookId }).HasName("PK__Reservat__7456C08E183CE62B");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.BookId).HasColumnName("BookID");

            entity.HasOne(d => d.Book).WithMany(p => p.ReservationRecords)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__BookI__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.ReservationRecords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__UserI__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC3A85CEC7");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534E03B1599").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Password)
                .HasMaxLength(26)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
