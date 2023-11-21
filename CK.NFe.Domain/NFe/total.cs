using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    //Grupo W. Total da NF-e
    // O grupo de valores totais da NF-e deve ser informado com 
    // o somatório do campo correspondente dos itens
    public class total
    {
        public ICMSTot ICMSTot { get; set; }
        public ISSQNtot ISSQNtot { get; set; }
        public retTrib retTrib { get; set; }
    }
}
