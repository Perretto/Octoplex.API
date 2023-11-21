using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N10f. Grupo CRT=1 (CSON 202 ou 203)
    /*
     202=Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS por Substituição 
    Tributária;
    203- Isenção do ICMS nos Simples Nacional para faixa de receita bruta e com cobrança do ICMS por Substituição 
    Tributária (v2.0)
    */
    public class ICMSSN203
    {
        public int orig { get; set; }
        public int CSOSN { get; set; }
        public int modBCST { get; set; }
        public decimal pMVAST { get; set; }
        public decimal pRedBCST { get; set; }
        public decimal vBCST { get; set; }
        public decimal pICMSST { get; set; }
        public decimal vICMSST { get; set; }
        public decimal vBCFCPST { get; set; }
        public decimal pFCPST { get; set; }
        public decimal vFCPST { get; set; }
    }
}
