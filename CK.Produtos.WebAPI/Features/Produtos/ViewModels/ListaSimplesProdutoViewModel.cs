using Octoplex.Impostos.Domain.Impostos;

namespace Octoplex.Produtos.WebAPI.Features.Produtos.ViewModels
{
    public class ListaSimplesProdutoViewModel
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Un { get; set; }
        public double Vrvista { get; set; }
        public double Estq { get; set; }
        public virtual ICollection<Imposto> Impostos { get; set; }
    }
}
