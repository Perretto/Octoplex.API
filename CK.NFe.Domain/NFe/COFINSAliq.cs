using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    /*
        01=Operação Tributável (base de cálculo = valor da 
        operação alíquota normal (cumulativo/não cumulativo));
        02=Operação Tributável (base de cálculo = valor da 
        operação (alíquota diferenciada))
    */
    public class COFINSAliq
    {
        public int CST { get; set; }
        public decimal vBC { get; set; }
        public decimal pCOFINS { get; set; }
        public decimal vCOFINS { get; set; }
    }
}
