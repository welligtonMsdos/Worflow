using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worflow.Migrations
{
    /// <inheritdoc />
    public partial class CotacaoModuloAjustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotacao_Seguradora_SeguradoraId",
                table: "Cotacao");

            migrationBuilder.AddColumn<bool>(
                name: "StatusFinalizada",
                table: "Cotacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Cotacao_Seguradora_SeguradoraId",
                table: "Cotacao",
                column: "SeguradoraId",
                principalTable: "Seguradora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotacao_Seguradora_SeguradoraId",
                table: "Cotacao");

            migrationBuilder.DropColumn(
                name: "StatusFinalizada",
                table: "Cotacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotacao_Seguradora_SeguradoraId",
                table: "Cotacao",
                column: "SeguradoraId",
                principalTable: "Seguradora",
                principalColumn: "Id");
        }
    }
}
