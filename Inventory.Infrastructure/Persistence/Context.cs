using Inventory.Domain.Common;
using Inventory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Inventory.Infrastructure.Persistence
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<GenericProduct> GenericProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttributeType> ProductAttributeTypes { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ProductInstance> ProductInstances { get; set; }
        public DbSet<ProductLot> ProductLots { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandManufacturer> BrandManufacturers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ProductPriceRecord> ProductPriceRecords { get; set; }
        public DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductUom> ProductUoms { get; set; }
        public DbSet<UomConversion> ProductUomConversions { get; set; }

        //// ----------------------------------------
        //// Global Query Filters (Soft Delete)
        //// ----------------------------------------
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Apply all IEntityTypeConfiguration<T> automatically
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //    // Soft delete global filter (for any BaseEntity)
        //    foreach (var entity in modelBuilder.Model.GetEntityTypes())
        //    {
        //        if (typeof(BaseModel).IsAssignableFrom(entity.ClrType))
        //        {
        //            var parameter = Expression.Parameter(entity.ClrType, "e");
        //            var body = Expression.Equal(
        //                Expression.Property(parameter, nameof(BaseModel.IsDeleted)),
        //                Expression.Constant(false)
        //            );

        //            var lambda = Expression.Lambda(body, parameter);
        //            entity.SetQueryFilter(lambda);
        //        }
        //    }
        //}

        //// ----------------------------------------
        //// Automatic CreatedDate / ModifiedDate
        //// ----------------------------------------
        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var entries = ChangeTracker.Entries<BaseModel>();

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.CreatedDate = DateTime.UtcNow;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Entity.ModifiedDate = DateTime.UtcNow;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -----------------------------
            // 1. Sites & Warehouses
            // -----------------------------
            modelBuilder.Entity<Site>()
                .HasMany(s => s.Warehouses)
                .WithOne(w => w.Site)
                .HasForeignKey(w => w.SiteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.Stock)
                .WithOne(s => s.Warehouse)
                .HasForeignKey(s => s.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // -----------------------------
            // 2. Categories, Groups, Generic Product
            // -----------------------------
            modelBuilder.Entity<ItemCategory>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemGroup>()
                .HasMany(g => g.Products)
                .WithOne(p => p.Group)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GenericProduct>()
                .HasMany(g => g.Products)
                .WithOne(p => p.GenericProduct)
                .HasForeignKey(p => p.GenericId)
                .OnDelete(DeleteBehavior.Restrict);

            // -----------------------------
            // 3. Brand & Manufacturer
            // -----------------------------
            modelBuilder.Entity<BrandManufacturer>()
                .HasMany(m => m.Brands)
                .WithOne(b => b.Manufacturer)
                .HasForeignKey(b => b.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            // -----------------------------
            // 4. Product
            // -----------------------------
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Attributes)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Instances)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Lots)
                .WithOne()
                .HasForeignKey(l => l.ProductAttributeValueId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Stock)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.ProductId);

            // -----------------------------
            // 5. Product Attributes
            // -----------------------------
            modelBuilder.Entity<ProductAttributeType>()
                .HasMany(t => t.ProductAttributes)
                .WithOne(a => a.AttributeType)
                .HasForeignKey(a => a.AttributeTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductAttribute>()
                .HasMany(a => a.Values)
                .WithOne(v => v.ProductAttribute)
                .HasForeignKey(v => v.ProductAttributeId);

            // -----------------------------
            // 6. Product Instances
            // -----------------------------
            modelBuilder.Entity<ProductInstance>()
                .HasOne(i => i.Brand)
                .WithMany()
                .HasForeignKey(i => i.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductInstance>()
                .HasOne(i => i.Stock)
                .WithMany()
                .HasForeignKey(i => i.StockId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProductInstance>()
                .HasOne(i => i.Lot)
                .WithMany()
                .HasForeignKey(i => i.LotId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProductInstance>()
                .HasOne(i => i.AttributeValue)
                .WithMany()
                .HasForeignKey(i => i.ProductAttributeValueId)
                .OnDelete(DeleteBehavior.SetNull);

            // -----------------------------
            // 7. Product Lot
            // -----------------------------
            modelBuilder.Entity<ProductLot>()
                .HasOne(l => l.AttributeValue)
                .WithMany()
                .HasForeignKey(l => l.ProductAttributeValueId)
                .OnDelete(DeleteBehavior.SetNull);

            // -----------------------------
            // 8. Stock
            // -----------------------------
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Stock)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.SetNull);


            // -----------------------------
            // 9. Product Price Records
            // -----------------------------
            modelBuilder.Entity<ProductPriceRecord>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // -----------------------------
            // 10. Purchase Orders
            // -----------------------------
            modelBuilder.Entity<PurchaseOrderHeader>()
                .HasMany(h => h.Lines)
                .WithOne(l => l.Header)
                .HasForeignKey(l => l.PurchaseOrderHeaderId);

            modelBuilder.Entity<PurchaseOrderHeader>()
                .HasOne(h => h.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(h => h.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrderLine>()
                .HasOne(l => l.Product)
                .WithMany()
                .HasForeignKey(l => l.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // -----------------------------
            // 11. UOM & Conversions
            // -----------------------------
            modelBuilder.Entity<ProductUom>()
                .HasMany(u => u.FromConversions)
                .WithOne(c => c.FromUom)
                .HasForeignKey(c => c.FromUomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductUom>()
                .HasMany(u => u.ToConversions)
                .WithOne(c => c.ToUom)
                .HasForeignKey(c => c.ToUomId)
                .OnDelete(DeleteBehavior.Restrict);
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                    {
                        property.SetPrecision(18);
                        property.SetScale(4);
                    }

        }

    }
}
