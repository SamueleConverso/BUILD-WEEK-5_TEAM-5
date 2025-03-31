using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildWeek5_Team5.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataVisita",
                table: "Visite",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataVisita",
                table: "Visite",
                type: "date",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
