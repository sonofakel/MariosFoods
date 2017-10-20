using Microsoft.EntityFrameworkCore;
using MariosFoods.Models;

namespace MariosFoods.Models
{
    public class TestDbContext : MariosFoodsContext
    {
        public override DbSet<Review> Reviews { get; set; }
        public override DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=mariosfoods_test;uid=root;pwd=root;");
        }
    }
}