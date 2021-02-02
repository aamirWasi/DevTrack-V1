﻿using DevTrack.Foundation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevTrack.Foundation.Contexts
{
    public class DevTrackContext : DbContext
    {
        public DbSet<SnapshotImage> SnapshotImages { get; set; }
        public DbSet<WebCamCaptureEntity> WebCamCapture { get; set; }

        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public DevTrackContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(ConnectionString(), m => m.MigrationsAssembly("DevTrack.TrackerWorkerService"));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        private static string ConnectionString()
        {
            var connection = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();
            return connection.GetConnectionString("SqliteConnection");
        }
    }
}
