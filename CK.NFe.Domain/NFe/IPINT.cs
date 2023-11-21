using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    /*
        Código da situação tributária do IPI:
        01=Entrada tributada com alíquota zero
        02=Entrada isenta
        03=Entrada não-tributada
        04=Entrada imune
        05=Entrada com suspensão
        51=Saída tributada com alíquota zero
        52=Saída isenta
        53=Saída não-tributada
        54=Saída imune
        55=Saída com suspensã
    */
    public class IPINT
    {
        public int CST { get; set; }
    }
}
