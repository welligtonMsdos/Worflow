using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worflow.Migrations
{
    /// <inheritdoc />
    public partial class historicoFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Lead_LeadId",
                table: "Historico");

            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Status_StatusId",
                table: "Historico");

            migrationBuilder.AlterColumn<string>(
                name: "Mensagem",
                table: "Historico",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Historico",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Lead_LeadId",
                table: "Historico",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Status_StatusId",
                table: "Historico",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Lead_LeadId",
                table: "Historico");

            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Status_StatusId",
                table: "Historico");

            migrationBuilder.AlterColumn<string>(
                name: "Mensagem",
                table: "Historico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Historico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Lead_LeadId",
                table: "Historico",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Status_StatusId",
                table: "Historico",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
