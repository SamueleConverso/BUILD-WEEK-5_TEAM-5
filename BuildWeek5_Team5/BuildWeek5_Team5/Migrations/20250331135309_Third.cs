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
            migrationBuilder.DropForeignKey(
                name: "FK_Ricoveri_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Ricoveri");

            migrationBuilder.DropForeignKey(
                name: "FK_Ricoveri_Animali_AnimaleId",
                table: "Ricoveri");

            migrationBuilder.DropForeignKey(
                name: "FK_Visite_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Visite");

            migrationBuilder.DropForeignKey(
                name: "FK_Visite_Animali_AnimaleId",
                table: "Visite");

            migrationBuilder.AlterColumn<int>(
                name: "AnimaleSmarritoId",
                table: "Visite",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimaleId",
                table: "Visite",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RicettaMedica",
                table: "Vendite",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimaleSmarritoId",
                table: "Ricoveri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimaleId",
                table: "Ricoveri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Visite_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Visite",
                column: "AnimaleSmarritoId",
                principalTable: "AnimaliSmarriti",
                principalColumn: "AnimaleSmarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visite_Animali_AnimaleId",
                table: "Visite",
                column: "AnimaleId",
                principalTable: "Animali",
                principalColumn: "AnimaleId");
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

            migrationBuilder.DropForeignKey(
                name: "FK_Visite_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Visite");

            migrationBuilder.DropForeignKey(
                name: "FK_Visite_Animali_AnimaleId",
                table: "Visite");

            migrationBuilder.AlterColumn<int>(
                name: "AnimaleSmarritoId",
                table: "Visite",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimaleId",
                table: "Visite",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RicettaMedica",
                table: "Vendite",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimaleSmarritoId",
                table: "Ricoveri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimaleId",
                table: "Ricoveri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Visite_AnimaliSmarriti_AnimaleSmarritoId",
                table: "Visite",
                column: "AnimaleSmarritoId",
                principalTable: "AnimaliSmarriti",
                principalColumn: "AnimaleSmarritoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visite_Animali_AnimaleId",
                table: "Visite",
                column: "AnimaleId",
                principalTable: "Animali",
                principalColumn: "AnimaleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
