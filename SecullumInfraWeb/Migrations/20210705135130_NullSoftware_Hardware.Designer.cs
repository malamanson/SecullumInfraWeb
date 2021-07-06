﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecullumInfraWeb.Models;

namespace SecullumInfraWeb.Migrations
{
    [DbContext(typeof(SecullumInfraWebContext))]
    [Migration("20210705135130_NullSoftware_Hardware")]
    partial class NullSoftware_Hardware
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecullumInfraWeb.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SecullumInfraWeb.Models.Hardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Description");

                    b.Property<string>("HdSsd");

                    b.Property<string>("Name");

                    b.Property<string>("Processor");

                    b.Property<int>("Ram");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Hardware");
                });

            modelBuilder.Entity("SecullumInfraWeb.Models.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("HardwareId");

                    b.Property<string>("Name");

                    b.Property<string>("Serial");

                    b.Property<int>("Status");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("HardwareId");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("SecullumInfraWeb.Models.Hardware", b =>
                {
                    b.HasOne("SecullumInfraWeb.Models.Department", "Department")
                        .WithMany("Hardwares")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecullumInfraWeb.Models.Software", b =>
                {
                    b.HasOne("SecullumInfraWeb.Models.Department", "Department")
                        .WithMany("Softwares")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SecullumInfraWeb.Models.Hardware", "Hardware")
                        .WithMany("Softwares")
                        .HasForeignKey("HardwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
