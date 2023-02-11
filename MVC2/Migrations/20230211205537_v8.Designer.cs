﻿// <auto-generated />
using System;
using MVC2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC2.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20230211205537_v8")]
    partial class v8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC2.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("employeeid")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("startDate")
                        .HasColumnType("Date");

                    b.HasKey("id");

                    b.HasIndex("employeeid")
                        .IsUnique()
                        .HasFilter("[employeeid] IS NOT NULL");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("MVC2.Models.Dependent", b =>
                {
                    b.Property<string>("name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("employeeid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("birthday")
                        .HasColumnType("Date");

                    b.Property<int>("order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order"));

                    b.Property<string>("relationship")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("sex")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("name", "employeeid");

                    b.HasIndex("employeeid");

                    b.ToTable("dependents");
                });

            modelBuilder.Entity("MVC2.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("birthday")
                        .HasColumnType("Date");

                    b.Property<int?>("departmentWFid")
                        .HasColumnType("int");

                    b.Property<string>("fname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("lname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("minit")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int?>("salary")
                        .HasColumnType("int");

                    b.Property<string>("sex")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("supervisorid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("departmentWFid");

                    b.HasIndex("supervisorid");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("MVC2.Models.Project", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<int>("departmentid")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.HasIndex("departmentid");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("MVC2.Models.WorksOn", b =>
                {
                    b.Property<int>("employeeid")
                        .HasColumnType("int");

                    b.Property<int>("projectid")
                        .HasColumnType("int");

                    b.Property<int?>("hours")
                        .HasColumnType("int");

                    b.HasKey("employeeid", "projectid");

                    b.HasIndex("projectid");

                    b.ToTable("workson");
                });

            modelBuilder.Entity("MVC2.Models.Department", b =>
                {
                    b.HasOne("MVC2.Models.Employee", "employee")
                        .WithOne("departmentMNG")
                        .HasForeignKey("MVC2.Models.Department", "employeeid");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("MVC2.Models.Dependent", b =>
                {
                    b.HasOne("MVC2.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("MVC2.Models.Employee", b =>
                {
                    b.HasOne("MVC2.Models.Department", "departmentWF")
                        .WithMany("employees")
                        .HasForeignKey("departmentWFid");

                    b.HasOne("MVC2.Models.Employee", "supervisor")
                        .WithMany()
                        .HasForeignKey("supervisorid");

                    b.Navigation("departmentWF");

                    b.Navigation("supervisor");
                });

            modelBuilder.Entity("MVC2.Models.Project", b =>
                {
                    b.HasOne("MVC2.Models.Department", "department")
                        .WithMany("Projects")
                        .HasForeignKey("departmentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("MVC2.Models.WorksOn", b =>
                {
                    b.HasOne("MVC2.Models.Employee", "employee")
                        .WithMany("worksOns")
                        .HasForeignKey("employeeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC2.Models.Project", "project")
                        .WithMany("worksOns")
                        .HasForeignKey("projectid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("MVC2.Models.Department", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("MVC2.Models.Employee", b =>
                {
                    b.Navigation("departmentMNG");

                    b.Navigation("worksOns");
                });

            modelBuilder.Entity("MVC2.Models.Project", b =>
                {
                    b.Navigation("worksOns");
                });
#pragma warning restore 612, 618
        }
    }
}
