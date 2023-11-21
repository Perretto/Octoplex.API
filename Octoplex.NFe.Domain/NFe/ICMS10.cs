using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N03. Grupo Tributação do ICMS= 10
    public class ICMS10
    {
        public int Orig { get; set; }

        public int CST { get; set; }

        public int modBC { get; set; }

        public decimal vBC { get; set; }

        public decimal pICMS { get; set; }

        public decimal vICMS { get; set; }

        ////4.0
        public decimal vBCFCP { get; set; }

        public decimal pFCP { get; set; }

        public decimal vFCP { get; set; }

        ///////////////

        public int modBCST { get; set; }

        public decimal pMVAST { get; set; }

        public decimal pRedBCST { get; set; }

        public decimal vBCST { get; set; }

        public decimal pICMSST { get; set; }

        public decimal vICMSST { get; set; }

        ////4.0
        public decimal vBCFCPST { get; set; }

        public decimal pFCPST { get; set; }

        public decimal vFCPST { get; set; }
    }
}
