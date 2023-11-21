using Microsoft.EntityFrameworkCore.Migrations;

namespace Octoplex.Impostos.Infra.Data.Migrations
{
    public partial class AddTabelaImpostos : Migration
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
                    CodigoUf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impostos", x => x.IdImposto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impostos");
        }
    }
}
