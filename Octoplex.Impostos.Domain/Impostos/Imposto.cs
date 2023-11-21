using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Impostos.Domain.Impostos
{
    public class Imposto
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] Utilizado para não gerar o ID automatico
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdImposto { get; set; }

        [ForeignKey("ProdutoId")]
        public int IdProduto { get; set; }
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
        public int CodigoUf { get; set; }

    }
}
