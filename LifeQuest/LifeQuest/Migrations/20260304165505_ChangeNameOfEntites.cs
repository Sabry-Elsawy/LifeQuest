using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeQuest.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOfEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChallanges_AspNetUsers_UserId",
                table: "UserChallanges");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UserChallanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserChallanges_ApplicationUserId",
                table: "UserChallanges",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChallanges_AspNetUsers_ApplicationUserId",
                table: "UserChallanges",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChallanges_AspNetUsers_ApplicationUserId",
                table: "UserChallanges");

            migrationBuilder.DropIndex(
                name: "IX_UserChallanges_ApplicationUserId",
                table: "UserChallanges");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserChallanges");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChallanges_AspNetUsers_UserId",
                table: "UserChallanges",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
