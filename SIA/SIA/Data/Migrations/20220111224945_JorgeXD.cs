using Microsoft.EntityFrameworkCore.Migrations;

namespace SIA.Data.Migrations
{
    public partial class JorgeXD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quadrantes_Tecnicas_TecnicaId",
                table: "Quadrantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quadrantes_Tecnicas_TecnicaId1",
                table: "Quadrantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quadrantes_Tecnicas_TecnicaId2",
                table: "Quadrantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quadrantes_Tecnicas_TecnicaId3",
                table: "Quadrantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilizador_Tecnicas_TecnicaId",
                table: "Utilizador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tecnicas",
                table: "Tecnicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quadrantes",
                table: "Quadrantes");

            migrationBuilder.RenameTable(
                name: "Tecnicas",
                newName: "Tecnica");

            migrationBuilder.RenameTable(
                name: "Quadrantes",
                newName: "Quadrante");

            migrationBuilder.RenameIndex(
                name: "IX_Quadrantes_TecnicaId3",
                table: "Quadrante",
                newName: "IX_Quadrante_TecnicaId3");

            migrationBuilder.RenameIndex(
                name: "IX_Quadrantes_TecnicaId2",
                table: "Quadrante",
                newName: "IX_Quadrante_TecnicaId2");

            migrationBuilder.RenameIndex(
                name: "IX_Quadrantes_TecnicaId1",
                table: "Quadrante",
                newName: "IX_Quadrante_TecnicaId1");

            migrationBuilder.RenameIndex(
                name: "IX_Quadrantes_TecnicaId",
                table: "Quadrante",
                newName: "IX_Quadrante_TecnicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tecnica",
                table: "Tecnica",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quadrante",
                table: "Quadrante",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrante_Tecnica_TecnicaId",
                table: "Quadrante",
                column: "TecnicaId",
                principalTable: "Tecnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrante_Tecnica_TecnicaId1",
                table: "Quadrante",
                column: "TecnicaId1",
                principalTable: "Tecnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrante_Tecnica_TecnicaId2",
                table: "Quadrante",
                column: "TecnicaId2",
                principalTable: "Tecnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrante_Tecnica_TecnicaId3",
                table: "Quadrante",
                column: "TecnicaId3",
                principalTable: "Tecnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizador_Tecnica_TecnicaId",
                table: "Utilizador",
                column: "TecnicaId",
                principalTable: "Tecnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quadrante_Tecnica_TecnicaId",
                table: "Quadrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Quadrante_Tecnica_TecnicaId1",
                table: "Quadrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Quadrante_Tecnica_TecnicaId2",
                table: "Quadrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Quadrante_Tecnica_TecnicaId3",
                table: "Quadrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilizador_Tecnica_TecnicaId",
                table: "Utilizador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tecnica",
                table: "Tecnica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quadrante",
                table: "Quadrante");

            migrationBuilder.RenameTable(
                name: "Tecnica",
                newName: "Tecnicas");

            migrationBuilder.RenameTable(
                name: "Quadrante",
                newName: "Quadrantes");

            migrationBuilder.RenameIndex(
                name: "IX_Quadrante_TecnicaId3",
                table: "Quadrantes",
                newName: "IX_Quadrantes_TecnicaId3");

            migrationBuilder.RenameIndex(
                name: "IX_Quadrante_TecnicaId2",
                table: "Quadrantes",
                newName: "IX_Quadrantes_TecnicaId2");

            migrationBuilder.RenameIndex(
                name: "IX_Quadrante_TecnicaId1",
                table: "Quadrantes",
                newName: "IX_Quadrantes_TecnicaId1");

            migrationBuilder.RenameIndex(
                name: "IX_Quadrante_TecnicaId",
                table: "Quadrantes",
                newName: "IX_Quadrantes_TecnicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tecnicas",
                table: "Tecnicas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quadrantes",
                table: "Quadrantes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrantes_Tecnicas_TecnicaId",
                table: "Quadrantes",
                column: "TecnicaId",
                principalTable: "Tecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrantes_Tecnicas_TecnicaId1",
                table: "Quadrantes",
                column: "TecnicaId1",
                principalTable: "Tecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrantes_Tecnicas_TecnicaId2",
                table: "Quadrantes",
                column: "TecnicaId2",
                principalTable: "Tecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrantes_Tecnicas_TecnicaId3",
                table: "Quadrantes",
                column: "TecnicaId3",
                principalTable: "Tecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizador_Tecnicas_TecnicaId",
                table: "Utilizador",
                column: "TecnicaId",
                principalTable: "Tecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
