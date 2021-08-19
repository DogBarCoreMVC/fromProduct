using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace fromProduct.Models.DB
{
    public partial class WareHouseDBContext : DbContext
    {
        public WareHouseDBContext()
        {
        }

        public WareHouseDBContext(DbContextOptions<WareHouseDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriesTbl> CategoriesTbls { get; set; }
        public virtual DbSet<ProductsTbl> ProductsTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DOGBARPC;Database=WareHouseDB;User Id=Porawit;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<CategoriesTbl>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A2B11B476AE");

                entity.ToTable("CategoriesTbl");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<ProductsTbl>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6EDB9795B1C");

                entity.ToTable("ProductsTbl");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductsTbls)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ProductsTbl_CategoriesTbl");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
