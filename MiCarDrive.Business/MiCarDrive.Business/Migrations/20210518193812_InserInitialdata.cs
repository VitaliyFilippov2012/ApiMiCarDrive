using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.Migrations
{
    public partial class InserInitialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Resource.InsertInitialData);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
