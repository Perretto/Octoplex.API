using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo E. Identificação do Destinatário da Nota Fiscal eletrônica
    public class dest
    {
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string idEstrangeiro { get; set; }
        public string xNome { get; set; }
        public enderDest enderDest { get; set; }
    }
}
