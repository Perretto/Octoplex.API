using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    public class ICMS00
    {
        public int Orig { get; set; }

        public int CST { get; set; }

        public int modBC { get; set; }

        public decimal vBC { get; set; }

        public decimal pICMS { get; set; }

        public decimal vICMS { get; set; }

        //4.0
        public decimal pFCP { get; set; }

        //4.0
        public decimal vFCP { get; set; }

    }
}
