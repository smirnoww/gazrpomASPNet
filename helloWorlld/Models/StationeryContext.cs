﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace helloWorlld.Models
{
    public partial class StationeryContext : DbContext
    {
        public StationeryContext()
        {
        }

        public StationeryContext(DbContextOptions<StationeryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SprProduct> SprProduct { get; set; }
        public virtual DbSet<SprUser> SprUser { get; set; }
        public virtual DbSet<UserProductRequest> UserProductRequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=WSCLASS05STUD08;Database=Stationery;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SprProduct>(entity =>
            {
                entity.ToTable("sprProduct");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<SprUser>(entity =>
            {
                entity.ToTable("sprUser");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(64);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(64);

            });

            modelBuilder.Entity<UserProductRequest>(entity =>
            {
                entity.Property(e => e.ProductAmount).HasColumnName("productAmount");
                entity.Property(e => e.ProductId).HasColumnName("productId");
                entity.Property(e => e.UserId).HasColumnName("userId");
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserProductRequest)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProductRequest_sprProduct");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProductRequest)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProductRequest_sprUser");
            });
        }
    }
}
