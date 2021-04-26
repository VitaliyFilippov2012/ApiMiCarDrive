using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.Migrations
{
    public partial class ChangeRelationshipBetweenUserAndAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUTHENTICATION_USER",
                table: "AUTHENTICATION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUTHENTICATION",
                table: "AUTHENTICATION");

            migrationBuilder.DropIndex(
                name: "IX_AUTHENTICATION_USER_ID",
                table: "AUTHENTICATION");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUTHENTICATION",
                table: "AUTHENTICATION",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__LOGIN_TY__D9C1FA00C38D47B8",
                table: "AUTHENTICATION",
                column: "LOGIN",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AUTHENTICATION_USER",
                table: "USERS",
                column: "USER_ID",
                principalTable: "AUTHENTICATION",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUTHENTICATION_USER",
                table: "USERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUTHENTICATION",
                table: "AUTHENTICATION");

            migrationBuilder.DropIndex(
                name: "UQ__LOGIN_TY__D9C1FA00C38D47B8",
                table: "AUTHENTICATION");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUTHENTICATION",
                table: "AUTHENTICATION",
                column: "LOGIN");

            migrationBuilder.CreateIndex(
                name: "IX_AUTHENTICATION_USER_ID",
                table: "AUTHENTICATION",
                column: "USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AUTHENTICATION_USER",
                table: "AUTHENTICATION",
                column: "USER_ID",
                principalTable: "USERS",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
