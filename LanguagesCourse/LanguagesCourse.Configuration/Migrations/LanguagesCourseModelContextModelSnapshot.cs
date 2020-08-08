﻿// <auto-generated />
using System;
using LanguagesCourse.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LanguagesCourse.Configuration.Migrations
{
    [DbContext(typeof(LanguagesCourseModelContext))]
    partial class LanguagesCourseModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LanguagesCourse.Entity.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("course");
                });

            modelBuilder.Entity("LanguagesCourse.Entity.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("student");
                });

            modelBuilder.Entity("LanguagesCourse.Entity.StudentHistory", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date");

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("end_date");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("student_history");
                });

            modelBuilder.Entity("LanguagesCourse.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("login")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(20);

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("LanguagesCourse.Entity.StudentHistory", b =>
                {
                    b.HasOne("LanguagesCourse.Entity.Course", "Course")
                        .WithMany("StudentHistories")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("id_course")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LanguagesCourse.Entity.Student", "Student")
                        .WithMany("StudentHistories")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("id_student")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
