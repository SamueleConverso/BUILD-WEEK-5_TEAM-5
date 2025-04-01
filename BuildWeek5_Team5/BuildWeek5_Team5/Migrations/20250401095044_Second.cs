using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildWeek5_Team5.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ricoveri_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Ricoveri");

            migrationBuilder.DropForeignKey(
                name: "FK_Ricoveri_Animali_AnimaleId",
                table: "Ricoveri");

            migrationBuilder.DropIndex(
                name: "IX_Ricoveri_AnimaleId",
                table: "Ricoveri");

            migrationBuilder.DropIndex(
                name: "IX_Ricoveri_AnimaleSmarritoId",
                table: "Ricoveri");

            migrationBuilder.CreateIndex(
                name: "IX_Ricoveri_AnimaleId",
                table: "Ricoveri",
                column: "AnimaleId",
                unique: true,
                filter: "[AnimaleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ricoveri_AnimaleSmarritoId",
                table: "Ricoveri",
                column: "AnimaleSmarritoId",
                unique: true,
                filter: "[AnimaleSmarritoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnimaliSmarriti_NumeroMicrochip",
                table: "AnimaliSmarriti",
                column: "NumeroMicrochip",
                unique: true,
                filter: "[NumeroMicrochip] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Animali_NumeroMicrochip",
                table: "Animali",
                column: "NumeroMicrochip",
                unique: true,
                filter: "[NumeroMicrochip] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Ricoveri_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Ricoveri",
                column: "AnimaleSmarritoId",
                principalTable: "AnimaliSmarriti",
                principalColumn: "AnimaleSmarritoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ricoveri_Animali_AnimaleId",
                table: "Ricoveri",
                column: "AnimaleId",
                principalTable: "Animali",
                principalColumn: "AnimaleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ricoveri_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Ricoveri");

            migrationBuilder.DropForeignKey(
                name: "FK_Ricoveri_Animali_AnimaleId",
                table: "Ricoveri");

            migrationBuilder.DropIndex(
                name: "IX_Ricoveri_AnimaleId",
                table: "Ricoveri");

            migrationBuilder.DropIndex(
                name: "IX_Ricoveri_AnimaleSmarritoId",
                table: "Ricoveri");

            migrationBuilder.DropIndex(
                name: "IX_AnimaliSmarriti_NumeroMicrochip",
                table: "AnimaliSmarriti");

            migrationBuilder.DropIndex(
                name: "IX_Animali_NumeroMicrochip",
                table: "Animali");

            migrationBuilder.CreateIndex(
                name: "IX_Ricoveri_AnimaleId",
                table: "Ricoveri",
                column: "AnimaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ricoveri_AnimaleSmarritoId",
                table: "Ricoveri",
                column: "AnimaleSmarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ricoveri_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Ricoveri",
                column: "AnimaleSmarritoId",
                principalTable: "AnimaliSmarriti",
                principalColumn: "AnimaleSmarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ricoveri_Animali_AnimaleId",
                table: "Ricoveri",
                column: "AnimaleId",
                principalTable: "Animali",
                principalColumn: "AnimaleId");
        }
    }
}
