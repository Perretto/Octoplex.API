using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo I01. Produtos e Serviços / Declaração de Importação
    public class DI
    {
        public string nDI { get; set; }
        public DateTime dDI { get; set; }
        public string xLocDesemb { get; set; }
        public string UFDesemb { get; set; }
        public DateTime dDesemb { get; set; }
        public int tpViaTransp { get; set; }
        public decimal vAFRMM { get; set; }
        public int tpIntermedio { get; set; }
        public string CNPJ { get; set; }
        public string UFTerceiro { get; set; }
        public string cExportador { get; set; }
        public adi adi { get; set; }
    }
}
