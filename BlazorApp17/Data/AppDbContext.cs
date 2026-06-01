using BlazorApp17.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlazorApp17.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserData> UserData { get; set; }
    }
}