using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;
using System.IO;

namespace Infrastructure
{
    public class DBAccess: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CrashLog> Crash_Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"))
                .Build();

            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>();
            builder.Entity<CrashLog>();

            base.OnModelCreating(builder);
        }
    }
}
