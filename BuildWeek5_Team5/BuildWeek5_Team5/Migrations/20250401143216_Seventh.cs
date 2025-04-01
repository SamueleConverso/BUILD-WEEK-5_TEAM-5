using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildWeek5_Team5.Migrations
{
    /// <inheritdoc />
    public partial class Seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmadiettiCassetti");

            migrationBuilder.AddColumn<int>(
                name: "ArmadiettoId",
                table: "Cassetti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cassetti_ArmadiettoId",
                table: "Cassetti",
                column: "ArmadiettoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cassetti_Armadietti_ArmadiettoId",
                table: "Cassetti",
                column: "ArmadiettoId",
                principalTable: "Armadietti",
                principalColumn: "ArmadiettoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cassetti_Armadietti_ArmadiettoId",
                table: "Cassetti");

            migrationBuilder.DropIndex(
                name: "IX_Cassetti_ArmadiettoId",
                table: "Cassetti");

            migrationBuilder.DropColumn(
                name: "ArmadiettoId",
                table: "Cassetti");

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
                name: "IX_ArmadiettiCassetti_ArmadiettoId",
                table: "ArmadiettiCassetti",
                column: "ArmadiettoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmadiettiCassetti_CassettoId",
                table: "ArmadiettiCassetti",
                column: "CassettoId");
        }
    }
}
