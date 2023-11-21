using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    public class rastro
    {
        // Grupo I80. Rastreabilidade de produto
        public string nLote { get; set; }
        public decimal qLote { get; set; }
        public DateTime dFab { get; set; }
        public DateTime dVal { get; set; }
        public string cAgreg { get; set; }
    }
}
