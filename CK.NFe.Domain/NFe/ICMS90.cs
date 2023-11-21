using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N10. Grupo Tributação do ICMS= 90
    public class ICMS90
    {
        public int orig { get; set; }
        public int CST { get; set; }
        public int modBC { get; set; }
        public decimal vBC { get; set; }
        public decimal pRedBC { get; set; }
        public decimal pICMS { get; set; }
        public decimal vICMS { get; set; }
        public decimal vBCFCP { get; set; }
        public decimal pFCP { get; set; }
        public decimal vFCP { get; set; }
        public decimal modBCST { get; set; }
        public decimal pMVAST { get; set; }
        public decimal pRedBCST { get; set; }
        public decimal vBCST { get; set; }
        public decimal pICMSST { get; set; }
        public decimal vICMSST { get; set; }
        public decimal vBCFCPST { get; set; }
        public decimal pFCPST { get; set; }
        public decimal vFCPST { get; set; }
        public decimal vICMSDeson { get; set; }
        public int motDesICMS { get; set; }
    }
}
