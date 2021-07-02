using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWebAppTest.Data.Migrations
{
    public partial class ChangeUserIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_AspNetUsers_UserId1",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_UserId1",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ContactDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ContactDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_UserId",
                table: "ContactDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_AspNetUsers_UserId",
                table: "ContactDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_AspNetUsers_UserId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_UserId",
                table: "ContactDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ContactDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_UserId1",
                table: "ContactDetails",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_AspNetUsers_UserId1",
                table: "ContactDetails",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
