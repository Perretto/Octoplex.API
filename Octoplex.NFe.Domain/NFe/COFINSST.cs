using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo T. COFINS ST
    // Informar os campos T02 e T03 para cálculo da COFINS Substituição Tributária em percentual (vBC - pCOFINS)
    // Informar os campos T04 e T05 para cálculo da COFINS Substituição Tributária em valor. (qBCProd - vAliqProd)
    public class COFINSST
    {
        public decimal vBC { get; set; }
        public decimal pCOFINS { get; set; }
        public decimal qBCProd { get; set; }
        public decimal vAliqProd { get; set; }
        public decimal vCOFINS { get; set; }
    }
}
