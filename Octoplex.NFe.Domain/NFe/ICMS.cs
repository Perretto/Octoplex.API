using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N01. ICMS Normal e ST
    public class ICMS
    {
        public ICMS00 ICMS00 { get; set; }
        public ICMS10 ICMS10 { get; set; }
        public ICMS20 ICMS20 { get; set; }
        public ICMS30 ICMS30 { get; set; }
        public ICMS40 ICMS40 { get; set; }
        public ICMS41 ICMS41 { get; set; }
        public ICMS50 ICMS50 { get; set; }
        public ICMS51 ICMS51 { get; set; }
        public ICMS60 ICMS60 { get; set; }
        public ICMS70 ICMS70 { get; set; }
        public ICMS90 ICMS90 { get; set; }
        public ICMSPart ICMSPart { get; set; }
        public ICMSST ICMSST { get; set; }
        public ICMSSN101 ICMSSN101 { get; set; }
        public ICMSSN102 ICMSSN102 { get; set; }
        public ICMSSN103 ICMSSN103 { get; set; }
        public ICMSSN201 ICMSSN201 { get; set; }
        public ICMSSN202 ICMSSN202 { get; set; }
        public ICMSSN203 ICMSSN203 { get; set; }
        public ICMSSN300 ICMSSN300 { get; set; }
        public ICMSSN400 ICMSSN400 { get; set; }
        public ICMSSN500 ICMSSN500 { get; set; }
        public ICMSSN900 ICMSSN900 { get; set; }
        public ICMSUFDest ICMSUFDest { get; set; }
    }
}
