using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    public class enderDest
    {
        [Required(ErrorMessage = "Informe o Logradouro")]
        [StringLength(60, MinimumLength = 2)]
        public string xLgr { get; set; }

        public string nro { get; set; }
        public string xCpl { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [StringLength(60, MinimumLength = 2)]
        public string xBairro { get; set; }
        
        public int cMun { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Municipio")]
        [StringLength(60, MinimumLength = 2)]
        public string xMun { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public int cPais { get; set; }
        public string xPais { get; set; }
        public int fone { get; set; }
        public int indIEDest { get; set; }
        public string IE { get; set; }
        public string ISUF { get; set; }
        public string IM { get; set; }
        public string email { get; set;}
    }
}
