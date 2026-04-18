#nullable disable
using System;
using CKFS_Management.Entities.VinhHNT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CKFS_Management.Repositories.VinhHNT.DBContext;

public class CKFS_ManagementContext : DbContext
{
    public CKFS_ManagementContext()
    {
    }

    public CKFS_ManagementContext(DbContextOptions<CKFS_ManagementContext> options)
        : base(options)
    {
    }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        return config.GetConnectionString(connectionStringName) ?? "";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<UserAccount> UserAccounts { get; set; }
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<ProductTaiLd> ProductsTaiLd { get; set; }
    public virtual DbSet<RecipeVinhHnt> RecipesVinhHnt { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");
            entity.HasKey(e => e.RoleId);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.ToTable("UserAccounts");
            entity.HasKey(e => e.UserAccountId);
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.UserName).HasColumnName("UserName");
            entity.Property(e => e.Password).HasColumnName("Password");
            entity.Property(e => e.FullName).HasColumnName("FullName");
            entity.Property(e => e.Email).HasColumnName("Email");
            entity.Property(e => e.Phone).HasColumnName("Phone");
            entity.Property(e => e.EmployeeCode).HasColumnName("EmployeeCode");
            entity.Property(e => e.RoleId).HasColumnName("RoleId");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.BusinessRole).HasColumnName("BusinessRole");
            entity.Property(e => e.IsActive).HasColumnName("IsActive");
            entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
            entity.Property(e => e.ModifiedDate).HasColumnName("ModifiedDate");
            entity.HasOne(d => d.Role).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserAccounts_roles");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("product_categories");
            entity.HasKey(e => e.CategoryId);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Code).HasColumnName("code").IsRequired(false);
            entity.Property(e => e.Name).HasColumnName("name").IsRequired(false);
            entity.Property(e => e.ParentId).HasColumnName("parent_id").IsRequired(false);
            entity.Property(e => e.Status).HasColumnName("status").IsRequired(false);
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").IsRequired(false);
            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .IsRequired(false)
                .HasConstraintName("FK_product_categories_parent");
        });

        modelBuilder.Entity<ProductTaiLd>(entity =>
        {
            entity.ToTable("products_TaiLD");
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Code).HasColumnName("code").IsRequired(false);
            entity.Property(e => e.Name).HasColumnName("name").IsRequired(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID").IsRequired(false);
            entity.Property(e => e.ProductType).HasColumnName("product_type").IsRequired(false);
            entity.Property(e => e.BaseUnit).HasColumnName("base_unit").IsRequired(false);
            entity.Property(e => e.StandardCost).HasColumnName("standard_cost").IsRequired(false);
            entity.Property(e => e.Status).HasColumnName("status").IsRequired(false);
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").IsRequired(false);
            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .IsRequired(false)
                .HasConstraintName("FK_products_TaiLD_category");
        });

        modelBuilder.Entity<RecipeVinhHnt>(entity =>
        {
            entity.ToTable("recipes_VinhHNT");
            entity.HasKey(e => e.RecipeId);
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID").IsRequired(false);
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID").IsRequired(false);
            entity.Property(e => e.Quantity).HasColumnName("quantity").IsRequired(false);
            entity.Property(e => e.Unit).HasColumnName("unit").IsRequired(false);
            entity.Property(e => e.Version).HasColumnName("version").IsRequired(false);
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").IsRequired(false);
            entity.HasOne(d => d.Product).WithMany(p => p.RecipesAsProduct)
                .HasForeignKey(d => d.ProductId)
                .IsRequired(false)
                .HasConstraintName("FK_recipes_Product");
            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipesAsIngredient)
                .HasForeignKey(d => d.IngredientId)
                .IsRequired(false)
                .HasConstraintName("FK_recipes_Ingredient");
        });
    }
}
