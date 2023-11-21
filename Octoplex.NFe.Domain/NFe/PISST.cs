using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo R. PIS ST
    /*
        Informar os campos R02 e R03 para cálculo do PIS em percentual. (vBC - pPIS)
        Informar os campos R04 e R05 para cálculo do PIS em valor. (qBCProd - vAliqProd)
    */
    public class PISST
    {
        public decimal vBC { get; set; }
        public decimal pPIS { get; set; }
        public decimal qBCProd { get; set; }
        public decimal vAliqProd { get; set; }
        public decimal vPIS { get; set; }
    }
}
