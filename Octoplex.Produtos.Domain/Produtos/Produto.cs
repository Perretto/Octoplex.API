using Octoplex.Impostos.Domain.Impostos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Domain.Produtos
{
    public class Produto
    {
        public Produto()
        {
            Impostos = new List<Imposto>(); //160123
            Imposto = new Imposto();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double Vrcompra { get; set; }
        public double Vrvista { get; set; }
        public string Un { get; set; }
        public string Validade { get; set; }
        public double Estq { get; set; }
        public double Lucro { get; set; }
        public string DtUltvenda { get; set; }
        public double Valultvenda { get; set; }
        public int CodGru { get; set; }
        public double EstMin { get; set; }
        public int Forn1 { get; set; }
        public int Forn2 { get; set; }
        public string Status { get; set; }
        public int IdEmp { get; set; }
        public double ValorA { get; set; }
        public double ValorB { get; set; }
        public string IniPromo { get; set; }
        public string FimPromo { get; set; }
        public bool Balanca { get; set; }
        public string TeclaB { get; set; }
        public string CodPf { get; set; }
        public string ImpCoz { get; set; }
        public string Guid { get; set; }
        public string Tipo { get; set; }
        public string DivForn { get; set; }
        public string DtAlt { get; set; }
        public string Codigoanp { get; set; }

        //IMPOSTOS
        //public virtual Imposto Impostos { get; set; }
        public virtual Imposto Imposto { get; set; }
        public ICollection<Imposto> Impostos { get; set; }

        //Comentado 160123
        //public List<Imposto> ListarImpostos(int idProduto = 0) => Impostos.Where(i => i.IdProduto == idProduto).ToList();

        public void ListarPorGrupo(int codGrupo) => CodGru = codGrupo;

        public void GetDataUltimaVenda(string dataUltimaVenda) => DtUltvenda = dataUltimaVenda;

        public void ListarPorFornecedor(int idFornecedor) => Forn1 = idFornecedor;
    }
}
