using DevTrack.Foundation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Contexts
{
    public interface IDevTrackWebContext
    {
        DbSet<ActiveProgram> ActivePrograms { get; set; }
        DbSet<Keyboard> Keyboards { get; set; }
        DbSet<Mouse> Mouses { get; set; }
        DbSet<RunningProgram> RunningPrograms { get; set; }
        DbSet<SnapshotImage> SnapshotImages { get; set; }
        DbSet<WebCamCaptureImage> WebCamCaptureImages { get; set; }
        DbSet<Project> Project { get; set; }
        DbSet<Settings> Settings { get; set; }
        //DbSet<TeamMember> TeamMembers { get; set; }
    }
}
