using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class makeDisparosMoldeadoraNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PlaneacionProduccion_año_NoParte_semana",
                table: "PlaneacionProduccion");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CreadoPorId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "DisparosPorHora",
                table: "Moldeadoras",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPorId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreadoPorId",
                table: "AspNetUsers",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ModificadoPorId",
                table: "AspNetUsers",
                column: "ModificadoPorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ModificadoPorId",
                table: "AspNetUsers",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ModificadoPorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CreadoPorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ModificadoPorId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "DisparosPorHora",
                table: "Moldeadoras",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPorId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlaneacionProduccion_año_NoParte_semana",
                table: "PlaneacionProduccion",
                columns: new[] { "año", "NoParte", "semana" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreadoPorId",
                table: "AspNetUsers",
                column: "CreadoPorId",
                unique: true,
                filter: "[CreadoPorId] IS NOT NULL");
        }
    }
}
