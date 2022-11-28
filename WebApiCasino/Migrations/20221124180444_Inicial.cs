using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCasino.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rifas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rifas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Premio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipanteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Premio_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cartas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipanteId = table.Column<int>(type: "int", nullable: true),
                    RifaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartas_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cartas_Rifas_RifaId",
                        column: x => x.RifaId,
                        principalTable: "Rifas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParticipanteRifa",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    RifaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipanteRifa", x => new { x.ParticipanteId, x.RifaId });
                    table.ForeignKey(
                        name: "FK_ParticipanteRifa_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipanteRifa_Rifas_RifaId",
                        column: x => x.RifaId,
                        principalTable: "Rifas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PremioRifa",
                columns: table => new
                {
                    PremioId = table.Column<int>(type: "int", nullable: false),
                    RifaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremioRifa", x => new { x.PremioId, x.RifaId });
                    table.ForeignKey(
                        name: "FK_PremioRifa_Premio_PremioId",
                        column: x => x.PremioId,
                        principalTable: "Premio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PremioRifa_Rifas_RifaId",
                        column: x => x.RifaId,
                        principalTable: "Rifas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_ParticipanteId",
                table: "Cartas",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_RifaId",
                table: "Cartas",
                column: "RifaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipanteRifa_RifaId",
                table: "ParticipanteRifa",
                column: "RifaId");

            migrationBuilder.CreateIndex(
                name: "IX_Premio_ParticipanteId",
                table: "Premio",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_PremioRifa_RifaId",
                table: "PremioRifa",
                column: "RifaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartas");

            migrationBuilder.DropTable(
                name: "ParticipanteRifa");

            migrationBuilder.DropTable(
                name: "PremioRifa");

            migrationBuilder.DropTable(
                name: "Premio");

            migrationBuilder.DropTable(
                name: "Rifas");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
