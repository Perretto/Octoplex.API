using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N10a. Grupo de Partilha do ICMS
    public class ICMSPart
    {
        public int orig { get; set; }
        public int CST { get; set; }
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
        public decimal pBCOp { get; set; }
        public string UFST { get; set; }

    }
}
