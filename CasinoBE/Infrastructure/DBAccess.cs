using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;
using System.IO;

namespace Infrastructure
{
    public class DBAccess: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"))
                .Build();

            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"));
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CrashLog> Crash_Log { get; set; }
    }
}
