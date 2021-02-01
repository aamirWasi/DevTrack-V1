﻿// <auto-generated />
using System;
using DevTrack.Foundation.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevTrack.TrackerWorkerService.Migrations
{
    [DbContext(typeof(DevTrackContext))]
    partial class DevTrackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11");

            modelBuilder.Entity("DevTrack.Foundation.Entities.ActiveProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProgramName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProgramTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ActivePrograms");
                });

            modelBuilder.Entity("DevTrack.Foundation.Entities.SnapshotImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CaptureTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SnapshotImages");
                });
#pragma warning restore 612, 618
        }
    }
}
