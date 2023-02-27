using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Worflow.Migrations
{
    /// <inheritdoc />
    public partial class CotacaoModulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguradora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguradora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEmissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    SeguradoraId = table.Column<int>(type: "int", nullable: false),
                    LeadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotacao_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotacao_Seguradora_SeguradoraId",
                        column: x => x.SeguradoraId,
                        principalTable: "Seguradora",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Seguradora",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[,]
                {
                    { 1, true, "Catu" },
                    { 2, true, "Itaú" },
                    { 3, true, "Porto Seguro" },
                    { 4, true, "MetLife" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotacao_LeadId",
                table: "Cotacao",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacao_SeguradoraId",
                table: "Cotacao",
                column: "SeguradoraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotacao");

            migrationBuilder.DropTable(
                name: "Seguradora");
        }
    }
}
