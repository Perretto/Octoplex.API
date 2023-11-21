using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Octoplex.NFe.Domain.NFe
{
    public class detEvento
    {
        [XmlAttribute]
        public string versao { get; set; }
        public string descEvento { get; set; }
        
        // Cancelamento
        public string nProt { get; set; }
        public string xJust { get; set; }

        // Carta de correção
        public string xCorrecao { get; set; }
        public string xCondUso { get; set; }
    }
}
