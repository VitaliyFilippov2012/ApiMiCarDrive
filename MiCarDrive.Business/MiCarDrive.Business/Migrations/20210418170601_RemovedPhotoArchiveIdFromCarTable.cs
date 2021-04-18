using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.Migrations
{
    public partial class RemovedPhotoArchiveIdFromCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARS_PHOTOARCHIVE",
                table: "CARS");

            migrationBuilder.DropIndex(
                name: "IX_CARS_PHOTO_ARCHIVE_ID",
                table: "CARS");

            migrationBuilder.DropColumn(
                name: "PHOTO_ARCHIVE_ID",
                table: "CARS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PHOTO_ARCHIVE_ID",
                table: "CARS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CARS_PHOTO_ARCHIVE_ID",
                table: "CARS",
                column: "PHOTO_ARCHIVE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CARS_PHOTOARCHIVE",
                table: "CARS",
                column: "PHOTO_ARCHIVE_ID",
                principalTable: "PHOTO_ARCHIVE",
                principalColumn: "PHOTO_ARCHIVE_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
