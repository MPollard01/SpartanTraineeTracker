using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainee_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCourse",
                columns: table => new
                {
                    TrainerId = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCourse", x => new { x.TrainerId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_TrainerCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerCourse_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<string>(type: "text", nullable: false),
                    Stop = table.Column<string>(type: "text", nullable: false),
                    Continue = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TechnicalSkill = table.Column<string>(type: "text", nullable: false),
                    ConsultantSkill = table.Column<string>(type: "text", nullable: false),
                    TraineeId = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracker_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerTrainee",
                columns: table => new
                {
                    TraineeId = table.Column<string>(type: "text", nullable: false),
                    TrainerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTrainee", x => new { x.TrainerId, x.TraineeId });
                    table.ForeignKey(
                        name: "FK_TrainerTrainee_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerTrainee_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "C# Developer" },
                    { 2, "C# SDET" },
                    { 3, "Java Developer" },
                    { 4, "Java SDET" }
                });

            migrationBuilder.InsertData(
                table: "Trainer",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "0c1518f6-e6bc-4568-b694-e50fb2a3eac1", "janedoe@sparta.com", "Jane", "Doe" },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", "johndoe@sparta.com", "John", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "Id", "CourseId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", 2, "kimsale@sparta.com", "Kim", "Sale" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", 1, "carlangle@sparta.com", "Carl", "Angle" }
                });

            migrationBuilder.InsertData(
                table: "TrainerCourse",
                columns: new[] { "CourseId", "TrainerId" },
                values: new object[,]
                {
                    { 1, "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { 2, "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { 1, "9e224968-33e4-4652-b7b7-8574d048cdb9" },
                    { 2, "9e224968-33e4-4652-b7b7-8574d048cdb9" }
                });

            migrationBuilder.InsertData(
                table: "Tracker",
                columns: new[] { "Id", "ConsultantSkill", "Continue", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Start", "StartDate", "Stop", "TechnicalSkill", "TraineeId" },
                values: new object[] { 1, "Partially Skilled", "Learning C#", "Carl Angle", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Studying every day", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Making silly mistakes", "Skilled", "7e6adc8b-0a6e-4970-af0c-18f7fe18336d" });

            migrationBuilder.InsertData(
                table: "TrainerTrainee",
                columns: new[] { "TraineeId", "TrainerId" },
                values: new object[,]
                {
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", "9e224968-33e4-4652-b7b7-8574d048cdb9" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "9e224968-33e4-4652-b7b7-8574d048cdb9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracker_TraineeId",
                table: "Tracker",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_CourseId",
                table: "Trainee",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCourse_CourseId",
                table: "TrainerCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTrainee_TraineeId",
                table: "TrainerTrainee",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracker");

            migrationBuilder.DropTable(
                name: "TrainerCourse");

            migrationBuilder.DropTable(
                name: "TrainerTrainee");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
