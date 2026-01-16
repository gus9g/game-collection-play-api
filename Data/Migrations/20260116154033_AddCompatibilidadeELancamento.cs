using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCollectionPlayApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompatibilidadeELancamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompatibilidadeNotebookGamerAtualId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompatibilidadePcGamerAtualId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLancamento",
                table: "Game",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DescricaoAdicional",
                table: "Game",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "LancamentoFlagId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompatibilidadeNotebookGamerAtual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatibilidadeNotebookGamerAtual", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompatibilidadePcGamerAtual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatibilidadePcGamerAtual", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LancamentoFlag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoFlag", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Game_CompatibilidadeNotebookGamerAtualId",
                table: "Game",
                column: "CompatibilidadeNotebookGamerAtualId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_CompatibilidadePcGamerAtualId",
                table: "Game",
                column: "CompatibilidadePcGamerAtualId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_LancamentoFlagId",
                table: "Game",
                column: "LancamentoFlagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_CompatibilidadeNotebookGamerAtual_CompatibilidadeNotebo~",
                table: "Game",
                column: "CompatibilidadeNotebookGamerAtualId",
                principalTable: "CompatibilidadeNotebookGamerAtual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_CompatibilidadePcGamerAtual_CompatibilidadePcGamerAtual~",
                table: "Game",
                column: "CompatibilidadePcGamerAtualId",
                principalTable: "CompatibilidadePcGamerAtual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_LancamentoFlag_LancamentoFlagId",
                table: "Game",
                column: "LancamentoFlagId",
                principalTable: "LancamentoFlag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_CompatibilidadeNotebookGamerAtual_CompatibilidadeNotebo~",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_CompatibilidadePcGamerAtual_CompatibilidadePcGamerAtual~",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_LancamentoFlag_LancamentoFlagId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "CompatibilidadeNotebookGamerAtual");

            migrationBuilder.DropTable(
                name: "CompatibilidadePcGamerAtual");

            migrationBuilder.DropTable(
                name: "LancamentoFlag");

            migrationBuilder.DropIndex(
                name: "IX_Game_CompatibilidadeNotebookGamerAtualId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_CompatibilidadePcGamerAtualId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_LancamentoFlagId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CompatibilidadeNotebookGamerAtualId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CompatibilidadePcGamerAtualId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "DataLancamento",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "DescricaoAdicional",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "LancamentoFlagId",
                table: "Game");
        }
    }
}
