﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TraineeTracker.Persistence;

#nullable disable

namespace TraineeTracker.Persistence.Migrations
{
    [DbContext(typeof(TraineeTrackerDbContext))]
    [Migration("20230116143448_AddedGeneratedNever")]
    partial class AddedGeneratedNever
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TraineeTracker.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "C# Developer"
                        },
                        new
                        {
                            Id = 2,
                            Title = "C# SDET"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Java Developer"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Java SDET"
                        });
                });

            modelBuilder.Entity("TraineeTracker.Domain.Tracker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConsultantSkill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Continue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Stop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicalSkill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraineeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trackers");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Trainee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Trainees");

                    b.HasData(
                        new
                        {
                            Id = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                            CourseId = 1,
                            Email = "carlangle@sparta.com",
                            FirstName = "Carl",
                            LastName = "Angle"
                        },
                        new
                        {
                            Id = "2cbdecbb-791e-45c0-93de-51abc9b71859",
                            CourseId = 2,
                            Email = "kimsale@sparta.com",
                            FirstName = "Kim",
                            LastName = "Sale"
                        });
                });

            modelBuilder.Entity("TraineeTracker.Domain.Trainer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trainer");

                    b.HasData(
                        new
                        {
                            Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                            Email = "johndoe@sparta.com",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                            Email = "janedoe@sparta.com",
                            FirstName = "Jane",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("TraineeTracker.Domain.TrainerCourse", b =>
                {
                    b.Property<string>("TrainerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("TrainerId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("TrainerCourse");

                    b.HasData(
                        new
                        {
                            TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                            CourseId = 1
                        },
                        new
                        {
                            TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                            CourseId = 2
                        },
                        new
                        {
                            TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                            CourseId = 1
                        },
                        new
                        {
                            TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                            CourseId = 2
                        });
                });

            modelBuilder.Entity("TraineeTracker.Domain.TrainerTrainee", b =>
                {
                    b.Property<string>("TraineeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TrainerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TraineeId", "TrainerId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerTrainee");

                    b.HasData(
                        new
                        {
                            TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                            TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                        },
                        new
                        {
                            TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859",
                            TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                        },
                        new
                        {
                            TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                            TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1"
                        },
                        new
                        {
                            TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859",
                            TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1"
                        });
                });

            modelBuilder.Entity("TraineeTracker.Domain.Trainee", b =>
                {
                    b.HasOne("TraineeTracker.Domain.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("TraineeTracker.Domain.TrainerCourse", b =>
                {
                    b.HasOne("TraineeTracker.Domain.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraineeTracker.Domain.Trainer", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("TraineeTracker.Domain.TrainerTrainee", b =>
                {
                    b.HasOne("TraineeTracker.Domain.Trainee", "Trainee")
                        .WithMany()
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraineeTracker.Domain.Trainer", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainee");

                    b.Navigation("Trainer");
                });
#pragma warning restore 612, 618
        }
    }
}
