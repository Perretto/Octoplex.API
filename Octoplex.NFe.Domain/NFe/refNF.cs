using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    public  class refNF
    {
        public int cUF { get; set; }
        public int AAMM { get; set; }
        public long CNPJ { get; set; }
        public int mod { get; set; }
        public int serie { get; set; }
        public int nNF { get; set; }
        public refNFP refNFP { get; set; }
    }
}
