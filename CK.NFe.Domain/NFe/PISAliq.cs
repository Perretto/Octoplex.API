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
        operação (alíquota diferenciada));
    */
    public class PISAliq
    {
        public int CST { get; set; }
        public decimal vBC { get; set; }
        public decimal pPIS { get; set; }
        public decimal vPIS { get; set; }
    }
}
