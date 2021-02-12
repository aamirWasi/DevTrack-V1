﻿// <auto-generated />
using System;
using DevTrack.Foundation.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevTrack.TrackerWorkerService.Migrations
{
    [DbContext(typeof(DevTrackContext))]
    [Migration("20210206170038_KeyboardTableInitialized")]
    partial class KeyboardTableInitialized
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("DevTrack.Foundation.Entities.Keyboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("A")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Add")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Apps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("B")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Back")
                        .HasColumnType("INTEGER");

                    b.Property<int>("C")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capital")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D0")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D3")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D4")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D5")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D6")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D7")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D8")
                        .HasColumnType("INTEGER");

                    b.Property<int>("D9")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Decimal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Delete")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Divide")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Down")
                        .HasColumnType("INTEGER");

                    b.Property<int>("E")
                        .HasColumnType("INTEGER");

                    b.Property<int>("End")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Enter")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Escape")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F10")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F11")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F12")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F3")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F4")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F5")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F6")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F7")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F8")
                        .HasColumnType("INTEGER");

                    b.Property<int>("F9")
                        .HasColumnType("INTEGER");

                    b.Property<int>("G")
                        .HasColumnType("INTEGER");

                    b.Property<int>("H")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Home")
                        .HasColumnType("INTEGER");

                    b.Property<int>("I")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Insert")
                        .HasColumnType("INTEGER");

                    b.Property<int>("J")
                        .HasColumnType("INTEGER");

                    b.Property<int>("K")
                        .HasColumnType("INTEGER");

                    b.Property<int>("L")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LControlKey")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LShiftKey")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LWin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Left")
                        .HasColumnType("INTEGER");

                    b.Property<int>("M")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Multiply")
                        .HasColumnType("INTEGER");

                    b.Property<int>("N")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Next")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumLock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad0")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad3")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad4")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad5")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad6")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad7")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad8")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPad9")
                        .HasColumnType("INTEGER");

                    b.Property<int>("O")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oem1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oem5")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oem6")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oem7")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OemMinus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OemOpenBrackets")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OemPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OemQuestion")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oemcomma")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oemplus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oemtilde")
                        .HasColumnType("INTEGER");

                    b.Property<int>("P")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PageUp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pause")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrintScreen")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Q")
                        .HasColumnType("INTEGER");

                    b.Property<int>("R")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RControlKey")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RShiftKey")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RWin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Right")
                        .HasColumnType("INTEGER");

                    b.Property<int>("S")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Scroll")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Space")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Subtract")
                        .HasColumnType("INTEGER");

                    b.Property<int>("T")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tab")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalKeyHits")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Up")
                        .HasColumnType("INTEGER");

                    b.Property<int>("V")
                        .HasColumnType("INTEGER");

                    b.Property<int>("W")
                        .HasColumnType("INTEGER");

                    b.Property<int>("X")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Y")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Z")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Keyboards");
                });

            modelBuilder.Entity("DevTrack.Foundation.Entities.RunningProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RunningApplications")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RunningApplicationsDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RunningPrograms");
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

            modelBuilder.Entity("DevTrack.Foundation.Entities.WebCamCaptureImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WebCamImageDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebCamImagePath")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WebCamCapture");
                });
#pragma warning restore 612, 618
        }
    }
}