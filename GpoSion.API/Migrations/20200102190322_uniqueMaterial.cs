using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class uniqueMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Materiales",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_ClaveMaterial",
                table: "Materiales",
                column: "Material");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_ClaveMaterial",
                table: "Materiales");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Materiales",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
