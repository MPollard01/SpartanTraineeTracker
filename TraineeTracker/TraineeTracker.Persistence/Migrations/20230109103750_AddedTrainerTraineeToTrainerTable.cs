﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrainerTraineeToTrainerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Trainer_TrainerId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "TraineeTrainer");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Courses");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

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
                        name: "FK_TraineeTrainer_Trainees_TraineesId",
                        column: x => x.TraineesId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeTrainer_Trainer_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrainerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrainerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrainerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "TrainerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeTrainer_TrainersId",
                table: "TraineeTrainer",
                column: "TrainersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Trainer_TrainerId",
                table: "Courses",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id");
        }
    }
}