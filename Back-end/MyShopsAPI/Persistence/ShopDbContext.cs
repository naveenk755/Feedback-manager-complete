using Microsoft.EntityFrameworkCore;
using MyShopsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopsAPI.Persistence
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Store> Shops { get; set; }
        public DbSet<Feedback> FeedBacks { get; set; }
    }
}
