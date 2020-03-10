using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class errorAjusteInventariProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AjustesInventarioProductos_AspNetUsers_CreadorPorId",
                table: "AjustesInventarioProductos");

            migrationBuilder.DropIndex(
                name: "IX_AjustesInventarioProductos_CreadorPorId",
                table: "AjustesInventarioProductos");

            migrationBuilder.DropColumn(
                name: "CreadorPorId",
                table: "AjustesInventarioProductos");

            migrationBuilder.AlterColumn<string>(
                name: "CreadoPorId",
                table: "AjustesInventarioProductos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventarioProductos_CreadoPorId",
                table: "AjustesInventarioProductos",
                column: "CreadoPorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AjustesInventarioProductos_AspNetUsers_CreadoPorId",
                table: "AjustesInventarioProductos",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AjustesInventarioProductos_AspNetUsers_CreadoPorId",
                table: "AjustesInventarioProductos");

            migrationBuilder.DropIndex(
                name: "IX_AjustesInventarioProductos_CreadoPorId",
                table: "AjustesInventarioProductos");

            migrationBuilder.AlterColumn<string>(
                name: "CreadoPorId",
                table: "AjustesInventarioProductos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadorPorId",
                table: "AjustesInventarioProductos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventarioProductos_CreadorPorId",
                table: "AjustesInventarioProductos",
                column: "CreadorPorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AjustesInventarioProductos_AspNetUsers_CreadorPorId",
                table: "AjustesInventarioProductos",
                column: "CreadorPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
