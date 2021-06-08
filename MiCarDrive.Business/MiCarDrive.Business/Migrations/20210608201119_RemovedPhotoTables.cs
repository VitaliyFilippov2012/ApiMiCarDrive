using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.Migrations
{
    public partial class RemovedPhotoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTS_PHOTOARCHIVE",
                table: "CAR_EVENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_PHOTOARCHIVE",
                table: "USERS");

            migrationBuilder.DropTable(
                name: "PHOTO_PHOTO_ARCHIVE");

            migrationBuilder.DropTable(
                name: "PHOTO_ARCHIVE");

            migrationBuilder.DropTable(
                name: "PHOTO");

            migrationBuilder.DropIndex(
                name: "IX_USERS_PHOTO_ARCHIVE_ID",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_CAR_EVENTS_PHOTO_ARCHIVE_ID",
                table: "CAR_EVENTS");

            migrationBuilder.DropColumn(
                name: "PHOTO_ARCHIVE_ID",
                table: "USERS");

            migrationBuilder.AddColumn<string>(
                name: "PHOTO_PATH",
                table: "USERS",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PHOTO_PATH",
                table: "USERS");

            migrationBuilder.AddColumn<Guid>(
                name: "PHOTO_ARCHIVE_ID",
                table: "USERS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PHOTO",
                columns: table => new
                {
                    PHOTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EXPANSION = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHOTO", x => x.PHOTO_ID);
                });

            migrationBuilder.CreateTable(
                name: "PHOTO_ARCHIVE",
                columns: table => new
                {
                    PHOTO_ARCHIVE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PATH = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHOTO_ARCHIVE", x => x.PHOTO_ARCHIVE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PHOTO_PHOTO_ARCHIVE",
                columns: table => new
                {
                    PHOTO_ARCHIVE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PHOTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHOTO_PHOTOARCHIVE", x => new { x.PHOTO_ARCHIVE_ID, x.PHOTO_ID });
                    table.ForeignKey(
                        name: "FK_PHOTO_PHOTOARCHIVE_PHOTO",
                        column: x => x.PHOTO_ARCHIVE_ID,
                        principalTable: "PHOTO_ARCHIVE",
                        principalColumn: "PHOTO_ARCHIVE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE",
                        column: x => x.PHOTO_ID,
                        principalTable: "PHOTO",
                        principalColumn: "PHOTO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_PHOTO_ARCHIVE_ID",
                table: "USERS",
                column: "PHOTO_ARCHIVE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_EVENTS_PHOTO_ARCHIVE_ID",
                table: "CAR_EVENTS",
                column: "PHOTO_ARCHIVE_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__PHOTO_AR__5985D08DF3D30FB3",
                table: "PHOTO_ARCHIVE",
                column: "PATH",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PHOTO_PHOTO_ARCHIVE_PHOTO_ID",
                table: "PHOTO_PHOTO_ARCHIVE",
                column: "PHOTO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTS_PHOTOARCHIVE",
                table: "CAR_EVENTS",
                column: "PHOTO_ARCHIVE_ID",
                principalTable: "PHOTO_ARCHIVE",
                principalColumn: "PHOTO_ARCHIVE_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_PHOTOARCHIVE",
                table: "USERS",
                column: "PHOTO_ARCHIVE_ID",
                principalTable: "PHOTO_ARCHIVE",
                principalColumn: "PHOTO_ARCHIVE_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
