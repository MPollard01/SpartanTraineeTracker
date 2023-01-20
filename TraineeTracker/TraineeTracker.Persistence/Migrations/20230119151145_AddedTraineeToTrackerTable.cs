using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedTraineeToTrackerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TraineeId",
                table: "Tracker",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tracker_TraineeId",
                table: "Tracker",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracker_Trainee_TraineeId",
                table: "Tracker",
                column: "TraineeId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracker_Trainee_TraineeId",
                table: "Tracker");

            migrationBuilder.DropIndex(
                name: "IX_Tracker_TraineeId",
                table: "Tracker");

            migrationBuilder.AlterColumn<string>(
                name: "TraineeId",
                table: "Tracker",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
