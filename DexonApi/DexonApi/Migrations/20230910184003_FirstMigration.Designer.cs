﻿// <auto-generated />
using System;
using DexonApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DexonApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230910184003_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DexonApi.Models.Cml", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("ActualOutsideDiameter")
                        .HasColumnType("float");

                    b.Property<string>("CmlDescription")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("CmlNumber")
                        .HasColumnType("int");

                    b.Property<double>("DesignThickness")
                        .HasColumnType("float");

                    b.Property<int>("InfoId")
                        .HasColumnType("int");

                    b.Property<string>("LineNumber")
                        .HasColumnType("varchar(250)");

                    b.Property<double>("RequiredThickness")
                        .HasColumnType("float");

                    b.Property<double>("StructuralThickness")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("Cml");
                });

            modelBuilder.Entity("DexonApi.Models.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Ca")
                        .HasColumnType("float");

                    b.Property<double>("DesignLife")
                        .HasColumnType("float");

                    b.Property<double>("DesignPressure")
                        .HasColumnType("float");

                    b.Property<double>("DesignTemperature")
                        .HasColumnType("float");

                    b.Property<string>("DrawingNumber")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("From")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("InserviceDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("JointEfficiency")
                        .HasColumnType("float");

                    b.Property<string>("LineNumber")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Material")
                        .HasColumnType("varchar(250)");

                    b.Property<double>("OperatingPressure")
                        .HasColumnType("float");

                    b.Property<double>("OperatingTemperature")
                        .HasColumnType("float");

                    b.Property<double>("OriginalThickness")
                        .HasColumnType("float");

                    b.Property<double>("PipeSize")
                        .HasColumnType("float");

                    b.Property<string>("Service")
                        .HasColumnType("varchar(250)");

                    b.Property<double>("Stress")
                        .HasColumnType("float");

                    b.Property<string>("To")
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Info");
                });

            modelBuilder.Entity("DexonApi.Models.TestPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CmlId")
                        .HasColumnType("int");

                    b.Property<int>("CmlNumber")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("TpDescription")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("TpNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CmlId");

                    b.ToTable("TestPoints");
                });

            modelBuilder.Entity("DexonApi.Models.Thickness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("ActualThickness")
                        .HasColumnType("float");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TpId")
                        .HasColumnType("int");

                    b.Property<int>("TpNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TpId");

                    b.ToTable("Thicknesses");
                });

            modelBuilder.Entity("DexonApi.Models.Cml", b =>
                {
                    b.HasOne("DexonApi.Models.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Info");
                });

            modelBuilder.Entity("DexonApi.Models.TestPoint", b =>
                {
                    b.HasOne("DexonApi.Models.Cml", "Cml")
                        .WithMany()
                        .HasForeignKey("CmlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cml");
                });

            modelBuilder.Entity("DexonApi.Models.Thickness", b =>
                {
                    b.HasOne("DexonApi.Models.TestPoint", "TestPoint")
                        .WithMany()
                        .HasForeignKey("TpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestPoint");
                });
#pragma warning restore 612, 618
        }
    }
}
