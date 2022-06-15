using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProvider.Server.Data.Migrations
{
    public partial class RemovedRatingColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Services",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
