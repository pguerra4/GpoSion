using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class cambioMovimientosMaterialAddRMM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequerimientoMaterialMaterialId",
                table: "MovimientosMaterial",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_RequerimientoMaterialMaterialId",
                table: "MovimientosMaterial",
                column: "RequerimientoMaterialMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MM_RMM_RMMId",
                table: "MovimientosMaterial",
                column: "RequerimientoMaterialMaterialId",
                principalTable: "RequerimientoMaterialMateriales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MM_RMM_RMMId",
                table: "MovimientosMaterial");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosMaterial_RequerimientoMaterialMaterialId",
                table: "MovimientosMaterial");

            migrationBuilder.DropColumn(
                name: "RequerimientoMaterialMaterialId",
                table: "MovimientosMaterial");
        }
    }
}
