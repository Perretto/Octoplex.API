using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo LA. Detalhamento Específico de Combustíveis
    public class comb
    {
        public int cProdANP { get; set; }
        public string descANP { get; set; }
        public int pGLP { get; set; }
        public int pGNn { get; set; }
        public int pGNi { get; set; }
        public decimal vPart { get; set; }
        public int CODIF { get; set; }
        public decimal qTemp { get; set; }
        public string UFCons { get; set; }
        public CIDE cIDE { get; set; }
    }
}
