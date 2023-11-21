using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N07. Grupo Tributação do ICMS= 51
    public class ICMS51
    {
        public int orig { get; set; }
        public int CST { get; set; }
        public int modBC { get; set; }
        public decimal pRedBC { get; set; }
        public decimal vBC { get; set; }
        public decimal pICMS { get; set; }
        public decimal vICMSOp { get; set; }
        public decimal pDif { get; set; }
        public decimal vICMSDif { get; set; }
        public decimal vICMS { get; set; }
        public decimal vBCFCP { get; set; }
        public decimal pFCP { get; set; }
        public decimal vFCP { get; set; }
    }
}
