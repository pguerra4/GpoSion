using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class CampoLocalidadViajero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<string>(
            //     name: "Localidad",
            //     table: "Viajeros",
            //     nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Viajeros");
        }
    }
}
