using Ecommerce.ShoppingCart.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.ShoppingCart.Core
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public ShoppingCartContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
