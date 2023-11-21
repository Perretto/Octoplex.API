using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo ZD. Informações do Responsável Técnico (NT 2018.005)
    public class infRespTec
    {
        public string CNPJ { get; set; }
        public string xContato { get; set; }
        public string email { get; set; }
        public string fone { get; set; }
        public int idCSRT { get; set; }
        public string hashCSRT { get; set; }
    }
}
