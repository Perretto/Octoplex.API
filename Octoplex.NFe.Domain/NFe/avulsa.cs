using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo D. Identificação do Fisco Emitente da NF-e
    public class avulsa
    {
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Informe o Orgão Emitente")]
        [StringLength(60, MinimumLength = 1)]
        public string xOrgao { get; set; }

        public string matr { get; set; }
        public string xAgente { get; set; }
        public int fone { get; set; }
        public string UF { get; set; }
        public string nDAR { get; set; }
        public DateTime dEmi { get; set; }    
        public decimal vDAR { get; set; }
        public string repEmi { get; set; }
        public DateTime dPag { get; set; }
    }
}
