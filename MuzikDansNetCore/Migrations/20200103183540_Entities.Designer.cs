﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MuzikDansNetCore.DataAccessLayer.Concrete.EntityFrameWork;

namespace MuzikDansNetCore.Migrations
{
    [DbContext(typeof(MuzikDbContext))]
    [Migration("20200103183540_Entities")]
    partial class Entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MuzikDansNetCore.Entities.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchName");

                    b.Property<string>("Education");

                    b.HasKey("BranchId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("MuzikDansNetCore.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Images");

                    b.Property<string>("LessonName");

                    b.HasKey("LessonId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("MuzikDansNetCore.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId");

                    b.Property<string>("Education");

                    b.Property<string>("Image");

                    b.Property<int>("LessonId");

                    b.Property<string>("TeacherName");

                    b.HasKey("TeacherId");

                    b.HasIndex("BranchId");

                    b.HasIndex("LessonId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("MuzikDansNetCore.Entities.Teacher", b =>
                {
                    b.HasOne("MuzikDansNetCore.Entities.Branch", "Branch")
                        .WithMany("Teachers")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MuzikDansNetCore.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
