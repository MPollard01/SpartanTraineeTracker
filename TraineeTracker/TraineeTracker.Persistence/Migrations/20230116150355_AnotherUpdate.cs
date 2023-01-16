using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AnotherUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Courses_CourseId",
                table: "Trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerCourse_Courses_CourseId",
                table: "TrainerCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerTrainee_Trainees_TraineeId",
                table: "TrainerTrainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerTrainee",
                table: "TrainerTrainee");

            migrationBuilder.DropIndex(
                name: "IX_TrainerTrainee_TrainerId",
                table: "TrainerTrainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainees",
                table: "Trainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trackers",
                table: "Trackers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "TrainerTrainee",
                keyColumns: new[] { "TraineeId", "TrainerId" },
                keyValues: new object[] { "2cbdecbb-791e-45c0-93de-51abc9b71859", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" });

            migrationBuilder.DeleteData(
                table: "TrainerTrainee",
                keyColumns: new[] { "TraineeId", "TrainerId" },
                keyValues: new object[] { "2cbdecbb-791e-45c0-93de-51abc9b71859", "9e224968-33e4-4652-b7b7-8574d048cdb9" });

            migrationBuilder.DeleteData(
                table: "TrainerTrainee",
                keyColumns: new[] { "TraineeId", "TrainerId" },
                keyValues: new object[] { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" });

            migrationBuilder.DeleteData(
                table: "TrainerTrainee",
                keyColumns: new[] { "TraineeId", "TrainerId" },
                keyValues: new object[] { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "9e224968-33e4-4652-b7b7-8574d048cdb9" });

            migrationBuilder.RenameTable(
                name: "Trainees",
                newName: "Trainee");

            migrationBuilder.RenameTable(
                name: "Trackers",
                newName: "Tracker");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Trainees_CourseId",
                table: "Trainee",
                newName: "IX_Trainee_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerTrainee",
                table: "TrainerTrainee",
                columns: new[] { "TrainerId", "TraineeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tracker",
                table: "Tracker",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CourseTrainer",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTrainer", x => new { x.CoursesId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_CourseTrainer_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTrainer_Trainer_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeTrainer",
                columns: table => new
                {
                    TraineesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeTrainer", x => new { x.TraineesId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_TraineeTrainer_Trainee_TraineesId",
                        column: x => x.TraineesId,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeTrainer_Trainer_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_TrainerTrainee_TraineeId",
                table: "TrainerTrainee",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainer_TrainersId",
                table: "CourseTrainer",
                column: "TrainersId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeTrainer_TrainersId",
                table: "TraineeTrainer",
                column: "TrainersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Course_CourseId",
                table: "Trainee",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerCourse_Course_CourseId",
                table: "TrainerCourse",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerTrainee_Trainee_TraineeId",
                table: "TrainerTrainee",
                column: "TraineeId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Course_CourseId",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerCourse_Course_CourseId",
                table: "TrainerCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerTrainee_Trainee_TraineeId",
                table: "TrainerTrainee");

            migrationBuilder.DropTable(
                name: "CourseTrainer");

            migrationBuilder.DropTable(
                name: "TraineeTrainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerTrainee",
                table: "TrainerTrainee");

            migrationBuilder.DropIndex(
                name: "IX_TrainerTrainee_TraineeId",
                table: "TrainerTrainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tracker",
                table: "Tracker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DeleteData(
                table: "TrainerTrainee",
                keyColumns: new[] { "TraineeId", "TrainerId" },
                keyValues: new object[] { "2cbdecbb-791e-45c0-93de-51abc9b71859", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" });

            migrationBuilder.DeleteData(
                table: "TrainerTrainee",
                keyColumns: new[] { "TraineeId", "TrainerId" },
                keyValues: new object[] { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" });

            migrationBuilder.DeleteData(
                table: "TrainerTrainee",
                keyColumns: new[] { "TraineeId", "TrainerId" },
                keyValues: new object[] { "2cbdecbb-791e-45c0-93de-51abc9b71859", "9e224968-33e4-4652-b7b7-8574d048cdb9" });

            migrationBuilder.DeleteData(
                table: "TrainerTrainee",
                keyColumns: new[] { "TraineeId", "TrainerId" },
                keyValues: new object[] { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "9e224968-33e4-4652-b7b7-8574d048cdb9" });

            migrationBuilder.RenameTable(
                name: "Trainee",
                newName: "Trainees");

            migrationBuilder.RenameTable(
                name: "Tracker",
                newName: "Trackers");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_CourseId",
                table: "Trainees",
                newName: "IX_Trainees_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerTrainee",
                table: "TrainerTrainee",
                columns: new[] { "TraineeId", "TrainerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainees",
                table: "Trainees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trackers",
                table: "Trackers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TrainerTrainee",
                columns: new[] { "TraineeId", "TrainerId" },
                values: new object[,]
                {
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", "9e224968-33e4-4652-b7b7-8574d048cdb9" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "9e224968-33e4-4652-b7b7-8574d048cdb9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTrainee_TrainerId",
                table: "TrainerTrainee",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Courses_CourseId",
                table: "Trainees",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerCourse_Courses_CourseId",
                table: "TrainerCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerTrainee_Trainees_TraineeId",
                table: "TrainerTrainee",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
