using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Produtos.Domain.Produtos;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Octoplex.Produtos.Domain.Produtos.DTO
{
    public class ProdutosDTO
    {
        public ProdutosDTO()
        {
            Impostos = new List<Imposto>();
        }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Un { get; set; }
        public double Vrvista { get; set; }
        public double Estq { get; set; }
        public virtual ICollection<Imposto> Impostos { get; set; }
    }
}
