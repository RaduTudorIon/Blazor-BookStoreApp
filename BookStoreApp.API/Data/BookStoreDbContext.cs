using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07D9BFC0FE");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC075CD854E2");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAADC568B0").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "25b8e858-91e3-4921-8055-f332fd22592e", Name = "User", NormalizedName = "USER" },
            new IdentityRole { Id = "4463133f-1e6c-47db-b81d-b8a1cc2b133f", Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
        );

        var hasher = new PasswordHasher<ApiUser>();
        
        modelBuilder.Entity<ApiUser>().HasData(
           new ApiUser
           {
               Id = "77ff77b0-e059-467f-9239-673baacfcba7",
               Email = "admin@bookstore.com",
               NormalizedEmail = "ADMIN@BOOKSTORE.COM",
               UserName = "admin@bookstore.com",
               NormalizedUserName = "ADMIN@BOOKSTORE.COM",
               FirstName = "Allen",
               LastName = "Carsley",
               PasswordHash = hasher.HashPassword(null, "password")
           },
           new ApiUser
           {
               Id = "2c6233b0-748f-48bf-a0a3-32b75ad6633a",
               Email = "user@bookstore.com",
               NormalizedEmail = "USER@BOOKSTORE.COM",
               UserName = "user@bookstore.com",
               NormalizedUserName = "USER@BOOKSTORE.COM",
               FirstName = "Charles",
               LastName = "Bigsby",
               PasswordHash = hasher.HashPassword(null, "password")
           }
       );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        new IdentityUserRole<string>
        {
            RoleId = "25b8e858-91e3-4921-8055-f332fd22592e",
            UserId = "2c6233b0-748f-48bf-a0a3-32b75ad6633a"
        },
        new IdentityUserRole<string>
        {
            RoleId = "4463133f-1e6c-47db-b81d-b8a1cc2b133f",
            UserId = "77ff77b0-e059-467f-9239-673baacfcba7"
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
