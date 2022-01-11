using Microsoft.EntityFrameworkCore.Migrations;

namespace SIA.Data.Migrations
{
    public partial class JorgeOP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TecnicaId",
                table: "Utilizador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tecnicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quadrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pontuacao = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TecnicaId = table.Column<int>(type: "int", nullable: true),
                    TecnicaId1 = table.Column<int>(type: "int", nullable: true),
                    TecnicaId2 = table.Column<int>(type: "int", nullable: true),
                    TecnicaId3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadrantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quadrantes_Tecnicas_TecnicaId",
                        column: x => x.TecnicaId,
                        principalTable: "Tecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quadrantes_Tecnicas_TecnicaId1",
                        column: x => x.TecnicaId1,
                        principalTable: "Tecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quadrantes_Tecnicas_TecnicaId2",
                        column: x => x.TecnicaId2,
                        principalTable: "Tecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quadrantes_Tecnicas_TecnicaId3",
                        column: x => x.TecnicaId3,
                        principalTable: "Tecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilizador_TecnicaId",
                table: "Utilizador",
                column: "TecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Quadrantes_TecnicaId",
                table: "Quadrantes",
                column: "TecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Quadrantes_TecnicaId1",
                table: "Quadrantes",
                column: "TecnicaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Quadrantes_TecnicaId2",
                table: "Quadrantes",
                column: "TecnicaId2");

            migrationBuilder.CreateIndex(
                name: "IX_Quadrantes_TecnicaId3",
                table: "Quadrantes",
                column: "TecnicaId3");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizador_Tecnicas_TecnicaId",
                table: "Utilizador",
                column: "TecnicaId",
                principalTable: "Tecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilizador_Tecnicas_TecnicaId",
                table: "Utilizador");

            migrationBuilder.DropTable(
                name: "Quadrantes");

            migrationBuilder.DropTable(
                name: "Tecnicas");

            migrationBuilder.DropIndex(
                name: "IX_Utilizador_TecnicaId",
                table: "Utilizador");

            migrationBuilder.DropColumn(
                name: "TecnicaId",
                table: "Utilizador");
        }
    }
}
