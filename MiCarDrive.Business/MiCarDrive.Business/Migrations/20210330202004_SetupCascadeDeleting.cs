using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.Migrations
{
    public partial class SetupCascadeDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTS_USERSCARS",
                table: "CAR_EVENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_DETAILS_CARS",
                table: "DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_PHOTO_PHOTOARCHIVE_PHOTO",
                table: "PHOTO_PHOTO_ARCHIVE");

            migrationBuilder.DropForeignKey(
                name: "FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE",
                table: "PHOTO_PHOTO_ARCHIVE");

            migrationBuilder.DropForeignKey(
                name: "FK_USERCARS_USER",
                table: "USERS_CARS");

            migrationBuilder.DropForeignKey(
                name: "FK_USERSCARS_RIGHTS_RIGHT",
                table: "USERS_CARS_RIGHTS");

            migrationBuilder.DropForeignKey(
                name: "FK_USERSCARS_ROLES_ROLE",
                table: "USERS_CARS_ROLES");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTS_USERSCARS",
                table: "CAR_EVENTS",
                column: "USER_CAR_ID",
                principalTable: "USERS_CARS",
                principalColumn: "USER_CAR_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DETAILS_CARS",
                table: "DETAILS",
                column: "CAR_ID",
                principalTable: "CARS",
                principalColumn: "CAR_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PHOTO_PHOTOARCHIVE_PHOTO",
                table: "PHOTO_PHOTO_ARCHIVE",
                column: "PHOTO_ARCHIVE_ID",
                principalTable: "PHOTO_ARCHIVE",
                principalColumn: "PHOTO_ARCHIVE_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE",
                table: "PHOTO_PHOTO_ARCHIVE",
                column: "PHOTO_ID",
                principalTable: "PHOTO",
                principalColumn: "PHOTO_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USERCARS_USER",
                table: "USERS_CARS",
                column: "USER_ID",
                principalTable: "USERS",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USERSCARS_RIGHTS_RIGHT",
                table: "USERS_CARS_RIGHTS",
                column: "RIGHT_ID",
                principalTable: "RIGHTS",
                principalColumn: "RIGHT_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USERSCARS_ROLES_ROLE",
                table: "USERS_CARS_ROLES",
                column: "ROLE_ID",
                principalTable: "ROLES",
                principalColumn: "ROLE_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTS_USERSCARS",
                table: "CAR_EVENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_DETAILS_CARS",
                table: "DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_PHOTO_PHOTOARCHIVE_PHOTO",
                table: "PHOTO_PHOTO_ARCHIVE");

            migrationBuilder.DropForeignKey(
                name: "FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE",
                table: "PHOTO_PHOTO_ARCHIVE");

            migrationBuilder.DropForeignKey(
                name: "FK_USERCARS_USER",
                table: "USERS_CARS");

            migrationBuilder.DropForeignKey(
                name: "FK_USERSCARS_RIGHTS_RIGHT",
                table: "USERS_CARS_RIGHTS");

            migrationBuilder.DropForeignKey(
                name: "FK_USERSCARS_ROLES_ROLE",
                table: "USERS_CARS_ROLES");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTS_USERSCARS",
                table: "CAR_EVENTS",
                column: "USER_CAR_ID",
                principalTable: "USERS_CARS",
                principalColumn: "USER_CAR_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DETAILS_CARS",
                table: "DETAILS",
                column: "CAR_ID",
                principalTable: "CARS",
                principalColumn: "CAR_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PHOTO_PHOTOARCHIVE_PHOTO",
                table: "PHOTO_PHOTO_ARCHIVE",
                column: "PHOTO_ARCHIVE_ID",
                principalTable: "PHOTO_ARCHIVE",
                principalColumn: "PHOTO_ARCHIVE_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE",
                table: "PHOTO_PHOTO_ARCHIVE",
                column: "PHOTO_ID",
                principalTable: "PHOTO",
                principalColumn: "PHOTO_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USERCARS_USER",
                table: "USERS_CARS",
                column: "USER_ID",
                principalTable: "USERS",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USERSCARS_RIGHTS_RIGHT",
                table: "USERS_CARS_RIGHTS",
                column: "RIGHT_ID",
                principalTable: "RIGHTS",
                principalColumn: "RIGHT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USERSCARS_ROLES_ROLE",
                table: "USERS_CARS_ROLES",
                column: "ROLE_ID",
                principalTable: "ROLES",
                principalColumn: "ROLE_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
