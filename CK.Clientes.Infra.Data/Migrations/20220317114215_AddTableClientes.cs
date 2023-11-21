using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Octoplex.Clientes.Infra.Data.Migrations
{
    public partial class AddTableClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lanca = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    CnpjCpf = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    IeRg = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodCidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EnviaEmail = table.Column<int>(type: "int", nullable: false),
                    Suframa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pontos = table.Column<double>(type: "float", nullable: false),
                    Convenio = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    TipoCadastro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credito = table.Column<double>(type: "float", nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VencimentoFixo = table.Column<int>(type: "int", nullable: false),
                    IndicadorIE = table.Column<int>(type: "int", nullable: false),
                    GuidIntegracaoNet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
