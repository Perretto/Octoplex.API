using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Octoplex.NFe.Domain.NFe
{
    public class infEvento
    {
        [XmlAttribute]
        public string Id { get; set; }

        public string cOrgao { get; set; }
        public string tpAmb { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string chNFe { get; set; }
        public string dhEvento { get; set; }
        public string tpEvento { get; set; }
        public string nSeqEvento { get; set; }
        public string verEvento { get; set; }
        public detEvento detEvento { get; set; }

        public infEvento()
        {
            this.detEvento = new detEvento();
        }
    }
}
