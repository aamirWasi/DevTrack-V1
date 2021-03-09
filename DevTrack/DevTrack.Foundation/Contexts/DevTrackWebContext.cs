using DevTrack.Foundation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Contexts
{
    public class DevTrackWebContext : DbContext, IDevTrackWebContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public DevTrackWebContext(string connectionString, string migrationAssemblyName)
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

        public DbSet<ActiveProgram> ActivePrograms { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<Mouse> Mouses { get; set; }
        public DbSet<RunningProgram> RunningPrograms { get; set; }
        public DbSet<SnapshotImage> SnapshotImages { get; set; }
        public DbSet<WebCamCaptureImage> WebCamCaptureImages { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Settings> Settings { get; set; }
        //public DbSet<TeamMember> TeamMembers { get; set; }
    }
}
