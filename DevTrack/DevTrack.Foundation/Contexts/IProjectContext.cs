﻿using DevTrack.Foundation.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Foundation.Contexts
{
    public interface IProjectContext
    {
        DbSet<Project> Project { get; set; }
        DbSet<TeamMember> TeamMembers { get; set; }
        DbSet<Settings> Settings { get; set; }
    }
}