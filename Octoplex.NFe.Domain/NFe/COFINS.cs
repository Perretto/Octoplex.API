using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo S. COFINS
    public class COFINS
    {
        public COFINSAliq COFINSAliq { get; set; }
        public COFINSQtde COFINSQtde { get; set; }
        public COFINSNT COFINSNT { get; set; }
        public COFINSOutr COFINSOutr { get; set; }
        public COFINSST COFINSST { get; set; }
    }
}
