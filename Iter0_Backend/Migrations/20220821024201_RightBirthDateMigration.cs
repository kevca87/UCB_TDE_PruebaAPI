using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iter0_Backend.Migrations
{
    public partial class RightBirthDateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Kids",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Kids",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Kids",
                newName: "Birthdate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "Kids",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
