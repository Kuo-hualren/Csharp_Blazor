﻿// <auto-generated />
using System;
using EmployRec.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployRec.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230720080103_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployRec.Shared.Emplo", b =>
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

            modelBuilder.Entity("EmployRec.Shared.Puns1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmploId")
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

                    b.HasIndex("EmploId");

                    b.ToTable("Punchs1");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hours = "",
                            Name = "Ben",
                            PunchId = 1,
                            PunchIn = new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4746),
                            PunchOut = new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4758),
                            Time = "2023/07/19"
                        },
                        new
                        {
                            Id = 2,
                            Hours = "",
                            Name = "Ben",
                            PunchId = 1,
                            PunchIn = new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4759),
                            PunchOut = new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4760),
                            Time = "2023/07/19"
                        });
                });

            modelBuilder.Entity("EmployRec.Shared.Puns2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmploId")
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

                    b.HasIndex("EmploId");

                    b.ToTable("Punchs2");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hours = "",
                            Name = "Alan",
                            PunchId = 2,
                            PunchIn = new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4776),
                            PunchOut = new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4776),
                            Time = "2023/07/19"
                        });
                });

            modelBuilder.Entity("EmployRec.Shared.Puns1", b =>
                {
                    b.HasOne("EmployRec.Shared.Emplo", null)
                        .WithMany("Punch1")
                        .HasForeignKey("EmploId");
                });

            modelBuilder.Entity("EmployRec.Shared.Puns2", b =>
                {
                    b.HasOne("EmployRec.Shared.Emplo", null)
                        .WithMany("Punch2")
                        .HasForeignKey("EmploId");
                });

            modelBuilder.Entity("EmployRec.Shared.Emplo", b =>
                {
                    b.Navigation("Punch1");

                    b.Navigation("Punch2");
                });
#pragma warning restore 612, 618
        }
    }
}
