﻿// <auto-generated />
using System;
using DevTrack.Foundation.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevTrack.Web.Data
{
    [DbContext(typeof(DevTrackWebContext))]
    partial class DevTrackWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevTrack.Foundation.Entities.ActiveProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProgramTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ActivePrograms");
                });

            modelBuilder.Entity("DevTrack.Foundation.Entities.Keyboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("A")
                        .HasColumnType("int");

                    b.Property<int>("Add")
                        .HasColumnType("int");

                    b.Property<int>("Apps")
                        .HasColumnType("int");

                    b.Property<int>("B")
                        .HasColumnType("int");

                    b.Property<int>("Back")
                        .HasColumnType("int");

                    b.Property<int>("C")
                        .HasColumnType("int");

                    b.Property<int>("Capital")
                        .HasColumnType("int");

                    b.Property<int>("D")
                        .HasColumnType("int");

                    b.Property<int>("D0")
                        .HasColumnType("int");

                    b.Property<int>("D1")
                        .HasColumnType("int");

                    b.Property<int>("D2")
                        .HasColumnType("int");

                    b.Property<int>("D3")
                        .HasColumnType("int");

                    b.Property<int>("D4")
                        .HasColumnType("int");

                    b.Property<int>("D5")
                        .HasColumnType("int");

                    b.Property<int>("D6")
                        .HasColumnType("int");

                    b.Property<int>("D7")
                        .HasColumnType("int");

                    b.Property<int>("D8")
                        .HasColumnType("int");

                    b.Property<int>("D9")
                        .HasColumnType("int");

                    b.Property<int>("Decimal")
                        .HasColumnType("int");

                    b.Property<int>("Delete")
                        .HasColumnType("int");

                    b.Property<int>("Divide")
                        .HasColumnType("int");

                    b.Property<int>("Down")
                        .HasColumnType("int");

                    b.Property<int>("E")
                        .HasColumnType("int");

                    b.Property<int>("End")
                        .HasColumnType("int");

                    b.Property<int>("Enter")
                        .HasColumnType("int");

                    b.Property<int>("Escape")
                        .HasColumnType("int");

                    b.Property<int>("F")
                        .HasColumnType("int");

                    b.Property<int>("F1")
                        .HasColumnType("int");

                    b.Property<int>("F10")
                        .HasColumnType("int");

                    b.Property<int>("F11")
                        .HasColumnType("int");

                    b.Property<int>("F12")
                        .HasColumnType("int");

                    b.Property<int>("F2")
                        .HasColumnType("int");

                    b.Property<int>("F3")
                        .HasColumnType("int");

                    b.Property<int>("F4")
                        .HasColumnType("int");

                    b.Property<int>("F5")
                        .HasColumnType("int");

                    b.Property<int>("F6")
                        .HasColumnType("int");

                    b.Property<int>("F7")
                        .HasColumnType("int");

                    b.Property<int>("F8")
                        .HasColumnType("int");

                    b.Property<int>("F9")
                        .HasColumnType("int");

                    b.Property<int>("G")
                        .HasColumnType("int");

                    b.Property<int>("H")
                        .HasColumnType("int");

                    b.Property<int>("Home")
                        .HasColumnType("int");

                    b.Property<int>("I")
                        .HasColumnType("int");

                    b.Property<int>("Insert")
                        .HasColumnType("int");

                    b.Property<int>("J")
                        .HasColumnType("int");

                    b.Property<int>("K")
                        .HasColumnType("int");

                    b.Property<int>("L")
                        .HasColumnType("int");

                    b.Property<int>("LControlKey")
                        .HasColumnType("int");

                    b.Property<int>("LShiftKey")
                        .HasColumnType("int");

                    b.Property<int>("LWin")
                        .HasColumnType("int");

                    b.Property<int>("Left")
                        .HasColumnType("int");

                    b.Property<int>("M")
                        .HasColumnType("int");

                    b.Property<int>("Multiply")
                        .HasColumnType("int");

                    b.Property<int>("N")
                        .HasColumnType("int");

                    b.Property<int>("Next")
                        .HasColumnType("int");

                    b.Property<int>("NumLock")
                        .HasColumnType("int");

                    b.Property<int>("NumPad0")
                        .HasColumnType("int");

                    b.Property<int>("NumPad1")
                        .HasColumnType("int");

                    b.Property<int>("NumPad2")
                        .HasColumnType("int");

                    b.Property<int>("NumPad3")
                        .HasColumnType("int");

                    b.Property<int>("NumPad4")
                        .HasColumnType("int");

                    b.Property<int>("NumPad5")
                        .HasColumnType("int");

                    b.Property<int>("NumPad6")
                        .HasColumnType("int");

                    b.Property<int>("NumPad7")
                        .HasColumnType("int");

                    b.Property<int>("NumPad8")
                        .HasColumnType("int");

                    b.Property<int>("NumPad9")
                        .HasColumnType("int");

                    b.Property<int>("O")
                        .HasColumnType("int");

                    b.Property<int>("Oem1")
                        .HasColumnType("int");

                    b.Property<int>("Oem5")
                        .HasColumnType("int");

                    b.Property<int>("Oem6")
                        .HasColumnType("int");

                    b.Property<int>("Oem7")
                        .HasColumnType("int");

                    b.Property<int>("OemMinus")
                        .HasColumnType("int");

                    b.Property<int>("OemOpenBrackets")
                        .HasColumnType("int");

                    b.Property<int>("OemPeriod")
                        .HasColumnType("int");

                    b.Property<int>("OemQuestion")
                        .HasColumnType("int");

                    b.Property<int>("Oemcomma")
                        .HasColumnType("int");

                    b.Property<int>("Oemplus")
                        .HasColumnType("int");

                    b.Property<int>("Oemtilde")
                        .HasColumnType("int");

                    b.Property<int>("P")
                        .HasColumnType("int");

                    b.Property<int>("PageUp")
                        .HasColumnType("int");

                    b.Property<int>("Pause")
                        .HasColumnType("int");

                    b.Property<int>("PrintScreen")
                        .HasColumnType("int");

                    b.Property<int>("Q")
                        .HasColumnType("int");

                    b.Property<int>("R")
                        .HasColumnType("int");

                    b.Property<int>("RControlKey")
                        .HasColumnType("int");

                    b.Property<int>("RShiftKey")
                        .HasColumnType("int");

                    b.Property<int>("RWin")
                        .HasColumnType("int");

                    b.Property<int>("Right")
                        .HasColumnType("int");

                    b.Property<int>("S")
                        .HasColumnType("int");

                    b.Property<int>("Scroll")
                        .HasColumnType("int");

                    b.Property<int>("Space")
                        .HasColumnType("int");

                    b.Property<int>("Subtract")
                        .HasColumnType("int");

                    b.Property<int>("T")
                        .HasColumnType("int");

                    b.Property<int>("Tab")
                        .HasColumnType("int");

                    b.Property<int>("TotalKeyHits")
                        .HasColumnType("int");

                    b.Property<int>("U")
                        .HasColumnType("int");

                    b.Property<int>("Up")
                        .HasColumnType("int");

                    b.Property<int>("V")
                        .HasColumnType("int");

                    b.Property<int>("W")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.Property<int>("Z")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Keyboards");
                });

            modelBuilder.Entity("DevTrack.Foundation.Entities.Mouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeftButtonClick")
                        .HasColumnType("int");

                    b.Property<int>("LeftButtonDoubleClick")
                        .HasColumnType("int");

                    b.Property<int>("MiddleButtonClick")
                        .HasColumnType("int");

                    b.Property<int>("MiddleButtonDoubleClick")
                        .HasColumnType("int");

                    b.Property<int>("MouseWheel")
                        .HasColumnType("int");

                    b.Property<int>("RightButtonClick")
                        .HasColumnType("int");

                    b.Property<int>("RightButtonDoubleClick")
                        .HasColumnType("int");

                    b.Property<int>("TotalClicks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mouses");
                });

            modelBuilder.Entity("DevTrack.Foundation.Entities.RunningProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RunningApplications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RunningApplicationsDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RunningPrograms");
                });

            modelBuilder.Entity("DevTrack.Foundation.Entities.SnapshotImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CaptureTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SnapshotImages");
                });

            modelBuilder.Entity("DevTrack.Foundation.Entities.WebCamCaptureImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("WebCamImageDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("WebCamImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebCamCaptureImages");
                });
#pragma warning restore 612, 618
        }
    }
}
