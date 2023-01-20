using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeededTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tracker",
                columns: new[] { "Id", "ConsultantSkill", "Continue", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Start", "StartDate", "Stop", "TechnicalSkill", "TraineeId" },
                values: new object[] { 1, "Partially Skilled", "Learning C#", "Carl Angle", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Studying every day", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Making silly mistakes", "Skilled", "7e6adc8b-0a6e-4970-af0c-18f7fe18336d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracker",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
