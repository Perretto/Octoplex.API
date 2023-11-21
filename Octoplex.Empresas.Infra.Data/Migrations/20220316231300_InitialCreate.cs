using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Octoplex.Empresas.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CpfCnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IeRg = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    InscMunicipal = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    RegimeTributario = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    ChavePrivada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
