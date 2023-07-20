﻿// <auto-generated />
using System;
using DBdesign.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBdesign.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DBdesign.Shared.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PunchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "sss@gmail.com",
                            Name = "Ben",
                            Phone = "0966666666",
                            Position = "engineer",
                            PunchId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "sssss@gmail.com",
                            Name = "Alan",
                            Phone = "0977777777",
                            Position = "engineer",
                            PunchId = 2
                        });
                });

            modelBuilder.Entity("DBdesign.Shared.Punchs1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<string>("Hours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PunchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PunchIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PunchOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Punchs1");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hours = "",
                            Name = "Ben",
                            PunchId = 1,
                            PunchIn = new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4843),
                            PunchOut = new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4853),
                            Time = "2023/07/19"
                        },
                        new
                        {
                            Id = 2,
                            Hours = "",
                            Name = "Ben",
                            PunchId = 1,
                            PunchIn = new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4855),
                            PunchOut = new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4856),
                            Time = "2023/07/19"
                        });
                });

            modelBuilder.Entity("DBdesign.Shared.Punchs2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<string>("Hours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PunchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PunchIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PunchOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Punchs2");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hours = "",
                            Name = "Alan",
                            PunchId = 2,
                            PunchIn = new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4872),
                            PunchOut = new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4872),
                            Time = "2023/07/19"
                        });
                });

            modelBuilder.Entity("DBdesign.Shared.Punchs1", b =>
                {
                    b.HasOne("DBdesign.Shared.Employees", null)
                        .WithMany("Punch1")
                        .HasForeignKey("EmployeesId");
                });

            modelBuilder.Entity("DBdesign.Shared.Punchs2", b =>
                {
                    b.HasOne("DBdesign.Shared.Employees", null)
                        .WithMany("Punch2")
                        .HasForeignKey("EmployeesId");
                });

            modelBuilder.Entity("DBdesign.Shared.Employees", b =>
                {
                    b.Navigation("Punch1");

                    b.Navigation("Punch2");
                });
#pragma warning restore 612, 618
        }
    }
}