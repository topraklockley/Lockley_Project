using Lockley.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) 
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Admin>().HasData(new Admin
            {
                ID = 1,
                FullName = "Toprak Lockley",
                LastLoginDate = DateTime.Now,
                LastLoginIP = "",
                Username = "toprak",
                Password = "e72056c6aa6c53dcf7806d37120ecb07" // lockley in MD5 Hash format
            });

			modelBuilder.Entity<Category>()
                .HasOne(x => x.ParentCategory)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.ParentID);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Brand)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProductPicture>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductPictures);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .OnDelete(DeleteBehavior.Restrict);
		}

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Slide> Slide { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
