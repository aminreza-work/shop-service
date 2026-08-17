using Microsoft.EntityFrameworkCore;
using ShopService.Entities;
using ShopService.Entities.Configs;

namespace ShopService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Shop> Shops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new InvoiceItemConfig());


            //#region Product Configuration

            //modelBuilder
            //    .Entity<Product>()
            //    .Property(p => p.Title)
            //    .HasMaxLength(100)
            //    .IsRequired();

            //#endregion
            
            // Seed 

            // Cascade Delete

        }

    }
}
