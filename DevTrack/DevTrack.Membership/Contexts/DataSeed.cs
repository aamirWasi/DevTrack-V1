using DevTrack.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Membership.Contexts
{
    internal class DataSeed
    {
        internal ApplicationRole[] ApplicationRoles
        {
            get
            {
                return new ApplicationRole[]
                {
                    new ApplicationRole { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
                    new ApplicationRole { Id = Guid.NewGuid(), Name = "Trainer", NormalizedName = "TRAINER" },
                    new ApplicationRole { Id = Guid.NewGuid(), Name = "Student", NormalizedName = "STUDENT" }
                };
            }
        }
    }
}
