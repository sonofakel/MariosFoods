using System;
using Microsoft.EntityFrameworkCore;


namespace MariosFoods.Models

{
    public class MariosFoodsContext : DbContext
    {
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
           .UseMySql(@"Server=localhost;Port=8889;database=mariosfoods;uid=root;pwd=root;");

    }
}

