using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worflow.Migrations
{
    /// <inheritdoc />
    public partial class EventAjustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Event",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Event",
                newName: "End");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Event",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Event",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
