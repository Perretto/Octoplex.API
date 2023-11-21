using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    public class evento
    {
        public string versao { get; set; }
        public infEvento infEvento { get; set; }
        public Signature Signature { get; set; }
        public evento()
        {
            this.infEvento = new infEvento();
            this.Signature = new Signature();
        }
    }
}
