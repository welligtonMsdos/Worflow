using Microsoft.EntityFrameworkCore.Migrations;

namespace Worflow.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SegmentoId",
                table: "Lead",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lead_SegmentoId",
                table: "Lead",
                column: "SegmentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_Segmento_SegmentoId",
                table: "Lead",
                column: "SegmentoId",
                principalTable: "Segmento",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_Segmento_SegmentoId",
                table: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Lead_SegmentoId",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "SegmentoId",
                table: "Lead");
        }
    }
}
