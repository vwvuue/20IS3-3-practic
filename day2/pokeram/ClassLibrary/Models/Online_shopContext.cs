using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary.Models
{
    public partial class Online_shopContext : DbContext
    {
        public Online_shopContext()
        {
        }

        public Online_shopContext(DbContextOptions<Online_shopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<SpecForProduct> SpecForProducts { get; set; } = null!;
        public virtual DbSet<Specification> Specifications { get; set; } = null!;
        public virtual DbSet<Specification1> Specification1s { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Online_shop;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId)
                    .ValueGeneratedNever()
                    .HasColumnName("cart_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProdCount).HasColumnName("prod_count");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_User");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.ProdCount).HasColumnName("prod_count");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Product");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Product__56958AB278768201");

                entity.ToTable("Product");

                entity.Property(e => e.ProdId)
                    .ValueGeneratedNever()
                    .HasColumnName("prod_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ProdCount).HasColumnName("Prod_count");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(100)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdPrice)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("prod_price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Product_category");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Product___D54EE9B438C2FCB4");

                entity.ToTable("Product_category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.IdSpecification).HasColumnName("id_specification");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProdCategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("prod_category_name");
            });

            modelBuilder.Entity<SpecForProduct>(entity =>
            {
                entity.HasKey(e => e.SpecProductId)
                    .HasName("PK__Spec_for__A1DB794A2C2A82BA");

                entity.ToTable("Spec_for_products");

                entity.Property(e => e.SpecProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("spec_product_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.SpecId).HasColumnName("spec_id");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.SpecForProducts)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Spec_for_products_Product");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecForProducts)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Spec_for_products_Specification1");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.SpecId)
                    .HasName("PK__Specific__F670C5677B7B022B");

                entity.ToTable("Specification");

                entity.Property(e => e.SpecId)
                    .ValueGeneratedNever()
                    .HasColumnName("spec_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.SpecName)
                    .HasMaxLength(50)
                    .HasColumnName("spec_name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Specification1>(entity =>
            {
                entity.HasKey(e => e.SpecId);

                entity.ToTable("Specification1");

                entity.Property(e => e.SpecId)
                    .ValueGeneratedNever()
                    .HasColumnName("spec_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.SpecName)
                    .HasMaxLength(100)
                    .HasColumnName("spec_name")
                    .IsFixedLength();

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Specification1s)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Specification1_Product_category");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("status_id");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.OrdersStatus).HasColumnName("Orders_status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Addres)
                    .HasMaxLength(1)
                    .HasColumnName("addres");

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .HasColumnName("email");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Login)
                    .HasMaxLength(40)
                    .HasColumnName("login");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(40)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_User_role");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__User_rol__760965CC90F77C65");

                entity.ToTable("User_role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(40)
                    .HasColumnName("role_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
