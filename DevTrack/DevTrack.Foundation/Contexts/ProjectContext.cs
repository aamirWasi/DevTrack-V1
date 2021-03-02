using DevTrack.Foundation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Contexts
{
    public class ProjectContext : DbContext, IProjectContext
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Settings> Settings { get; set; }

        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ProjectContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
