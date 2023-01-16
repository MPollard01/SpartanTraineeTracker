using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedJoins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraineeTrainer");

            migrationBuilder.CreateTable(
                name: "TrainerTrainee",
                columns: table => new
                {
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTrainee", x => new { x.TraineeId, x.TrainerId });
                    table.ForeignKey(
                        name: "FK_TrainerTrainee_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerTrainee");

            migrationBuilder.CreateTable(
                name: "TraineeTrainer",
                columns: table => new
                {
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeTrainer", x => new { x.TraineeId, x.TrainerId });
                    table.ForeignKey(
                        name: "FK_TraineeTrainer_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeTrainer_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TraineeTrainer",
                columns: new[] { "TraineeId", "TrainerId" },
                values: new object[,]
                {
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { "2cbdecbb-791e-45c0-93de-51abc9b71859", "9e224968-33e4-4652-b7b7-8574d048cdb9" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "0c1518f6-e6bc-4568-b694-e50fb2a3eac1" },
                    { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", "9e224968-33e4-4652-b7b7-8574d048cdb9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineeTrainer_TrainerId",
                table: "TraineeTrainer",
                column: "TrainerId");
        }
    }
}
