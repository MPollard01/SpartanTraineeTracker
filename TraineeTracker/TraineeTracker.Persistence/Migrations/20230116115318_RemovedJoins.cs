using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedJoins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraineeTrainers_Trainees_TraineeId",
                table: "TraineeTrainers");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineeTrainers_Trainer_TrainerId",
                table: "TraineeTrainers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerCourses_Courses_CourseId",
                table: "TrainerCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerCourses_Trainer_TrainerId",
                table: "TrainerCourses");

            migrationBuilder.DropTable(
                name: "TrainerTrainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerCourses",
                table: "TrainerCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraineeTrainers",
                table: "TraineeTrainers");

            migrationBuilder.RenameTable(
                name: "TrainerCourses",
                newName: "TrainerCourse");

            migrationBuilder.RenameTable(
                name: "TraineeTrainers",
                newName: "TraineeTrainer");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerCourses_CourseId",
                table: "TrainerCourse",
                newName: "IX_TrainerCourse_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeTrainers_TrainerId",
                table: "TraineeTrainer",
                newName: "IX_TraineeTrainer_TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerCourse",
                table: "TrainerCourse",
                columns: new[] { "TrainerId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraineeTrainer",
                table: "TraineeTrainer",
                columns: new[] { "TraineeId", "TrainerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeTrainer_Trainees_TraineeId",
                table: "TraineeTrainer",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeTrainer_Trainer_TrainerId",
                table: "TraineeTrainer",
                column: "TrainerId",
                principalTable: "Trainer",
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
                name: "FK_TrainerCourse_Trainer_TrainerId",
                table: "TrainerCourse",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraineeTrainer_Trainees_TraineeId",
                table: "TraineeTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineeTrainer_Trainer_TrainerId",
                table: "TraineeTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerCourse_Courses_CourseId",
                table: "TrainerCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerCourse_Trainer_TrainerId",
                table: "TrainerCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerCourse",
                table: "TrainerCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraineeTrainer",
                table: "TraineeTrainer");

            migrationBuilder.RenameTable(
                name: "TrainerCourse",
                newName: "TrainerCourses");

            migrationBuilder.RenameTable(
                name: "TraineeTrainer",
                newName: "TraineeTrainers");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerCourse_CourseId",
                table: "TrainerCourses",
                newName: "IX_TrainerCourses_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeTrainer_TrainerId",
                table: "TraineeTrainers",
                newName: "IX_TraineeTrainers_TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerCourses",
                table: "TrainerCourses",
                columns: new[] { "TrainerId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraineeTrainers",
                table: "TraineeTrainers",
                columns: new[] { "TraineeId", "TrainerId" });

            migrationBuilder.CreateTable(
                name: "TrainerTrainees",
                columns: table => new
                {
                    TrainerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTrainees", x => new { x.TrainerId, x.TraineeId });
                    table.ForeignKey(
                        name: "FK_TrainerTrainees_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerTrainees_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TrainerTrainees",
                columns: new[] { "TraineeId", "TrainerId" },
                values: new object[,]
                {
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", "9e224968-33e4-4652-b7b7-8574d048cdb9" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "9e224968-33e4-4652-b7b7-8574d048cdb9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTrainees_TraineeId",
                table: "TrainerTrainees",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeTrainers_Trainees_TraineeId",
                table: "TraineeTrainers",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeTrainers_Trainer_TrainerId",
                table: "TraineeTrainers",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerCourses_Courses_CourseId",
                table: "TrainerCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerCourses_Trainer_TrainerId",
                table: "TrainerCourses",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
