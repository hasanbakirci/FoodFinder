using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Context
{
    public class FoodApplicationDbContext : DbContext
    {
        public FoodApplicationDbContext(DbContextOptions<FoodApplicationDbContext> options) : base(options){}
        public DbSet<Category> categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Food> foods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<Comment>().Property(c => c.Text).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.Nickname).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Comment>().Property(c => c.Email).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Comment>().Property(c => c.FoodId).IsRequired();

            modelBuilder.Entity<Food>().Property(f => f.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Food>().Property(f => f.Recipe).IsRequired();
            modelBuilder.Entity<Food>().Property(f => f.Ingredients).IsRequired();
            modelBuilder.Entity<Food>().Property(f => f.CategoryId).IsRequired();
            modelBuilder.Entity<Food>().Property(f => f.ImageUrl).IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            base.OnConfiguring(optionsBuilder);
        }
    }
}