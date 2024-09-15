using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopingApi.Models;
using System.Collections.Generic;

namespace ShopingApi.Data
{
    public class Db_Context : IdentityDbContext<AppUser>
    {
        public Db_Context(DbContextOptions<Db_Context> option) : base(option)
        {

        }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Color> Colors { get;set; }
        public DbSet<Item> Items { get;set; }
        public DbSet<Size> Sizes { get;set; }
        public DbSet<ItemColors> ItemColors { get;set; }
        public DbSet<ItemSizes> ItemSizes { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite key for ItemColors
            modelBuilder.Entity<ItemColors>()
                .HasKey(ic => new { ic.ColorId, ic.ItemID });

            // Configure relationships
            modelBuilder.Entity<ItemColors>()
                .HasOne(ic => ic.Item)
                .WithMany(i => i.Colors)
                .HasForeignKey(ic => ic.ItemID);

            modelBuilder.Entity<ItemColors>()
                .HasOne(ic => ic.Color)
                .WithMany(c => c.ItemColors)
                .HasForeignKey(ic => ic.ColorId);

            base.OnModelCreating(modelBuilder);
        }

    }
}