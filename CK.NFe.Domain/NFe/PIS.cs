using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo Q. PIS
    public class PIS
    {
        public PISAliq PISAliq { get; set; }
        public PISQtde PISQtde { get; set; }
        public PISNT PISNT { get; set; }
        public PISOutr PISOutr { get; set; }
        public PISST PISST { get; set; }
    }
}
