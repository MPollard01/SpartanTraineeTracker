using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AnotherUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTrainer");

            migrationBuilder.DropTable(
                name: "TraineeTrainer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainer_TrainersId",
                table: "CourseTrainer",
                column: "TrainersId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeTrainer_TrainersId",
                table: "TraineeTrainer",
                column: "TrainersId");
        }
    }
}
