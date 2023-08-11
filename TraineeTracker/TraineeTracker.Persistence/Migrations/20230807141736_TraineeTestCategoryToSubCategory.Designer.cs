﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TraineeTracker.Persistence;

#nullable disable

namespace TraineeTracker.Persistence.Migrations
{
    [DbContext(typeof(TraineeTrackerDbContext))]
    [Migration("20230807141736_TraineeTestCategoryToSubCategory")]
    partial class TraineeTestCategoryToSubCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TraineeTracker.Domain.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Course");

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

            modelBuilder.Entity("TraineeTracker.Domain.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TraineeTracker.Domain.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Tracker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConsultantSkill")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Continue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Stop")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TechnicalSkill")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TraineeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TraineeId");

                    b.ToTable("Tracker");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConsultantSkill = "Partially Skilled",
                            Continue = "Learning C#",
                            CreatedBy = "Carl Angle",
                            CreatedDate = new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Start = "Studying every day",
                            StartDate = new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stop = "Making silly mistakes",
                            TechnicalSkill = "Skilled",
                            TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                        });
                });

            modelBuilder.Entity("TraineeTracker.Domain.Trainee", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Trainee");

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

            modelBuilder.Entity("TraineeTracker.Domain.TraineeAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TraineeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TraineeTestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TraineeTestId");

                    b.ToTable("TraineeAnswers");
                });

            modelBuilder.Entity("TraineeTracker.Domain.TraineeTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("TraineeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("TraineeTests");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Trainer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

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
                        .HasColumnType("text");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

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
                    b.Property<string>("TrainerId")
                        .HasColumnType("text");

                    b.Property<string>("TraineeId")
                        .HasColumnType("text");

                    b.HasKey("TrainerId", "TraineeId");

                    b.HasIndex("TraineeId");

                    b.ToTable("TrainerTrainee");

                    b.HasData(
                        new
                        {
                            TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                            TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                        },
                        new
                        {
                            TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                            TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859"
                        },
                        new
                        {
                            TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                            TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                        },
                        new
                        {
                            TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                            TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859"
                        });
                });

            modelBuilder.Entity("TraineeTracker.Domain.Answer", b =>
                {
                    b.HasOne("TraineeTracker.Domain.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Option", b =>
                {
                    b.HasOne("TraineeTracker.Domain.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Question", b =>
                {
                    b.HasOne("TraineeTracker.Domain.SubCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TraineeTracker.Domain.SubCategory", b =>
                {
                    b.HasOne("TraineeTracker.Domain.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Tracker", b =>
                {
                    b.HasOne("TraineeTracker.Domain.Trainee", "Trainee")
                        .WithMany()
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainee");
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

            modelBuilder.Entity("TraineeTracker.Domain.TraineeAnswer", b =>
                {
                    b.HasOne("TraineeTracker.Domain.TraineeTest", "TraineeTest")
                        .WithMany("Answers")
                        .HasForeignKey("TraineeTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TraineeTest");
                });

            modelBuilder.Entity("TraineeTracker.Domain.TraineeTest", b =>
                {
                    b.HasOne("TraineeTracker.Domain.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
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

            modelBuilder.Entity("TraineeTracker.Domain.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("TraineeTracker.Domain.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("TraineeTracker.Domain.TraineeTest", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
