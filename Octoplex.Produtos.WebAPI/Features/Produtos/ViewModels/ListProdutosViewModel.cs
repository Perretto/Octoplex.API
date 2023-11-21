using Octoplex.Impostos.Domain.Impostos;
using System.Collections.Generic;

namespace Octoplex.Produtos.WebAPI.Features.Produtos.ViewModels
{
    public class ListProdutosViewModel
    {
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
        public virtual ICollection<Imposto> Impostos { get; set; }
    }
}
