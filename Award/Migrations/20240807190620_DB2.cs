using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwardWeb.Migrations
{
    /// <inheritdoc />
    public partial class DB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserAward_AwardId",
                table: "UserAward",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAward_UserId",
                table: "UserAward",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Award_CategoryId",
                table: "Award",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Award_Category_CategoryId",
                table: "Award",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAward_Award_AwardId",
                table: "UserAward",
                column: "AwardId",
                principalTable: "Award",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAward_User_UserId",
                table: "UserAward",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Award_Category_CategoryId",
                table: "Award");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAward_Award_AwardId",
                table: "UserAward");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAward_User_UserId",
                table: "UserAward");

            migrationBuilder.DropIndex(
                name: "IX_UserAward_AwardId",
                table: "UserAward");

            migrationBuilder.DropIndex(
                name: "IX_UserAward_UserId",
                table: "UserAward");

            migrationBuilder.DropIndex(
                name: "IX_Award_CategoryId",
                table: "Award");
        }
    }
}
