using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    public class refNFP
    {
        public int cUF { get; set; }
        public int AAMM { get; set; }
        public long CNPJ { get; set; }
        public long CPF { get; set; }
        public long IE { get; set; }
        public int mod { get; set; }
        public int serie { get; set; }
        public int nNF { get; set; }
        public int refCTe { get; set; }
        public refECF refECF { get; set; }
    }
}
