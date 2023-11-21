using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo NA. ICMS para a UF de destino
    /*
        Grupo a ser informado nas vendas interestaduais para 
        consumidor final, não contribuinte do ICMS.
        Observação: Este grupo não deve ser utilizado nas 
        operações com veículos automotores novos efetuadas por 
        meio de faturamento direto para o consumidor (Convênio 
        ICMS 51/00), as quais possuem grupo de campos próprio 
        (ICMSPart)
        (Grupo criado na NT 2015/003)
    */
    public class ICMSUFDest
    {
        public decimal vBCUFDest { get; set; }
        public decimal vBCFCPUFDest { get; set; }
        public decimal pFCPUFDest { get; set; }
        public decimal pICMSUFDest { get; set; }
        public decimal pICMSInter { get; set; }
        public decimal pICMSInterPart { get; set; }
        public decimal vFCPUFDest { get; set; }
        public decimal vICMSUFDest { get; set; }
        public decimal vICMSUFRemet { get; set; }
    }
}
