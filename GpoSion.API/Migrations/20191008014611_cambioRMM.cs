using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class cambioRMM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_RequerimientoMaterialMateriales_Viajeros_ViajeroId",
            //     table: "RequerimientoMaterialMateriales");

            // migrationBuilder.AlterColumn<int>(
            //     name: "ViajeroId",
            //     table: "RequerimientoMaterialMateriales",
            //     nullable: true,
            //     oldClrType: typeof(int));

            // migrationBuilder.AddForeignKey(
            //     name: "FK_RequerimientoMaterialMateriales_Viajeros_ViajeroId",
            //     table: "RequerimientoMaterialMateriales",
            //     column: "ViajeroId",
            //     principalTable: "Viajeros",
            //     principalColumn: "ViajeroId",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_RequerimientoMaterialMateriales_Viajeros_ViajeroId",
            //     table: "RequerimientoMaterialMateriales");

            // migrationBuilder.AlterColumn<int>(
            //     name: "ViajeroId",
            //     table: "RequerimientoMaterialMateriales",
            //     nullable: false,
            //     oldClrType: typeof(int),
            //     oldNullable: true);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_RequerimientoMaterialMateriales_Viajeros_ViajeroId",
            //     table: "RequerimientoMaterialMateriales",
            //     column: "ViajeroId",
            //     principalTable: "Viajeros",
            //     principalColumn: "ViajeroId",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
