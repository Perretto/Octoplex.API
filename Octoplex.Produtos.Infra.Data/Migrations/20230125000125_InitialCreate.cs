using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Octoplex.Produtos.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Impostos",
                columns: table => new
                {
                    IdImposto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Cest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cfop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ncm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CstIcms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AliqIcms = table.Column<double>(type: "float", nullable: false),
                    Csosn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CstIpi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AliqIpi = table.Column<double>(type: "float", nullable: false),
                    CstPis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AliqPis = table.Column<double>(type: "float", nullable: false),
                    CstCofins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AliqCofins = table.Column<double>(type: "float", nullable: false),
                    CodigoSefaz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IbptAliq = table.Column<double>(type: "float", nullable: false),
                    CodigoUf = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impostos", x => x.IdImposto);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ValorCompra = table.Column<double>(type: "float", nullable: false),
                    ValorVenda = table.Column<double>(type: "float", nullable: false),
                    Un = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estoque = table.Column<double>(type: "float", nullable: false),
                    Lucro = table.Column<double>(type: "float", nullable: false),
                    DtUltvenda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valultvenda = table.Column<double>(type: "float", nullable: false),
                    CodGru = table.Column<int>(type: "int", nullable: false),
                    EstMin = table.Column<double>(type: "float", nullable: false),
                    idFornecedor1 = table.Column<int>(type: "int", nullable: false),
                    idFornecedor2 = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idEmpresa = table.Column<int>(type: "int", nullable: false),
                    ValorA = table.Column<double>(type: "float", nullable: false),
                    ValorB = table.Column<double>(type: "float", nullable: false),
                    IniPromo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FimPromo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balanca = table.Column<bool>(type: "bit", nullable: false),
                    TeclaBalanca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoNoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImprimeCozinha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuidIntegracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivForn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoAnp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpostoIdImposto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Impostos_ImpostoIdImposto",
                        column: x => x.ImpostoIdImposto,
                        principalTable: "Impostos",
                        principalColumn: "IdImposto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Impostos_ProdutoId",
                table: "Impostos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ImpostoIdImposto",
                table: "Produtos",
                column: "ImpostoIdImposto");

            migrationBuilder.AddForeignKey(
                name: "FK_Impostos_Produtos_ProdutoId",
                table: "Impostos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impostos_Produtos_ProdutoId",
                table: "Impostos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Impostos");
        }
    }
}
