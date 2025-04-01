using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildWeek5_Team5.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodotti_Armadietti_ArmadiettoId",
                table: "Prodotti");

            migrationBuilder.DropIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti");

            migrationBuilder.DropColumn(
                name: "ArmadiettoId",
                table: "Prodotti");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArmadiettoId",
                table: "Prodotti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti",
                column: "ArmadiettoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prodotti_Armadietti_ArmadiettoId",
                table: "Prodotti",
                column: "ArmadiettoId",
                principalTable: "Armadietti",
                principalColumn: "ArmadiettoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
