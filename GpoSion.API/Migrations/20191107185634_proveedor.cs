using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class proveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_DetalleRecibos_Materiales_MaterialId",
            //     table: "DetalleRecibos");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Recibos_Clientes_ClienteId",
            //     table: "Recibos");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Recibos",
                newName: "ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Recibos_ClienteId",
                table: "Recibos",
                newName: "IX_Recibos_ProveedorId");

            migrationBuilder.AddColumn<string>(
                name: "NoLote",
                table: "Recibos",
                nullable: true);

            // migrationBuilder.AlterColumn<int>(
            //     name: "MaterialId",
            //     table: "DetalleRecibos",
            //     nullable: false,
            //     oldClrType: typeof(int),
            //     oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            // migrationBuilder.AddForeignKey(
            //     name: "FK_DetalleRecibos_Materiales_MaterialId",
            //     table: "DetalleRecibos",
            //     column: "MaterialId",
            //     principalTable: "Materiales",
            //     principalColumn: "MaterialId",
            //     onDelete: ReferentialAction.Restrict);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Recibos_Proveedores_ProveedorId",
            //     table: "Recibos",
            //     column: "ProveedorId",
            //     principalTable: "Proveedores",
            //     principalColumn: "ProveedorId",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleRecibos_Materiales_MaterialId",
                table: "DetalleRecibos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibos_Proveedores_ProveedorId",
                table: "Recibos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropColumn(
                name: "NoLote",
                table: "Recibos");

            migrationBuilder.RenameColumn(
                name: "ProveedorId",
                table: "Recibos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Recibos_ProveedorId",
                table: "Recibos",
                newName: "IX_Recibos_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "DetalleRecibos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleRecibos_Materiales_MaterialId",
                table: "DetalleRecibos",
                column: "MaterialId",
                principalTable: "Materiales",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibos_Clientes_ClienteId",
                table: "Recibos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
