using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    public class infNFe
    {
        public string versao { get; set; }
        public string Id { get; set; }
        public ide ide { get; set; }
        public emit emit { get; set; }
        public dest dest { get; set; }
        public det det { get; set; }
        public total total { get; set; }
        public transp transp { get; set; }
        public cobr cobr { get; set; }
        public pag pag { get; set; }
        public infAdic infAdic { get; set; }

    }
}
