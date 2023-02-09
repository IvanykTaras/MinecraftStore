using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinecraftStore.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace MinecraftStore.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}


