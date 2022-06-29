﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentSystem_Repository.DataAccess;

#nullable disable

namespace StudentSystem_Repository.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20220629170921_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.Property<Guid>("DepartmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LecturesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentsId", "LecturesId");

                    b.HasIndex("LecturesId");

                    b.ToTable("DepartmentLecture");
                });

            modelBuilder.Entity("StudentSystem_Repository.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("StudentSystem_Repository.Entities.Lecture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("StudentSystem_Repository.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.HasOne("StudentSystem_Repository.Entities.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentSystem_Repository.Entities.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentSystem_Repository.Entities.Lecture", b =>
                {
                    b.HasOne("StudentSystem_Repository.Entities.Student", null)
                        .WithMany("Lectures")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("StudentSystem_Repository.Entities.Student", b =>
                {
                    b.HasOne("StudentSystem_Repository.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StudentSystem_Repository.Entities.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentSystem_Repository.Entities.Student", b =>
                {
                    b.Navigation("Lectures");
                });
#pragma warning restore 612, 618
        }
    }
}
