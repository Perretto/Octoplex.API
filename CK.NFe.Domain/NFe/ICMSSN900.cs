using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N10h. Grupo CRT=1 (CSON 900)
    // 900=Outros (v2.0)
    public class ICMSSN900
    {
        public int orig { get; set; }
        public int CSOSN { get; set; }
        public int modBC { get; set; }
        public decimal vBC { get; set; }
        public decimal pRedBC { get; set; }
        public decimal pICMS { get; set; }
        public decimal vICMS { get; set; }
        public decimal modBCST { get; set; }
        public decimal pMVAST { get; set; }
        public decimal pRedBCST { get; set; }
        public decimal vBCST { get; set; }
        public decimal pICMSST { get; set; }
        public decimal vICMSST { get; set; }
        public decimal vBCFCPST { get; set; }
        public decimal pFCPST { get; set; }
        public decimal vFCPST { get; set; }
        public decimal pCredSN { get; set; }
        public decimal vCredICMSSN { get; set; }
    }
}
