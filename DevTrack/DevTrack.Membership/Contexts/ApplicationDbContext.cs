using DevTrack.Membership.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Membership.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
            //    new ApplicationRole { Id = Guid.NewGuid(), Name = "Trainer", NormalizedName = "TRAINER" },
            //    new ApplicationRole { Id = Guid.NewGuid(), Name = "Student", NormalizedName = "STUDENT" });

            modelBuilder.Entity<ApplicationRole>()
                .HasData(new DataSeed().ApplicationRoles);

            base.OnModelCreating(modelBuilder);
        }
    }
}
