using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class EstatusMolde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstatusMoldeId",
                table: "Moldes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moldes_EstatusMoldeId",
                table: "Moldes",
                column: "EstatusMoldeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moldes_EstatusMolde_EstatusMoldeId",
                table: "Moldes",
                column: "EstatusMoldeId",
                principalTable: "EstatusMolde",
                principalColumn: "EstatusMoldeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moldes_EstatusMolde_EstatusMoldeId",
                table: "Moldes");

            migrationBuilder.DropIndex(
                name: "IX_Moldes_EstatusMoldeId",
                table: "Moldes");

            migrationBuilder.DropColumn(
                name: "EstatusMoldeId",
                table: "Moldes");
        }
    }
}
