using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    /*
        03=Operação Tributável (base de cálculo = quantidade 
        vendida x alíquota por unidade de produto);
    */
    public class COFINSQtde
    {
        public int CST { get; set; }
        public decimal qBCProd { get; set; }
        public decimal vAliqProd { get; set; }
        public decimal vCOFINS { get; set; }
    }
}
