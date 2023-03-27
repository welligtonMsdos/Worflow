using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worflow.Migrations
{
    /// <inheritdoc />
    public partial class AnexoAjustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "Anexo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Anexo_LeadId",
                table: "Anexo",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anexo_Lead_LeadId",
                table: "Anexo",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexo_Lead_LeadId",
                table: "Anexo");

            migrationBuilder.DropIndex(
                name: "IX_Anexo_LeadId",
                table: "Anexo");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Anexo");
        }
    }
}
