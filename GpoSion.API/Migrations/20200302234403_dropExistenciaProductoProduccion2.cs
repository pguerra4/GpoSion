using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class dropExistenciaProductoProduccion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciaProductoProduccion_AspNetUsers_CreadoPorId",
                table: "ExistenciaProductoProduccion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciaProductoProduccion_AspNetUsers_ModificadoPorId",
                table: "ExistenciaProductoProduccion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciaProductoProduccion_NumerosParte_NoParte",
                table: "ExistenciaProductoProduccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExistenciaProductoProduccion",
                table: "ExistenciaProductoProduccion");

            migrationBuilder.RenameTable(
                name: "ExistenciaProductoProduccion",
                newName: "ExistenciasProductoProduccion");

            migrationBuilder.RenameIndex(
                name: "IX_ExistenciaProductoProduccion_NoParte",
                table: "ExistenciasProductoProduccion",
                newName: "IX_ExistenciasProductoProduccion_NoParte");

            migrationBuilder.RenameIndex(
                name: "IX_ExistenciaProductoProduccion_ModificadoPorId",
                table: "ExistenciasProductoProduccion",
                newName: "IX_ExistenciasProductoProduccion_ModificadoPorId");

            migrationBuilder.RenameIndex(
                name: "IX_ExistenciaProductoProduccion_CreadoPorId",
                table: "ExistenciasProductoProduccion",
                newName: "IX_ExistenciasProductoProduccion_CreadoPorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExistenciasProductoProduccion",
                table: "ExistenciasProductoProduccion",
                column: "ExistenciaProductoProduccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasProductoProduccion_AspNetUsers_CreadoPorId",
                table: "ExistenciasProductoProduccion",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasProductoProduccion_AspNetUsers_ModificadoPorId",
                table: "ExistenciasProductoProduccion",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasProductoProduccion_NumerosParte_NoParte",
                table: "ExistenciasProductoProduccion",
                column: "NoParte",
                principalTable: "NumerosParte",
                principalColumn: "NoParte",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasProductoProduccion_AspNetUsers_CreadoPorId",
                table: "ExistenciasProductoProduccion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasProductoProduccion_AspNetUsers_ModificadoPorId",
                table: "ExistenciasProductoProduccion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasProductoProduccion_NumerosParte_NoParte",
                table: "ExistenciasProductoProduccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExistenciasProductoProduccion",
                table: "ExistenciasProductoProduccion");

            migrationBuilder.RenameTable(
                name: "ExistenciasProductoProduccion",
                newName: "ExistenciaProductoProduccion");

            migrationBuilder.RenameIndex(
                name: "IX_ExistenciasProductoProduccion_NoParte",
                table: "ExistenciaProductoProduccion",
                newName: "IX_ExistenciaProductoProduccion_NoParte");

            migrationBuilder.RenameIndex(
                name: "IX_ExistenciasProductoProduccion_ModificadoPorId",
                table: "ExistenciaProductoProduccion",
                newName: "IX_ExistenciaProductoProduccion_ModificadoPorId");

            migrationBuilder.RenameIndex(
                name: "IX_ExistenciasProductoProduccion_CreadoPorId",
                table: "ExistenciaProductoProduccion",
                newName: "IX_ExistenciaProductoProduccion_CreadoPorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExistenciaProductoProduccion",
                table: "ExistenciaProductoProduccion",
                column: "ExistenciaProductoProduccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciaProductoProduccion_AspNetUsers_CreadoPorId",
                table: "ExistenciaProductoProduccion",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciaProductoProduccion_AspNetUsers_ModificadoPorId",
                table: "ExistenciaProductoProduccion",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciaProductoProduccion_NumerosParte_NoParte",
                table: "ExistenciaProductoProduccion",
                column: "NoParte",
                principalTable: "NumerosParte",
                principalColumn: "NoParte",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
