using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginStatistic.Migrations
{
    public partial class UserLoginAttemptOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempts_Users_UserId",
                table: "LoginAttempts");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "LoginAttempts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempts_Users_UserId",
                table: "LoginAttempts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempts_Users_UserId",
                table: "LoginAttempts");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "LoginAttempts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempts_Users_UserId",
                table: "LoginAttempts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
