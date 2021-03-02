using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class ColumnViajeroExistenciaProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExistenciaProduccion",
                table: "Viajeros",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExistenciaProduccion",
                table: "Viajeros");
        }
    }
}
