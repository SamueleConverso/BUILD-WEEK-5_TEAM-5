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
            migrationBuilder.DropIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti");

            migrationBuilder.DropColumn(
                name: "Cassetto",
                table: "Armadietti");

            migrationBuilder.AddColumn<int>(
                name: "CassettoId",
                table: "Prodotti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cassetti",
                columns: table => new
                {
                    CassettoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCassetto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cassetti", x => x.CassettoId);
                });

            migrationBuilder.CreateTable(
                name: "ArmadiettiCassetti",
                columns: table => new
                {
                    ArmadiettoCassettoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmadiettoId = table.Column<int>(type: "int", nullable: false),
                    CassettoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmadiettiCassetti", x => x.ArmadiettoCassettoId);
                    table.ForeignKey(
                        name: "FK_ArmadiettiCassetti_Armadietti_ArmadiettoId",
                        column: x => x.ArmadiettoId,
                        principalTable: "Armadietti",
                        principalColumn: "ArmadiettoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmadiettiCassetti_Cassetti_CassettoId",
                        column: x => x.CassettoId,
                        principalTable: "Cassetti",
                        principalColumn: "CassettoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti",
                column: "ArmadiettoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_CassettoId",
                table: "Prodotti",
                column: "CassettoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmadiettiCassetti_ArmadiettoId",
                table: "ArmadiettiCassetti",
                column: "ArmadiettoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmadiettiCassetti_CassettoId",
                table: "ArmadiettiCassetti",
                column: "CassettoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodotti_Cassetti_CassettoId",
                table: "Prodotti",
                column: "CassettoId",
                principalTable: "Cassetti",
                principalColumn: "CassettoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodotti_Cassetti_CassettoId",
                table: "Prodotti");

            migrationBuilder.DropTable(
                name: "ArmadiettiCassetti");

            migrationBuilder.DropTable(
                name: "Cassetti");

            migrationBuilder.DropIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti");

            migrationBuilder.DropIndex(
                name: "IX_Prodotti_CassettoId",
                table: "Prodotti");

            migrationBuilder.DropColumn(
                name: "CassettoId",
                table: "Prodotti");

            migrationBuilder.AddColumn<int>(
                name: "Cassetto",
                table: "Armadietti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti",
                column: "ArmadiettoId");
        }
    }
}
