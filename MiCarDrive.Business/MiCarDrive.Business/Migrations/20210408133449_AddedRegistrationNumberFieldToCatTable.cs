using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.Migrations
{
    public partial class AddedRegistrationNumberFieldToCatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "REGISTRATION_NUMBER",
                table: "CARS",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REGISTRATION_NUMBER",
                table: "CARS");
        }
    }
}
