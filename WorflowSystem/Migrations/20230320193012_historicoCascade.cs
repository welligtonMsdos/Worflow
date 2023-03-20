using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worflow.Migrations
{
    /// <inheritdoc />
    public partial class historicoCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Lead_LeadId",
                table: "Historico");

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Lead_LeadId",
                table: "Historico",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Lead_LeadId",
                table: "Historico");

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Lead_LeadId",
                table: "Historico",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id");
        }
    }
}
