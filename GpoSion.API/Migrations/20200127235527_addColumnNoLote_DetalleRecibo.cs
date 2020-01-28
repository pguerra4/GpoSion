using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class addColumnNoLote_DetalleRecibo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoLote",
                table: "DetalleRecibos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoLote",
                table: "DetalleRecibos");
        }
    }
}
