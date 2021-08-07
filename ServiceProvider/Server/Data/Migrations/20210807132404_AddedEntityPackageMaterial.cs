using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProvider.Server.Data.Migrations
{
    public partial class AddedEntityPackageMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Packages_PackageId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_PackageId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Materials");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PackageMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageMaterials_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageMaterials_MaterialId",
                table: "PackageMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageMaterials_PackageId",
                table: "PackageMaterials",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageMaterials");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_PackageId",
                table: "Materials",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Packages_PackageId",
                table: "Materials",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
