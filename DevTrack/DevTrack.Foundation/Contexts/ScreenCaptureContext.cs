using DevTrack.Foundation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.Contexts
{
    public class ScreenCaptureContext : DbContext
    {
        public DbSet<SnapshotImage> SnapshotImages { get; set; }

        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ScreenCaptureContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_migrationAssemblyName));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
