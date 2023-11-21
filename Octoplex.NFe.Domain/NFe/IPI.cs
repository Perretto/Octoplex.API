using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo O. Imposto sobre Produtos Industrializados
    public class IPI
    {
        public string CNPJProd { get; set; }
        public string cSelo { get; set; }
        public string qSelo { get; set; }
        public int cEnq { get; set; }
        public IPITrib IPITrib { get; set; }
        public IPINT IPINT { get; set; }
    }
}
