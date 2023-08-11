using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TraineeTestCategoryToSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraineeTests_Categories_CategoryId",
                table: "TraineeTests");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "TraineeTests",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeTests_CategoryId",
                table: "TraineeTests",
                newName: "IX_TraineeTests_SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeTests_SubCategories_SubCategoryId",
                table: "TraineeTests",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraineeTests_SubCategories_SubCategoryId",
                table: "TraineeTests");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "TraineeTests",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeTests_SubCategoryId",
                table: "TraineeTests",
                newName: "IX_TraineeTests_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeTests_Categories_CategoryId",
                table: "TraineeTests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
