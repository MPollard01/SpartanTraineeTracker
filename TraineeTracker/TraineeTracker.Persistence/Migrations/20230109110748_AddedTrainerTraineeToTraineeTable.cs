using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrainerTraineeToTraineeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Trainees_TraineeId",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_TraineeId",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                table: "Trainer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TraineeId",
                table: "Trainer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                column: "TraineeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                column: "TraineeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_TraineeId",
                table: "Trainer",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Trainees_TraineeId",
                table: "Trainer",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id");
        }
    }
}
