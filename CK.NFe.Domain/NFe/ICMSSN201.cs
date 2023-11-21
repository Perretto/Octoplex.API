using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N10e. Grupo CRT=1 (CSON 201)
    public class ICMSSN201
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
        public decimal pCredSN { get; set; }
        public decimal vCredICMSSN { get; set; }
    }
}
