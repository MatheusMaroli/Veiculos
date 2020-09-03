using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Veiculos.Dominio.Migrations
{
    public partial class CriacaoBancoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Deletado = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Deletado = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modelos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Deletado = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    IdMarca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modelos_marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Deletado = table.Column<string>(nullable: true),
                    IdModelo = table.Column<int>(nullable: false),
                    IdMarca = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    ValorCompra = table.Column<double>(nullable: false),
                    ValorVenda = table.Column<double>(nullable: false),
                    Cor = table.Column<string>(nullable: false),
                    TipoCombustivel = table.Column<string>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anuncios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_anuncios_marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_anuncios_modelos_IdModelo",
                        column: x => x.IdModelo,
                        principalTable: "modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_anuncios_IdMarca",
                table: "anuncios",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_anuncios_IdModelo",
                table: "anuncios",
                column: "IdModelo");

            migrationBuilder.CreateIndex(
                name: "IX_modelos_IdMarca",
                table: "modelos",
                column: "IdMarca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anuncios");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "modelos");

            migrationBuilder.DropTable(
                name: "marcas");
        }
    }
}
