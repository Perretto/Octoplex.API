using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    /*
        04=Operação Tributável (tributação monofásica, alíquota zero);
        05=Operação Tributável (Substituição Tributária);
        06=Operação Tributável (alíquota zero);
        07=Operação Isenta da Contribuição;
        08=Operação Sem Incidência da Contribuição;
        09=Operação com Suspensão da Contribuição;
    */
    public class COFINSNT
    {
        public int CST { get; set; }
    }
}
