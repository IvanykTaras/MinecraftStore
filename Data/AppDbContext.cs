using Microsoft.EntityFrameworkCore;
using MinecraftStore.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MinecraftStore.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}


