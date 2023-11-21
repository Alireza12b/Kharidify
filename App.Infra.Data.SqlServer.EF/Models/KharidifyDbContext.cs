using System;
using System.Collections.Generic;
using System.Reflection;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;
using App.Infra.Data.SqlServer.EF.Configs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.SqlServer.EF.Models;

public partial class KharidifyDbContext : IdentityDbContext<User, IdentityRole<int>,int>
{
    public KharidifyDbContext()
    {
    }

    public KharidifyDbContext(DbContextOptions<KharidifyDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DiscountCode> DiscountCodes { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsPrice> ProductsPrices { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Category> SubCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.AddressDetail).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsPaid).HasColumnName("isPaid");
            entity.Property(e => e.PayDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.PostalCode).HasMaxLength(20);

            entity.HasOne(d => d.City).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Carts_Cities");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });


        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.Message).HasMaxLength(1000);

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Products");
        });


        modelBuilder.Entity<DiscountCode>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(10);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.IsRemoved).HasColumnName("isRemoved");

            entity.HasOne(d => d.Products).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Images_Products");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CartLines");

            entity.HasOne(d => d.Cart).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartLines_Carts");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(400);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsRemoved).HasColumnName("isRemoved");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");

            entity.HasOne(d => d.Shop).WithMany(p => p.Products)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Shop");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_SubCategories");
        });

        modelBuilder.Entity<ProductsPrice>(entity =>
        {
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsPrices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsPrices_ProductsPrices");
        });


        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.AdressDetail).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.ShopName).HasMaxLength(100);

            entity.HasOne(d => d.City).WithMany(p => p.Shops)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shop_Cities");
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
