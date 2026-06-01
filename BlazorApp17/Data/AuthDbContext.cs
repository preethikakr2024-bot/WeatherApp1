using BlazorApp17.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlazorApp17.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}