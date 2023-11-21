namespace Octoplex.Impostos.WebAPI.Features.Impostos.ViewModels
{
    public class ImpostoViewModel
    {
        public int IdProduto { get; set; }
        public int IdImposto { get; set; }
        public string Cest { get; set; }
        public string Cfop { get; set; }
        public string Ncm { get; set; }
        public string Origem { get; set; }
        public string CstIcms { get; set; }
        public double AliqIcms { get; set; }
        public string Csosn { get; set; }
        public string CstIpi { get; set; }
        public double AliqIpi { get; set; }
        public string CstPis { get; set; }
        public double AliqPis { get; set; }
        public string CstCofins { get; set; }
        public double AliqCofins { get; set; }
        public string CodigoSefaz { get; set; }
        public double IbptAliq { get; set; }
    }
}
