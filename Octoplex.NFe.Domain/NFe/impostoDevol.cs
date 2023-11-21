using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo UA. Tributos Devolvidos (para o item da NF-e)
    /*
        Observação: O motivo da devolução deverá ser informado 
        pela empresa no campo de Informações Adicionais do 
        Produto (tag:infAdProd).
    */
    public class impostoDevol
    {
        public decimal pDevol { get; set; }
        public decimal vIPIDevol { get; set; }
    }
}
