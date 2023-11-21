using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo P. Imposto de Importação
    // Informar apenas quando o item for sujeito ao II
    public class II
    {
        public decimal vBC { get; set; }
        public decimal vDespAdu { get; set; }
        public decimal vII { get; set; }
        public decimal vIOF { get; set; }
    }
}
