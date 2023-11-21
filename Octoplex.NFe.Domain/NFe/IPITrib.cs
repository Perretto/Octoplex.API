using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    /*
        00=Entrada com recuperação de crédito
        49=Outras entradas
        50=Saída tributada
        99=Outras saídas
    */
    public class IPITrib
    {
        public int CST { get; set; }
        public decimal vBC { get; set; }
        public decimal pIPI { get; set; }
        public decimal qUnid { get; set; }
        public decimal vUnid { get; set; }
        public decimal vIPI { get; set; }

    }
}
