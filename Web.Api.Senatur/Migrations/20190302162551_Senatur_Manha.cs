using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai.Web.Api.Senatur.Migrations
{
    public partial class Senatur_Manha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PACOTES",
                columns: table => new
                {
                    PacoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PacoteNome = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataIda = table.Column<DateTime>(type: "DATE", nullable: false),
                    DataVolta = table.Column<DateTime>(type: "DATE", nullable: false),
                    NomeCidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<decimal>(type: "MONEY", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACOTES", x => x.PacoteId);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(250)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PACOTES");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
