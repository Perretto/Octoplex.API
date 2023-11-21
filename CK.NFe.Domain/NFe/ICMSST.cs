using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N10b. Grupo de Repasse do ICMS ST
    public class ICMSST
    {
        public int orig { get; set; }
        public int CST { get; set; }
        public decimal vBCSTRet { get; set; }
        public decimal pST { get; set; }
        public decimal vICMSSubstituto { get; set; }
        public decimal vICMSSTRet { get; set; }
        public decimal vBCFCPSTRet { get; set; }
        public decimal pFCPSTRet { get; set; }
        public decimal vFCPSTRet { get; set; }
        public decimal vBCSTDest { get; set; }
        public decimal vICMSSTDest { get; set; }
        public decimal pRedBCEfet { get; set; }
        public decimal vBCEfet { get; set; }
        public decimal pICMSEfet { get; set; }
        public decimal vICMSEfet { get; set; }
    }
}
