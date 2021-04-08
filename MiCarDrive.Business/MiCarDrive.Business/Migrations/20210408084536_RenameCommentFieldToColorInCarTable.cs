using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.Migrations
{
    public partial class RenameCommentFieldToColorInCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COMMENT",
                table: "CARS",
                newName: "COLOR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COLOR",
                table: "CARS",
                newName: "COMMENT");
        }
    }
}
