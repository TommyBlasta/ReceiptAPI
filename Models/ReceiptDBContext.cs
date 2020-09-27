using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReceiptAPI.Models
{
    public partial class ReceiptDBContext : DbContext
    {
        public ReceiptDBContext()
        {
        }

        public ReceiptDBContext(DbContextOptions<ReceiptDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductToReceipt> ProductToReceipt { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=C:\\\\Users\\\\Eliss\\\\source\\\\repos\\\\ReceiptAPI\\ReceiptDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BasePrice)
                    .IsRequired()
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProductToReceipt>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.ProductToReceipt)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ReceiptNavigation)
                    .WithMany(p => p.ProductToReceipt)
                    .HasForeignKey(d => d.Receipt)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateOfPurchase).IsRequired();

                entity.HasOne(d => d.SellerNavigation)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.Seller)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
