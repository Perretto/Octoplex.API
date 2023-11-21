using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo C. Identificação do Emitente da Nota Fiscal eletrônica
    public class emit
    {
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string xNome { get; set; }
        public string xFant { get; set; }
        public enderEmit enderEmit { get; set; }

    }
}
