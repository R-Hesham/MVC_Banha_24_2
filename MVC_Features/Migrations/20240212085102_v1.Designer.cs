﻿// <auto-generated />
using System;
using MVC_Features.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Features.Migrations
{
    [DbContext(typeof(BanhaITIContext))]
    [Migration("20240212085102_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_Features.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MVC_Features.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MangerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MangerId")
                        .IsUnique()
                        .HasFilter("[MangerId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVC_Features.Models.Ins_Course", b =>
                {
                    b.Property<int>("InsId")
                        .HasColumnType("int");

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("Evaluation")
                        .HasColumnType("int");

                    b.HasKey("InsId", "CrsId");

                    b.HasIndex("CrsId");

                    b.ToTable("Ins_Courses");
                });

            modelBuilder.Entity("MVC_Features.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("MVC_Features.Models.Std_Course", b =>
                {
                    b.Property<int>("StdId")
                        .HasColumnType("int");

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StdId", "CrsId");

                    b.HasIndex("CrsId");

                    b.ToTable("Std_Courses");
                });

            modelBuilder.Entity("MVC_Features.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int");

                    b.Property<int?>("LeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.HasIndex("LeaderId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MVC_Features.Models.Department", b =>
                {
                    b.HasOne("MVC_Features.Models.Instructor", "manger")
                        .WithOne("mangeDepartment")
                        .HasForeignKey("MVC_Features.Models.Department", "MangerId");

                    b.Navigation("manger");
                });

            modelBuilder.Entity("MVC_Features.Models.Ins_Course", b =>
                {
                    b.HasOne("MVC_Features.Models.Course", "course")
                        .WithMany("instructors")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Features.Models.Instructor", "instructor")
                        .WithMany("courses")
                        .HasForeignKey("InsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("MVC_Features.Models.Instructor", b =>
                {
                    b.HasOne("MVC_Features.Models.Department", "workDepartment")
                        .WithMany("instructors")
                        .HasForeignKey("Dept_Id");

                    b.Navigation("workDepartment");
                });

            modelBuilder.Entity("MVC_Features.Models.Std_Course", b =>
                {
                    b.HasOne("MVC_Features.Models.Course", "course")
                        .WithMany("students")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Features.Models.Student", "student")
                        .WithMany("courses")
                        .HasForeignKey("StdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("student");
                });

            modelBuilder.Entity("MVC_Features.Models.Student", b =>
                {
                    b.HasOne("MVC_Features.Models.Department", "department")
                        .WithMany("students")
                        .HasForeignKey("DeptId");

                    b.HasOne("MVC_Features.Models.Student", "leader")
                        .WithMany("group")
                        .HasForeignKey("LeaderId");

                    b.Navigation("department");

                    b.Navigation("leader");
                });

            modelBuilder.Entity("MVC_Features.Models.Course", b =>
                {
                    b.Navigation("instructors");

                    b.Navigation("students");
                });

            modelBuilder.Entity("MVC_Features.Models.Department", b =>
                {
                    b.Navigation("instructors");

                    b.Navigation("students");
                });

            modelBuilder.Entity("MVC_Features.Models.Instructor", b =>
                {
                    b.Navigation("courses");

                    b.Navigation("mangeDepartment")
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_Features.Models.Student", b =>
                {
                    b.Navigation("courses");

                    b.Navigation("group");
                });
#pragma warning restore 612, 618
        }
    }
}
