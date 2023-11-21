using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Octoplex.Impostos.Domain.Impostos
{
    [NotMapped]
    public class ImpostoCalculo
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        public int idProduto { get; set; }
        public int idImposto { get; set;}
        public double AliqIcms { get; set; }
        public double AliqIcmsST { get; set; }
        public double vBC { get; set; }
        public double vICMS { get; set; }
        public double vICMSST { get; set; }
        public double vICMSDeson { get; set; }
        public double vFCPUFDest { get; set; }
        public double vICMSUFDest { get; set; }
        public double vICMSUFRemet { get; set; }
        public double vFCP { get; set; }
        public double vBCST { get; set; }
        public double vST { get; set; }
        public double vFCPST { get; set; }
        public double vFCPSTRet { get; set; }
        public double vProd { get; set; }
        public double vFrete { get; set; }
        public double vSeg { get; set; }
        public double vDesc { get; set; }
        public double vII { get; set; }
        public double aliqIPI { get; set; }
        public double vIPI { get; set; }
        public double vIPIDevol { get; set; }
        public double aliqPIS { get; set; }
        public double vPis { get; set; }
        public double aliqCOFINS { get; set; }
        public double vCofins { get; set;}
        public double vMVA { get; set; }
        public double vOutro { get; set; }
        public double vNF { get; set; }
        public double vTotTrib { get; set; }
        public double pFrete { get; set; }

        public ImpostoCalculo CalcularImpostoProduto()
        {
            var impostoCalculo = new ImpostoCalculo
            {
                vFrete = vFrete,
                pFrete = (vFrete * 100) / vNF,
                vIPI = ((vProd + vFrete) * aliqIPI) / 100,
                vProd = ((vProd + vIPI) * pFrete) / 100,
                vST = vST,
                vFCPST = vFCPST,
                vSeg = vSeg,
                vOutro = vOutro,
                vII = vII,
                vIPIDevol = vIPIDevol,
                vDesc = vDesc,
                vICMSDeson = vICMSDeson,
                aliqCOFINS = aliqCOFINS,
                aliqPIS = aliqPIS,
                aliqIPI = aliqIPI,
                vBC = vProd + vIPI + vFrete + vSeg,
                vBCST = (((vProd + vIPI + vFrete + vSeg + vOutro) - vDesc) * vMVA) / 100,
                vICMS = (vBC * AliqIcms) / 100,
                vICMSST = (vBCST * AliqIcmsST) - vICMS,
                vPis = aliqPIS > 0 ? (vBC * aliqPIS) / 100 : 0,
                vCofins = (vBC * aliqCOFINS) / 100,
                vNF = ((vProd + vST + vFCPST + vFrete + vSeg + vOutro + vII + vIPI + vIPIDevol) - vDesc - vICMSDeson),
            };
            return impostoCalculo;
        }
    }
}
