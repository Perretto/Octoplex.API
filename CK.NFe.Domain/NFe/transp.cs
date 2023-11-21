using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo X. Informações do Transporte da NF-e
    /*
        0=Contratação do Frete por conta do Remetente (CIF); 
        1=Contratação do Frete por conta do Destinatário (FOB); 
        2=Contratação do Frete por conta de Terceiros; 
        3=Transporte Próprio por conta do Remetente; 
        4=Transporte Próprio por conta do Destinatário; 
        9=Sem Ocorrência de Transporte.
        (Atualizado na NT2016.002)
    */
    public class transp
    {
        public int modFrete { get; set; }
        public transporta transporta { get; set; }
        public retTransp retTransp { get; set; }
        public veicTransp veicTransp { get; set; }
        public reboque reboque { get; set; }
        public vol vol { get; set; }
        public lacres lacres { get; set; }
    }
}
