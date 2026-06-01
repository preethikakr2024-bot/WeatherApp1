using BlazorApp18.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlazorApp18.Data
{
    public class UserDataDbContext : DbContext
    {
        public UserDataDbContext(DbContextOptions<UserDataDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserPreference> UserPreferences { get; set; }
    }
}